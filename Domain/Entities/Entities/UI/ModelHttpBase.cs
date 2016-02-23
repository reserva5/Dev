using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UI
{
    public class ModelHttpBase
    {
        public string HttpStatusDesc { get; set; }
        public int HttpStatusCode { get; set; }
        public Exception Exception { get; set; }
}
}
