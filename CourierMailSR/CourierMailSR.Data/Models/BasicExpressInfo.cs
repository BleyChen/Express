using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierMailSR.Data
{
    public class BasicExpressInfo
    {
        [Key]
        public int Id { get; set; }

        public string ExpressNo { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public MailType MailType { get; set; }

    }
}
