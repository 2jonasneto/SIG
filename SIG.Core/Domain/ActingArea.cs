using SIG.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Core.Domain
{
    public sealed class ActingArea:Entity
    {
        public ActingArea(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }

        public ICollection<Locacity> Locacities { get; private set; }
     
    }
}
