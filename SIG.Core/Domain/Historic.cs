using SIG.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Core.Domain
{
    public sealed class Historic:Entity
    {
        public Historic(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
        public Guid ComputerId { get; set; }


        public Computer Computer { get; set; }
    }
}
