﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantDataModel
{
    public class OrderItems
    {
        [Key]
        public int order_item_id { get; set; }
        public int order_id { get; set; }
        public int item_id { get; set; }
        public decimal quantity { get; set; }
    }
}
