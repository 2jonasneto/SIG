using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIG.Services;
using SIG.Shared.Enums;

namespace SIG.Services
{
    public class ComputerViewModel:Model
    {
       

        [Display(Name ="Nome")]
        [Required(ErrorMessage ="Nome do computador é obrigatório!")]
        public string Name { get;  set; } = string.Empty;
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Nome do computador é obrigatório!")]
        public string Description { get;  set; } = string.Empty;
        public string Processor { get;  set; } = string.Empty;
        public int MemoryType { get;  set; }
        public int DiskType { get;  set; }
        public int DiskSize { get;  set; }
        public int MemorySize { get;  set; }
        public Guid BrandId { get;  set; }
        public string BrandName { get;  set; } = string.Empty;
        public Guid TypeId { get;  set; }
        public string TypeName { get;  set; } = string.Empty;
        public string SerialNumber { get;  set; } = string.Empty;
        public Guid LocacityId { get;  set; }
        public Guid AreaId { get;  set; }
        public Guid SectorId { get;  set; }

    }
}
