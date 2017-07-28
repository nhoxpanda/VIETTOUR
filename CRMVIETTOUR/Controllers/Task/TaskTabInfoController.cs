﻿using CRM.Core;
using CRM.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CRMVIETTOUR.Utilities;

namespace CRMVIETTOUR.Controllers.Task
{
    [Authorize]
    public class TaskTabInfoController : BaseController
    {
        //
        // GET: /TaskTabInfo/
        #region Init

        private IGenericRepository<tbl_Staff> _staffRepository;
        private IGenericRepository<tbl_Customer> _customerRepository;
        private IGenericRepository<tbl_Partner> _partnerRepository;
        private IGenericRepository<tbl_Tags> _tagsRepository;
        private IGenericRepository<tbl_CustomerContact> _customerContactRepository;
        private IGenericRepository<tbl_StaffVisa> _staffVisaRepository;
        private IGenericRepository<tbl_Task> _taskRepository;

        private IGenericRepository<tbl_Dictionary> _dictionaryRepository;
        private IGenericRepository<tbl_DocumentFile> _documentFileRepository;
        private IGenericRepository<tbl_UpdateHistory> _updateHistoryRepository;
        private IGenericRepository<tbl_ContactHistory> _contactHistoryRepository;
        private IGenericRepository<tbl_AppointmentHistory> _appointmentHistoryRepository;
        private IGenericRepository<tbl_TaskStaff> _taskStaffRepository;
        private IGenericRepository<tbl_TaskHandling> _taskHandlingRepository;
        private IGenericRepository<tbl_TaskNote> _taskNoteRepository;
        private DataContext _db;

        public TaskTabInfoController(
            IGenericRepository<tbl_Staff> staffRepository,
            IGenericRepository<tbl_Partner> partnerRepository,
            IGenericRepository<tbl_Customer> customerRepository,
            IGenericRepository<tbl_Tags> tagsRepository,
            IGenericRepository<tbl_CustomerContact> customerContactRepository,
            IGenericRepository<tbl_StaffVisa> customerVisaRepository,

            IGenericRepository<tbl_Dictionary> dictionaryRepository,
            IGenericRepository<tbl_Task> taskRepository,
            IGenericRepository<tbl_DocumentFile> documentFileRepository,
            IGenericRepository<tbl_UpdateHistory> updateHistoryRepository,
            IGenericRepository<tbl_ContactHistory> contactHistoryRepository,
            IGenericRepository<tbl_AppointmentHistory> appointmentHistoryRepository,
            IGenericRepository<tbl_TaskStaff> taskStaffRepository,
            IGenericRepository<tbl_TaskHandling> taskHandlingRepository,
            IGenericRepository<tbl_TaskNote> taskNoteRepository,
            IBaseRepository baseRepository)
            : base(baseRepository)
        {
            this._staffRepository = staffRepository;
            this._partnerRepository = partnerRepository;
            this._customerRepository = customerRepository;
            this._customerContactRepository = customerContactRepository;
            this._tagsRepository = tagsRepository;
            this._staffVisaRepository = customerVisaRepository;
            this._taskRepository = taskRepository;

            this._dictionaryRepository = dictionaryRepository;
            this._documentFileRepository = documentFileRepository;
            this._contactHistoryRepository = contactHistoryRepository;
            this._appointmentHistoryRepository = appointmentHistoryRepository;
            this._updateHistoryRepository = updateHistoryRepository;
            this._taskStaffRepository = taskStaffRepository;
            this._taskHandlingRepository = taskHandlingRepository;
            this._taskNoteRepository = taskNoteRepository;
            _db = new DataContext();
        }
        #endregion
        void Permission(int PermissionsId, int formId)
        {
            var list = _db.tbl_ActionData.Where(p => p.FormId == formId && p.PermissionsId == PermissionsId).Select(p => p.FunctionId).ToList();
            ViewBag.IsAdd = list.Contains(1);
            ViewBag.IsDelete = list.Contains(2);
            ViewBag.IsEdit = list.Contains(3);
            ViewBag.IsImport = list.Contains(4);
            ViewBag.IsExport = list.Contains(5);
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
            var model = _taskRepository.GetAllAsQueryable().AsEnumerable().Where(p => p.Id == id).Select(p => new tbl_Task
            {
                Name = p.Name,
                Code = p.Code,
                CreatedDate = p.CreatedDate,
                ModifiedDate = p.ModifiedDate,
                PercentFinish = p.PercentFinish != null ? p.PercentFinish : 0,
                tbl_DictionaryTaskType = _dictionaryRepository.FindId(p.TaskTypeId),
                tbl_DictionaryTaskPriority = _dictionaryRepository.FindId(p.TaskPriorityId),
                tbl_DictionaryTaskStatus = _dictionaryRepository.FindId(p.TaskStatusId),
                CodeTour = p.CodeTour,
                Email = p.Email,
                Phone = p.Phone,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Time = p.Time

            }).SingleOrDefault();
            return PartialView("_ThongTinChiTiet", model);
        }
        #endregion

        #region NhatKyXuLy
        [ChildActionOnly]
        public ActionResult _NhatKyXuLy()
        {
            return PartialView("_NhatKyXuLy");
        }
        [HttpPost]
        public async Task<ActionResult> InfoNhatKyXuLy(int id)
        {
            var model = _taskHandlingRepository.GetAllAsQueryable().AsEnumerable().Where(p => p.TaskId == id).Where(p => p.IsDelete == false).Select(p => new tbl_TaskHandling
            {
                Id = p.Id,
                CreateDate = p.CreateDate,
                Note = p.Note,
                File = p.File,
                PercentFinish = p.PercentFinish,
                tbl_Staff = _staffRepository.FindId(p.StaffId),
                tbl_Dictionary = _dictionaryRepository.FindId(p.StatusId)
            }).ToList();
            return PartialView("_NhatKyXuLy", model);
        }
        #endregion

        #region LichHen
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
            Permission(clsPermission.GetUser().PermissionID, 73);
            var model = _appointmentHistoryRepository.GetAllAsQueryable().AsEnumerable().Where(p => p.IsDelete == false).Where(p => p.TaskId == id)
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
                    StaffId = p.StaffId
                }).ToList();
            return PartialView("_LichHen", model);
        }
        #endregion

        #region DSNhanVienDangLamNhiemVu
        [ChildActionOnly]
        public ActionResult _DSNhanVienDangLamNhiemVu()
        {
            return PartialView("_DSNhanVienDangLamNhiemVu");
        }
        [HttpPost]
        public async Task<ActionResult> InfoDSNhanVienDangLamNhiemVu(int id)
        {
            var model = _taskStaffRepository.GetAllAsQueryable().Where(p => p.TaskId == id && p.IsDelete == false).ToList();
            return PartialView("_DSNhanVienDangLamNhiemVu", model);
        }
        #endregion

        #region TaiLieuMau
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
            Permission(clsPermission.GetUser().PermissionID, 74);
            var model = _documentFileRepository.GetAllAsQueryable().Where(p => p.TaskId == id && p.IsDelete == false).ToList();
            return PartialView("_TaiLieuMau", model);
        }
        #endregion

        #region GhiChu
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
            Permission(clsPermission.GetUser().PermissionID, 75);
            var model = _taskNoteRepository.GetAllAsQueryable().AsEnumerable().Where(p => p.TaskId == id).Where(p => p.IsDelete == false).Select(p => new tbl_TaskNote
            {
                Id = p.Id,
                Note = p.Note,
                tbl_Staff = _staffRepository.FindId(p.StaffId),
                CreatedDate = p.CreatedDate
            }).ToList();
            return PartialView("_GhiChu", model);
        }
        #endregion
    }
}