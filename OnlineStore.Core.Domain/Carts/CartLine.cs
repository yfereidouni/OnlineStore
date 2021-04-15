using OnlineStore.Core.Domain.Products;

namespace OnlineStore.Core.Domain.Carts
{
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

}
