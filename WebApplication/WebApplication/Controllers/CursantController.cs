using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.ServiceReference;
using WebApplication.Models;


namespace WebApplication.Controllers
{
    public class CursantController : Controller
    {
        ServiciuLectoriClient serviciu = new ServiciuLectoriClient();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string user, string parola)
        {
             ServiciuLectoriClient serviciu = new ServiciuLectoriClient();
             user = Request.Form["ContCursant"];
             parola = Request.Form["parolaCursant"];

            if (serviciu.Logare(user, parola))
            {
                Session["logareCursant"] = user;
                return RedirectToAction("Logat", "Cursant");
            }
            else
            {
                ViewBag.Eroare = "Datele introduse sunt gresite";
                return View();
            }
        }

        public ActionResult Logat()
        {
            List<string> testeProgramate = new List<string>();

            var listaTesteProgramte = serviciu.GetListProgramareTests();
            foreach(var a in listaTesteProgramte)
            {
                string numeTestProgramat = a.NumeTestProgramat;
                var testProgramat = serviciu.GetProgramareTestByName(numeTestProgramat);
                var listaCursantiTestProgramat = testProgramat.ListaCursantiTestProgramats.Select(s => s.Cursanti.ContCursant).ToList();

                //daca cursantul logat se gaseste printre vrun cursant din aceasta lista
                // atunci inseamana ca trebuie sa dea un test programat
                foreach(var curs in listaCursantiTestProgramat)
                {
                    if(Session["logareCursant"].ToString() == curs)
                    {
                        testeProgramate.Add(numeTestProgramat);
                    }
                }
            }
            ViewBag.listaTesteProgramte = testeProgramate;

            string incepeTestul = Request.Form["incepeTestul"];
            if(incepeTestul!=null && incepeTestul.Length !=0)
            {
                Session["numeTestProgramat"] = Request.Form["numeTestProgramat"];
                return RedirectToAction("RezolvaTestul", "Cursant");
            }

            return View();
        }

        public ActionResult Delogare()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RezolvaTestul()
        {
            string numeTestProgramat = Session["numeTestProgramat"].ToString();

            if(Session["amIncarcatDatele"]==null)
            {
                Session["amIncarcatDatele"] = "da";
                var listaIntrebari = serviciu.GetListaIntrebariRaspunsuriTestProgramatByNumeTestProgramat(numeTestProgramat);
                var contCursant = serviciu.GetCursantByCont(Session["logareCursant"].ToString());

                Session["IntrebariTest"] = listaIntrebari.Length;
                int indexIntrebare = 1;
                foreach (var v in listaIntrebari)
                {
                    GrupareRezolvareTest g = new GrupareRezolvareTest();
                    g.intrebareObj = v;
                    g.index = indexIntrebare;

                    Session["intrebare" + indexIntrebare] = g;
                    indexIntrebare++;
                }

                Session["indexIntrebareCurenta"] = 1;
            }

            string prevBtn = Request.Form["prevBtn"];
            string nextBtn = Request.Form["nextBtn"];
            if(prevBtn!=null)
            {
                string justificare = Request.Form["justificare"];
                if (justificare != null)
                {
                    GrupareRezolvareTest ggPrev = (GrupareRezolvareTest)Session["intrebare" + Session["indexIntrebareCurenta"]];
                    ggPrev.justificare = justificare;

           // o sa construim raspunsul
                    string raspuns = "";
                    for(int i=0; i<ggPrev.intrebareObj.Raspunsuris.Length; i++)
                    {
                       bool exista =  Request.Form[i.ToString()] != null;
                        if(exista)
                        {
                            raspuns += "1";
                        }
                        else
                        {
                            raspuns += "0";
                        }
                    }
                    ggPrev.raspuns = raspuns;
                    Session["intrebare" + Session["indexIntrebareCurenta"]] = ggPrev;
                }

                int nr = Convert.ToInt32(Session["indexIntrebareCurenta"].ToString());
                if (nr == 1){}
                else
                nr--;
                Session["indexIntrebareCurenta"] = nr;

            }

            if (nextBtn != null)
            {
                string justificare = Request.Form["justificare"];
                if (justificare != null)
                {
                    GrupareRezolvareTest ggNext = (GrupareRezolvareTest)Session["intrebare" + Session["indexIntrebareCurenta"]];
                    ggNext.justificare = justificare;

                    // o sa construim raspunsul
                    string raspuns = "";
                    for (int i = 0; i < ggNext.intrebareObj.Raspunsuris.Length; i++)
                    {
                        bool exista = Request.Form[i.ToString()] != null;
                        if (exista)
                        {
                            raspuns += "1";
                        }
                        else
                        {
                            raspuns += "0";
                        }
                    }
                    ggNext.raspuns = raspuns;

                    Session["intrebare" + Session["indexIntrebareCurenta"]] = ggNext;
                }

                int nr = Convert.ToInt32(Session["indexIntrebareCurenta"].ToString());
                if(nr == Convert.ToInt32(Session["IntrebariTest"].ToString())){}
                else
                nr++;
                Session["indexIntrebareCurenta"] = nr;
            }

            GrupareRezolvareTest gg = (GrupareRezolvareTest)Session["intrebare" + Session["indexIntrebareCurenta"]];

            // nu pot obtine obiectul
            // de verificat

            bool putemSalvaInBazaDeDate = true;
            for(int i=1; i<=Convert.ToInt32(Session["IntrebariTest"].ToString());i++)
            {
                GrupareRezolvareTest ggSalvareBazaDate = (GrupareRezolvareTest)Session["intrebare" +i.ToString()];
                    if (ggSalvareBazaDate.justificare == null)
                        putemSalvaInBazaDeDate = false;
                    else
                    if(ggSalvareBazaDate.justificare.Length==0)
                      putemSalvaInBazaDeDate = false;
            }


            bool salvatiTestulInBazaDeDate = Request.Form["salvatiTestulInBazaDeDate"]!=null;
            if(salvatiTestulInBazaDeDate)
            {
                string cont = Session["logareCursant"].ToString();
                var cursant = serviciu.GetCursantByCont(cont);
                var testProgramat = serviciu.GetProgramareTestByName(numeTestProgramat);

                for(int i=1; i<= Convert.ToInt32(Session["IntrebariTest"].ToString()); i++)
                {
                    GrupareRezolvareTest v = (GrupareRezolvareTest)Session["intrebare" + i.ToString()];

                    TesteSalvateInBazaDeDate test = new TesteSalvateInBazaDeDate
                    {
                        CursantiIdCursant = cursant.IdCursant,
                        IntrebariIdIntrebare = v.intrebareObj.IdIntrebare,
                        TestCreatDeLectorIdTest = testProgramat.TestCreatDeLectorIdTest,
                        Raspuns = v.raspuns,
                        MotivareRaspuns = v.justificare
                    };

                    serviciu.TesteSalvateInBazaDeDateUDI(test);
                }

                serviciu.DeleteFromListaCursantiTestProgramats(testProgramat.Id, cursant.IdCursant);

                Session.Clear();
                Session["testSalvaInBazaDeDate"] = true;

                return RedirectToAction("Index", "Cursant");
            }
            ViewBag.putemSalvaInBazaDeDate = putemSalvaInBazaDeDate;
            return View(gg);
        }

    }
}