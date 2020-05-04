﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstShop.Core.Models
{
    public class Basket : BaseEntity
    {
        public virtual ICollection<BasketItem> BaseketItems { get; set; }

        public Basket()
        {
            this.BaseketItems = new List<BasketItem>();
        }
    }
}