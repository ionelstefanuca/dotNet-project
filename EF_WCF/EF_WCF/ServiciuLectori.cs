using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EF_WCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiciuLectori : IServiciuLectori
    {
        public Disciplina GetDisciplinaById(int id)
        {
            using (ModelContext context = new ModelContext())
            {
                try
                {
                    Disciplina dis = context.Disciplinas.Find(id);
                    return dis;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public Disciplina GetDisciplinaByNume_Capitole(string numeDisciplina)
        {
            using (ModelContext context = new ModelContext())
            {

                try
                {
                    var disciplina = (from ct in context.Disciplinas
                                      where ct.NumeDisciplina == numeDisciplina
                                      select ct).Include("Capitoles").Single();
                    return disciplina;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public List<Disciplina> GetListaDiscipline()
        {
            using (ModelContext context = new ModelContext())
            {
                var discipline = context.Disciplinas.Include("Capitoles").ToList();

                return discipline;
            }
        }

        public void DisciplinaUDI(Disciplina d)
        {
            using (var context = new ModelContext())
            {
                context.Disciplinas.Add(d);
                foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
                {
                    entry.State = EntityConvertState.ConvertState(entry.Entity.State);
                    if (entry.State == EntityState.Modified)
                    {
                        entry.State = EntityState.Unchanged;
                        var databaseValues = entry.GetDatabaseValues();
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }
                context.SaveChanges();
            }
        }

        public void CapitoleUDI(Capitole c)
        {
            using (var context = new ModelContext())
            {
                context.Capitoles.Add(c);
                foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
                {
                    entry.State = EntityConvertState.ConvertState(entry.Entity.State);
                    if (entry.State == EntityState.Modified)
                    {
                        entry.State = EntityState.Unchanged;
                        var databaseValues = entry.GetDatabaseValues();
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }
                context.SaveChanges();
            }
        }

        public void StergeDisciplina(Disciplina d)
        {
            using (var context = new ModelContext())
            {
                context.Database.ExecuteSqlCommand("delete from capitoles where DisciplinaIdDisciplina =" + d.IdDisciplina);
                context.Database.ExecuteSqlCommand("delete from cursantis where DisciplinaIdDisciplina =" + d.IdDisciplina);
                context.Database.ExecuteSqlCommand("delete from lectoris where DisciplinaIdDisciplina =" + d.IdDisciplina);
                context.Disciplinas.Remove(d);
            }
        }

        public List<Cursanti> GetListaCursanti()
        {
            using (var context = new ModelContext())
            {
                var cursanti = context.Cursantis.Include("Disciplina").ToList();
                return cursanti;
            }
        }

        public void CursantiUDI(Cursanti c)
        {
            using (var context = new ModelContext())
            {
                context.Cursantis.Add(c);
                foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
                {
                    entry.State = EntityConvertState.ConvertState(entry.Entity.State);
                    if (entry.State == EntityState.Modified)
                    {
                        entry.State = EntityState.Unchanged;
                        var databaseValues = entry.GetDatabaseValues();
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }
                context.SaveChanges();
            }
        }

        public Capitole GetCapitolByName(string nume)
        {
            using (var context = new ModelContext())
            {
                try
                {
                    var capitol = (from ct in context.Capitoles
                                   where ct.NumeCapitol == nume
                                   select ct).Single();
                    return capitol;
                }
                catch (Exception)
                {
                    return null;
                }

            }
        }

        public void IntrebariUDI(Intrebari intrebare)
        {
            using (var context = new ModelContext())
            {
                context.Intrebaris.Add(intrebare);
                foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
                {
                    entry.State = EntityConvertState.ConvertState(entry.Entity.State);
                    if (entry.State == EntityState.Modified)
                    {
                        entry.State = EntityState.Unchanged;
                        var databaseValues = entry.GetDatabaseValues();
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }
                context.SaveChanges();
            }
        }

        public void RaspunsuriUDI(Raspunsuri r)
        {
            using (var context = new ModelContext())
            {
                context.Raspunsuris.Add(r);
                foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
                {
                    entry.State = EntityConvertState.ConvertState(entry.Entity.State);
                    if (entry.State == EntityState.Modified)
                    {
                        entry.State = EntityState.Unchanged;
                        var databaseValues = entry.GetDatabaseValues();
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }
                context.SaveChanges();
            }
        }

        public Intrebari GetIntrebareByNume(string intrebare)
        {
            using (var context = new ModelContext())
            {
                var i = (from ct in context.Intrebaris
                         where ct.Intrebarea == intrebare
                         select ct).Include("Raspunsuris").ToArray();

                return i[0];
            }
        }

        public List<Disciplina> GetListaDiscipline_CapitoleIntrebariRaspunsuri()
        {
            using (var ctx = new ModelContext())
            {
                var d = (from ct in ctx.Disciplinas
                         select ct).
                         Include(s => s.Capitoles
                         .Select(a => a.Intrebaris
                         .Select(b => b.Raspunsuris))
                         );

                return d.ToList();
            }
        }

        public int GetMaxId()
        {
            using (ModelContext context = new ModelContext())
            {
                int intIdt = context.Intrebaris.Max(u => u.IdIntrebare);

                return intIdt;
            }
        }

        public void LectoriUDI(Lectori lector)
        {
            using (var context = new ModelContext())
            {
                context.Lectoris.Add(lector);
                foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
                {
                    entry.State = EntityConvertState.ConvertState(entry.Entity.State);
                    if (entry.State == EntityState.Modified)
                    {
                        entry.State = EntityState.Unchanged;
                        var databaseValues = entry.GetDatabaseValues();
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }
                context.SaveChanges();
            }
        }

        public List<Lectori> GetListaLectori()
        {
            using (var context = new ModelContext())
            {
                var lista = context.Lectoris;
                return lista.ToList() ;
            }
        }

        public List<Lectori> GetListaLectoriPerDisciplina(string numeDisciplina)
        {
            using (var context = new ModelContext())
            {
                var l = (from ct in context.Lectoris
                         where ct.Disciplina.NumeDisciplina == numeDisciplina
                         select ct).Include(s => s.Disciplina.Capitoles);

                return l.ToList();
            }
        }

        public Lectori GetLectorByCont(string cont)
        {
            using (var context = new ModelContext())
            {
                var lector = (from ct in context.Lectoris
                              where ct.ContLector == cont
                              select ct);

                return lector.ToArray()[0];
            }
        }

        public void TestCreatDeLectorUDI(TestCreatDeLector test)
        {
            using (var context = new ModelContext())
            {
                context.TestCreatDeLectors.Add(test);
                foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
                {
                    entry.State = EntityConvertState.ConvertState(entry.Entity.State);
                    if (entry.State == EntityState.Modified)
                    {
                        entry.State = EntityState.Unchanged;
                        var databaseValues = entry.GetDatabaseValues();
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }
                context.SaveChanges();
            }
        }

        public void IntrebariTesteUDI(IntrebariTeste intrebare)
        {
            using (var context = new ModelContext())
            {
                context.IntrebariTestes.Add(intrebare);
                foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
                {
                    entry.State = EntityConvertState.ConvertState(entry.Entity.State);
                    if (entry.State == EntityState.Modified)
                    {
                        entry.State = EntityState.Unchanged;
                        var databaseValues = entry.GetDatabaseValues();
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }
                context.SaveChanges();
            }
        }

        public Capitole GetCapitolPentruTest(string numeCapitol)
        {
            using (var context = new ModelContext())
            {
                var c = (from ct in context.Capitoles
                         where ct.NumeCapitol == numeCapitol
                         select ct).Include(s=>s.Intrebaris.Select(a=>a.Raspunsuris)).Single();
                return c;
            }
        }

        public TestCreatDeLector GetTestCreatDeLectorByName(string numeTest)
        {
            using (var context = new ModelContext())
            {
                var test = (from ct in context.TestCreatDeLectors
                            where ct.NumeTest == numeTest
                            select ct).Single();

                return test;
            }
        }

        public List<TestCreatDeLector> GetListaTesteCreateDeLector()
        {
            using (var context = new ModelContext())
            {
                var lista = context.TestCreatDeLectors;
                return lista.ToList();
            }
        }

        public List<Cursanti> GetCursantiCareDauTestulCreatDeLector(string numeTest)
        {
            using (var context = new ModelContext())
            {
                var lista = (from ct in context.TestCreatDeLectors
                             where ct.NumeTest == numeTest
                             select ct.Lectori.Disciplina.Cursantis).Single();

                return lista.ToList();
            }
        }

        public List<Intrebari> GetListaIntrebariTestCreatDeLectorByNumeTest(string numeTest)
        {
            using (var context = new ModelContext())
            {
                var listaIntrebari = (from ct in context.TestCreatDeLectors
                                      where ct.NumeTest == numeTest
                                      select ct).Include(s=>s.IntrebariTestes.Select(a=>a.Intrebari.Raspunsuris)).Single();

                return listaIntrebari.IntrebariTestes.Select(s=>s.Intrebari).ToList();
            }
        }

        public void ProgramareTestsUDI(ProgramareTest programare)
        {
            using (var context = new ModelContext())
            {
                context.ProgramareTests.Add(programare);
                foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
                {
                    entry.State = EntityConvertState.ConvertState(entry.Entity.State);
                    if (entry.State == EntityState.Modified)
                    {
                        entry.State = EntityState.Unchanged;
                        var databaseValues = entry.GetDatabaseValues();
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }
                context.SaveChanges();
            }
        }

        public void ListaCursantiTestProgramatsUID(ListaCursantiTestProgramat lista)
        {
            using (var context = new ModelContext())
            {
                context.ListaCursantiTestProgramats.Add(lista);
                foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
                {
                    entry.State = EntityConvertState.ConvertState(entry.Entity.State);
                    if (entry.State == EntityState.Modified)
                    {
                        entry.State = EntityState.Unchanged;
                        var databaseValues = entry.GetDatabaseValues();
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }
                context.SaveChanges();
            }
        }

        public Cursanti GetCursantByCont(string cont)
        {
            using (var context = new ModelContext())
            {
                var c = (from ct in context.Cursantis
                         where ct.ContCursant == cont
                         select ct).Single();

                return c;
            }
        }

        public ProgramareTest GetProgramareTestByName(string nume)
        {
            using (var context = new ModelContext())
            {
                var v = (from ct in context.ProgramareTests
                         where ct.NumeTestProgramat == nume
                         select ct).Include(s=>s.ListaCursantiTestProgramats.Select(a=>a.Cursanti)).Single();

                return v;
            }
        }

        public List<ProgramareTest> GetListProgramareTests()
        {
            using (var context = new ModelContext())
            {
                var lista = from ct in context.ProgramareTests
                            select ct;

                return lista.ToList();
            }
        }

        public bool CurataBazaDeDate()
        {
            using (var context = new ModelContext())
            {
                try
                {
                    context.Database.ExecuteSqlCommand("delete from ListaCursantiTestProgramats");
                    context.Database.ExecuteSqlCommand("delete from IstoricTesteRezolvateNerezolvateDeCursants");
                    context.Database.ExecuteSqlCommand("delete from IstoricTesteCreateDeLectoris");
                    context.Database.ExecuteSqlCommand("delete from IntrebariTestes");
                    context.Database.ExecuteSqlCommand("delete from TesteSalvateInBazaDeDates");
                    context.Database.ExecuteSqlCommand("delete from Raspunsuris");
                    context.Database.ExecuteSqlCommand("delete from ProgramareTests");
                    context.Database.ExecuteSqlCommand("delete from TestCreatDeLectors");
                    context.Database.ExecuteSqlCommand("delete from Lectoris");
                    context.Database.ExecuteSqlCommand("delete from Cursantis");
                    context.Database.ExecuteSqlCommand("delete from Intrebaris");
                    context.Database.ExecuteSqlCommand("delete from Capitoles");
                    context.Database.ExecuteSqlCommand("delete from Disciplinas");

                    return true;
                }
                catch(Exception)
                {
                    return false;
                }                
            }
        }

        public List<Intrebari> GetListaIntrebariRaspunsuriTestProgramatByNumeTestProgramat(string numeTest)
        {
            using (var context = new ModelContext())
            {
                var lista = (from ct in context.ProgramareTests
                             where ct.NumeTestProgramat == numeTest
                             select ct.TestCreatDeLector.IntrebariTestes.Select(s=>s.Intrebari)).Single();

                List<Intrebari> listaIntrebari = new List<Intrebari>();

                foreach(var v in lista)
                {
                    var intrebare = (from ct in context.Intrebaris
                                     where ct.IdIntrebare == v.IdIntrebare
                                     select ct).Include(s=>s.Raspunsuris).Single();
                    listaIntrebari.Add(intrebare);
                }

                return listaIntrebari;
            }
        }

        public ProgramareTest GetProgramareTestByNumeTest(string numeTest)
        {
            using (var context = new ModelContext())
            {
                var test = (from ct in context.ProgramareTests
                            where ct.NumeTestProgramat == numeTest
                            select ct).Single();

                return test;
            }
        }

        public void TesteSalvateInBazaDeDateUDI(TesteSalvateInBazaDeDate test)
        {
            using (var context = new ModelContext())
            {
                context.TesteSalvateInBazaDeDates.Add(test);
                foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
                {
                    entry.State = EntityConvertState.ConvertState(entry.Entity.State);
                    if (entry.State == EntityState.Modified)
                    {
                        entry.State = EntityState.Unchanged;
                        var databaseValues = entry.GetDatabaseValues();
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }
                context.SaveChanges();
            }
        }

        public void DeleteFromListaCursantiTestProgramats(int idTest, int idCursat)
        {
            using (var context = new ModelContext())
            {
                context.Database.ExecuteSqlCommand("delete from ListaCursantiTestProgramats where ProgramareTestId = {0} and CursantiIdCursant = {1}", idTest, idCursat);
            }
        }

        public List<TestCreatDeLector> GetTesteSalvateInBazaDeDateByContCursant(string cont)
        {
            using (var context = new ModelContext())
            {
                var lista = (from ct in context.TesteSalvateInBazaDeDates
                            where ct.Cursanti.ContCursant == cont
                            select ct.TestCreatDeLector).Distinct().Include(s=>s.IntrebariTestes.Select(a=>a.Intrebari.Raspunsuris)).Include(b=>b.TesteSalvateInBazaDeDates);

                return lista.ToList();
            }
        }

        public List<TestCreatDeLector> GetListTesteCreateDeLectorByContLector(string cont)
        {
            using (var context = new ModelContext())
            {
                var lista = (from ct in context.Lectoris
                             where ct.ContLector == cont
                             select ct).Include(s=>s.TestCreatDeLectors).Single().TestCreatDeLectors;

                return lista.ToList();
            }
        }

        public List<Cursanti> GetListaCursantiCareAuDatTestulCreatDeLectorByNumeTest(string numeTest)
        {
            using (var context = new ModelContext())
            {
                var lista = ((from ct in context.TestCreatDeLectors
                              where ct.NumeTest == numeTest
                              select ct).Include(s => s.TesteSalvateInBazaDeDates.Select(a=>a.Cursanti)).Single().TesteSalvateInBazaDeDates.Select(b=>b.Cursanti).Distinct());

                return lista.ToList();
            }
        }

        public List<TesteSalvateInBazaDeDate> GetListaTesteSalvateInBazaDeDateByID_CURSANT_ID_TestCreatDeLector(int idCursant, int idTest)
        {
            using (var context = new ModelContext())
            {
                var lista = (from ct in context.TestCreatDeLectors
                             where ct.IdTest == idTest
                             select ct)
                             .Include(s=>s.TesteSalvateInBazaDeDates.Select(b=>b.Intrebari.Raspunsuris))
                             .Single().TesteSalvateInBazaDeDates.Where(a => a.CursantiIdCursant == idCursant);

                return lista.ToList();
            }
        }

        public bool Logare(string user, string parola)
        {
            using (var context = new ModelContext())
            {
                try
                {
                    var userr = (from ct in context.Cursantis
                                 where ct.ContCursant == user && ct.Parola == parola
                                 select ct).Single();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }  
            }
        }

        public bool LogareLector(string cont, string parola)
        {
            using (var context = new ModelContext())
            {
                try
                {
                    var userr = (from ct in context.Lectoris
                                 where ct.ContLector == cont && ct.Parola == parola
                                 select ct).Single();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool RegisterLector(Lectori lector)
        {
            using (var context = new ModelContext())
            {
                try
                {
                    Disciplina d;
                    try
                    {
                        d = context.Disciplinas.Single(s => s.NumeDisciplina == "Disciplina noua");
                        lector.DisciplinaIdDisciplina = d.IdDisciplina;
                    }
                    catch(Exception)
                    {
                        d = new Disciplina
                        {
                            NumeDisciplina = "Disciplina noua"
                        };

                        context.Disciplinas.Add(d);
                        context.SaveChanges();
                        d = context.Disciplinas.Single(s => s.NumeDisciplina == "Disciplina noua");

                        var list = context.Disciplinas;
                        foreach(var vv in list)
                        {
                            d = vv;
                            lector.DisciplinaIdDisciplina = d.IdDisciplina;
                            break;
                        }
                    }

                    LectoriUDI(lector);
                    return true;
                }
               catch(Exception)
                {
                    return false;
                }
            }
        }

        public List<Disciplina> GetListDisciplineByNumeLector(string numeLEctor)
        {
            using (var context = new ModelContext())
            {
                var listaDiscipline = (from ct in context.Lectoris
                                      where ct.ContLector == numeLEctor
                                      select ct.Disciplina).Include(o=>o.Capitoles).ToList();


                return listaDiscipline;
            }
        }

        public List<Capitole> GetListaCapitoleByNumeDisciplina(string numeDisciplina)
        {
            using (var context = new ModelContext())
            {
                var lista = (from ct in context.Disciplinas
                             where ct.NumeDisciplina == numeDisciplina
                             select ct.Capitoles).Single();

                return lista.ToList();
            }
        }
    }
}