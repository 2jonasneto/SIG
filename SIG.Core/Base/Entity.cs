using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Core.Base
{
    public abstract class Entity
    {
        protected Entity( string modifiedBy)
        {
            Id = Guid.NewGuid(); 
            ModifiedBy = modifiedBy;
            ModifyDate = DateTime.Now;
            IsActive = true;
        }

        public Guid Id { get;  set; }= Guid.NewGuid();

        public string ModifiedBy { get;  set; }=string.Empty;

        public DateTime ModifyDate { get;  set; } = DateTime.Now;
        public bool IsActive { get;  set; }=true;

    }
}
