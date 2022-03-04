using NInjectInMVC.Models.Abstract;

namespace NInjectInMVC.Models.Entity
{
    public class DbData : IData
    {
        public string GetDataFromResource()
        {
            return "Get some data from Database.";
        }
    }
}