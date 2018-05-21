using CourierMailSR.Data;
using CourierMailSR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourierMailSR.Web.Controllers
{
    public class MailSRController : Controller
    {

        #region express receive

        public ActionResult ExpressReceive()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetMailSR(string search, int draw, int start, int length)
        {

            List<ExpressReceiveInfo> expressReceiveInfoList = null;
            using (var dbcontext = new ExpressDBContext())
            {

                var query = dbcontext.ExpressReceiveInfos;

                if (!string.IsNullOrEmpty(search))
                {
                    expressReceiveInfoList = query.Where(s => s.ExpressNo.Contains(search) || s.Phone.Contains(search)).ToList();
                }
                else
                {
                    expressReceiveInfoList = query.ToList();
                }
            }

            int total = expressReceiveInfoList.Count();
            return Json(new
            {
                draw = draw,
                recordsTotal = total,
                recordsFiltered = total,
                data = expressReceiveInfoList.Skip(start).Take(length).Select(s => new
                {
                    s.Id,
                    s.ExpressNo,
                    s.MailType,
                    s.Name,
                    ReceiveTime = s.ReceiveTime.ToString("yyyy-MM-dd/hh:mm:ss"),
                    Status = s.Status.ToString(),
                    s.Signer,
                    Signtime = string.IsNullOrEmpty(s.Signer) ? "" : s.Signtime.ToString("yyyy-MM-dd/hh:mm:ss"),
                    s.Phone
                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SubmitExpressInfo(ExpressModel model)
        {
            using (var dbcontext = new ExpressDBContext())
            {
                if (model.ExpressType == ExpressType.Receive)
                {
                    var express = new ExpressReceiveInfo();
                    express.ExpressNo = model.ExpressNo;
                    express.MailType = model.MailType;
                    express.Phone = model.Phone;
                    express.ReceiveTime = DateTime.Now;
                    express.Status = MailReceiveStatus.WaitForSign;
                    express.Name = model.Name;
                    dbcontext.ExpressReceiveInfos.Add(express);
                }
                else
                {
                    var express = new ExpressSendInfo();
                    express.ExpressNo = model.ExpressNo;
                    express.MailType = model.MailType;
                    express.Phone = model.Phone;
                    express.ReceiveTime = DateTime.Now;
                    express.Status = MailSendStatus.WaitSend;
                    express.Name = model.Name;
                    dbcontext.ExpressSendInfos.Add(express);
                }

                dbcontext.SaveChanges();
            }

            return Json(new
            {
                Success = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SignExpress(SignModel singer)
        {
            using (var dbcontext = new ExpressDBContext())
            {
                var needSignExpress = dbcontext.ExpressReceiveInfos.FirstOrDefault(s => s.Id == singer.Id);
                if (needSignExpress != null)
                {
                    needSignExpress.Signer = singer.Name;
                    needSignExpress.Signtime = DateTime.Now;
                    needSignExpress.Status = MailReceiveStatus.AlreadySign;
                    dbcontext.SaveChanges();
                }
            }

            return Json(new
            {
                Success = true
            }, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region express send
        public ActionResult ExpressSend()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GetMailSendList(string search, int draw, int start, int length)
        {
            List<ExpressSendInfo> expressSendInfoList = null;
            using (var dbcontext = new ExpressDBContext())
            {

                var query = dbcontext.ExpressSendInfos;

                if (!string.IsNullOrEmpty(search))
                {
                    expressSendInfoList = query.Where(s => s.ExpressNo.Contains(search) || s.Phone.Contains(search)).ToList();
                }
                else
                {
                    expressSendInfoList = query.ToList();
                }
            }

            int total = expressSendInfoList.Count();
            return Json(new
            {
                draw = draw,
                recordsTotal = total,
                recordsFiltered = total,
                data = expressSendInfoList.Skip(start).Take(length).Select(s => new
                {
                    s.Id,
                    s.ExpressNo,
                    s.MailType,
                    s.Name,
                    ReceiveTime = s.ReceiveTime.ToString("yyyy-MM-dd/hh:mm:ss"),
                    Status = s.Status.ToString(),
                    SendTime = s.SendTime == DateTime.MinValue ? "" : s.SendTime.ToString("yyyy-MM-dd/hh:mm:ss"),
                    s.Phone
                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SendExpress(int id)
        {
            using (var dbcontext = new ExpressDBContext())
            {
                var needSignExpress = dbcontext.ExpressSendInfos.FirstOrDefault(s => s.Id == id);
                if (needSignExpress != null)
                {
                    needSignExpress.SendTime = DateTime.Now;
                    needSignExpress.Status = MailSendStatus.AlreadySend;
                    dbcontext.SaveChanges();
                }
            }


            return Json(new
            {
                Success = true
            }, JsonRequestBehavior.AllowGet);
        }


        #endregion

    }




}