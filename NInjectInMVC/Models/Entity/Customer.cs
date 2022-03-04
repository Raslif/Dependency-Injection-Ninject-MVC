using NInjectInMVC.Models.Abstract;

namespace NInjectInMVC.Models.Entity
{
    public class Customer : ICustomer
    {
        public string GetCustomerDetailsFromDB()
        {
            return "Get Customer Details From Database";
        }
    }
}