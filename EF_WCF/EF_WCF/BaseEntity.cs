using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EF_WCF
{
    [DataContract(IsReference = true)]
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            State = State.Unchanged;
        }
        [DataMember]
        public State State { get; set; }
    }
    public enum State
    {
        Added,
        Unchanged,
        Modified,
        Deleted
    }
}
