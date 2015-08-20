using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp.WebSite.Base.ViewModels.Results
{
    public class Result<T>
        : ResultBase
        where T : new()
    {
        public Result(bool success)
            : base(success)
        {
            data = new T();
        }

        public T data { get; set; }
    }
}
