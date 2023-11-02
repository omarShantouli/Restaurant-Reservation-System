using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantDataModel
{
    public class Orders
    {
        public int order_id { get; set; }
        public int reservation_id { get; set; }
        public int employee_id { get; set; }
        public DateTime order_date { get; set; }
        public decimal total_amount { get; set; }
    }
}
