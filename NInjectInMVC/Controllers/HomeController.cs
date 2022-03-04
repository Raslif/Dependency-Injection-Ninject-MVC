using Ninject;
using NInjectInMVC.Models.Abstract;
using NInjectInMVC.Models.Entity;
using System;
using System.Web.Mvc;

namespace NInjectInMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployee _employee = null;
        private readonly IConnection _connection = null;
        private readonly IData[] _data = null;
        private readonly IData _fileData = null;
        private readonly IData _dbData = null;
        private readonly Service _service = null;
        public HomeController(IEmployee employee, IConnection connection, IData[] data,
            [Named("FileData")] IData fileData, [Named("DbData")] IData dbData, Service service)
        {
            _employee = employee ?? throw new ArgumentNullException(nameof(employee));
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _fileData = fileData ?? throw new ArgumentNullException(nameof(fileData));
            _dbData = dbData ?? throw new ArgumentNullException(nameof(dbData));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public ActionResult Index()
        {
            ViewBag.Name = _employee.GetEmployeeName();
            ViewBag.ConnectionString = _connection.GetConnectionString();
            var customerObjectByNamedParameter = InjectionResolver.GetType<ICustomer>("customer");
            var customerObject = InjectionResolver.GetType<ICustomer>();
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