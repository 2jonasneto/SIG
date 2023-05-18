using SIG.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Core.Domain
{
    public sealed class Locacity : Entity
    {
        public Locacity(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }


        public Guid ActingAreaId { get; private set; }
        public ActingArea ActingArea { get; private set; }

        public ICollection<Computer> Computers { get; set; }
    }
}
