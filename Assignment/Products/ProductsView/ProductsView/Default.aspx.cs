using System;
using System.Collections.Generic;

namespace ProductApp
{
    public partial class ProductViewer : System.Web.UI.Page
    {
        Dictionary<string, (string imageUrl, string price)> products = new Dictionary<string, (string, string)>()
        {
            { "Laptop", ("https://i5.walmartimages.com/asr/9dc2a21d-15b9-455e-a6a1-1ce51c8160ea.01c65474624eed67f2eac46afe9ddff5.jpeg", "₹65,000") },
            { "Smartphone", ("https://tse1.mm.bing.net/th/id/OIP.oiQBmgw9ZcWxB73JrfrtzgHaHa?w=166&h=180&c=7&r=0&o=7&dpr=1.5&pid=1.7&rm=3", "₹35,000") },
            { "Headphones", ("https://pisces.bbystatic.com/image2/BestBuy_US/images/products/39a31325-a258-474b-ab0b-ff6150f80606.jpg", "₹2,500") },
            { "Smartwatch", ("https://m.media-amazon.com/images/I/71PjidaynlL._AC_SL1500_.jpg", "₹8,000") }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.DataSource = products.Keys;
                ddlProducts.DataBind();
                ddlProducts.Items.Insert(0, "Select a product");
                imgProduct.ImageUrl = "";
                lblPrice.Text = "";
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = ddlProducts.SelectedValue;
            if (products.ContainsKey(selected))
            {
                imgProduct.ImageUrl = products[selected].imageUrl;
                lblPrice.Text = "";
            }
            else
            {
                imgProduct.ImageUrl = "";
                lblPrice.Text = "";
            }
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            string selected = ddlProducts.SelectedValue;
            if (products.ContainsKey(selected))
            {
                lblPrice.Text = "Price: " + products[selected].price;
            }
            else
            {
                lblPrice.Text = "Please select a product.";
            }
        }
    }
}
