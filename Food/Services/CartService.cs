using Food.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Services
{
    //tinh truu tuong bat buoc th nao ke thua phai sd het cac thuoc tinh cua no
    interface CartService
    {
        List<CartItem> GetCarts();
        bool AddToCart(CartItem item);
        bool DeleteItem(CartItem item);
        bool UpdateQty(CartItem item, int newQty);
        bool ClearCart();
    }
}
