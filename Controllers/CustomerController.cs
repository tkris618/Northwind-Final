using Microsoft.AspNetCore.Mvc;

public class CustomerController : Controller
{
    // this controller depends on the DataContext
        private DataContext _dataContext;
        public CustomerController(DataContext db) => _dataContext = db;
        public IActionResult Register() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (_dataContext.Customers.Any(c => c.CompanyName == customer.CompanyName))
                {
                    ModelState.AddModelError("", "Company Name must be unique");
                }
                else
                {
                    _dataContext.AddCustomer(customer);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
}
