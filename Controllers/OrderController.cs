using adminautentication.Interface;
using adminautentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace adminautentication.Controllers
{
    public class OrderController : Controller
    {
        private readonly ISweetcatering _context;

    public OrderController(ISweetcatering context)
    {
        _context = context;
    }

    

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateorderPost(CustomerEntity customerData)
    {
        _context.Create(customerData);
        return RedirectToAction("Index");

    }

    [HttpGet]
    public IActionResult Edit(string FullName)
    {
        var cd = _context.GetCustomerdetail(FullName);

        return View(cd);
    }

    [HttpPost]
    public IActionResult EditPost(string Id, CustomerEntity customerData)
    {
        _context.Update(Id, customerData);
        return RedirectToAction("Index");

    }


    [HttpGet]
    public IActionResult OrderDetails(string FullName)
    {
        var cd = _context.GetCustomerdetail(FullName);

        return View(cd);
    }

    [HttpGet]
    public IActionResult Deleteorder(string FullName)
    {
        var cd = _context.GetCustomerdetail(FullName);

        return View(cd);
    }

    [HttpPost]
    public IActionResult DeleteorderPost(string FullName)
    {
        _context.Delete(FullName);
        return RedirectToAction("Index");
    }
}
}
