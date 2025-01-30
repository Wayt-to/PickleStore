using System.ComponentModel.DataAnnotations.Schema;

namespace PickleWebStore.Models
{
    public class ShoppingCart
    {
        public int ID { get; set; }

        public int Member_ID { get; set; }
        [ForeignKey("Member_ID")]
        public virtual Member Member { get; set; }

        public int Product_ID { get; set; }
        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}