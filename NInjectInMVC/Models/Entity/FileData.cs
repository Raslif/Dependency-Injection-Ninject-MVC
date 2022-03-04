using NInjectInMVC.Models.Abstract;

namespace NInjectInMVC.Models.Entity
{
    public class FileData : IData
    {
        public string GetDataFromResource()
        {
            return "Get some data from File.";
        }
    }
}