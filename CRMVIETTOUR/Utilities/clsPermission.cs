﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRMVIETTOUR.Models;
using CRM.Core;
using CRM.Infrastructure;

namespace CRMVIETTOUR.Utilities
{

    public static class clsPermission
    {
        public static CookieUser GetUser()
        {
            var item = new CookieUser();
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string user = HttpContext.Current.User.Identity.Name;
                if (HttpContext.Current.Request.Cookies["CookieUser" + user] != null)
                {
                    item.StaffID = Convert.ToInt32(HttpContext.Current.Request.Cookies["CookieUser" + user]["MaNV"]);
                    item.BranchID = HttpContext.Current.Request.Cookies["CookieUser" + user]["MaCN"] == "" ? 0 : Convert.ToInt32(HttpContext.Current.Request.Cookies["CookieUser" + user]["MaCN"]);
                    item.DepartmentID = HttpContext.Current.Request.Cookies["CookieUser" + user]["MaPB"] == "" ? 0 : Convert.ToInt32(HttpContext.Current.Request.Cookies["CookieUser" + user]["MaPB"]);
                    item.GroupID = HttpContext.Current.Request.Cookies["CookieUser" + user]["MaNKD"] == "" ? 0 : Convert.ToInt32(HttpContext.Current.Request.Cookies["CookieUser" + user]["MaNKD"]);
                    item.PermissionID = Convert.ToInt32(HttpContext.Current.Request.Cookies["CookieUser" + user]["PerID"]);
                }
            }
            return item;
        }

        public static bool AccessData(int form)
        {
            using (DataContext _db = new DataContext())
            {
                var check = _db.tbl_AccessData.AsEnumerable().FirstOrDefault(p => p.FormId == form
                && p.PermissionId == GetUser().PermissionID && p.ShowDataById == 6);
                if (check != null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}