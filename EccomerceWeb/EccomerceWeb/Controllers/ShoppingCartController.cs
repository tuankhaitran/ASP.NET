using EccomerceWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EccomerceWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        TrendUpEntities db = new TrendUpEntities();
        private const string strCart = "Cart";
        // GET: ShoppingCart
        public ActionResult Index()
        { 
            return View();
        }
        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session[strCart] == null)
            {
                List<Cart> lsCart = new List<Cart> {
                new Cart(db.Products.Find(id),1)
                };
                Session[strCart] = lsCart;
            }
            else
            {
                List<Cart> lsCart = (List<Cart>)Session[strCart];
                int check = isExistingCheck(id);
                if (check == -1)
                    lsCart.Add(new Cart(db.Products.Find(id), 1));
                else
                    lsCart[check].Quantity++;
                Session[strCart] = lsCart;

            }
            return View("Index");
        }

        private int isExistingCheck(int? id)
        {
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            for (int i = 0; i < lsCart.Count; i++)
            {
                if (lsCart[i].Product.ProductID == id) { return i; }
            }
            return -1;
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int check = isExistingCheck(id);
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            lsCart.RemoveAt(check);
            return View("Index");
        }
        public ActionResult UpdateCart(FormCollection frc)
        {
            string[] quantities = frc.GetValues("quantity");
            var lstCart = (List<Cart>)Session[strCart];
            for (int i = 0;i < lstCart.Count; i++)
            {
                lstCart[i].Quantity = Convert.ToInt32(quantities[i]);

            }
            Session[strCart] = lstCart;
            return View("Index");
        }
        public ActionResult CheckOut()
        {
           
            return View("CheckOut");
        }
        public ActionResult ProcessOrder(FormCollection frc)
        {
            List<Cart> lstCart = (List<Cart>)Session[strCart];
            Order order = new Order()
            {
                UserFname = frc["fname"],
                UserLname = frc["lname"],
                UserPhone = frc["number"],
                UserEmail = frc["compemailany"],
                OrderDate = DateTime.Now,
                Address = frc["add1"],
                City = frc["city"],
                State = frc["state"],
                Zip = frc["zip"],
            };
           
            decimal total = 0;
            foreach(Cart cart in lstCart)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderID = order.OrderID,
                    ProductID = cart.Product.ProductID,
                    Quantity = cart.Quantity,
                    Price = cart.Product.Price
                };
                total += System.Convert.ToDecimal(orderDetail.Quantity * orderDetail.Price);
                db.OrderDetails.Add(orderDetail);
            }
            order.TotalPrice = total;
            db.Orders.Add(order);
            db.SaveChanges();


            // Remove all shopping cart session
            Session.Remove(strCart);
            return View("OrderSuccess");
        }


    }
}