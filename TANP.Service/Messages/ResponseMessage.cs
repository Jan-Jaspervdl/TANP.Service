using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TANP.Service.Messages
{
    public class ResponseMessage: IMessage
    {
        public string Response { get; set; }
        public IMessage RequestMessage { get; set; }
        public object ResponseObject { get; set; }
    }
}
