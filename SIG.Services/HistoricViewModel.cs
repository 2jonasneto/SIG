using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Services
{
    public  class HistoricViewModel:Model
    {
        public string Description { get; set; }
        public Guid ComputerId { get; set; }
    }
}
