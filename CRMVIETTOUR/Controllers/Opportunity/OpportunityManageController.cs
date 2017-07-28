using CRM.Core;
using CRM.Infrastructure;
using CRMVIETTOUR.Models;
using CRMVIETTOUR.Utilities;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CRMVIETTOUR.Controllers;
using System.Data.Entity;
using CRM.Enum;

namespace CRMVIETTOUR.Controllers.Opportunity
{
    public class OpportunityManageController : BaseController
    {
        // GET: OpportunityManage

        #region Init

        private IGenericRepository<tbl_UpdateHistory> _updateHistoryRepository;
        private IGenericRepository<tbl_Tags> _tagRepository;
        private IGenericRepository<tbl_Dictionary> _dictionaryRepository;
        private IGenericRepository<tbl_DocumentFile> _documentFileRepository;
        private IGenericRepository<tbl_Staff> _staffRepository;
        private IGenericRepository<tbl_Customer> _customerRepository;
        private IGenericRepository<tbl_CustomerVisa> _customerVisaRepository;
        private IGenericRepository<tbl_Opportunity> _opportunityRepository;
        private DataContext _db;

        public OpportunityManageController(IGenericRepository<tbl_Dictionary> dictionaryRepository,
            IGenericRepository<tbl_Opportunity> opportunityRepository,
            IGenericRepository<tbl_UpdateHistory> updateHistoryRepository,
            IGenericRepository<tbl_Opportunity> contractRepository,
            IGenericRepository<tbl_DocumentFile> documentFileRepository,
            IGenericRepository<tbl_Staff> staffRepository,
            IGenericRepository<tbl_Tags> tagRepository,
            IGenericRepository<tbl_CustomerVisa> customerVisaRepository,
            IGenericRepository<tbl_Customer> customerRepository,
            IBaseRepository baseRepository)
            : base(baseRepository)
        {
            this._updateHistoryRepository = updateHistoryRepository;
            this._customerRepository = customerRepository;
            this._staffRepository = staffRepository;
            this._opportunityRepository = opportunityRepository;
            this._documentFileRepository = documentFileRepository;
            this._dictionaryRepository = dictionaryRepository;
            this._tagRepository = tagRepository;
            this._customerVisaRepository = customerVisaRepository;
            _db = new DataContext();
        }

        #endregion

        #region List
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

            //cập nhật trạng thái
            var listUS = _db.tbl_ActionData.Where(p => p.FormId == 1128 & p.PermissionsId == PermissionsId).Select(p => p.FunctionId).ToList();
            ViewBag.IsUpdateStatus = list.Contains(1);

            var ltAccess = _db.tbl_AccessData.Where(p => p.PermissionId == PermissionsId && p.FormId == formId).Select(p => p.ShowDataById).FirstOrDefault();
            if (ltAccess != 0)
                this.SDBID = ltAccess;

            switch (SDBID)
            {
                case 2:
                    maPB = clsPermission.GetUser().DepartmentID;
                    maCN = clsPermission.GetUser().BranchID;
                    break;
                case 3:
                    maNKD = clsPermission.GetUser().GroupID;
                    maCN = clsPermission.GetUser().BranchID; break;
                case 4: maNV = clsPermission.GetUser().StaffID; break;
                case 5: maCN = clsPermission.GetUser().BranchID; break;
            }
        }

        public ActionResult Index()
        {
            Permission(clsPermission.GetUser().PermissionID, 1128);

            if (SDBID == 6)
                return View(new List<tbl_Opportunity>());
            return View();
        }

        [ChildActionOnly]
        public ActionResult _Partial_List()
        {
            Permission(clsPermission.GetUser().PermissionID, 1128);
            if (SDBID == 6)
                return PartialView("_Partial_List", new List<tbl_Opportunity>());

            try
            {
                int maPB = 0, maNKD = 0, maNV = 0, maCN = 0;
                switch (SDBID)
                {
                    case 2:
                        maPB = clsPermission.GetUser().DepartmentID;
                        maCN = clsPermission.GetUser().BranchID;
                        break;
                    case 3:
                        maNKD = clsPermission.GetUser().GroupID;
                        maCN = clsPermission.GetUser().BranchID; break;
                    case 4: maNV = clsPermission.GetUser().StaffID; break;
                    case 5: maCN = clsPermission.GetUser().BranchID; break;
                }

                DateTime dateFrom = new DateTime(DateTime.Now.Year, 1, 1);
                DateTime dateTo = new DateTime(DateTime.Now.Year, 12, 31);

                var model = _opportunityRepository.GetAllAsQueryable().AsEnumerable()
                    .Where(p => ((p.StaffId == maNV | maNV == 0) || p.ManagerId == maNV)
                        & (p.tbl_Staff.DepartmentId == maPB | maPB == 0)
                        & (p.tbl_Staff.StaffGroupId == maNKD | maNKD == 0)
                        & (p.tbl_Staff.HeadquarterId == maCN | maCN == 0) & (p.IsDelete == false)
                        & (dateFrom <= p.CreatedDate && p.CreatedDate <= dateTo))
                    .OrderByDescending(p => p.CreatedDate).ToList();

                return PartialView("_Partial_List", model);
            }
            catch
            { }

            return PartialView("_Partial_List");
        }

        [HttpPost]
        public ActionResult Filter(DateTime? dateFrom, DateTime? dateTo, int group, int? status, int? percentFrom, int? percentTo)
        {
            Permission(clsPermission.GetUser().PermissionID, 1128);
            if (SDBID == 6)
                return PartialView("_Partial_List", new List<tbl_Opportunity>());

            try
            {
                int maPB = 0, maNKD = 0, maNV = 0, maCN = 0;
                switch (SDBID)
                {
                    case 2:
                        maPB = clsPermission.GetUser().DepartmentID;
                        maCN = clsPermission.GetUser().BranchID;
                        break;
                    case 3:
                        maNKD = clsPermission.GetUser().GroupID;
                        maCN = clsPermission.GetUser().BranchID; break;
                    case 4: maNV = clsPermission.GetUser().StaffID; break;
                    case 5: maCN = clsPermission.GetUser().BranchID; break;
                }

                var model = _opportunityRepository.GetAllAsQueryable().AsEnumerable()
                    .Where(p => ((p.StaffId == maNV | maNV == 0) || p.ManagerId == maNV)
                        & (p.tbl_Staff.DepartmentId == maPB | maPB == 0)
                        & (p.tbl_Staff.StaffGroupId == maNKD | maNKD == 0)
                        & (p.tbl_Staff.HeadquarterId == maCN | maCN == 0) & (p.IsDelete == false)
                        & (dateTo == dateFrom ? p.CreatedDate.ToString("yyyy-MM-dd") == dateFrom.Value.ToString("yyyy-MM-dd") : dateFrom <= p.CreatedDate && p.CreatedDate <= dateTo.Value.AddDays(1))
                        & (status == 0 ? p.Id != 0 : p.StatusId == status)
                        & (group == 0 ? p.Id != 0 : p.GroupId == group)
                        & (percentFrom <= p.TiemNang && p.TiemNang <= percentTo)
                        )
                    .OrderByDescending(p => p.CreatedDate).ToList();

                return PartialView("_Partial_List", model);
            }
            catch
            { }

            return PartialView("_Partial_List");
        }

        [HttpPost]
        public ActionResult GetIdOpportunity(int id)
        {
            Session["idOpportunity"] = id;
            return Json(JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Create

        public JsonResult GetPercentByStatus(int id)
        {
            return Json(_dictionaryRepository.FindId(id).Icon, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(tbl_Opportunity model, FormCollection form)
        {
            Permission(clsPermission.GetUser().PermissionID, 1128);
            try
            {
                model.Code = GenerateCode.OpportunityCode();
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.ManagerId = clsPermission.GetUser().StaffID;
                model.StaffId = clsPermission.GetUser().StaffID;
                if (await _opportunityRepository.Create(model))
                {
                    UpdateHistory.SaveHistory(1128, "Thêm mới cơ hội: " + model.Code + " - " + model.Name);

                    return RedirectToAction("Index");
                }
            }
            catch { }

            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        [HttpPost]
        public ActionResult Edit(int id)
        {
            Permission(clsPermission.GetUser().PermissionID, 1128);
            var model = _opportunityRepository.FindId(id);
            return PartialView("_Partial_EditOpportunity", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Update(tbl_Opportunity model, FormCollection form)
        {
            Permission(clsPermission.GetUser().PermissionID, 1128);
            try
            {
                model.ModifiedDate = DateTime.Now;
                model.StaffId = clsPermission.GetUser().StaffID;
                model.ManagerId = clsPermission.GetUser().StaffID;
                if (await _opportunityRepository.Update(model))
                {
                    UpdateHistory.SaveHistory(1128, "Cập nhật cơ hội: " + model.Code);
                    return RedirectToAction("Index");
                }
            }
            catch { }

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(FormCollection fc)
        {
            Permission(clsPermission.GetUser().PermissionID, 1128);
            try
            {
                if (fc["listItemId"] != null && fc["listItemId"] != "")
                {
                    var listIds = fc["listItemId"].Split(',');
                    listIds = listIds.Take(listIds.Count() - 1).ToArray();
                    if (listIds.Count() > 0)
                    {
                        foreach (string id in listIds)
                        {
                            var update = _db.tbl_UpdateHistory.AsEnumerable().FirstOrDefault(p => p.ContractId.ToString() == id);
                            if (update != null)
                            {
                                _db.tbl_UpdateHistory.Remove(update);
                            }
                            ////
                            var opportunity = _opportunityRepository.FindId(Convert.ToInt32(id));
                            UpdateHistory.SaveHistory(1128, "Xóa cơ hội: " + opportunity.Code + " - " + opportunity.Name);
                        }

                        if (await _opportunityRepository.DeleteMany(listIds, false))
                        {
                            return Json(new ActionModel() { Succeed = true, Code = "11280", View = "", Message = "Xóa dữ liệu thành công !", IsPartialView = false, RedirectTo = Url.Action("Index", "OpportunityManage") }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new ActionModel() { Succeed = false, Code = "11280", View = "", Message = "Xóa dữ liệu thất bại !" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                return Json(new ActionModel() { Succeed = false, Code = "11280", View = "", Message = "Vui lòng chọn những mục cần xóa !" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region Excel Sample

        public void ExportExcelTemplateOpportunity(MemoryStream stream, string templateFile, IDictionary<string, string> header = null)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            using (var xlPackage = new ExcelPackage(stream, new MemoryStream(System.IO.File.ReadAllBytes(templateFile))))
            {
                var ws = xlPackage.Workbook.Worksheets[1]; //first worksheet
                var valWs = xlPackage.Workbook.Worksheets.Add("Validation");
                valWs.Hidden = eWorkSheetHidden.VeryHidden;

                //ws.AddHeader(header);

                // nhân viên quản lý
                var nhanvien = LoadData.StaffList()
                    .Select(p => new ExportItem
                    {
                        Text = p.FullName,
                        Value = p.Id
                    });
                var columnIndex = ws.GetColumnIndex(OpportunityColumn.NVQL.ToString());
                ws.AddListValidation(valWs, nhanvien, columnIndex, "Lỗi", "Lỗi", "NVQL", "NVQLName");

                // nhóm cơ hội
                var nhomcohoi = LoadData.OpportunityGroupList()
                    .Select(p => new ExportItem
                    {
                        Text = p.Name,
                        Value = p.Id
                    });
                columnIndex = ws.GetColumnIndex(OpportunityColumn.NHOMCOHOI.ToString());
                ws.AddListValidation(valWs, nhomcohoi, columnIndex, "Lỗi", "Lỗi", "NHOMCOHOI", "NHOMCOHOIName");

                // tình trạng
                var tintrang = LoadData.OpportunityStatusList()
                    .Select(p => new ExportItem
                    {
                        Text = p.Name,
                        Value = p.Id
                    });
                columnIndex = ws.GetColumnIndex(OpportunityColumn.TINHTRANG.ToString());
                ws.AddListValidation(valWs, tintrang, columnIndex, "Lỗi", "Lỗi", "TINHTRANG", "TINHTRANGName");

                // hình thức tiếp xúc
                var hinhthuc = LoadData.ContactFormList()
                    .Select(p => new ExportItem
                    {
                        Text = p.Name,
                        Value = p.Id
                    });
                columnIndex = ws.GetColumnIndex(OpportunityColumn.HINHTHUCTIEPXUC.ToString());
                ws.AddListValidation(valWs, hinhthuc, columnIndex, "Lỗi", "Lỗi", "HINHTHUCTIEPXUC", "HINHTHUCTIEPXUCName");

                // danh xung
                var danhxung = LoadData.NameTypeList()
                    .Select(p => new ExportItem
                    {
                        Text = p.Name,
                        Value = p.Id
                    });
                columnIndex = ws.GetColumnIndex(OpportunityColumn.DANHXUNG.ToString());
                ws.AddListValidation(valWs, danhxung, columnIndex, "Lỗi", "Lỗi", "DANHXUNG", "DANHXUNGName");

                // tinh tp
                var tinhthanh = _tagRepository.GetAllAsQueryable().AsEnumerable().Where(p => p.IsDelete == false && p.TypeTag == 5)
                    .Select(p => new ExportItem
                    {
                        Text = p.Tag,
                        Value = p.Id
                    });
                columnIndex = ws.GetColumnIndex(OpportunityColumn.TINHTHANH.ToString());
                ws.AddListValidation(valWs, tinhthanh, columnIndex, "Lỗi", "Lỗi", "TINHTP", "TINHTPName");

                // ngành nghề
                var nghenghiep = LoadData.CareerList()
                    .Select(p => new ExportItem
                    {
                        Text = p.Name,
                        Value = p.Id
                    });
                columnIndex = ws.GetColumnIndex(OpportunityColumn.NGANHNGHE.ToString());
                ws.AddListValidation(valWs, nghenghiep, columnIndex, "Lỗi", "Lỗi", "NGANHNGHE", "NGANHNGHEName");

                // nguồn đến
                var nguonden = LoadData.OriginList()
                    .Select(p => new ExportItem
                    {
                        Text = p.Name,
                        Value = p.Id
                    });
                columnIndex = ws.GetColumnIndex(OpportunityColumn.NGUONDEN.ToString());
                ws.AddListValidation(valWs, nguonden, columnIndex, "Lỗi", "Lỗi", "NGUONDEN", "NGUONDENName");

                // nhóm khách
                var nhomkhach = LoadData.CustomerGroupList()
                    .Select(p => new ExportItem
                    {
                        Text = p.Name,
                        Value = p.Id
                    });
                columnIndex = ws.GetColumnIndex(OpportunityColumn.NHOMKH.ToString());
                ws.AddListValidation(valWs, nhomkhach, columnIndex, "Lỗi", "Lỗi", "NHOMKH", "NHOMKHName");

                xlPackage.Save();
            }
        }

        public ActionResult ExcelSample()
        {
            try
            {
                IDictionary<string, string> header = new Dictionary<string, string>();
                header.Add("TITLE", "DANH SÁCH CƠ HỘI");

                byte[] bytes = null;
                using (var stream = new MemoryStream())
                {
                    string templateFile = System.Web.HttpContext.Current.Server.MapPath("~\\Upload\\ImportExport\\Import_CoHoiCRMVIETTOUR.xlsx");
                    ExportExcelTemplateOpportunity(stream, templateFile, header);
                    bytes = stream.ToArray();
                }

                string fileName = "Mau-import-co-hoi-CRMVIETTOUR.xlsx";
                return File(bytes, "text/xls", fileName);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region Import
        [HttpPost]
        public ActionResult ImportFile(HttpPostedFileBase FileNameOpportunity)
        {
            try
            {

                using (var excelPackage = new ExcelPackage(FileNameOpportunity.InputStream))
                {
                    List<OpportunityViewModel> list = new List<OpportunityViewModel>();
                    var worksheet = excelPackage.Workbook.Worksheets[1];
                    var lastRow = worksheet.Dimension.End.Row;
                    for (int row = 7; row <= lastRow; row++)
                    {
                        if (worksheet.Cells["B" + row].Value == null || worksheet.Cells["B" + row].Text == "")
                            continue;
                        var cus = new OpportunityViewModel
                        {
                            TENCOHOI = worksheet.Cells["B" + row].Value != null ? worksheet.Cells["B" + row].Text : null,
                            TIEMNANG = worksheet.Cells["D" + row].Value != null ? Convert.ToInt32(worksheet.Cells["D" + row].Text) : 0,
                            TENKH = worksheet.Cells["G" + row].Value != null ? worksheet.Cells["G" + row].Text : null,
                            DIACHI = worksheet.Cells["I" + row].Value != null ? worksheet.Cells["I" + row].Text : null,
                            EMAIL = worksheet.Cells["K" + row].Value != null ? worksheet.Cells["K" + row].Text : null,
                            DIDONG = worksheet.Cells["L" + row].Value != null ? worksheet.Cells["L" + row].Text : null,
                            DIENTHOAI = worksheet.Cells["M" + row].Value != null ? worksheet.Cells["M" + row].Text : null,
                            GHICHU = worksheet.Cells["R" + row].Value != null ? worksheet.Cells["R" + row].Text : null
                        };
                        string cel = "";
                        // nhóm cơ hội
                        try
                        {
                            cel = "C";
                            if (worksheet.Cells[cel + row].Value != null && worksheet.Cells[cel + row].Text != "")
                            {
                                string danhxung = worksheet.Cells[cel + row].Text;
                                cus.TENNHOMCOHOI = danhxung;
                                cus.NHOMCOHOI = _dictionaryRepository.GetAllAsQueryable().AsEnumerable().FirstOrDefault(c => c.Name == danhxung && c.DictionaryCategoryId == 32).Id;
                            }
                        }
                        catch { }
                        // tình trạng
                        try
                        {
                            cel = "E";
                            if (worksheet.Cells[cel + row].Value != null && worksheet.Cells[cel + row].Text != "")
                            {
                                string danhxung = worksheet.Cells[cel + row].Text;
                                cus.TENTINHTRANG = danhxung;
                                cus.TINHTRANG = _dictionaryRepository.GetAllAsQueryable().AsEnumerable().FirstOrDefault(c => c.Name == danhxung && c.DictionaryCategoryId == 30).Id;
                            }
                        }
                        catch { }
                        // hình thức tiếp xúc
                        try
                        {
                            cel = "F";
                            if (worksheet.Cells[cel + row].Value != null && worksheet.Cells[cel + row].Text != "")
                            {
                                string danhxung = worksheet.Cells[cel + row].Text;
                                cus.TENHINHTHUCTIEPXUC = danhxung;
                                cus.HINHTHUCTIEPXUC = _dictionaryRepository.GetAllAsQueryable().AsEnumerable().FirstOrDefault(c => c.Name == danhxung && c.DictionaryCategoryId == 31).Id;
                            }
                        }
                        catch { }
                        // danh xưng
                        try
                        {
                            cel = "H";
                            if (worksheet.Cells[cel + row].Value != null && worksheet.Cells[cel + row].Text != "")
                            {
                                string danhxung = worksheet.Cells[cel + row].Text;
                                cus.TENDANHXUNG = danhxung;
                                cus.DANHXUNG = _dictionaryRepository.GetAllAsQueryable().AsEnumerable().FirstOrDefault(c => c.Name == danhxung && c.DictionaryCategoryId == 7).Id;
                            }
                        }
                        catch { }
                        // nguồn khách
                        try
                        {
                            cel = "P";
                            if (worksheet.Cells[cel + row].Value != null && worksheet.Cells[cel + row].Text != "")
                            {
                                string nguonkhach = worksheet.Cells[cel + row].Text;
                                cus.TENNGUONDEN = nguonkhach;
                                cus.NGUONDEN = _dictionaryRepository.GetAllAsQueryable().AsEnumerable().FirstOrDefault(c => c.Name == nguonkhach && c.DictionaryCategoryId == 4).Id;
                            }
                        }
                        catch { }
                        //tagid dia chi
                        try
                        {
                            // tinh thanh
                            cel = "J";
                            if (worksheet.Cells[cel + row].Value != null && worksheet.Cells[cel + row].Text != "")
                            {
                                string tinhtp = worksheet.Cells[cel + row].Text;
                                cus.TENTINHTHANH = tinhtp;
                                cus.TINHTHANH = _tagRepository.GetAllAsQueryable().AsEnumerable().Where(c => c.Tag == tinhtp).Select(c => c.Id).SingleOrDefault().ToString();
                            }
                        }
                        catch { }
                        //nhóm khách hàng
                        try
                        {
                            cel = "O";
                            if (worksheet.Cells[cel + row].Value != null && worksheet.Cells[cel + row].Text != "")
                            {
                                string nhomkh = worksheet.Cells[cel + row].Text;
                                cus.TENNHOMKH = nhomkh;
                                cus.NHOMKH = _dictionaryRepository.GetAllAsQueryable().AsEnumerable().FirstOrDefault(c => c.Name == nhomkh && c.DictionaryCategoryId == 3).Id;
                            }
                        }
                        catch { }
                        //ngành nghề
                        try
                        {
                            cel = "N";
                            if (worksheet.Cells[cel + row].Value != null && worksheet.Cells[cel + row].Text != "")
                            {
                                string nganhnghe = worksheet.Cells[cel + row].Text;
                                cus.TENNGANHNGHE = nganhnghe;
                                cus.NGANHNGHE = _dictionaryRepository.GetAllAsQueryable().AsEnumerable().FirstOrDefault(c => c.Name == nganhnghe && c.DictionaryCategoryId == 2).Id;
                            }
                        }
                        catch { }
                        //nhân viên quản lý
                        try
                        {
                            cel = "Q";
                            if (worksheet.Cells[cel + row].Value != null && worksheet.Cells[cel + row].Text != "")
                            {
                                string nhanvien = worksheet.Cells[cel + row].Text;
                                cus.TENNVQL = nhanvien;
                                cus.NVQL = _staffRepository.GetAllAsQueryable().AsEnumerable().FirstOrDefault(c => c.FullName == nhanvien).Id;
                            }
                        }
                        catch { }
                        list.Add(cus);
                    }
                    Session["listOpportunityImport"] = list;
                    return PartialView("_Partial_ImportDataList", list);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<ActionResult> SaveImport()
        {
            try
            {
                List<OpportunityViewModel> list = Session["listOpportunityImport"] as List<OpportunityViewModel>;
                foreach (var item in list)
                {
                    // lưu cơ hội
                    var op = new tbl_Opportunity
                    {
                        Code = GenerateCode.OpportunityCode(),
                        Name = item.TENCOHOI,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        GroupId = item.NHOMCOHOI,
                        FormContactId = item.HINHTHUCTIEPXUC,
                        IsDelete = false,
                        ManagerId = item.NVQL,
                        Note = item.GHICHU,
                        StaffId = clsPermission.GetUser().StaffID,
                        StatusId = item.TINHTRANG,
                        TiemNang = item.TIEMNANG
                    };
                    await _opportunityRepository.Create(op);
                    // lưu khách hàng
                    if (!string.IsNullOrEmpty(item.TENKH))
                    {
                        var checkCus = _customerRepository.GetAllAsQueryable().AsEnumerable()
                            .FirstOrDefault(p => p.Phone == item.DIENTHOAI || p.MobilePhone == item.DIDONG);
                        if (checkCus == null)
                        {
                            // thêm mới khách hàng
                            var cus = new tbl_Customer
                            {
                                FullName = item.TENKH,
                                NameTypeId = item.DANHXUNG,
                                Phone = item.DIENTHOAI,
                                MobilePhone = item.DIDONG,
                                CompanyEmail = item.EMAIL,
                                PersonalEmail = item.EMAIL,
                                Address = item.DIACHI,
                                TagsId = item.TINHTHANH,
                                Code = GenerateCode.CustomerCode(),
                                CustomerType = CustomerType.Personal,
                                CreatedDate = DateTime.Now,
                                ModifiedDate = DateTime.Now,
                                CareerId = item.NGANHNGHE,
                                OriginId = item.NGUONDEN,
                                CustomerGroupId = item.NHOMKH,
                                IsTemp = false,
                                IsDelete = false,
                                IsSendAccount = false,
                                StaffId = clsPermission.GetUser().StaffID,
                                StaffManager = item.NVQL,
                                Note = item.GHICHU
                            };
                            await _customerRepository.Create(cus);
                            // cập nhật khách hàng trong cơ hội
                            var updateOp = _db.tbl_Opportunity.Find(op.Id);
                            updateOp.CustomerId = cus.Id;
                            _db.SaveChanges();
                        }
                        else
                        {
                            // khách hàng cũ
                            var oldCus = _db.tbl_Customer.Find(op.Id);
                            oldCus.FullName = item.TENKH;
                            oldCus.NameTypeId = item.DANHXUNG;
                            oldCus.Phone = item.DIENTHOAI;
                            oldCus.MobilePhone = item.DIDONG;
                            oldCus.CompanyEmail = item.EMAIL;
                            oldCus.PersonalEmail = item.EMAIL;
                            oldCus.Address = item.DIACHI;
                            oldCus.TagsId = item.TINHTHANH;
                            oldCus.Code = GenerateCode.CustomerCode();
                            oldCus.CustomerType = CustomerType.Personal;
                            oldCus.ModifiedDate = DateTime.Now;
                            oldCus.CareerId = item.NGANHNGHE;
                            oldCus.OriginId = item.NGUONDEN;
                            oldCus.CustomerGroupId = item.NHOMKH;
                            oldCus.StaffId = clsPermission.GetUser().StaffID;
                            oldCus.StaffManager = item.NVQL;
                            oldCus.Note = item.GHICHU;
                            // cập nhật khách hàng cho cơ hội
                            var updateOp = _db.tbl_Opportunity.Find(op.Id);
                            updateOp.CustomerId = oldCus.Id;
                            _db.SaveChanges();
                        }
                    }
                }

                Session["listOpportunityImport"] = null;
                UpdateHistory.SaveHistory(1128, "Import danh sách cơ hội");
                return Json(new ActionModel() { Succeed = true, Code = "200", View = "", Message = "Đã import thành công " + list.Count() + " dòng dữ liệu !", IsPartialView = false, RedirectTo = Url.Action("Index", "OpportunityManage") }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                Session["listOpportunityImport"] = null;
                return Json(new ActionModel() { Succeed = false, Code = "200", View = "", Message = "Import dữ liệu lỗi !" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteImport(String listItemId)
        {
            try
            {
                List<OpportunityViewModel> list = Session["listOpportunityImport"] as List<OpportunityViewModel>;
                if (listItemId != null && listItemId != "")
                {
                    var listIds = listItemId.Split(',');
                    listIds = listIds.Take(listIds.Count() - 1).ToArray();
                    if (listIds.Count() > 0)
                    {
                        int[] listIdsint = new int[listIds.Length];
                        for (int i = 0; i < listIds.Length; i++)
                        {
                            listIdsint[i] = Int32.Parse(listIds[i]);
                        }
                        for (int i = 0; i < listIdsint.Length; i++)
                        {
                            for (int j = i; j < listIdsint.Length; j++)
                            {
                                if (listIdsint[i] < listIdsint[j])
                                {
                                    int temp = listIdsint[i];
                                    listIdsint[i] = listIdsint[j];
                                    listIdsint[j] = temp;
                                }
                            }
                        }
                        foreach (var item in listIdsint)
                        {
                            list.RemoveAt(item);
                        }
                    }
                }
                Session["listOpportunityImport"] = list;
                return PartialView("_Partial_ImportDataList", list);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Create Customer

        [ChildActionOnly]
        public ActionResult _Partial_CustomerList()
        {
            return PartialView("_Partial_CustomerList", LoadData.CustomerList());
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> CreateCustomer(CustomerViewModel model, FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1);

                if (form["radioCustomerType"] == "0" && model.SingleCompany.FullName != null) // doanh nghiệp
                {
                    model.SingleCompany.Code = GenerateCode.CustomerCode();
                    model.SingleCompany.CustomerType = CustomerType.Organization;
                    model.SingleCompany.TagsId = form["SingleCompany.TagsId"];
                    model.SingleCompany.CreatedDate = DateTime.Now;
                    model.SingleCompany.ModifiedDate = DateTime.Now;
                    model.SingleCompany.IdentityCard = model.IdentityCard;
                    model.SingleCompany.IdentityTagId = model.IdentityTagId;
                    model.SingleCompany.ParentId = 0;
                    model.SingleCompany.PassportCard = model.PassportCard;
                    model.SingleCompany.PassportTagId = model.PassportTagId;
                    model.SingleCompany.NameTypeId = 47;
                    model.SingleCompany.StaffId = clsPermission.GetUser().StaffID;
                    model.SingleCompany.StaffManager = clsPermission.GetUser().StaffID;
                    if (model.CreatedDateIdentity != null && model.CreatedDateIdentity.Year >= 1980)
                    {
                        model.SingleCompany.CreatedDateIdentity = model.CreatedDateIdentity;
                    }
                    if (model.CreatedDatePassport != null && model.CreatedDatePassport.Year >= 1980)
                    {
                        model.SingleCompany.CreatedDatePassport = model.CreatedDatePassport;
                    }
                    if (model.ExpiredDatePassport != null && model.ExpiredDatePassport.Year >= 1980)
                    {
                        model.SingleCompany.ExpiredDatePassport = model.ExpiredDatePassport;
                    }

                    if (await _customerRepository.Create(model.SingleCompany))
                    {
                        UpdateHistory.SaveHistory(1, "Thêm mới khách hàng doanh nghiệp, code: " + model.SingleCompany.Code + " - " + model.SingleCompany.FullName);

                        for (int i = 1; i < 6; i++)
                        {
                            if (form["VisaNumber" + i] != null && form["VisaNumber" + i] != "")
                            {
                                var visa = new tbl_CustomerVisa
                                {
                                    VisaNumber = form["VisaNumber" + i].ToString(),
                                    TagsId = Convert.ToInt32(form["TagsId" + i].ToString()),
                                    CreatedDate = DateTime.Now,
                                    ModifiedDate = DateTime.Now,
                                    CustomerId = model.SingleCompany.Id,
                                    DictionaryId = 1069,
                                };
                                if (Convert.ToDateTime(form["CreatedDateVisa" + i]).Year >= 1980)
                                {
                                    visa.CreatedDateVisa = Convert.ToDateTime(form["CreatedDateVisa" + i]);
                                }
                                if (Convert.ToDateTime(form["ExpiredDateVisa" + i]).Year >= 1980)
                                {
                                    visa.ExpiredDateVisa = Convert.ToDateTime(form["ExpiredDateVisa" + i]);
                                }
                                if (Convert.ToDateTime(form["CreatedDateVisa" + i]).Year >= 1980 && (Convert.ToDateTime(form["ExpiredDateVisa" + i]).Year >= 1980))
                                {
                                    int age = Convert.ToDateTime(form["ExpiredDateVisa" + i]).Year - Convert.ToDateTime(form["CreatedDateVisa" + i]).Year;
                                    if (Convert.ToDateTime(form["CreatedDateVisa" + i]) > Convert.ToDateTime(form["ExpiredDateVisa" + i]).AddYears(-age)) age--;
                                    visa.Deadline = age;
                                }
                                await _customerVisaRepository.Create(visa);
                            }
                        }
                        var customerList = _db.tbl_Customer.AsEnumerable()
                                        .Where(p => p.IsDelete == false &&
                                        (p.StaffId == clsPermission.GetUser().StaffID || p.StaffManager == clsPermission.GetUser().StaffID)
                                        || p.tbl_Tour.Where(x => (x.Permission != null && x.Permission.Contains(clsPermission.GetUser().StaffID.ToString()))
                                        || x.StaffId == clsPermission.GetUser().StaffID || x.CreateStaffId == clsPermission.GetUser().StaffID).ToList().Count() > 0)
                                        .OrderByDescending(p => p.CreatedDate)
                                        .Select(p => new tbl_Customer
                                        {
                                            Id = p.Id,
                                            FullName = p.FullName,
                                            Code = p.Code
                                        }).ToList();
                        return PartialView("_Partial_CustomerList", customerList);
                    }
                    else
                    {
                        var customerList = _db.tbl_Customer.AsEnumerable()
                                        .Where(p => p.IsDelete == false &&
                                        (p.StaffId == clsPermission.GetUser().StaffID || p.StaffManager == clsPermission.GetUser().StaffID)
                                        || p.tbl_Tour.Where(x => (x.Permission != null && x.Permission.Contains(clsPermission.GetUser().StaffID.ToString()))
                                        || x.StaffId == clsPermission.GetUser().StaffID || x.CreateStaffId == clsPermission.GetUser().StaffID).ToList().Count() > 0)
                                        .OrderByDescending(p => p.CreatedDate)
                                        .Select(p => new tbl_Customer
                                        {
                                            Id = p.Id,
                                            FullName = p.FullName,
                                            Code = p.Code
                                        }).ToList();
                        return PartialView("_Partial_CustomerList", customerList);
                    }
                }
                if (form["radioCustomerType"] == "1" && model.SinglePersonal.FullName != null) // cá nhân
                {
                    // insert other company
                    if (form["OtherCompanyName"] != null && form["OtherCompanyName"] != "")
                    {
                        var other = new tbl_Customer
                        {
                            Address = form["OtherCompanyAddress"],
                            CompanyEmail = form["OtherCompanyEmail"],
                            CreatedDate = DateTime.Now,
                            Director = form["OtherCompanyDirector"],
                            Phone = form["OtherCompanyPhone"],
                            FullName = form["OtherCompanyName"],
                            IsDelete = false,
                            IsTemp = true,
                            ModifiedDate = DateTime.Now,
                            ParentId = 0,
                            StaffId = clsPermission.GetUser().StaffID,
                            StaffManager = clsPermission.GetUser().StaffID,
                            TagsId = form["OtherCompanyTagsId"],
                            SubscribeSMS = true,
                            SubscribeEmail = true,
                            Code = "OTHERCOMPANY",
                            CareerId = Convert.ToInt32(form["OtherCompanyCareerId"]),
                            CustomerType = CustomerType.Organization,
                            NameTypeId = 47,
                            PassportTagId = 11,
                            IdentityTagId = 11
                        };
                        if (await _customerRepository.Create(other))
                        {
                            UpdateHistory.SaveHistory(1, "Thêm công ty mới: " + other.FullName);

                            model.SinglePersonal.OtherCompany = other.FullName;
                            model.SinglePersonal.ParentId = other.Id;
                        }
                    }
                    //
                    model.SinglePersonal.Code = GenerateCode.CustomerCode();
                    model.SinglePersonal.CustomerType = CustomerType.Personal;
                    model.SinglePersonal.TagsId = form["SinglePersonal.TagsId"];
                    model.SinglePersonal.CreatedDate = DateTime.Now;
                    model.SinglePersonal.ModifiedDate = DateTime.Now;
                    model.SinglePersonal.IdentityCard = model.IdentityCard;
                    model.SinglePersonal.IdentityTagId = model.IdentityTagId;
                    model.SinglePersonal.PassportCard = model.PassportCard;
                    model.SinglePersonal.PassportTagId = model.PassportTagId;
                    model.SinglePersonal.StaffId = clsPermission.GetUser().StaffID;
                    model.SinglePersonal.StaffManager = clsPermission.GetUser().StaffID;

                    if (model.CreatedDateIdentity != null && model.CreatedDateIdentity.Year >= 1980)
                    {
                        model.SinglePersonal.CreatedDateIdentity = model.CreatedDateIdentity;
                    }
                    if (model.CreatedDatePassport != null && model.CreatedDatePassport.Year >= 1980)
                    {
                        model.SinglePersonal.CreatedDatePassport = model.CreatedDatePassport;
                    }
                    if (model.ExpiredDatePassport != null && model.ExpiredDatePassport.Year >= 1980)
                    {
                        model.SinglePersonal.ExpiredDatePassport = model.ExpiredDatePassport;
                    }

                    if (await _customerRepository.Create(model.SinglePersonal))
                    {
                        UpdateHistory.SaveHistory(1, "Thêm mới khách hàng cá nhân, code: " + model.SinglePersonal.Code + " - " + model.SinglePersonal.FullName);

                        for (int i = 1; i < 6; i++)
                        {
                            if (form["VisaNumber" + i] != null && form["VisaNumber" + i] != "")
                            {
                                var visa = new tbl_CustomerVisa
                                {
                                    VisaNumber = form["VisaNumber" + i].ToString(),
                                    TagsId = Convert.ToInt32(form["TagsId" + i].ToString()),
                                    CreatedDate = DateTime.Now,
                                    ModifiedDate = DateTime.Now,
                                    CustomerId = model.SinglePersonal.Id,
                                    DictionaryId = 1069
                                };
                                if (Convert.ToDateTime(form["CreatedDateVisa" + i]).Year >= 1980)
                                {
                                    visa.CreatedDateVisa = Convert.ToDateTime(form["CreatedDateVisa" + i]);
                                }
                                if (Convert.ToDateTime(form["ExpiredDateVisa" + i]).Year >= 1980)
                                {
                                    visa.ExpiredDateVisa = Convert.ToDateTime(form["ExpiredDateVisa" + i]);
                                }
                                if (Convert.ToDateTime(form["CreatedDateVisa" + i]).Year >= 1980 && (Convert.ToDateTime(form["ExpiredDateVisa" + i]).Year >= 1980))
                                {
                                    int age = Convert.ToDateTime(form["ExpiredDateVisa" + i]).Year - Convert.ToDateTime(form["CreatedDateVisa" + i]).Year;
                                    if (Convert.ToDateTime(form["CreatedDateVisa" + i]) > Convert.ToDateTime(form["ExpiredDateVisa" + i]).AddYears(-age)) age--;
                                    visa.Deadline = age;
                                }
                                await _customerVisaRepository.Create(visa);
                            }
                        }

                        var customerList = _db.tbl_Customer.AsEnumerable()
                                        .Where(p => p.IsDelete == false &&
                                        (p.StaffId == clsPermission.GetUser().StaffID || p.StaffManager == clsPermission.GetUser().StaffID)
                                        || p.tbl_Tour.Where(x => (x.Permission != null && x.Permission.Contains(clsPermission.GetUser().StaffID.ToString()))
                                        || x.StaffId == clsPermission.GetUser().StaffID || x.CreateStaffId == clsPermission.GetUser().StaffID).ToList().Count() > 0)
                                        .OrderByDescending(p => p.CreatedDate)
                                        .Select(p => new tbl_Customer
                                        {
                                            Id = p.Id,
                                            FullName = p.FullName,
                                            Code = p.Code
                                        }).ToList();
                        return PartialView("_Partial_CustomerList", customerList);
                    }
                    else
                    {
                        var customerList = _db.tbl_Customer.AsEnumerable()
                                        .Where(p => p.IsDelete == false &&
                                        (p.StaffId == clsPermission.GetUser().StaffID || p.StaffManager == clsPermission.GetUser().StaffID)
                                        || p.tbl_Tour.Where(x => (x.Permission != null && x.Permission.Contains(clsPermission.GetUser().StaffID.ToString()))
                                        || x.StaffId == clsPermission.GetUser().StaffID || x.CreateStaffId == clsPermission.GetUser().StaffID).ToList().Count() > 0)
                                        .OrderByDescending(p => p.CreatedDate)
                                        .Select(p => new tbl_Customer
                                        {
                                            Id = p.Id,
                                            FullName = p.FullName,
                                            Code = p.Code
                                        }).ToList();
                        return PartialView("_Partial_CustomerList", customerList);
                    }
                }
            }
            catch
            {

            }
            var cusList = _db.tbl_Customer.AsEnumerable()
                                        .Where(p => p.IsDelete == false &&
                                        (p.StaffId == clsPermission.GetUser().StaffID || p.StaffManager == clsPermission.GetUser().StaffID)
                                        || p.tbl_Tour.Where(x => (x.Permission != null && x.Permission.Contains(clsPermission.GetUser().StaffID.ToString()))
                                        || x.StaffId == clsPermission.GetUser().StaffID || x.CreateStaffId == clsPermission.GetUser().StaffID).ToList().Count() > 0)
                                        .OrderByDescending(p => p.CreatedDate)
                                        .Select(p => new tbl_Customer
                                        {
                                            Id = p.Id,
                                            FullName = p.FullName,
                                            Code = p.Code
                                        }).ToList();
            return PartialView("_Partial_CustomerList", cusList);
        }
        #endregion
    }
}