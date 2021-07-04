using System.Collections.Generic;

namespace Employees.Models.Generics
{
    public class Result
    {
        public string status { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public Dictionary<string, object> data { get; set; }

        public Result()
        {
            data = new Dictionary<string, object>();
        }
    }
}
