using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WebApplication.ServiceReference;

namespace WebApplication.Controllers
{
    public class LectorController : Controller
    {
        ServiciuLectoriClient serviciu = new ServiciuLectoriClient();

        public ActionResult Index()
        {
            if(verificareSesiuneLogareLector())
                return RedirectToAction("AdaugaDisciplina", "Lector");

            string cont = Request.Form["contLector"];
            string parola = Request.Form["parolaLector"];
            if (cont != null && cont.Length != 0)
            {
                if (parola != null && parola.Length != 0)
                {
                    bool logare = serviciu.LogareLector(cont, parola);
                    if (logare)
                    {
                        Session["LogareLector"] = cont;
                        return RedirectToAction("AdaugaDisciplina", "Lector");
                    }
                    else
                    {
                        ViewBag.Eroare = 1;
                    }
                }
            }
            return View();
        }

        public ActionResult Register()
        {
            if (verificareSesiuneLogareLector())
                return RedirectToAction("AdaugaDisciplina", "Lector");

            string cont = Request.Form["contLector"];
            string parola = Request.Form["parolaLector"];
            if (cont != null && cont.Length != 0)
            {
                if (parola != null && parola.Length != 0)
                {
                    var dis = serviciu.GetListaDiscipline();

                    Lectori l = new Lectori
                    {
                        ContLector = cont,
                        Parola = parola,
                    };

                    if(serviciu.RegisterLector(l))
                    {

                    }

                    Session["LogareLector"] = cont;
                        return RedirectToAction("AdaugaDisciplina", "Lector");  
                }
            }
            return View();
        }

        public ActionResult AdaugaDisciplina()
        {
            if (!verificareSesiuneLogareLector())
                return RedirectToAction("Index", "Lector");

            //adaugam o noua disciplina
            string numeDisciplina = Request.Form["numeDisciplina"];
            if (numeDisciplina != null && numeDisciplina.Length != 0)
            {
                Disciplina d = new Disciplina
                {
                    NumeDisciplina = numeDisciplina
                };
                d.State = State.Added;
                serviciu.DisciplinaUDI(d);
            }

            //adaugam un capitol pentru disciplina
            numeDisciplina = Request.Form["valoareSelectata"];
            string numeCapitol = Request.Form["numeCapitol"];
            if (numeDisciplina != null && numeDisciplina.Length != 0)
                if (numeCapitol != null && numeCapitol.Length != 0)
                {
                    Disciplina d = serviciu.GetDisciplinaByNume_Capitole(numeDisciplina);
                    Capitole c = new Capitole
                    {
                        DisciplinaIdDisciplina = d.IdDisciplina,
                        NumeCapitol = numeCapitol
                    };

                    c.State = State.Added;
                    serviciu.CapitoleUDI(c);
                }

            var lista = serviciu.GetListaDiscipline();
            return View(lista);
        }

        public ActionResult GestionareCursanti()
        {
            if (!verificareSesiuneLogareLector())
                return RedirectToAction("Index", "Lector");

            string NumeDisciplina = Request.Form["NumeDisciplina"];
            string contCursant = Request.Form["contCursant"];
            string parolaCursant = Request.Form["parolaCursant"];
            string emailCursant = Request.Form["emailCursant"];

            if (NumeDisciplina != null && NumeDisciplina.Length != 0)
                if (contCursant != null && contCursant.Length != 0)
                    if (parolaCursant != null && parolaCursant.Length != 0)
                        if (emailCursant != null && emailCursant.Length != 0)
                        {
                            var disciplina = serviciu.GetDisciplinaByNume_Capitole(NumeDisciplina);
                            Cursanti cursant = new Cursanti
                            {
                                ContCursant = contCursant,
                                Email = emailCursant,
                                Parola = parolaCursant,
                                DisciplinaIdDisciplina = disciplina.IdDisciplina
                            };
                            cursant.State = State.Added;
                            serviciu.CursantiUDI(cursant);
                        }


            var cursanti = serviciu.GetListaCursanti();
            ViewBag.NumeDiscipline = serviciu.GetListaDiscipline();
            return View(cursanti);
        }

        public ActionResult AdaugaIntrebari()
        {
            if (!verificareSesiuneLogareLector())
                return RedirectToAction("Index", "Lector");

            var listDiscipline = serviciu.GetListaDiscipline();
            string numeDisciplina = Request.Form["numeDisciplina"];
            if (numeDisciplina != null && numeDisciplina.Length != 0)
            {
                //Session["numeDisciplina"] = numeDisciplina;
                System.Web.HttpContext.Current.Session["numeDisciplina"] = numeDisciplina;
                var element = listDiscipline.Single(s => s.NumeDisciplina == numeDisciplina);
                var list = listDiscipline.ToList();
                list.Remove(element);
                list.Insert(0, element);
                listDiscipline = list.ToArray();

                Session["numeCapitol"] = null;
                Session["numarRaspunsuri"] = null;
            }

            string numeCapitol = Request.Form["numeCapitol"];
            if (numeCapitol != null && numeCapitol.Length != 0)
            {
                Session["numeCapitol"] = numeCapitol;
                Session["numarRaspunsuri"] = null;
            }

            string numarRaspunsuri = Request.Form["numarRaspunsuri"];
            if (numarRaspunsuri != null && numarRaspunsuri.Length != 0)
            {
                Session["numarRaspunsuri"] = numarRaspunsuri;
            }


            //de aici este codul pentru a adauga intrebarile
            string adaugaINtrebarea = Request.Form["AdaugaIntrebare"];

            if (adaugaINtrebarea != null)
            {
                List<string> erori = new List<string>();
                string Intrebare = Request.Form["Intrebare"];
                string R1 = Request.Form["R1"];
                string M1 = Request.Form["M1"];
                string T1 = Request.Form["T1"];
                string R2 = Request.Form["R2"];
                string M2 = Request.Form["M2"];
                string T2 = Request.Form["T2"];
                string R3 = Request.Form["R3"];
                string M3 = Request.Form["M3"];
                string T3 = Request.Form["T3"];
                string R4 = Request.Form["R4"];
                string M4 = Request.Form["M4"];
                string T4 = Request.Form["T4"];
                string R5 = Request.Form["R5"];
                string M5 = Request.Form["M5"];
                string T5 = Request.Form["T5"];

                if (Intrebare == null || Intrebare.Length == 0)
                    erori.Add("Trebuie completat campul pentru intrebare");

                if (R1 == null || R1.Length == 0)
                    erori.Add("Trebuie completat campul pentru R1");
                if (R2 == null || R2.Length == 0)
                    erori.Add("Trebuie completat campul pentru R2");
                if (R3 == null || R3.Length == 0)
                    erori.Add("Trebuie completat campul pentru R3");

                if (M1 == null || M1.Length == 0)
                    erori.Add("Trebuie completat campul pentru M1");
                if (M2 == null || M2.Length == 0)
                    erori.Add("Trebuie completat campul pentru M2");
                if (M3 == null || M3.Length == 0)
                    erori.Add("Trebuie completat campul pentru M3");

                if (4 <= Convert.ToInt32(numarRaspunsuri))
                {
                    if (R4 == null || R4.Length == 0)
                        erori.Add("Trebuie completat campul pentru R4");
                    if (M4 == null || M4.Length == 0)
                        erori.Add("Trebuie completat campul pentru M4");
                }

                if (5 <= Convert.ToInt32(numarRaspunsuri))
                {
                    if (R5 == null || R5.Length == 0)
                        erori.Add("Trebuie completat campul pentru R5");
                    if (M5 == null || M5.Length == 0)
                        erori.Add("Trebuie completat campul pentru M5");
                }
                ViewBag.Erori = erori;

                //////////////////////////////////////////////////////////////
                //daca nu avem erori, vom crea obiectele si le vom adaug ainb aza de date

                var capItol = serviciu.GetCapitolByName(Session["numeCapitol"].ToString());
                //var capItol = serviciu.GetCapitolByName("e1");

                Intrebari intrebareOb = new Intrebari
                {
                    CapitoleIdCapitol = capItol.IdCapitol,
                    Intrebarea = Intrebare
                };

                intrebareOb.State = State.Added;
                serviciu.IntrebariUDI(intrebareOb);

                intrebareOb = serviciu.GetIntrebareByNume(Intrebare);

                // vom adauga raspunsurile
                switch (Session["numarRaspunsuri"].ToString())
                // switch ("3")
                {
                    case "3":
                        Raspunsuri r1Ob = new Raspunsuri
                        {
                            IntrebariIdIntrebare = intrebareOb.IdIntrebare,
                            Raspuns = R1,
                            RaspunsCorect = T1 == "Gresit" ? 0 : 1,
                            MotivareRaspuns = M1
                        };

                        Raspunsuri r2Ob = new Raspunsuri
                        {
                            IntrebariIdIntrebare = intrebareOb.IdIntrebare,
                            Raspuns = R2,
                            RaspunsCorect = T2 == "Gresit" ? 0 : 1,
                            MotivareRaspuns = M2
                        };

                        Raspunsuri r3Ob = new Raspunsuri
                        {
                            IntrebariIdIntrebare = intrebareOb.IdIntrebare,
                            Raspuns = R3,
                            RaspunsCorect = T3 == "Gresit" ? 0 : 1,
                            MotivareRaspuns = M3
                        };

                        r1Ob.State = State.Added;
                        r2Ob.State = State.Added;
                        r3Ob.State = State.Added;

                        serviciu.RaspunsuriUDI(r1Ob);
                        serviciu.RaspunsuriUDI(r2Ob);
                        serviciu.RaspunsuriUDI(r3Ob);

                        break;

                    case "4":
                        Raspunsuri r11Ob = new Raspunsuri
                        {
                            IntrebariIdIntrebare = intrebareOb.IdIntrebare,
                            Raspuns = R1,
                            RaspunsCorect = T1 == "Gresit" ? 0 : 1,
                            MotivareRaspuns = M1
                        };

                        Raspunsuri r22Ob = new Raspunsuri
                        {
                            IntrebariIdIntrebare = intrebareOb.IdIntrebare,
                            Raspuns = R2,
                            RaspunsCorect = T2 == "Gresit" ? 0 : 1,
                            MotivareRaspuns = M2
                        };

                        Raspunsuri r33Ob = new Raspunsuri
                        {
                            IntrebariIdIntrebare = intrebareOb.IdIntrebare,
                            Raspuns = R3,
                            RaspunsCorect = T3 == "Gresit" ? 0 : 1,
                            MotivareRaspuns = M3
                        };

                        Raspunsuri r44Ob = new Raspunsuri
                        {
                            IntrebariIdIntrebare = intrebareOb.IdIntrebare,
                            Raspuns = R4,
                            RaspunsCorect = T4 == "Gresit" ? 0 : 1,
                            MotivareRaspuns = M4
                        };

                        r11Ob.State = State.Added;
                        r22Ob.State = State.Added;
                        r33Ob.State = State.Added;
                        r44Ob.State = State.Added;

                        serviciu.RaspunsuriUDI(r11Ob);
                        serviciu.RaspunsuriUDI(r22Ob);
                        serviciu.RaspunsuriUDI(r33Ob);
                        serviciu.RaspunsuriUDI(r44Ob);

                        break;

                    case "5":
                        Raspunsuri r111Ob = new Raspunsuri
                        {
                            IntrebariIdIntrebare = intrebareOb.IdIntrebare,
                            Raspuns = R1,
                            RaspunsCorect = T1 == "Gresit" ? 0 : 1,
                            MotivareRaspuns = M1
                        };

                        Raspunsuri r222Ob = new Raspunsuri
                        {
                            IntrebariIdIntrebare = intrebareOb.IdIntrebare,
                            Raspuns = R2,
                            RaspunsCorect = T2 == "Gresit" ? 0 : 1,
                            MotivareRaspuns = M2
                        };

                        Raspunsuri r333Ob = new Raspunsuri
                        {
                            IntrebariIdIntrebare = intrebareOb.IdIntrebare,
                            Raspuns = R3,
                            RaspunsCorect = T2 == "Gresit" ? 0 : 1,
                            MotivareRaspuns = M2
                        };

                        Raspunsuri r444Ob = new Raspunsuri
                        {
                            IntrebariIdIntrebare = intrebareOb.IdIntrebare,
                            Raspuns = R4,
                            RaspunsCorect = T4 == "Gresit" ? 0 : 1,
                            MotivareRaspuns = M4
                        };

                        Raspunsuri r555Ob = new Raspunsuri
                        {
                            IntrebariIdIntrebare = intrebareOb.IdIntrebare,
                            Raspuns = R5,
                            RaspunsCorect = T5 == "Gresit" ? 0 : 1,
                            MotivareRaspuns = M5
                        };


                        r111Ob.State = State.Added;
                        r222Ob.State = State.Added;
                        r333Ob.State = State.Added;
                        r444Ob.State = State.Added;
                        r555Ob.State = State.Added;

                        serviciu.RaspunsuriUDI(r111Ob);
                        serviciu.RaspunsuriUDI(r222Ob);
                        serviciu.RaspunsuriUDI(r333Ob);
                        serviciu.RaspunsuriUDI(r444Ob);
                        serviciu.RaspunsuriUDI(r555Ob);
                        break;
                }
            }

            return View(listDiscipline);
        }

        public ActionResult ImportaIntrebari()
        {
            if (!verificareSesiuneLogareLector())
                return RedirectToAction("Index", "Lector");

            return View();
        }

        [HttpPost]
        public ActionResult ImportaIntrebari(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/FisiereXML"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);

                /////////citim fisierul xml
                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(path);

                    Disciplina disCiplina = null;
                    Capitole capItol = null;
                    Intrebari intreBare = null;
                    Raspunsuri rasPunsuri = null;
                    int idIntrebare = 0;

                    while (reader.Read())
                    {
                        reader.MoveToContent();
                        if (reader.NodeType == System.Xml.XmlNodeType.Element)
                        {
                            if (reader.Name == "Disciplina")
                            {
                                string s = reader.GetAttribute(0); // numele disciplinei


                                var v_dis = serviciu.GetDisciplinaByNume_Capitole(s);
                                disCiplina = v_dis;

                                if (disCiplina == null)
                                {
                                    // inseamna ca nu exista elemente
                                    // vom crea o noua disciplina

                                    disCiplina = new Disciplina
                                    {
                                        NumeDisciplina = s
                                    };

                                    disCiplina.State = State.Added;
                                    serviciu.DisciplinaUDI(disCiplina);
                                    disCiplina = serviciu.GetDisciplinaByNume_Capitole(s);
                                }
                            } // if disciplina

                            if (reader.Name == "capitol")
                            {
                                string numeCapitol = reader.GetAttribute(0); // numele capitolului

                                var var_cap = serviciu.GetCapitolByName(numeCapitol);
                                capItol = var_cap;
                                if (capItol == null)
                                {
                                    // inseamana ca nu exista elemente
                                    // vom crea un nou capitol
                                    capItol = new Capitole
                                    {
                                        NumeCapitol = numeCapitol,
                                        DisciplinaIdDisciplina = disCiplina.IdDisciplina
                                    };

                                    capItol.State = State.Added;
                                    serviciu.CapitoleUDI(capItol);
                                    capItol = serviciu.GetCapitolByName(numeCapitol);
                                }
                            }
                        }

                        if (reader.NodeType == System.Xml.XmlNodeType.Element)
                        {
                            if (reader.Name == "intrebare")
                            {
                                reader.Read();
                                intreBare = new Intrebari
                                {
                                    CapitoleIdCapitol = capItol.IdCapitol,
                                    Intrebarea = reader.Value
                                };

                                intreBare.State = State.Added;
                                serviciu.IntrebariUDI(intreBare);

                                idIntrebare = serviciu.GetMaxId();
                            }

                            //vom completa cu informatiile pentru raspuns
                            if (reader.Name == "raspunsMotivate")
                            {
                                rasPunsuri = new Raspunsuri();
                                rasPunsuri.IntrebariIdIntrebare = idIntrebare;
                            }

                            if (reader.Name == "raspuns")
                            {
                                reader.Read();
                                rasPunsuri.Raspuns = reader.Value;
                            }
                            if (reader.Name == "motivare")
                            {
                                reader.Read();
                                rasPunsuri.MotivareRaspuns = reader.Value;
                            }
                            if (reader.Name == "corect")
                            {
                                reader.Read();
                                rasPunsuri.RaspunsCorect = reader.Value == "f" ? 0 : 1;
                                rasPunsuri.State = State.Added;
                                serviciu.RaspunsuriUDI(rasPunsuri);
                            }
                        }
                    }

                    ViewBag.Message = "Fisierul a fost incarcat cu succes";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Exceptie:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "Nu ai ales nici un fisier";
            }
            return View();
        }

        bool verificareSesiuneLogareLector()
        {
            bool logat = Session["LogareLector"] != null;
            return logat;
        }

        public ActionResult ListareIntrebari()
        {
             if (!verificareSesiuneLogareLector())
                return RedirectToAction("Index", "Lector");

            var items = serviciu.GetListaDiscipline_CapitoleIntrebariRaspunsuri();
            return View(items);
        }

        public ActionResult Delogare()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Setari()
        {
            if (!verificareSesiuneLogareLector())
                return RedirectToAction("Index", "Lector");

            bool curataBazaDeDate = Request.Form["curataBazaDeDate"] != null;
            if(curataBazaDeDate)
            {
                serviciu.CurataBazaDeDate();
                ViewBag.MesajCurataBazaDeDate = true;
            }
            return View();
        }

        public ActionResult CreazaGrupaTest()
        {
            if (!verificareSesiuneLogareLector())
                return RedirectToAction("Index", "Lector");

            string testSelectat = Request.Form["testSelectat"];
            if (testSelectat != null && testSelectat.Length != 0)
            {
               Session["testSelectat"] = testSelectat;
               var listaCursanti = serviciu.GetCursantiCareDauTestulCreatDeLector(testSelectat).ToArray();

                List<string> lista = new List<string>();
                for(int i=0; i< listaCursanti.Length;i++)
                {
                    lista.Add(listaCursanti[i].ContCursant);
                }
               ViewBag.Cursanti = lista;
                Session["countCUrsanti"] = lista.Count;
            }


            //genereazaTest
            string genereazaTest = Request.Form["genereazaTest"];
            if(genereazaTest != null && genereazaTest.Length!=0)
            {
                var testCreatDeLector = serviciu.GetTestCreatDeLectorByName(Session["testSelectat"].ToString());

                ProgramareTest test = new ProgramareTest
                {
                    TestCreatDeLectorIdTest = testCreatDeLector.IdTest,
                    NumeTestProgramat = Request.Form["dataTest"] + " -- " + Session["testSelectat"].ToString()
                };

                test.State = State.Added;
                serviciu.ProgramareTestsUDI(test);
                test = serviciu.GetProgramareTestByName(Request.Form["dataTest"] + " -- " + Session["testSelectat"].ToString());

                //trebuie sa obinem cursantii din comboboxList
                List<string> cursantiAlesi = new List<string>();
                var listaCursanti = serviciu.GetCursantiCareDauTestulCreatDeLector(Session["testSelectat"].ToString()).ToArray();
                for(int i=0; i< listaCursanti.Length;i++)
                {
                    if(Request.Form[i.ToString()]!=null)
                    {
                        cursantiAlesi.Add(listaCursanti[i].ContCursant);
                    }
                }

                foreach (var v in cursantiAlesi)
                {
                    var cursant = serviciu.GetCursantByCont(v.ToString());

                    ListaCursantiTestProgramat lcursanti = new ListaCursantiTestProgramat
                    {
                        CursantiIdCursant = cursant.IdCursant,
                        ProgramareTestId = test.Id
                    };

                    lcursanti.State = State.Added;
                    serviciu.ListaCursantiTestProgramatsUID(lcursanti);
                }

                ViewBag.TestCreat = 1;
            }

            var ceva = serviciu.GetListaTesteCreateDeLector();
            return View(ceva);
        }

        public ActionResult GenereazaTest()
        {
            if (!verificareSesiuneLogareLector())
                return RedirectToAction("Index", "Lector");

            string numeDisciplinaGenereazaTest = Request.Form["numeDisciplinaGenereazaTest"];
            if(numeDisciplinaGenereazaTest != null && numeDisciplinaGenereazaTest.Length!=0)
            {
                Session["numeDisciplinaGenereazaTest"] = numeDisciplinaGenereazaTest;
            }
            
            string genereazaTest = Request.Form["genereazaTest"];
            if(genereazaTest!=null)
            {
                string numarIntrebari =Request.Form["numarIntrebari"].ToString();
                string timpTest = Request.Form["timpTest"].ToString();
                string contLectorText = Session["LogareLector"].ToString();
                List<string> numeCapitoleSelectate = new List<string>();

                //vom itera peste capitolele selectate si vom vedea daca avem un request de la formular
                var capitole = serviciu.GetListaCapitoleByNumeDisciplina(Session["numeDisciplinaGenereazaTest"].ToString());
                for(int p=0; p<capitole.Length;p++)
                {
                    if(Request.Form[p.ToString()]!=null)
                    {
                        numeCapitoleSelectate.Add(capitole[p].NumeCapitol);
                    }
                }



                //avem toate informatiile pt a genera un test
                // urmeaza codul pentru a genera acel test
                int nrCapitole = 0;

                string numeTest = "Test ";
                foreach (var v in numeCapitoleSelectate)
                {
                    numeTest += v + " ";
                    nrCapitole++;
                }

                numeTest += "- " + numarIntrebari + " intrebari";

                var contLector = serviciu.GetLectorByCont(contLectorText);

                TestCreatDeLector test = new TestCreatDeLector
                {
                    NumeTest = numeTest,
                    LectoriIdLector = contLector.IdLector,
                    Timp = timpTest,
                    NrIntrebari = Convert.ToInt32(numarIntrebari)
                };

                test.State = State.Added;
                serviciu.TestCreatDeLectorUDI(test);

                test = serviciu.GetTestCreatDeLectorByName(numeTest);

                //algoritm intrebari
                int nrIntrebariTest = Convert.ToInt32(numarIntrebari);
                int intrebariPeCapitol = 0;


                intrebariPeCapitol = nrIntrebariTest / nrCapitole;
                int primulTake = 0;

                if (intrebariPeCapitol * nrCapitole == nrIntrebariTest)
                {
                    primulTake = intrebariPeCapitol;
                }
                else
                {
                    primulTake = intrebariPeCapitol + nrIntrebariTest - intrebariPeCapitol * nrCapitole;
                }

                foreach (var v in numeCapitoleSelectate)
                {
                    var disci = serviciu.GetCapitolPentruTest(v.ToString());

                    // de motificat astfel incat acest take sa fie random
                    //OrderBy(r => Guid.NewGuid()) -- este pentru a lua intrebarile random din baza de date
                    var m = disci.Intrebaris.OrderBy(r => Guid.NewGuid()).Take(primulTake);
                    primulTake = intrebariPeCapitol;

                    foreach (var z in m)
                    {
                        // adaugam intrebarile pentru testul selectat
                        IntrebariTeste iT = new IntrebariTeste
                        {
                            TestCreatDeLectorIdTest = test.IdTest,
                            IntrebariIdIntrebare = z.IdIntrebare
                        };

                        iT.State = State.Added;
                        serviciu.IntrebariTesteUDI(iT);
                    }
                }


                // am creat testul
                Session["numeDisciplinaGenereazaTest"] = null;
                ViewBag.MesajCreareTest = "true";
        }

            //var listaDiscipline = serviciu.GetListDisciplineByNumeLector(Session["LogareLector"].ToString());
            var listaDiscipline = serviciu.GetListaDiscipline();
            return View(listaDiscipline.ToArray());
        }

        public ActionResult CorecteazaTest()
        {

            string prevBtn = Request.Form["prevBtn"];
            string nextBtn = Request.Form["nextBtn"];
            if (prevBtn != null)
            {
                int index = Convert.ToInt32(Session["IndexIntrebareCurenta"].ToString());
                if (index <= 0)
                    Session["IndexIntrebareCurenta"] = 0;
                else
                    Session["IndexIntrebareCurenta"] = index - 1;
            }

            if (nextBtn != null)
            {
                int index = Convert.ToInt32(Session["IndexIntrebareCurenta"].ToString());
                if (index+1 >= Convert.ToInt32(Session["numarIntrebariTest"].ToString()))
                    Session["IndexIntrebareCurenta"] = index;
                else
                    Session["IndexIntrebareCurenta"] = index + 1;
            }


            string testSelectat = Request.Form["testSelectat"];
            if(testSelectat != null)
            {
                Session["testSelectat"] = testSelectat;
                var lista = serviciu.GetListaCursantiCareAuDatTestulCreatDeLectorByNumeTest(Session["testSelectat"].ToString()).Select(s => s.ContCursant).ToList();
                Session["ViewBag.testSelectat"] = lista;
            }

            string IncepeCorectareTest = Request.Form["IncepeCorectareTest"];
            if(IncepeCorectareTest!=null)
            {
                Session["IncepeCorectareTest"] = true;
                Session["CursantCuTestDeCorectat"] = Request.Form["cursantTestSelectat"];  //cursantTestSelectat
                Session["IndexIntrebareCurenta"] = 0;

               var  vTestCreatDeLector = serviciu.GetTestCreatDeLectorByName(Session["testSelectat"].ToString());
               var  vCursant = serviciu.GetCursantByCont(Session["CursantCuTestDeCorectat"].ToString());
               var lista = serviciu.GetListaTesteSalvateInBazaDeDateByID_CURSANT_ID_TestCreatDeLector(vCursant.IdCursant, vTestCreatDeLector.IdTest);
                Session["numarIntrebariTest"] = lista.Length;

                for (int i=0; i<lista.Length;i++)
                {
                    Session["TDCintrebare" + i] = lista[i];
                }
            }

            var ceva = serviciu.GetListaTesteCreateDeLector().ToList();
            List<string> listaTeste = new List<string>();
            foreach(var a in ceva)
            {
                listaTeste.Add(a.NumeTest);
            }

            ViewBag.listTeste = listaTeste;

            TesteSalvateInBazaDeDate test = null;

            if(Session["IndexIntrebareCurenta"]!=null)
            {
                int index = Convert.ToInt32(Session["IndexIntrebareCurenta"].ToString());
                test = (TesteSalvateInBazaDeDate)Session["TDCintrebare" + index];
            }

            if(test==null)
            {
                Session["IndexIntrebareCurenta"] = null;
            }

            return View(test);
        }
    }
}