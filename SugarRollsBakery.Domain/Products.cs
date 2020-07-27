using Stripe;
using System.Collections.Generic;

namespace SugarRollsBakery.Domain
{
    public class Products
    {
        public Products(StripeList<Stripe.Product> stripeProducts, StripeList<Price> stripePrices)
        {
            BuildProducts(stripeProducts, stripePrices);
        }

        public List<Product> Items { get; set; }

        public void BuildProducts(StripeList<Stripe.Product> stripeProducts, StripeList<Price> stripePrices)
        {
            Items = new List<Product>();

            for (var i = 0; i < stripeProducts.Data.Count; i++)
            {
                Items.Add(new Product
                {
                    Image = stripeProducts.Data[i].Images.Count == 0 ? null : stripeProducts.Data[i].Images[0],
                    Name = stripeProducts.Data[i].Name,
                    Description = stripeProducts.Data[i].Description,
                    Price = stripePrices.Data[i].UnitAmountDecimal.Value / 100,
                    Unit = stripeProducts.Data[i].UnitLabel
                });
            }
        }
    }
}