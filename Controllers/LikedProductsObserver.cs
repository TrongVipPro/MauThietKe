using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTW.Controllers
{
    public class LikedProductsObserver : IObserver
    {
        public void Update(List<int> likedProducts)
        {
            HttpContext.Current.Session["LikedProducts"] = likedProducts;
        }
    }

}