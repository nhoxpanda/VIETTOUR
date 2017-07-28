using CRM.Core;
using CRM.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CRMVIETTOUR.Models;
using CRMVIETTOUR.Utilities;
using CRMVIETTOUR.Controllers;

namespace CRMVIETTOUR.Controllers.Opportunity
{
    public class OpportunityTabInfoController : BaseController
    {
        // GET: OpportunityTabInfo
        #region Init

        private IGenericRepository<tbl_Staff> _staffRepository;
        private IGenericRepository<tbl_Customer> _customerRepository;
        private IGenericRepository<tbl_Dictionary> _dictionaryRepository;
        private IGenericRepository<tbl_Opportunity> _opportunityRepository;
        private IGenericRepository<tbl_OpportunityTransaction> _opportunityTransactionRepository;
        private IGenericRepository<tbl_OpportunityRequest> _opportunityRequestRepository;
        private IGenericRepository<tbl_AppointmentHistory> _appointmentHistoryRepository;
        private IGenericRepository<tbl_DocumentFile> _documentFileRepository;
        private IGenericRepository<tbl_ContactHistory> _contactHistoryRepository;
        private IGenericRepository<tbl_CustomerContact> _customerContactRepository;
        private IGenericRepository<tbl_Competitor> _competitorRepository;
        private IGenericRepository<tbl_UpdateHistory> _updateHistoryRepository;
        private DataContext _db;

        public OpportunityTabInfoController(
            IGenericRepository<tbl_Staff> staffRepository,
            IGenericRepository<tbl_Customer> customerRepository,
            IGenericRepository<tbl_Opportunity> opportunityRepository,
            IGenericRepository<tbl_OpportunityTransaction> opportunityTransactionRepository,
            IGenericRepository<tbl_OpportunityRequest> opportunityRequestRepository,
            IGenericRepository<tbl_AppointmentHistory> appointmentHistoryRepository,
            IGenericRepository<tbl_DocumentFile> documentFileRepository,
            IGenericRepository<tbl_ContactHistory> contactHistoryRepository,
            IGenericRepository<tbl_CustomerContact> customerContactRepository,
            IGenericRepository<tbl_Competitor> competitorRepository,
            IGenericRepository<tbl_UpdateHistory> updateHistoryRepository,
            IGenericRepository<tbl_Dictionary> dictionaryRepository,
            IBaseRepository baseRepository)
            : base(baseRepository)
        {
            this._customerRepository = customerRepository;
            this._staffRepository = staffRepository;
            this._opportunityRepository = opportunityRepository;
            this._opportunityRequestRepository = opportunityRequestRepository;
            this._opportunityTransactionRepository = opportunityTransactionRepository;
            this._appointmentHistoryRepository = appointmentHistoryRepository;
            this._documentFileRepository = documentFileRepository;
            this._contactHistoryRepository = contactHistoryRepository;
            this._customerContactRepository = customerContactRepository;
            this._competitorRepository = competitorRepository;
            this._updateHistoryRepository = updateHistoryRepository;
            this._dictionaryRepository = dictionaryRepository;
            _db = new DataContext();
        }
        #endregion

        #region Phân quyền
        void Permission(int PermissionsId, int formId)
        {
            var list = _db.tbl_ActionData.Where(p => p.FormId == formId && p.PermissionsId == PermissionsId).Select(p => p.FunctionId).ToList();
            ViewBag.IsAdd = list.Contains(1);
            ViewBag.IsDelete = list.Contains(2);
            ViewBag.IsEdit = list.Contains(3);
        }
        #endregion

        #region Thông tin chi tiết
        [ChildActionOnly]
        public ActionResult _ThongTinChiTiet()
        {
            return PartialView("_ThongTinChiTiet");
        }

        [HttpPost]
        public async Task<ActionResult> InfoThongTinChiTiet(int id)
        {
            Permission(clsPermission.GetUser().PermissionID, 1128);
            var model = await _opportunityRepository.GetById(id);
            return PartialView("_ThongTinChiTiet", model);
        }
        #endregion

        #region Nhật ký xử lý
        [ChildActionOnly]
        public ActionResult _NhatKyXuLy()
        {
            return PartialView("_NhatKyXuLy");
        }

        [HttpPost]
        public ActionResult InfoNhatKyXuLy(int id)
        {
            Permission(clsPermission.GetUser().PermissionID, 1132);
            var model = _updateHistoryRepository.GetAllAsQueryable().AsEnumerable()
                .Where(p => (p.OpportunityId == id || p.Note.Contains(_opportunityRepository.FindId(id).Code)) && p.IsDelete == false)
                .OrderByDescending(p => p.CreatedDate)
                .Select(p => new tbl_UpdateHistory
                {
                    Id = p.Id,
                    tbl_Dictionary = _dictionaryRepository.FindId(p.DictionaryId),
                    tbl_Staff = _staffRepository.FindId(p.StaffId),
                    CreatedDate = p.CreatedDate,
                    Note = p.Note
                }).ToList();
            return PartialView("_NhatKyXuLy", model);
        }
        #endregion

        #region Lịch hẹn
        [ChildActionOnly]
        public ActionResult _LichHen()
        {
            ViewBag.IsAdd = false;
            ViewBag.IsDelete = false;
            ViewBag.IsEdit = false;
            return PartialView("_LichHen");
        }

        [HttpPost]
        public ActionResult InfoLichHen(int id)
        {
            Permission(clsPermission.GetUser().PermissionID, 1133);
            var model = _appointmentHistoryRepository.GetAllAsQueryable().AsEnumerable()
                .Where(p => p.OpportunityId == id && p.IsDelete == false).Select(p => new tbl_AppointmentHistory
            {
                Id = p.Id,
                Time = p.Time,
                Title = p.Title,
                Note = p.Note,
                StatusId = p.StatusId,
                tbl_DictionaryStatus = _dictionaryRepository.FindId(p.DictionaryId),
                tbl_Staff = _staffRepository.FindId(p.StaffId),
                OtherStaff = p.OtherStaff,
                StaffId = p.StaffId
            }).ToList();
            return PartialView("_LichHen", model);
        }
        #endregion

        #region Người liên hệ
        [ChildActionOnly]
        public ActionResult _NguoiLienHe()
        {
            ViewBag.IsAdd = false;
            ViewBag.IsDelete = false;
            ViewBag.IsEdit = false;
            return PartialView("_NguoiLienHe");
        }

        [HttpPost]
        public ActionResult InfoNguoiLienHe(int id)
        {
            Permission(clsPermission.GetUser().PermissionID, 1134);
            int cusId = _opportunityRepository.FindId(id).CustomerId ?? 0;
            var model = _customerContactRepository.GetAllAsQueryable().AsEnumerable()
                .Where(p => p.CustomerId == cusId && p.IsDelete == false)
                .Select(p => new tbl_CustomerContact
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    Position = p.Position,
                    Mobile = p.Mobile,
                    Address = p.Address,
                    Email = p.Email,
                    TagsId = p.TagsId
                }).ToList();
            return PartialView("_NguoiLienHe", model);
        }
        #endregion

        #region Đối thủ cạnh tranh
        [ChildActionOnly]
        public ActionResult _DoiThu()
        {
            ViewBag.IsAdd = false;
            ViewBag.IsDelete = false;
            ViewBag.IsEdit = false;
            return PartialView("_DoiThu");
        }

        [HttpPost]
        public ActionResult InfoDoiThu(int id)
        {
            Permission(clsPermission.GetUser().PermissionID, 1135);
            var model = _competitorRepository.GetAllAsQueryable().AsEnumerable()
                .Where(p => p.OpportunityId == id && p.IsDelete == false).ToList();
            return PartialView("_DoiThu", model);
        }
        #endregion

        #region Nhật ký giao dịch
        [ChildActionOnly]
        public ActionResult _NhatKyGiaoDich()
        {
            ViewBag.IsAdd = false;
            ViewBag.IsDelete = false;
            ViewBag.IsEdit = false;
            return PartialView("_NhatKyGiaoDich");
        }

        [HttpPost]
        public ActionResult InfoNhatKyGiaoDich(int id)
        {
            Permission(clsPermission.GetUser().PermissionID, 1137);
            var model = _opportunityTransactionRepository.GetAllAsQueryable().AsEnumerable()
                              .Where(p => p.OpportunityId == id && p.IsDelete == false).ToList();
            return PartialView("_NhatKyGiaoDich", model);
        }
        #endregion

        #region Tài liệu mẫu
        [ChildActionOnly]
        public ActionResult _TaiLieuMau()
        {
            ViewBag.IsAdd = false;
            ViewBag.IsDelete = false;
            ViewBag.IsEdit = false;
            return PartialView("_TaiLieuMau");
        }

        [HttpPost]
        public ActionResult InfoTaiLieuMau(int id)
        {
            int cusId = _opportunityRepository.FindId(id).CustomerId ?? 0;
            Permission(clsPermission.GetUser().PermissionID, 1138);
            var model = _documentFileRepository.GetAllAsQueryable().AsEnumerable()
                              .Where(p => (p.OpportunityId == id || p.CustomerId == cusId) && p.IsDelete == false)
                              .Select(p => new tbl_DocumentFile
                              {
                                  Id = p.Id,
                                  FileName = p.FileName,
                                  FileSize = p.FileSize,
                                  Note = p.Note,
                                  CreatedDate = p.CreatedDate,
                                  TagsId = p.TagsId,
                                  tbl_Staff = _staffRepository.FindId(p.StaffId)
                              }).ToList();
            return PartialView("_TaiLieuMau", model);
        }
        #endregion

        #region Yêu cầu phản hồi

        [ChildActionOnly]
        public ActionResult _YeuCauPhanHoi()
        {
            ViewBag.IsAdd = false;
            ViewBag.IsDelete = false;
            ViewBag.IsEdit = false;
            return PartialView("_YeuCauPhanHoi");
        }

        [HttpPost]
        public ActionResult InfoYeuCauPhanHoi(int id)
        {
            Permission(clsPermission.GetUser().PermissionID, 1136);
            var model = _opportunityRequestRepository.GetAllAsQueryable().AsEnumerable()
                              .Where(p => p.OpportunityId == id && p.IsDelete == false).ToList();
            return PartialView("_YeuCauPhanHoi", model);
        }
        #endregion

        #region Lịch sử liên hệ
        [ChildActionOnly]
        public ActionResult _LichSuLienHe()
        {
            ViewBag.IsAdd = false;
            ViewBag.IsDelete = false;
            ViewBag.IsEdit = false;
            return PartialView("_LichSuLienHe");
        }

        [HttpPost]
        public ActionResult InfoLichSuLienHe(int id)
        {
            Permission(clsPermission.GetUser().PermissionID, 1140);
            var model = _contactHistoryRepository.GetAllAsQueryable().AsEnumerable()
                        .Where(p => p.Opportunity == id && p.IsDelete == false).OrderByDescending(p => p.CreatedDate)
                       .Select(p => new tbl_ContactHistory
                       {
                           Id = p.Id,
                           ContactDate = p.ContactDate,
                           Request = p.Request,
                           Note = p.Note,
                           tbl_Staff = _staffRepository.FindId(p.StaffId),
                           tbl_Dictionary = _dictionaryRepository.FindId(p.DictionaryId),
                           StaffId = p.StaffId,
                           DictionaryId = p.DictionaryId,
                           OtherStaffId = p.OtherStaffId,
                           tbl_StaffOther = _staffRepository.FindId(p.OtherStaffId)
                       }).ToList();
            return PartialView("_LichSuLienHe", model);
        }
        #endregion
    }
}