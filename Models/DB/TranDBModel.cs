using FirstBlazor.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FirstBlazor.Models.DB
{
    [Index(nameof(TranType))]
    [Index(nameof(AccountId))]
    [Index(nameof(CategoryId))]
    public class TranDBModel
    {
        public int Id { get; set; }
        [Required]
        public int TranType { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [MaxLength(500)]
        public string Note { get; set; }
        public List<TransLablesModel> Lables { get; set; }
    }
}
