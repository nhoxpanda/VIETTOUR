﻿using CRM.Core;
using CRM.Infrastructure;
using CRMVIETTOUR.Models;
using CRMVIETTOUR.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CRMVIETTOUR.Controllers.Visa
{
    [Authorize]
    public class DocumentaryVisaManageController : BaseController
    {
        // GET: DocumentaryVisa

        #region Init

        private IGenericRepository<tbl_DocumentFile> _documentFileRepository;
        private IGenericRepository<tbl_Dictionary> _dictionaryRepository;

        private DataContext _db;

        public DocumentaryVisaManageController(IGenericRepository<tbl_DocumentFile> documentFileRepository,
            IGenericRepository<tbl_Dictionary> dictionaryRepository,
            IBaseRepository baseRepository)
            : base(baseRepository)
        {
            this._documentFileRepository = documentFileRepository;
            this._dictionaryRepository = dictionaryRepository;
            _db = new DataContext();
        }

        #endregion

        public ActionResult Index()
        {
            Permission(clsPermission.GetUser().PermissionID, 13);
            return View();
        }
        int SDBID = 6;
        int maPB = 0, maNKD = 0, maNV = 0, maCN = 0;
        void Permission(int PermissionsId, int formId)
        {
            var list = _db.tbl_ActionData.Where(p => p.FormId == formId && p.PermissionsId == PermissionsId).Select(p => p.FunctionId).ToList();
            ViewBag.IsAdd = list.Contains(1);
            ViewBag.IsDelete = list.Contains(2);
            ViewBag.IsEdit = list.Contains(3);
            ViewBag.IsImport = list.Contains(4);
            ViewBag.IsExport = list.Contains(5);
            ViewBag.IsLock = list.Contains(6);
            ViewBag.IsUnLock = list.Contains(7);

            var ltAccess = _db.tbl_AccessData.Where(p => p.PermissionId == PermissionsId && p.FormId == formId).Select(p => p.ShowDataById).FirstOrDefault();
            if (ltAccess != 0)
                this.SDBID = ltAccess;

            switch (SDBID)
            {
                case 2: maPB = clsPermission.GetUser().DepartmentID;
                    maCN = clsPermission.GetUser().BranchID;
                    break;
                case 3: maNKD = clsPermission.GetUser().GroupID;
                    maCN = clsPermission.GetUser().BranchID; break;
                case 4: maNV = clsPermission.GetUser().StaffID; break;
                case 5: maCN = clsPermission.GetUser().BranchID; break;
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(tbl_DocumentFile model, FormCollection form)
        {
            Permission(clsPermission.GetUser().PermissionID, 13);
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedDate = DateTime.Now;
                    model.IsRead = false;
                    model.ModifiedDate = DateTime.Now;
                    if (form["TagsId"] != null && form["TagsId"] != "")
                    {
                        model.TagsId = form["TagsId"].ToString();
                    } 
                    model.DictionaryId = 27;
                    model.StaffId = clsPermission.GetUser().StaffID;

                    HttpPostedFileBase file = Request.Files["FileName"];
                    if (file != null && file.ContentLength > 0)
                    {
                        String path = Server.MapPath("~/Upload/file/" + file.FileName);
                        file.SaveAs(path);
                        model.FileName = file.FileName;
                        model.FileSize = Common.ConvertFileSize(file.ContentLength);
                    }

                    if (await _documentFileRepository.Create(model))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Dữ liệu đầu vào không đúng định dạng!");
                    }
                }
            }
            catch { }
            return RedirectToAction("Index");
        }

        //[ChildActionOnly]
        //public ActionResult _Partial_EditDocumentVisa()
        //{
        //    List<SelectListItem> lstTag = new List<SelectListItem>();
        //    ViewData["TagsId"] = lstTag;
        //    return PartialView("_Partial_EditDocumentVisa", new tbl_DocumentFile());
        //}

        [HttpPost]
        public async Task<ActionResult> EditInfoDocument(int id)
        {
            Permission(clsPermission.GetUser().PermissionID, 13);
            var model = await _documentFileRepository.GetById(id);
            return PartialView("_Partial_EditDocumentVisa", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Update(tbl_DocumentFile model, FormCollection form)
        {
            Permission(clsPermission.GetUser().PermissionID, 13);
            try
            {
                if (ModelState.IsValid)
                {
                    model.IsRead = true;
                    model.ModifiedDate = DateTime.Now;
                    if (form["TagsId"] != null && form["TagsId"] != "")
                    {
                        model.TagsId = form["TagsId"] != null ? form["TagsId"].ToString() : "";
                    } 

                    HttpPostedFileBase file = Request.Files["FileName"];
                    if (file != null && file.ContentLength > 0)
                    {
                        String path = Server.MapPath("~/Upload/file/" + file.FileName);
                        file.SaveAs(path);
                        model.FileName = file.FileName;
                        model.FileSize = Common.ConvertFileSize(file.ContentLength);
                    }
                    else
                    {
                        var doc = _db.tbl_DocumentFile.Find(model.Id);
                        model.FileName = doc.FileName;
                        model.FileSize = doc.FileSize;
                    }

                    if (await _documentFileRepository.Update(model))
                    {
                        UpdateHistory.SaveHistory(13, "Cập nhật tài liệu visa: " + model.Code);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Dữ liệu đầu vào không đúng định dạng!");
                    }
                }
            }
            catch
            {
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(FormCollection fc)
        {
            Permission(clsPermission.GetUser().PermissionID, 13);
            try
            {
                if (fc["listItemId"] != null && fc["listItemId"] != "")
                {
                    var listIds = fc["listItemId"].Split(',');
                    listIds = listIds.Take(listIds.Count() - 1).ToArray();
                    if (listIds.Count() > 0)
                    {
                        //
                        foreach (var i in listIds)
                        {
                            var item = _documentFileRepository.FindId(Convert.ToInt32(i));
                            UpdateHistory.SaveHistory(13, "Xóa tài liệu visa: " + item.Code + " - " + item.FileName);
                        }
                        //
                        if (await _documentFileRepository.DeleteMany(listIds, false))
                        {
                            return Json(new ActionModel() { Succeed = true, Code = "200", View = "", Message = "Xóa dữ liệu thành công !", IsPartialView = false, RedirectTo = Url.Action("Index", "DocumentaryVisaManage") }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new ActionModel() { Succeed = false, Code = "200", View = "", Message = "Xóa dữ liệu thất bại !" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                return Json(new ActionModel() { Succeed = false, Code = "200", View = "", Message = "Vui lòng chọn những mục cần xóa !" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [ChildActionOnly]
        public ActionResult _Partial_ListDocument()
        {
            Permission(clsPermission.GetUser().PermissionID, 13);

            if (SDBID == 6)
                return PartialView("_Partial_ListDocument", new List<DocumentFileViewModel>());

            var model = _documentFileRepository.GetAllAsQueryable().AsEnumerable().Where(p => (p.StaffId == maNV | maNV == 0)
                    & (p.tbl_Staff.DepartmentId == maPB | maPB == 0)
                    & (p.tbl_Staff.StaffGroupId == maNKD | maNKD == 0)
                    & (p.tbl_Staff.HeadquarterId == maCN | maCN == 0)
                    & (p.DictionaryId == 27)
                    & (p.IsDelete == false))
                    .OrderByDescending(p => p.CreatedDate)
                 .Select(p => new DocumentFileViewModel
                 {
                     Id = p.Id,
                     Code = p.Code,
                     ModifiedDate = p.ModifiedDate.ToString("dd/MM/yyyy"),
                     URL = "https://view.officeapps.live.com/op/embed.aspx?src=" + Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port) + "/Upload/file/" + p.FileName,
                     CreatedDate = p.CreatedDate.ToString("dd/MM/yyyy"),
                     DictionaryName = p.tbl_Dictionary.Name,
                     FileName = p.FileName,
                     FileSize = p.FileSize,
                     Note = p.Note,
                     TagsId = LoadData.LocationTags(p.TagsId),
                     Staff = p.tbl_Staff.FullName
                 }).ToList();
            return PartialView("_Partial_ListDocument", model);
        }

        [HttpPost]
        public ActionResult SearchCountryVisa(string id)
        {
            Permission(clsPermission.GetUser().PermissionID, 13);

            var model = _documentFileRepository.GetAllAsQueryable().AsEnumerable().Where(p => p.TagsId.Split(',').Contains(id) && p.DictionaryId == 27).Where(p => (p.StaffId == maNV | maNV == 0)
                    & (p.tbl_Staff.DepartmentId == maPB | maPB == 0)
                    & (p.tbl_Staff.StaffGroupId == maNKD | maNKD == 0)
                    & (p.tbl_Staff.HeadquarterId == maCN | maCN == 0)
                    & (p.IsDelete == false))
                .Select(p => new DocumentFileViewModel
                {
                    Id = p.Id,
                    Code = p.Code,
                    ModifiedDate = p.ModifiedDate.ToString("dd/MM/yyyy"),
                    URL = "https://view.officeapps.live.com/op/embed.aspx?src=" + Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port) + "/Upload/file/" + p.FileName,
                    CreatedDate = p.CreatedDate.ToString("dd/MM/yyyy"),
                    DictionaryName = p.tbl_Dictionary.Name,
                    FileName = p.FileName,
                    FileSize = p.FileSize,
                    Note = p.Note,
                    TagsId = LoadData.LocationTags(p.TagsId),
                    Staff = p.tbl_Staff.FullName
                }).ToList();
            return PartialView("_Partial_ListDocument", model);

        }

    }
}