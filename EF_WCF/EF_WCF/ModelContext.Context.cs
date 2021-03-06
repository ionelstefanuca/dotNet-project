﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF_WCF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
        {
            // Cod adugat manual
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types<BaseEntity>().Configure(x => x.Ignore(y => y.State));
        }
    
        public virtual DbSet<Capitole> Capitoles { get; set; }
        public virtual DbSet<Cursanti> Cursantis { get; set; }
        public virtual DbSet<Disciplina> Disciplinas { get; set; }
        public virtual DbSet<Intrebari> Intrebaris { get; set; }
        public virtual DbSet<IntrebariTeste> IntrebariTestes { get; set; }
        public virtual DbSet<IstoricTesteCreateDeLectori> IstoricTesteCreateDeLectoris { get; set; }
        public virtual DbSet<IstoricTesteRezolvateNerezolvateDeCursant> IstoricTesteRezolvateNerezolvateDeCursants { get; set; }
        public virtual DbSet<Lectori> Lectoris { get; set; }
        public virtual DbSet<ListaCursantiTestProgramat> ListaCursantiTestProgramats { get; set; }
        public virtual DbSet<ProgramareTest> ProgramareTests { get; set; }
        public virtual DbSet<Raspunsuri> Raspunsuris { get; set; }
        public virtual DbSet<TestCreatDeLector> TestCreatDeLectors { get; set; }
        public virtual DbSet<TesteSalvateInBazaDeDate> TesteSalvateInBazaDeDates { get; set; }
    }
}
