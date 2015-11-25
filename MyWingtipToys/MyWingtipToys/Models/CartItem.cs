﻿using System;
using System.ComponentModel.DataAnnotations;


namespace MyWingtipToys.Models
{
    public class CartItem
    {
        [Key]
        public string ItemId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
        public virtual Products Product { get; set; }
    }
}