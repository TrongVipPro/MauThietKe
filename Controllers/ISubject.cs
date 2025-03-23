using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTW.Controllers
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

}