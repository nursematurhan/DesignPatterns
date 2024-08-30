using DesignPattern.ChainOfResponsibility.ChainOfResponsibility;
using DesignPattern.ChainOfResponsibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.ChainOfResponsibility.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee treasurer = new Treasurer();
            Employee managerAssistant = new ManagerAssistant();
            Employee manager = new Manager();
            Employee regionalDirector = new RegionalDirector();

            treasurer.SetNextApprover(managerAssistant);
            treasurer.SetNextApprover(manager);
            treasurer.SetNextApprover(regionalDirector);
            
            treasurer.ProcessRequest(model);

            return View();
        }
    }
}
