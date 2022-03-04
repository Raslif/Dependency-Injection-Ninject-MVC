using NInjectInMVC.Models.Abstract;
using System;
using System.Web.Mvc;

namespace NInjectInMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployee _employee = null;
        private readonly IConnectionString _connectionString = null;

        public HomeController(IEmployee employee, IConnectionString connectionString)
        {
            _employee = employee ?? throw new ArgumentNullException(nameof(employee));
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public ActionResult Index()
        {
            ViewBag.Name = _employee.GetEmployeeName();
            ViewBag.ConnectionString = _connectionString.GetConnectionString();
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