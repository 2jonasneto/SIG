using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Services
{
    public  class LocacityViewModel : Model
    {
     

        public string Name { get;  set; }


        public Guid ActingAreaModelId { get;  set; }
        public ActingAreaViewModel ActingArea { get;  set; }

    }
}
