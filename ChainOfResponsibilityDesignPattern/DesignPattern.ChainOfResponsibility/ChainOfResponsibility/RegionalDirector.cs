using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class RegionalDirector : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();

            if (req.Amount <= 400000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Regional Director - Tom Kelley";
                customerProcess.Description = "Withdrawal completed, the amount requested by the customer has been paid!";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Regional Director - Tom Kelley";
                customerProcess.Description = "Since the withdrawal amount exceeded the amount the regional director could pay per day, The maximum amount that a customer can withdraw per day is TL 400,000; for larger amounts, the customer must come to the branch on more than one day!";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
                
            }
        }
    }
}
