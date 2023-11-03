using System.ComponentModel.DataAnnotations;

namespace ResturantDataModel
{
    public class Customers
    {
        [Key]
        public int customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set;}
        public string email { get; set; }
        public string phone_number { get; set; }
            
    }
}
