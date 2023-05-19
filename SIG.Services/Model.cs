using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Services
{
    public abstract class Model
    {
     
        public Guid Id { get;  set; }
        public string ModifiedBy { get; set; } = "";
        public DateTime ModifyDate { get;  set; }= DateTime.Now;
        public bool IsActive { get; set; } = true;

    }
}
