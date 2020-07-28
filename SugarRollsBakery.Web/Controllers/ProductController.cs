using SugarRollsBakery.Infrastructure.Configuration;
using SugarRollsBakery.Infrastructure.Services;
using SugarRollsBakery.Integration.Stripe;
using SugarRollsBakery.Web.Models;
using System.Web.Mvc;
using StripeNet = Stripe;

namespace SugarRollsBakery.Web.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            StripeNet.StripeConfiguration.ApiKey = new Configuration().BuildFromAppConfiguration<IStripeConfiguration>().ApiKey;
            var productService = new ProductService(new StripeProductService(new StripeNet.ProductService()), new StripePriceService(new StripeNet.PriceService()));

            return View(new ProductModel
            {
                Products = productService.GetProducts().Items
            });
        }
    }
}