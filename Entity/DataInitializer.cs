using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Trade.MvsWebUI.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category(){Name="Shos",Description="Shos idependent"},
                new Category(){Name="Jeans",Description="jeans idependent"},
                new Category(){Name="Swith",Description="Swith idependent"}
            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>() {

                new Product(){Name="sarı",Description="",Stock=121,IsApproved=true,CategoryId=1},
                new Product(){Name="kırmızı",Description="",Stock=121,IsApproved=true,CategoryId=2},
                new Product(){Name="turuncu",Description="",Stock=121,IsApproved=true,CategoryId=3}
            };

            foreach ( var urun in urunler)
            {
                context.Products.Add(urun);
            }

            context.SaveChanges();
            base.Seed(context);
            
        }
    }
}