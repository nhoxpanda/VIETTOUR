﻿using CRM.Core;
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

namespace CRMVIETTOUR.Controllers.Partner
{
    [Authorize]
    public class PartnerTabInfoController : BaseController
    {
        // GET: PartnerTabInfo

        #region Init

        private IGenericRepository<tbl_Staff> _staffRepository;
        private IGenericRepository<tbl_Partner> _partnerRepository;
        private IGenericRepository<tbl_Tags> _tagsRepository;
        private IGenericRepository<tbl_PartnerNote> _partnerNoteRepository;
        private IGenericRepository<tbl_Dictionary> _dictionaryRepository;
        private IGenericRepository<tbl_DocumentFile> _documentFileRepository;
        private IGenericRepository<tbl_UpdateHistory> _updateHistoryRepository;
        private IGenericRepository<tbl_ContactHistory> _contactHistoryRepository;
        private IGenericRepository<tbl_AppointmentHistory> _appointmentHistoryRepository;
        private IGenericRepository<tbl_ServicesPartner> _servicesPartnerHistoryRepository;
        private IGenericRepository<tbl_Tour> _tourRepository;
        private IGenericRepository<tbl_TourOption> _tourOptionRepository;
        private IGenericRepository<tbl_LiabilityCustomer> _liabilityCustomerRepository;
        private IGenericRepository<tbl_LiabilityPartner> _liabilityPartnerRepository;
        private DataContext _db;

        public PartnerTabInfoController(
            IGenericRepository<tbl_Staff> staffRepository,
            IGenericRepository<tbl_Partner> partnerRepository,
            IGenericRepository<tbl_Tags> tagsRepository,
            IGenericRepository<tbl_Dictionary> dictionaryRepository,
            IGenericRepository<tbl_Task> taskRepository,
            IGenericRepository<tbl_DocumentFile> documentFileRepository,
            IGenericRepository<tbl_UpdateHistory> updateHistoryRepository,
            IGenericRepository<tbl_ContactHistory> contactHistoryRepository,
            IGenericRepository<tbl_AppointmentHistory> appointmentHistoryRepository,
            IGenericRepository<tbl_ServicesPartner> servicesPartnerHistoryRepository,
            IGenericRepository<tbl_PartnerNote> partnerNoteRepository,
            IGenericRepository<tbl_Tour> tourRepository,
            IGenericRepository<tbl_TourOption> tourOptionRepository,
            IGenericRepository<tbl_LiabilityCustomer> liabilityCustomerRepository,
            IGenericRepository<tbl_LiabilityPartner> liabilityPartnerRepository,
            IBaseRepository baseRepository)
            : base(baseRepository)
        {
            this._staffRepository = staffRepository;
            this._partnerRepository = partnerRepository;
            this._tagsRepository = tagsRepository;
            this._partnerNoteRepository = partnerNoteRepository;
            this._dictionaryRepository = dictionaryRepository;
            this._documentFileRepository = documentFileRepository;
            this._contactHistoryRepository = contactHistoryRepository;
            this._appointmentHistoryRepository = appointmentHistoryRepository;
            this._updateHistoryRepository = updateHistoryRepository;
            this._servicesPartnerHistoryRepository = servicesPartnerHistoryRepository;
            this._tourRepository = tourRepository;
            this._tourOptionRepository = tourOptionRepository;
            this._liabilityCustomerRepository = liabilityCustomerRepository;
            this._liabilityPartnerRepository = liabilityPartnerRepository;
            _db = new DataContext();
        }
        #endregion
        void Permission(int PermissionsId, int formId)
        {
            var list = _db.tbl_ActionData.Where(p => p.FormId == formId && p.PermissionsId == PermissionsId).Select(p => p.FunctionId).ToList();
            ViewBag.IsAdd = list.Contains(1);
            ViewBag.IsDelete = list.Contains(2);
            ViewBag.IsEdit = list.Contains(3);
        }
        #region ThongTinChiTiet
        [ChildActionOnly]
        public ActionResult _ThongTinChiTiet()
        {
            return PartialView("_ThongTinChiTiet");
        }

        [HttpPost]
        public async Task<ActionResult> InfoThongTinChiTiet(int id)
        {
            var model = await _partnerRepository.GetById(id);
            return PartialView("_ThongTinChiTiet", model);
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
        public async Task<ActionResult> InfoLichHen(int id)
        {
            Permission(clsPermission.GetUser().PermissionID, 63);
            //var model = await _appointmentHistoryRepository.GetAllAsQueryable().Where(p => p.PartnerId == id).ToListAsync();
            var model = _appointmentHistoryRepository.GetAllAsQueryable().AsEnumerable().Where(p => p.PartnerId == id && p.IsDelete == false)
                            .Select(p => new tbl_AppointmentHistory
                            {
                                Id = p.Id,
                                Title = p.Title,
                                Time = p.Time,
                                StatusId = p.StatusId,
                                tbl_DictionaryStatus = _dictionaryRepository.FindId(p.StatusId),
                                tbl_Staff = _staffRepository.FindId(p.StaffId),
                                Note = p.Note,
                                OtherStaff = p.OtherStaff,
                                TourId = p.TourId,
                                tbl_Tour = _tourRepository.FindId(p.TourId),
                                StaffId = p.StaffId
                            }).ToList();
            return PartialView("_LichHen", model);
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
        public async Task<ActionResult> InfoLichSuLienHe(int id)
        {
            Permission(clsPermission.GetUser().PermissionID, 64);
            //var model = await _contactHistoryRepository.GetAllAsQueryable().Where(p => p.PartnerId == id).ToListAsync();
            var model = _db.tbl_ContactHistory.AsEnumerable().Where(p => p.PartnerId == id && p.IsDelete == false)
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

        #region Thầu/tour
        [ChildActionOnly]
        public ActionResult _TourTuyen()
        {
            return PartialView("_TourTuyen");
        }

        [HttpPost]
        public async Task<ActionResult> InfoTourTuyen(int id)
        {
            var model = _tourOptionRepository.GetAllAsQueryable().Where(c => c.PartnerId == id && c.IsDelete == false)
                .Select(p => new TourListViewModel
                {
                    Id = p.tbl_Tour.Id,
                    Code = p.tbl_Tour.Code,
                    Name = p.tbl_Tour.Name,
                    NumberCustomer = p.tbl_Tour.NumberCustomer ?? 0,
                    StartDate = p.tbl_Tour.StartDate,
                    EndDate = p.tbl_Tour.EndDate,
                    NumberDay = p.tbl_Tour.NumberDay ?? 0,
                    TourType = p.tbl_Tour.tbl_DictionaryTypeTour.Name,
                    Status = p.tbl_Tour.tbl_DictionaryStatus.Name,
                }).ToList();
            foreach (var item in model)
            {
                item.CongNoDoiTac = _liabilityPartnerRepository.GetAllAsQueryable().Where(c => c.TourId == item.Id && c.IsDelete == false).Sum(c => c.ServicePrice) ?? 0;
                item.CongNoKhachHang = _liabilityCustomerRepository.GetAllAsQueryable().Where(c => c.TourId == item.Id && c.IsDelete == false).Sum(c => c.TotalContract) ?? 0;
            }
            return PartialView("_TourTuyen", model);
        }
        #endregion

        #region Đánh giá
        [ChildActionOnly]
        public ActionResult _DanhGia()
        {
            return PartialView("_DanhGia");
        }

        [HttpPost]
        public ActionResult InfoDanhGia()
        {
            return PartialView("_DanhGia");
        }
        #endregion

        #region Dịch vụ cung cấp
        [ChildActionOnly]
        public ActionResult _DichVuCungCap()
        {
            return PartialView("_DichVuCungCap");
        }

        [HttpPost]
        public async Task<ActionResult> InfoDichVuCungCap(int id)
        {
            var model = await _servicesPartnerHistoryRepository.GetAllAsQueryable().Where(p => p.PartnerId == id && p.IsDelete == false).ToListAsync();
            return PartialView("_DichVuCungCap", model);
        }
        #endregion

        #region Ghi chú
        [ChildActionOnly]
        public ActionResult _GhiChu()
        {
            ViewBag.IsAdd = false;
            ViewBag.IsDelete = false;
            ViewBag.IsEdit = false;
            return PartialView("_GhiChu");
        }

        [HttpPost]
        public async Task<ActionResult> InfoGhiChu(int id)
        {
            Permission(clsPermission.GetUser().PermissionID, 65);
            var model = _db.tbl_PartnerNote.AsEnumerable().Where(p => p.PartnerId == id).Where(p => p.IsDelete == false).ToList();
            return PartialView("_GhiChu", model);
        }
        #endregion

        #region Invoice
        [ChildActionOnly]
        public ActionResult _Invoice()
        {
            return PartialView("_Invoice");
        }

        [HttpPost]
        public async Task<ActionResult> InfoInvoice()
        {
            return PartialView("_Invoice");
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
        public async Task<ActionResult> InfoTaiLieuMau(int id)
        {
            Permission(clsPermission.GetUser().PermissionID, 62);
            // var model = await _documentFileRepository.GetAllAsQueryable().Where(p => p.PartnerId == id).ToListAsync();
            var model = _db.tbl_DocumentFile.AsEnumerable().Where(p => p.PartnerId == id && p.IsDelete == false)
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
    }
}