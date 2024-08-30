using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Treasurer - John Steinbeck";
                customerProcess.Description = "Withdrawal completed, the amount requested by the customer has been paid!";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
            }
            else if(NextApprover != null)
            { 
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Treasurer - John Steinbeck";
                customerProcess.Description = "Since the withdrawal amount exceeded the amount the treasurer could pay per day, the transaction was directed to the assistant branch manager!";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
