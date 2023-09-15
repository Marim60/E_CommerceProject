using E_CommerceProject.Data;

namespace E_CommerceProject.Models
{
    
    public class Item
    {
        public int Quantity { get; set; }
        public  Product Product { get; set; }
    }
}
