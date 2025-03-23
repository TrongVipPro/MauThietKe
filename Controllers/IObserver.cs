using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTW.Controllers
{
    public interface IObserver
    {
        void Update(List<int> likedProducts);

    }
}