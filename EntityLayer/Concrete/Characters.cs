using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Characters
    {

        [Key]
        public int CharcID { get; set; }
        public string CharcName { get; set; }
    }
}
