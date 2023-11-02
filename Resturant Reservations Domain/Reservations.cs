using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantDataModel
{
    public class Reservations
    {
        public int reservation_id { get; set; }
        public int customer_id { get; set; }
        public int resturant_id { get; set; }
        public int table_id { get; set; }
        public DateTime reservation_date { get; set; }
        public int party_size { get; set; }

    }
}
