using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlazor.Models.DB
{
    public class LableDBModel
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string Name { get; set; }
    }
}
