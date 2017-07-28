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

namespace CRMVIETTOUR.Controllers.Quotation
{
    [Authorize]
    public class QuotationManageController : BaseController
    {
        // GET: QuotationManage

        #region Init

        private IGenericRepository<tbl_Tags> _tagRepository;
        private IGenericRepository<tbl_PartnerNote> _partnerNoteRepository;
        private IGenericRepository<tbl_Dictionary> _dictionaryRepository;
        private IGenericRepository<tbl_DocumentFile> _documentFileRepository;
        private IGenericRepository<tbl_Quotation> _quotationRepository;
        private IGenericRepository<tbl_Customer> _customerRepository;
        private DataContext _db;

        public QuotationManageController(IGenericRepository<tbl_Dictionary> dictionaryRepository,
            IGenericRepository<tbl_PartnerNote> partnerNoteRepository,
            IGenericRepository<tbl_DocumentFile> documentFileRepository,
            IGenericRepository<tbl_Tags> tagRepository,
            IGenericRepository<tbl_Quotation> quotationRepository,
            IGenericRepository<tbl_Customer> customerRepository,
            IBaseRepository baseRepository)
            : base(baseRepository)
        {
            this._customerRepository = customerRepository;
            this._partnerNoteRepository = partnerNoteRepository;
            this._documentFileRepository = documentFileRepository;
            this._dictionaryRepository = dictionaryRepository;
            this._tagRepository = tagRepository;
            this._quotationRepository = quotationRepository;
            _db = new DataContext();
        }

        #endregion

        #region Permission
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
        #endregion

        #region Index
        public ActionResult Index()
        {
            Permission(clsPermission.GetUser().PermissionID, 22);

            if (SDBID == 6)
                return View(new List<tbl_Quotation>());

            var model = _quotationRepository.GetAllAsQueryable().AsEnumerable()
                .Where(p => ((p.StaffId == maNV | maNV == 0) || (p.StaffQuotationId == maNV | maNV == 0)
                    || ((p.TourId != null) && (p.tbl_Tour.Permission != null && p.tbl_Tour.Permission.Contains(maNV.ToString())
                    || p.tbl_Tour.StaffId == maNV || p.tbl_Tour.CreateStaffId == maNV)))
                    & (p.tbl_Staff.DepartmentId == maPB | maPB == 0)
                    & (p.tbl_Staff.StaffGroupId == maNKD | maNKD == 0)
                    & (p.tbl_Staff.HeadquarterId == maCN | maCN == 0) & (p.IsDelete == false))
                    .OrderByDescending(p => p.CreatedDate).ToList();
            return View(model);
        }
        #endregion

        #region Create
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(tbl_Quotation model, FormCollection form, IEnumerable<HttpPostedFileBase> FileName)
        {
            Permission(clsPermission.GetUser().PermissionID, 22);

            try
            {
                model.Code = GenerateCode.QuotationCode();
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.TagsId = form["TagsId"] != null && form["TagsId"] != "" ? form["TagsId"].ToString() : null;
                model.StaffId = clsPermission.GetUser().StaffID;
                model.StartDate = DateTime.Now;
                model.EndDate = DateTime.Now;
                model.DictionaryId = 29;
                if (form["QuotationDate"] != null && form["QuotationDate"] != "" && form["QuotationDate"] != "")
                {
                    model.QuotationDate = Convert.ToDateTime(form["QuotationDate"].ToString());
                }

                if (FileName != null)
                {
                    foreach (var file in FileName)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            String path = Server.MapPath("~/Upload/file/" + file.FileName);
                            file.SaveAs(path);
                            model.FileName = file.FileName;
                        }
                        if (await _quotationRepository.Create(model))
                        {
                            UpdateHistory.SaveHistory(22, "Thêm mới báo giá, code: " + model.Code);
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            catch { }
            return RedirectToAction("Index");
        }
        #endregion

        #region Update

        [HttpPost]
        public async Task<ActionResult> EditInfoQuotation(int id)
        {
            Permission(clsPermission.GetUser().PermissionID, 22);

            var model = await _quotationRepository.GetById(id);
            return PartialView("_Partial_Edit_Quotation", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Update(tbl_Quotation model, FormCollection form)
        {
            Permission(clsPermission.GetUser().PermissionID, 22);

            try
            {
                model.ModifiedDate = DateTime.Now;
                if (form["TagsId"] != null && form["TagsId"] != "")
                {
                    model.TagsId = form["TagsId"].ToString();
                }
                if (form["QuotationDate"] != null && form["QuotationDate"] != "")
                {
                    model.QuotationDate = Convert.ToDateTime(form["QuotationDate"].ToString());
                }

                HttpPostedFileBase file = Request.Files["FileName"];
                if (file != null && file.ContentLength > 0)
                {
                    String path = Server.MapPath("~/Upload/file/" + file.FileName);
                    file.SaveAs(path);
                    model.FileName = file.FileName;
                }

                if (await _quotationRepository.Update(model))
                {
                    UpdateHistory.SaveHistory(22, "Cập nhật báo giá: " + model.Code);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Dữ liệu đầu vào không đúng định dạng!");
                }
            }
            catch
            {
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(FormCollection fc)
        {
            Permission(clsPermission.GetUser().PermissionID, 22);

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
                            var item = _quotationRepository.FindId(Convert.ToInt32(i));
                            UpdateHistory.SaveHistory(22, "Xóa báo giá: " + item.Code);
                        }
                        //
                        if (await _quotationRepository.DeleteMany(listIds, false))
                        {
                            return Json(new ActionModel() { Succeed = true, Code = "200", View = "", Message = "Xóa dữ liệu thành công !", IsPartialView = false, RedirectTo = Url.Action("Index", "QuotationManage") }, JsonRequestBehavior.AllowGet);
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
        #endregion
    }
}