using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_2.Models
{
    public class chores
    {
        [Key]
        public int id { get; set; }
        public string main_task { get; set; }
        public string secondary_task { get; set; }

    }
}
