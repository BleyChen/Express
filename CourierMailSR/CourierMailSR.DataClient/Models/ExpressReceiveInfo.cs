using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierMailSR.DataClient.Models
{
    public class ExpressReceiveInfo : BasicExpressInfo
    {
        public DateTime ReceiveTime { get; set; }

        public DateTime? Signtime { get; set; }

        public string Signer { get; set; }

        public MailReceiveStatus Status { get; set; }
    }
}
