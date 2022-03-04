using NInjectInMVC.Models.Abstract;

namespace NInjectInMVC.Models.Entity
{
    public class Employee : IEmployee
    {
        public string GetEmployeeName()
        {
            return "Hai, My name is ****";
        }
    }
}