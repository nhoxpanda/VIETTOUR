using CRM.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Core;
using CRMVIETTOUR.Utilities;

namespace CRMVIETTOUR.Controllers.Other
{
    [AllowAnonymous]
    public class SubmitFromWebController : Controller
    {
        private DataContext _db = new DataContext();

        // GET: SubmitFromWeb
        public ActionResult Index(FormCollection fc)
        {
            string url = Request.RawUrl;
            string name = fc["your-name"];
            string email = fc["your-email"];
            string phone = fc["mobi"];
            string tour = fc["dynamictext-815"];
            string note = fc["yeucaukhac"];
            string sotreem = fc["sotreem"];
            string songuoilon = fc["songuoilon"];
            string date = fc["date-349"];
            //
            var customer = new tbl_Customer
            {
                Code = GenerateCode.CustomerCode(),
                FullName = name,
                Phone = phone,
                MobilePhone = phone,
                CompanyEmail = email,
                PersonalEmail = email,
                NoteTour = note,
                IsDelete = false,
                IsSendAccount = false,
                IsTemp = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                StaffId = 1073,
                StaffManager = 1073
            };
            _db.tbl_Customer.Add(customer);
            _db.SaveChanges();
            //
            return Redirect(url);
        }
    }
}