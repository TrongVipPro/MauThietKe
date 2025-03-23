using LTW.Areas.Admin.Controllers;
using System.Collections.Generic;
using System;

namespace LTW.Areas.Admin.Model
{
    public class KhuyenMaiReport
    {
        public class KhuyenMai
        {

            public int MaKM { get; set; }
            public string TenKM { get; set; }
            public DateTime NgayBatDau { get; set; }
            public DateTime NgayKetThuc { get; set; }
            public decimal PhanTramGiam { get; set; }

            public IPromotionState State { get; private set; }

            public void SetState(IPromotionState state)
            {
                State = state;
            }

            public void UpdateState()
            {
                DateTime now = DateTime.Now;
                if (NgayBatDau > now)
                {
                    SetState(new UpcomingState());
                }
                else if (NgayBatDau <= now && NgayKetThuc >= now)
                {
                    SetState(new ActiveState());
                }
                else
                {
                    SetState(new EndedState());
                }
            }
        }
        public int TotalPromotions { get; set; }
        public int ActivePromotions { get; set; }
        public int TotalProducts { get; set; }
        public int TotalOrders { get; set; }

        public decimal TotalRevenue { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal ActualRevenue { get; set; }

        public List<string> ChartLabels { get; set; }
        public List<decimal> ChartData { get; set; }

        public List<string> PieLabels { get; set; }
        public List<int> PieData { get; set; }

        public List<PromotionDetailReport> PromotionDetails { get; set; }

        public KhuyenMaiReport()
        {
            ChartLabels = new List<string>();
            ChartData = new List<decimal>();
            PieLabels = new List<string>();
            PieData = new List<int>();
            PromotionDetails = new List<PromotionDetailReport>();
        }
    }
}
