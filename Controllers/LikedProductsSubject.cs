using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTW.Controllers
{
    public class LikedProductsSubject : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private List<int> _likedProducts = new List<int>();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_likedProducts);
            }
        }

        public void SetLikedProducts(List<int> likedProducts)
        {
            _likedProducts = likedProducts;
            Notify();
        }
    }

}