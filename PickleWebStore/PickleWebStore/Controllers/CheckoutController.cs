using PickleWebStore.Data.ViewModels;
using PickleWebStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PickleWebStore.Controllers
{
    public class CheckoutController : Controller
    {
        PickleWebDBModel db = new PickleWebDBModel();
        PaymentViewModel payment = new PaymentViewModel();

        [HttpGet]
        // GET: Checkout
        public ActionResult Index()
        {
            int Member_ID = 0;
            if (Session["user"] != null)
            {
                Member_ID = (Session["user"] as Member).ID;
                ViewBag.cart = db.ShoppingCarts.Where(x => x.Member_ID == Member_ID).ToList();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            return View(payment);

        }
        [HttpPost]
        public async Task<ActionResult> Index(string cardNumber, string ExpirationMonth, string ExpirationYear, string cvv, string address, string city)
        {
            cardNumber = cardNumber.Replace(" ", "");
            int Member_ID = 0;
            if (Session["user"] != null)
            {
                Member_ID = (Session["user"] as Member).ID;
            }

            List<ShoppingCart> cart = db.ShoppingCarts.Where(x => x.Member_ID == Member_ID).ToList();
            double total = cart.Sum(x => x.Product.Price * x.Quantity);
            string priceStr = total.ToString().Replace(",", ".");

            string merchantID = "123456";
            string merchantPass = "1234";
            string apiUrl = $"https://localhost:44392/API/PAY?kartNo={cardNumber}&ay={ExpirationMonth}&yil={ExpirationYear}&cvv={cvv}&bakiye={priceStr}&merchantID={merchantID}&merchantPass={merchantPass}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    var stringResp = await response.Content.ReadAsStringAsync();

                    if (stringResp == "\"201\"")
                    {

                        foreach (var item in cart)
                        {
                            Sale sale = new Sale();
                            sale.Product_ID = item.Product_ID;
                            sale.Price = item.Product.Price;
                            sale.Quantity = item.Quantity;
                            sale.TotalPrice = item.Product.Price * item.Quantity;
                            sale.SaleTime = DateTime.Now;
                            sale.IsActive = true;
                            sale.IsDeleted = false;
                            sale.Member_ID = item.Member_ID;
                            sale.Address = city + " şehri " + address;
                            db.Sales.Add(sale);
                            db.ShoppingCarts.Remove(item);
                        }
                        ViewBag.Message = "Ödeme Başarılı";
                        db.SaveChanges();
                        return RedirectToAction("PaymentSuccess");
                    }
                    else if (stringResp == "\"901\"")
                    {
                        ViewBag.Message = "Kart Numarası Hatalı Girildi";
                        ViewBag.cart = cart;
                    }
                    else if (stringResp == "\"501\"")
                    {
                        ViewBag.Message = "Geçersiz Kart Tarihi";
                        ViewBag.cart = cart;
                    }
                    else if (stringResp == "\"701\"")
                    {
                        ViewBag.Message = "Banka Mesajı = Bir Hata Oluştu";
                        ViewBag.cart = cart;
                    }
                    else if (stringResp == "\"801\"")
                    {
                        ViewBag.Message = "Banka Mesajı = CVV Hatalı";
                        ViewBag.cart = cart;
                    }
                    else if (stringResp == "\"401\"")
                    {
                        ViewBag.Message = "Banka Mesajı = Kart Aktif Değil";
                        ViewBag.cart = cart;
                    }
                    else if (stringResp == "\"301\"")
                    {
                        ViewBag.Message = "Banka Mesajı = Kart Bakiyesi Yetersiz";
                        ViewBag.cart = cart;
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Bağlantı hatası: " + ex.Message;
                }
            }
            ViewBag.cart = cart;
            return View(payment);

        }

        public ActionResult PaymentSuccess()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}