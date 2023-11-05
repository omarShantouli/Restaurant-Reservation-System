using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantDataModel
{
    public class Tables
    {
        [Key]
        public int table_id { get; set; }
        public int resturant_id { get; set; }
        public int capacity { get; set; }
    }
}
