using LTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTW.Controllers
{
    public class DataContextSingleton
    {
        private static readonly Lazy<MyDataDataContext> _instance = new Lazy<MyDataDataContext>(() => new MyDataDataContext());

        private DataContextSingleton() { }

        public static MyDataDataContext Instance => _instance.Value;
    }

}