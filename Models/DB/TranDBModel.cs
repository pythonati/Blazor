﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FirstBlazor.Models.DB
{
    public class TranDBModel
    {
        public int Id{ get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public int Account { get; set; }
        [Required]
        public int Category { get; set; }
        public string Note { get; set; }
        public IEnumerable<TransLablesModel> Lables { get; set; }
    }
}
