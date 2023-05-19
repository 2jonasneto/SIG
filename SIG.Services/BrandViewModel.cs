using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Services
{
    public  class BrandViewModel:Model
    { 
        [Required(ErrorMessage ="Defina um nome!")]
        [Display(Name ="Nome")]
        public string Name { get;  set; }
    }
}
