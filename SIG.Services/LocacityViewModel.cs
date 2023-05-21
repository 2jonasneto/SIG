using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Services
{
    public  class LocacityViewModel : Model
    {
     

        public string Name { get;  set; }


        public Guid ActingAreaId { get;  set; }
        [NotMapped]
        public virtual ActingAreaViewModel ActingArea { get; set; } =new ActingAreaViewModel();

    }
}
