using LTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTW.Areas.Admin.Controllers
{
    public class UpcomingState : IPromotionState
    {
        public void Handle(KhuyenMai promotion)
        {
            // Logic khi khuyến mãi ở trạng thái Upcoming
            Console.WriteLine($"Khuyến mãi {promotion.TenKM} chưa bắt đầu.");
        }

        public string GetStateName()
        {
            return "Upcoming";
        }
    }

    public class ActiveState : IPromotionState
    {
        public void Handle(KhuyenMai promotion)
        {
            // Logic khi khuyến mãi đang diễn ra
            Console.WriteLine($"Khuyến mãi {promotion.TenKM} đang diễn ra.");
        }

        public string GetStateName()
        {
            return "Active";
        }
    }

    public class EndedState : IPromotionState
    {
        public void Handle(KhuyenMai promotion)
        {
            // Logic khi khuyến mãi đã kết thúc
            Console.WriteLine($"Khuyến mãi {promotion.TenKM} đã kết thúc.");
        }

        public string GetStateName()
        {
            return "Ended";
        }
    }

}