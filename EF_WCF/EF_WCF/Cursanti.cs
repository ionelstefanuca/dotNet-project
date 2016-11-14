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
    public partial class Cursanti:BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cursanti()
        {
            this.IstoricTesteRezolvateNerezolvateDeCursants = new HashSet<IstoricTesteRezolvateNerezolvateDeCursant>();
            this.ListaCursantiTestProgramats = new HashSet<ListaCursantiTestProgramat>();
            this.TesteSalvateInBazaDeDates = new HashSet<TesteSalvateInBazaDeDate>();
        }

        [DataMember]
        public int IdCursant { get; set; }
        [DataMember]
        public string ContCursant { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Parola { get; set; }
        [DataMember]
        public int DisciplinaIdDisciplina { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<IstoricTesteRezolvateNerezolvateDeCursant> IstoricTesteRezolvateNerezolvateDeCursants { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<ListaCursantiTestProgramat> ListaCursantiTestProgramats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<TesteSalvateInBazaDeDate> TesteSalvateInBazaDeDates { get; set; }
        [DataMember]
        public virtual Disciplina Disciplina { get; set; }
    }
}
