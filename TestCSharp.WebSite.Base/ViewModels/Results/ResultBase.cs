using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp.WebSite.Base.ViewModels.Results
{
    public class ResultBase
    {
        public ResultBase(bool success)
        {
            this.success = success;
        }

        public bool success { get; set; }
        public string url { get; set; }
        public string message { get; set; }
    }
}
