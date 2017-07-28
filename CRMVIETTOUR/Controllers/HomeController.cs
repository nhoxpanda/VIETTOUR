﻿using CRM.Core;
using CRM.Enum;
using CRM.Infrastructure;
using CRMVIETTOUR.Models;
using CRMVIETTOUR.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CRMVIETTOUR.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {

        #region Init

        private IGenericRepository<tbl_DocumentFile> _documentFileRepository;
        private IGenericRepository<tbl_Dictionary> _dictionaryRepository;
        private IGenericRepository<tbl_Tags> _tagsRepository;
        private IGenericRepository<tbl_Customer> _customerRepository;
        private IGenericRepository<tbl_Staff> _staffRepository;
        private IGenericRepository<tbl_Tour> _tourRepository;
        private IGenericRepository<tbl_CustomerContact> _customerContactRepository;
        private IGenericRepository<tbl_CustomerContactVisa> _customerContactVisaRepository;
        private IGenericRepository<tbl_CustomerVisa> _customerVisaRepository;
        private IGenericRepository<tbl_StaffVisa> _staffVisaRepository;
        private IGenericRepository<tbl_AppointmentHistory> _appointmentHistoryRepository;
        private IGenericRepository<tbl_TourGuide> _tourGuideRepository;
        private IGenericRepository<tbl_TourSchedule> _tourScheduleRepository;
        private IGenericRepository<tbl_Task> _taskRepository;
        private IGenericRepository<tbl_VisaInfomation> _visaInfomationRepository;
        private DataContext _db;

        public HomeController(IGenericRepository<tbl_DocumentFile> documentFileRepository,
            IGenericRepository<tbl_Dictionary> dictionaryRepository,
            IGenericRepository<tbl_Tags> tagsRepository,
            IGenericRepository<tbl_Customer> customerRepository,
            IGenericRepository<tbl_Staff> staffRepository,
            IGenericRepository<tbl_Tour> tourRepository,
            IGenericRepository<tbl_CustomerContact> customerContactRepository,
            IGenericRepository<tbl_CustomerContactVisa> customerContactVisaRepository,
            IGenericRepository<tbl_CustomerVisa> customerVisaRepository,
            IGenericRepository<tbl_StaffVisa> staffVisaRepository,
            IGenericRepository<tbl_AppointmentHistory> appointmentHistoryRepository,
            IGenericRepository<tbl_TourGuide> tourGuideRepository,
            IGenericRepository<tbl_TourSchedule> tourScheduleRepository,
            IGenericRepository<tbl_Task> taskRepository,
            IGenericRepository<tbl_VisaInfomation> visaInfomationRepository,
            IBaseRepository baseRepository)
            : base(baseRepository)
        {
            this._documentFileRepository = documentFileRepository;
            this._dictionaryRepository = dictionaryRepository;
            this._tagsRepository = tagsRepository;
            this._customerRepository = customerRepository;
            this._staffRepository = staffRepository;
            this._tourRepository = tourRepository;
            this._customerContactRepository = customerContactRepository;
            this._customerContactVisaRepository = customerContactVisaRepository;
            this._customerVisaRepository = customerVisaRepository;
            this._staffVisaRepository = staffVisaRepository;
            this._appointmentHistoryRepository = appointmentHistoryRepository;
            this._tourGuideRepository = tourGuideRepository;
            this._tourScheduleRepository = tourScheduleRepository;
            this._taskRepository = taskRepository;
            this._visaInfomationRepository = visaInfomationRepository;
            _db = new DataContext();
        }

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMessages()
        {
            MessagesRepository _messageRepository = new MessagesRepository();
            return PartialView("_Partial_MessagesList", _messageRepository.GetAllMessages());
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }

        #region Load Lịch hẹn
        [ChildActionOnly]
        public ActionResult _Partial_Appointment()
        {
            var model = new AppointmentViewModel();
            model.TodayList = _appointmentHistoryRepository.GetAllAsQueryable().AsEnumerable()
                                .Where(p => p.IsDelete == false && p.Time != null
                                    && (p.Time.ToString("dd-MM-yyyy") == DateTime.Now.ToString("dd-MM-yyyy"))
                                    && (p.StaffId == clsPermission.GetUser().StaffID
                                    || (p.OtherStaff != null
                                    && p.OtherStaff.Contains(clsPermission.GetUser().StaffID.ToString()))))
                                    .OrderByDescending(p => p.Time)
                                    .Select(p => new SingleAppoinment()
                                    {
                                        Id = p.Id,
                                        Time = p.Time,
                                        Title = p.Title
                                    }).ToList();
            model.TomorrowList = _appointmentHistoryRepository.GetAllAsQueryable().AsEnumerable()
                                 .Where(p => p.IsDelete == false && p.Time != null
                                     && (p.Time.ToString("dd-MM-yyyy") == DateTime.Now.AddDays(1).ToString("dd-MM-yyyy"))
                                     && (p.StaffId == clsPermission.GetUser().StaffID
                                     || (p.OtherStaff != null
                                     && p.OtherStaff.Contains(clsPermission.GetUser().StaffID.ToString()))))
                                     .OrderByDescending(p => p.Time)
                                     .Select(p => new SingleAppoinment()
                                     {
                                         Id = p.Id,
                                         Time = p.Time,
                                         Title = p.Title
                                     }).ToList();
            return PartialView("_Partial_Appointment", model);
        }
        #endregion

        #region Load nhiệm vụ
        [ChildActionOnly]
        public ActionResult _Partial_Task()
        {
            var model = new TaskViewModel();

            model.TodayList = _taskRepository.GetAllAsQueryable().AsEnumerable()
                                .Where(p => ((p.StaffId == clsPermission.GetUser().StaffID) || p.Permission.Contains(clsPermission.GetUser().StaffID.ToString()))
                                        && p.IsDelete == false && p.StartDate != null
                                        && (p.StartDate.Value.ToString("dd-MM-yyyy") == DateTime.Now.ToString("dd-MM-yyyy")))
                                    .OrderByDescending(p => p.StartDate)
                                    .Select(p => new SingleTask()
                                    {
                                        Id = p.Id,
                                        Time = p.StartDate ?? DateTime.Now,
                                        Title = p.Name
                                    }).ToList();
            model.TomorrowList = _taskRepository.GetAllAsQueryable().AsEnumerable()
                                .Where(p => ((p.StaffId == clsPermission.GetUser().StaffID) || p.Permission.Contains(clsPermission.GetUser().StaffID.ToString()))
                                        && p.IsDelete == false && p.StartDate != null
                                        && p.StartDate.Value.ToString("dd-MM-yyyy") == DateTime.Now.AddDays(1).ToString("dd-MM-yyyy"))
                                    .OrderByDescending(p => p.StartDate)
                                    .Select(p => new SingleTask()
                                    {
                                        Id = p.Id,
                                        Time = p.StartDate ?? DateTime.Now,
                                        Title = p.Name
                                    }).ToList();

            return PartialView("_Partial_Task", model);
        }
        #endregion

        #region Visa sắp hết hạn

        [ChildActionOnly]
        public ActionResult _Partial_ExpiredVisa()
        {
            var info = _visaInfomationRepository.GetAllAsQueryable().AsEnumerable().Where(p => p.IsDelete == false).ToList();
            var checkCustomer = _customerVisaRepository.GetAllAsQueryable().AsEnumerable()
                .Where(p => p.IsDelete == false && p.ExpiredDateVisa != null && info.FirstOrDefault(i => i.TagId == p.TagsId) != null
                && DateTime.Now.AddDays(Convert.ToDouble(info.FirstOrDefault(i => i.TagId == p.TagsId).ExpirationDay)).ToString("dd/MM/yyyy") == p.ExpiredDateVisa.Value.ToString("dd/MM/yyyy")).ToList();
            return PartialView("_Partial_ExpiredVisa", checkCustomer);
        }

        #endregion

        #region Đếm số lịch hẹn, nhiệm vụ
        [ChildActionOnly]
        public ActionResult _Partial_CountNotice()
        {
            int? s1 = _appointmentHistoryRepository.GetAllAsQueryable().AsEnumerable()
                                .Where(p => p.IsDelete == false && p.Time != null
                                    && ((p.Time.ToString("dd-MM-yyyy") == DateTime.Now.ToString("dd-MM-yyyy"))
                                    || (p.Time.ToString("dd-MM-yyyy") == DateTime.Now.AddDays(1).ToString("dd-MM-yyyy")))
                                    && (p.StaffId == clsPermission.GetUser().StaffID
                                    || (p.OtherStaff != null
                                    && p.OtherStaff.Contains(clsPermission.GetUser().StaffID.ToString()))))
                                    .ToList().Count();
            int? s2 = _taskRepository.GetAllAsQueryable().AsEnumerable()
                                .Where(p => ((p.StaffId == clsPermission.GetUser().StaffID) || p.Permission.Contains(clsPermission.GetUser().StaffID.ToString()))
                                    && p.IsDelete == false && p.StartDate != null
                                    && (p.StartDate.Value.ToString("dd-MM-yyyy") == DateTime.Now.ToString("dd-MM-yyyy")
                                    || p.StartDate.Value.ToString("dd-MM-yyyy") == DateTime.Now.AddDays(1).ToString("dd-MM-yyyy")))
                                    .ToList().Count();

            return PartialView("_Partial_CountNotice", s1 + s2);
        }
        #endregion

        #region Tỉnh/TP, Quận/Huyện, Phường/Xã

        public JsonResult DistrictList(int id)
        {
            var model = _tagsRepository.GetAllAsQueryable()
                .Where(p => p.IsDelete == false && p.TypeTag == 6 && p.ParentId == id).OrderBy(p => p.Tag).ToList();
            return Json(new SelectList(model, "Id", "Tag"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult WardList(int id)
        {
            var model = _tagsRepository.GetAllAsQueryable()
                .Where(p => p.IsDelete == false && p.TypeTag == 7 && p.ParentId == id).OrderBy(p => p.Tag).ToList();
            return Json(new SelectList(model, "Id", "Tag"), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region tính toán

        public ActionResult CalTotalPrice(string sl, string dg)
        {
            double dongia = !string.IsNullOrEmpty(dg) ? Convert.ToDouble(dg) : 0;
            int soluong = !string.IsNullOrEmpty(sl) ? Convert.ToInt32(sl) : 0;
            return Json(string.Format("{0:0,0}", dongia * soluong), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}