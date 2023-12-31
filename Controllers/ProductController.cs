using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    // this controller depends on the NorthwindRepository
    private DataContext _dataContext;
    public ProductController(DataContext db) => _dataContext = db;
    public IActionResult Category() => View(_dataContext.Categories.OrderBy(c => c.CategoryName));
    public IActionResult Index(int id){
        ViewBag.id = id;
        return View(_dataContext.Categories.OrderBy(c => c.CategoryName));
    }
    public IActionResult DiscountDetail() => View(_dataContext.Discounts.OrderBy(d => d.Title));
    public IActionResult DeleteDiscount(int id)
    {
        _dataContext.DeleteDiscount(_dataContext.Discounts.FirstOrDefault(d => d.DiscountId == id));
        return RedirectToAction("DiscountDetail");
    }
     [Authorize(Roles = "northwind-employee")]
    public  IActionResult EditDiscount(int Id) => View(_dataContext.Discounts.FirstOrDefault(d => d.DiscountId == Id));
  
  
  [Authorize(Roles = "northwind-employee"), HttpPost]
    public IActionResult EditDiscount(Discount discount)
    {
      //Edit Discount info
      _dataContext.EditDiscount(discount);
      return RedirectToAction("DiscountDetail", "Product");
    }
}
