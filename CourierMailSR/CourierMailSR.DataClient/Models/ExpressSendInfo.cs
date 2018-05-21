using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierMailSR.DataClient.Models
{
    public class ExpressSendInfo : BasicExpressInfo
    {

        public DateTime ReceiveTime { get; set; }

        public DateTime? SendTime { get; set; }

        public MailSendStatus Status { get; set; }
    }
}
