using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TH_Ogani_Test.Models;
using X.PagedList;

namespace TH_Ogani_Test.Area.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("ProductList")]
        public IActionResult ProductList(int page = 1)
        {

            int pageNumber = page;
            int pageSize = 20;
            var lstSanPham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp).Where(x => x.IsDelete == 0);

            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstSanPham, pageNumber, pageSize);
            return View(lst);
        }

        [Route("AddProduct")]
        public IActionResult AddProductForm()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
            return View();
        }

        [Route("AddProductToDB")]
        [HttpPost]
        public IActionResult AddProductToDB(TDanhMucSp danhMucSp)
        {
            db.Add(danhMucSp);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [Route("UpdateProduct")]
        [HttpGet]
        public IActionResult UpdateProduct(string maSp)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");

            TDanhMucSp danhMucSp = db.TDanhMucSps.Find(maSp);

            return View(danhMucSp);
        }

        [Route("UpdateProductToDB")]
        public IActionResult UpdateProductToDB(TDanhMucSp danhMucSp)
        {
            db.Update(danhMucSp);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(string maSp)
        {
            TDanhMucSp danhMucSp = db.TDanhMucSps.Find(maSp);
            danhMucSp.IsDelete = 1;
            db.Update(danhMucSp);
            db.SaveChanges();

            return RedirectToAction("ProductList");
        }
    }
}
