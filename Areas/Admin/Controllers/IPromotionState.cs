using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LTW.Models;


namespace LTW.Areas.Admin.Controllers
{
    public interface IPromotionState
    {
        void Handle(KhuyenMai promotion);
        string GetStateName();
    }
}