using SIG.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Core.Domain
{
    public sealed class EquipType:Entity
    {
        public EquipType(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

     
    }
}
