using CourierMailSR.DataClient;
using CourierMailSR.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourierMailSR.Web.Models
{

    public enum ExpressType
    {
        Receive =1,
        Send =2
    }

    public class ExpressModel
    {
        public string ExpressNo { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }

        public MailType MailType { get; set; }

        public ExpressType ExpressType { get; set; }
    }


    public class SignModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}