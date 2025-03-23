using LTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTW.Areas.Admin.Controllers
{
    public class OrderFacade
    {
        private MyDataDataContext data;

        public OrderFacade()
        {
            data = new MyDataDataContext();
        }

        // Hàm tạo công nợ từ đơn hàng
        public void TaoCongNoTuDonHang(DonHang donHang)
        {
            if (donHang.TrangThai == "chuagiao")
            {
                var congNo = new CongNo
                {
                    MaKH = donHang.MaKH,
                    NgayPhatSinh = DateTime.Now,
                    SoTienNo = donHang.TongTienDonHang,
                    DaThanhToan = 0,
                    ConLai = donHang.TongTienDonHang,
                    HanThanhToan = DateTime.Now.AddDays(30),
                    TrangThai = "Đang nợ"
                };

                data.CongNos.InsertOnSubmit(congNo);
                data.SubmitChanges();

                var chiTietCongNo = new ChiTietCongNo
                {
                    MaCN = congNo.MaCN,
                    MaDH = donHang.MaDH,
                    MaTT = donHang.MaTT,
                    SoTien = donHang.TongTienDonHang,
                    LoaiPhatSinh = "Nợ mới từ đơn hàng",
                    GhiChu = $"Công nợ từ đơn hàng {donHang.MaDH}"
                };

                data.ChiTietCongNos.InsertOnSubmit(chiTietCongNo);
                data.SubmitChanges();
            }
        }

        // Hàm cập nhật trạng thái đơn hàng
        public void CapNhatTrangThaiDonHang(int id, int matt, string trangthai)
        {
            var donhang = data.DonHangs.FirstOrDefault(d => d.MaDH == id && d.MaTT == matt);
            if (donhang != null)
            {
                string trangThaiCu = donhang.TrangThai;
                donhang.TrangThai = trangthai;

                if (trangThaiCu == "chuagiao" && trangthai == "dagiao")
                {
                    var congNoHienTai = data.CongNos.FirstOrDefault(cn =>
                        data.ChiTietCongNos.Any(ct => ct.MaDH == id && ct.MaTT == matt && ct.MaCN == cn.MaCN));

                    if (congNoHienTai == null)
                    {
                        TaoCongNoTuDonHang(donhang);
                    }
                }
                else if (trangthai == "trahang")
                {
                    var congNo = data.CongNos.FirstOrDefault(cn =>
                        data.ChiTietCongNos.Any(ct => ct.MaDH == id && ct.MaTT == matt && ct.MaCN == cn.MaCN));

                    if (congNo != null)
                    {
                        congNo.TrangThai = "Đã hủy - Trả hàng";
                        congNo.ConLai = 0;
                    }
                }

                data.SubmitChanges();
            }
        }

        // Hàm cập nhật trạng thái thanh toán
        public void CapNhatTrangThaiThanhToan(int id, int matt, string trangthaithanhtoan)
        {
            var donhang = data.DonHangs.FirstOrDefault(d => d.MaDH == id && d.MaTT == matt);
            if (donhang != null)
            {
                donhang.TrangThaiThanhToan = trangthaithanhtoan;

                if (trangthaithanhtoan == "dathanhtoan")
                {
                    var congNo = (from cn in data.CongNos
                                  join ct in data.ChiTietCongNos
                                  on cn.MaCN equals ct.MaCN
                                  where ct.MaDH == id && ct.MaTT == matt
                                  select cn).FirstOrDefault();

                    if (congNo != null)
                    {
                        congNo.DaThanhToan = congNo.SoTienNo;
                        congNo.ConLai = 0;
                        congNo.TrangThai = "Đã thanh toán";
                    }
                }

                data.SubmitChanges();
            }
        }
    }
}
