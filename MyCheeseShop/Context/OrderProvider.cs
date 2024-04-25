using MyCheeseShop.Model;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MyCheeseShop.Context
{
    public class OrderProvider
    {
        public async Task CreateOrder(User user, IEnumerable<CartItem> items)
        {
            var order = new Order
            {

            };
        }
    }
}
