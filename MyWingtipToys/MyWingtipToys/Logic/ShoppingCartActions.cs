using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWingtipToys.Models;

namespace MyWingtipToys.Logic
{
    public class ShoppingCartActions : IDisposable
    {
        public string ShoppingCartId { get; set; }
        private ProductContext _db = new ProductContext();

        public const string CartSessionKey = "CartId";

        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCArtId();
            return _db.ShoppingCartItems.Where(c => c.CartId == ShoppingCartId).ToList();
        }
        
        public void AddToCart(int id)
        {
            ShoppingCartId = GetCArtId();

            var carItem = _db.ShoppingCartItems.SingleOrDefault(c => c.CartId == ShoppingCartId && c.ProductId == id);

            if (carItem == null)
            {
                carItem = new CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    CartId = ShoppingCartId,
                    Product = _db.Products.SingleOrDefault(p => p.ProductID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };
                _db.ShoppingCartItems.Add(carItem);
            }
            else
            {
                carItem.Quantity++;

            }
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        private string GetCArtId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public decimal GetTotal()
        {
            ShoppingCartId = GetCArtId();//zasto se ovo radi na pocetku???
            decimal? total = decimal.Zero;
            total = (decimal?)(from CartItem in _db.ShoppingCartItems
                               where CartItem.CartId == ShoppingCartId
                               select (int?)CartItem.Quantity * CartItem.Product.UnitPrice).Sum();

            return total ?? decimal.Zero;
        }
    }
}