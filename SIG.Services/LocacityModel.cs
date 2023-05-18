using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Core.Services
{
    public  class LocacityModel : Model
    {
     

        public string Name { get;  set; }


        public Guid ActingAreaModelId { get;  set; }
        public ActingAreaModel ActingArea { get;  set; }

    }
}
