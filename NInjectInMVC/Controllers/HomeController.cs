using NInjectInMVC.Models.Abstract;
using System;
using System.Web.Mvc;

namespace NInjectInMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployee _employee = null;

        public HomeController(IEmployee employee)
        {
            _employee = employee ?? throw new ArgumentNullException(nameof(employee));
        }

        public ActionResult Index()
        {
            ViewBag.Name = _employee.GetEmployeeName();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}