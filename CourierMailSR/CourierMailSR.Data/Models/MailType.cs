using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierMailSR.Data
{
    public enum MailType
    {
        YuanTong = 1,
        Shengtong = 2,
        Cainiao = 3,
        JD = 4,
        Yunda = 5,
        Shunfeng = 6,
        EMS = 7,
        TianTian = 8,
        Other = 9
    }

    public enum MailReceiveStatus
    {
        WaitForSign = 1,
        AlreadySign = 2
    }

    public enum MailSendStatus
    {
        WaitSend = 1,
        AlreadySend = 2
    }
}
