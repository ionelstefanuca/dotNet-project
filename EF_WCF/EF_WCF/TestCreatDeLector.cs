//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    [DataContract(IsReference = true)]
    public partial class TestCreatDeLector: BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestCreatDeLector()
        {
            this.IntrebariTestes = new HashSet<IntrebariTeste>();
            this.IstoricTesteCreateDeLectoris = new HashSet<IstoricTesteCreateDeLectori>();
            this.IstoricTesteRezolvateNerezolvateDeCursants = new HashSet<IstoricTesteRezolvateNerezolvateDeCursant>();
            this.ProgramareTests = new HashSet<ProgramareTest>();
            this.TesteSalvateInBazaDeDates = new HashSet<TesteSalvateInBazaDeDate>();
        }

        [DataMember]
        public int IdTest { get; set; }
        [DataMember]
        public string NumeTest { get; set; }
        [DataMember]
        public string Timp { get; set; }
        [DataMember]
        public int LectoriIdLector { get; set; }
        [DataMember]
        public int NrIntrebari { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<IntrebariTeste> IntrebariTestes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<IstoricTesteCreateDeLectori> IstoricTesteCreateDeLectoris { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<IstoricTesteRezolvateNerezolvateDeCursant> IstoricTesteRezolvateNerezolvateDeCursants { get; set; }
        [DataMember]
        public virtual Lectori Lectori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<ProgramareTest> ProgramareTests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<TesteSalvateInBazaDeDate> TesteSalvateInBazaDeDates { get; set; }
    }
}