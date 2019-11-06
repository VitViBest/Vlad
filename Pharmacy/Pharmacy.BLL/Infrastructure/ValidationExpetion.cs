using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Infrastructure
{
    public class ValidationExpetion : System.Exception
    {
        public string Property { get; protected set; }

        public ValidationExpetion(string message, string property) : base(message)
        {
            Property = property;
        }
    }
}
