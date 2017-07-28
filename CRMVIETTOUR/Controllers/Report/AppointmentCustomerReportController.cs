﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRMVIETTOUR.Models;
using CRMVIETTOUR.Utilities;
using CRM.Core;
using CRM.Infrastructure;
using System.IO;
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Style;

namespace CRMVIETTOUR.Controllers
{
    [Authorize]
    public class AppointmentCustomerReportController : BaseController
    {
        //
        // GET: /ReportsManage/

        #region Init

        private IGenericRepository<tbl_Dictionary> _dictionaryRepository;
        private IGenericRepository<tbl_ServicesPartner> _servicesPartnerRepository;
        private IGenericRepository<tbl_Tour> _tourRepository;
        private IGenericRepository<tbl_ReviewTour> _reviewTourRepository;
        private IGenericRepository<tbl_ReviewTourDetail> _reviewTourDetailRepository;
        private IGenericRepository<tbl_Customer> _customerRepository;
        private IGenericRepository<tbl_CustomerVisa> _customerVisaRepository;
        private IGenericRepository<tbl_Tags> _tagsRepository;
        private IGenericRepository<tbl_Task> _taskRepository;
        private IGenericRepository<tbl_DocumentFile> _documentFileRepository;
        private IGenericRepository<tbl_AppointmentHistory> _appointmentHistoryRepository;
        private IGenericRepository<tbl_ContactHistory> _contactHistoryRepository;
        private IGenericRepository<tbl_Contract> _contractRepository;
        private IGenericRepository<tbl_Partner> _partnerRepository;
        private IGenericRepository<tbl_TourGuide> _tourGuideRepository;
        private IGenericRepository<tbl_TourSchedule> _tourScheduleRepository;
        private IGenericRepository<tbl_TourCustomer> _tourCustomerRepository;
        private IGenericRepository<tbl_TourCustomerVisa> _tourCustomerVisaRepository;
        private IGenericRepository<tbl_TourOption> _tourOptionRepository;
        private IGenericRepository<tbl_Staff> _staffRepository;
        private IGenericRepository<tbl_LiabilityCustomer> _liabilityCustomerRepository;
        private IGenericRepository<tbl_LiabilityPartner> _liabilityPartnerRepository;
        private IGenericRepository<tbl_CustomerContact> _customerContactRepository;
        private IGenericRepository<tbl_CustomerContactVisa> _customerContactVisaRepository;
        private IGenericRepository<tbl_UpdateHistory> _updateHistoryRepository;
        private IGenericRepository<tbl_Program> _programRepository;
        private DataContext _db;

        public AppointmentCustomerReportController(IGenericRepository<tbl_Dictionary> dictionaryRepository,
            IGenericRepository<tbl_ServicesPartner> servicesPartnerRepository,
            IGenericRepository<tbl_Tour> tourRepository,
            IGenericRepository<tbl_ReviewTour> reviewTourRepository,
            IGenericRepository<tbl_ReviewTourDetail> reviewTourDetailRepository,
            IGenericRepository<tbl_Customer> customerRepository,
            IGenericRepository<tbl_CustomerVisa> customerVisaRepository,
            IGenericRepository<tbl_Tags> tagsRepository,
            IGenericRepository<tbl_Task> taskRepository,
            IGenericRepository<tbl_DocumentFile> documentFileRepository,
            IGenericRepository<tbl_AppointmentHistory> appointmentHistoryRepository,
            IGenericRepository<tbl_ContactHistory> contactHistoryRepository,
            IGenericRepository<tbl_Contract> contractRepository,
            IGenericRepository<tbl_Partner> partnerRepository,
            IGenericRepository<tbl_TourGuide> tourGuideRepository,
            IGenericRepository<tbl_TourSchedule> tourScheduleRepository,
            IGenericRepository<tbl_TourCustomer> tourCustomerRepository,
            IGenericRepository<tbl_TourCustomerVisa> tourCustomerVisaRepository,
            IGenericRepository<tbl_TourOption> tourOptionRepository,
            IGenericRepository<tbl_Staff> staffRepository,
            IGenericRepository<tbl_LiabilityCustomer> liabilityCustomerRepository,
            IGenericRepository<tbl_LiabilityPartner> liabilityPartnerRepository,
            IGenericRepository<tbl_CustomerContact> customerContactRepository,
            IGenericRepository<tbl_CustomerContactVisa> customerContactVisaRepository,
            IGenericRepository<tbl_UpdateHistory> updateHistoryRepository,
            IGenericRepository<tbl_Program> programRepository,
            IBaseRepository baseRepository)
            : base(baseRepository)
        {
            this._dictionaryRepository = dictionaryRepository;
            this._servicesPartnerRepository = servicesPartnerRepository;
            this._tourRepository = tourRepository;
            this._reviewTourRepository = reviewTourRepository;
            this._reviewTourDetailRepository = reviewTourDetailRepository;
            this._customerRepository = customerRepository;
            this._customerVisaRepository = customerVisaRepository;
            this._tagsRepository = tagsRepository;
            this._taskRepository = taskRepository;
            this._documentFileRepository = documentFileRepository;
            this._appointmentHistoryRepository = appointmentHistoryRepository;
            this._contactHistoryRepository = contactHistoryRepository;
            this._contractRepository = contractRepository;
            this._partnerRepository = partnerRepository;
            this._tourGuideRepository = tourGuideRepository;
            this._tourScheduleRepository = tourScheduleRepository;
            this._tourCustomerRepository = tourCustomerRepository;
            this._tourCustomerVisaRepository = tourCustomerVisaRepository;
            this._tourOptionRepository = tourOptionRepository;
            this._staffRepository = staffRepository;
            this._liabilityCustomerRepository = liabilityCustomerRepository;
            this._liabilityPartnerRepository = liabilityPartnerRepository;
            this._programRepository = programRepository;
            this._customerContactRepository = customerContactRepository;
            this._customerContactVisaRepository = customerContactVisaRepository;
            this._updateHistoryRepository = updateHistoryRepository;
            _db = new DataContext();
        }
        #endregion

        #region Permission
        int SDBID = 6;
        int maPB = 0, maNKD = 0, maNV = 0, maCN = 0;
        void Permission(int PermissionsId, int formId)
        {
            var list = _db.tbl_ActionData.Where(p => p.FormId == formId && p.PermissionsId == PermissionsId).Select(p => p.FunctionId).ToList();

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

        #region List
        public ActionResult Index()
        {
            Permission(clsPermission.GetUser().PermissionID, 1123);
            return View();
        }

        [ChildActionOnly]
        public ActionResult _Partial_ListAppointmentReport()
        {
            Permission(clsPermission.GetUser().PermissionID, 1123);

            var model = _appointmentHistoryRepository.GetAllAsQueryable().AsEnumerable()
                .Where(p => (p.StaffId == maNV | maNV == 0)
                    & (_staffRepository.FindId(p.StaffId).DepartmentId == maPB | maPB == 0)
                    & (_staffRepository.FindId(p.StaffId).StaffGroupId == maNKD | maNKD == 0)
                    & (_staffRepository.FindId(p.StaffId).HeadquarterId == maCN | maCN == 0)
                    & (p.IsDelete == false))
                    .OrderByDescending(p => p.CreatedDate)
                    .Select(p => new tbl_AppointmentHistory
                    {
                        Id = p.Id,
                        Title = p.Title,
                        CustomerId = p.CustomerId,
                        Time = p.Time,
                        tbl_Customer = _customerRepository.FindId(p.CustomerId),
                        tbl_Program = _programRepository.FindId(p.ProgramId),
                        tbl_Task = _taskRepository.FindId(p.TaskId),
                        tbl_DictionaryService = _dictionaryRepository.FindId(p.tbl_DictionaryService),
                        tbl_Partner = _partnerRepository.FindId(p.PartnerId),
                        tbl_Tour = _tourRepository.FindId(p.TourId),
                        Note = p.Note,
                        OtherStaff = p.OtherStaff,
                        tbl_DictionaryStatus = _dictionaryRepository.FindId(p.StatusId),
                        tbl_Staff = _staffRepository.FindId(p.StaffId),
                        StaffId = p.StaffId,
                        CreatedDate = p.CreatedDate
                    }).ToList();
            return PartialView("_Partial_ListAppointmentReport", model);
        }

        public ActionResult GetStartEndDate(int id)
        {
            return Json(LoadData.GetDate(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterDate(DateTime start, DateTime end, int staff)
        {
            Permission(clsPermission.GetUser().PermissionID, 1123);

            var list = _appointmentHistoryRepository.GetAllAsQueryable().AsEnumerable().Where(p =>
                                (start == end ? p.Time.ToString("dd-MM-yyyy") == start.ToString("dd-MM-yyyy") : start <= p.Time && p.Time <= end)
                                && p.OtherStaff != null && ((staff != 0 ? p.OtherStaff.Contains(staff.ToString()) : p.Id != 0)
                                || p.StaffId == staff)
                                & (_staffRepository.FindId(p.StaffId).DepartmentId == maPB | maPB == 0)
                                & (_staffRepository.FindId(p.StaffId).StaffGroupId == maNKD | maNKD == 0)
                                & (_staffRepository.FindId(p.StaffId).HeadquarterId == maCN | maCN == 0)
                                & (p.IsDelete == false))
                               .Select(p => new tbl_AppointmentHistory
                               {
                                   Id = p.Id,
                                   Title = p.Title,
                                   Time = p.Time,
                                   tbl_Customer = _customerRepository.FindId(p.CustomerId),
                                   tbl_Program = _programRepository.FindId(p.ProgramId),
                                   tbl_Task = _taskRepository.FindId(p.TaskId),
                                   tbl_DictionaryService = _dictionaryRepository.FindId(p.tbl_DictionaryService),
                                   tbl_Partner = _partnerRepository.FindId(p.PartnerId),
                                   tbl_Tour = _tourRepository.FindId(p.TourId),
                                   Note = p.Note,
                                   OtherStaff = p.OtherStaff,
                                   tbl_DictionaryStatus = _dictionaryRepository.FindId(p.StatusId),
                                   tbl_Staff = _staffRepository.FindId(p.StaffId),
                                   CreatedDate = p.CreatedDate
                               }).ToList();
            return PartialView("_Partial_ListAppointmentReport", list);
        }
        #endregion

        #region ExportExcel

        public ActionResult ExportExcel(FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1123);

                var contract = _contractRepository.GetAllAsQueryable();
                HtmlToText converthtml = new HtmlToText();
                string filename = "";
                byte[] bytes;
                using (var stream = new MemoryStream())
                {
                    if (form["listItemId"] != null && form["listItemId"] !=  "")
                    {
                        var lstExport = new List<tbl_AppointmentHistory>();
                        var listIds = form["listItemId"].Split(',');
                        listIds = listIds.Take(listIds.Count() - 1).ToArray();
                        if (listIds.Count() > 0)
                        {
                            foreach (var i in listIds)
                            {
                                lstExport.Add(_appointmentHistoryRepository.FindId(Convert.ToInt32(i)));
                            }
                            lstExport = lstExport.Select(p => new tbl_AppointmentHistory
                            {
                                Id = p.Id,
                                Title = p.Title,
                                Time = p.Time,
                                tbl_Customer = _customerRepository.FindId(p.CustomerId),
                                tbl_Program = _programRepository.FindId(p.ProgramId),
                                tbl_Task = _taskRepository.FindId(p.TaskId),
                                tbl_DictionaryService = _dictionaryRepository.FindId(p.tbl_DictionaryService),
                                tbl_Partner = _partnerRepository.FindId(p.PartnerId),
                                tbl_Tour = _tourRepository.FindId(p.TourId),
                                Note = p.Note,
                                OtherStaff = p.OtherStaff,
                                tbl_DictionaryStatus = _dictionaryRepository.FindId(p.StatusId),
                                tbl_Staff = _staffRepository.FindId(p.StaffId),
                                CreatedDate = p.CreatedDate
                            }).ToList();
                            filename = "[CRMVIETTOUR] Thống kê báo cáo lịch hẹn";
                            ExportToursToXlsx(stream, lstExport, filename);
                        }
                    }
                    else
                    {
                        var list = _appointmentHistoryRepository.GetAllAsQueryable().AsEnumerable().Where(p =>
                                (form["tungay"] == form["denngay"] ? p.CreatedDate.ToString("dd-MM-yyyy") == Convert.ToDateTime(form["tungay"]).ToString("dd-MM-yyyy") : Convert.ToDateTime(form["tungay"]) <= p.CreatedDate && p.CreatedDate <= Convert.ToDateTime(form["denngay"]))
                                && (form["denngay"] != null ? p.Time <= Convert.ToDateTime(form["denngay"]) : p.Id != 0)
                                && p.OtherStaff != null
                                && ((form["nhanvien"] != "0" ? p.OtherStaff.Contains(form["nhanvien"].ToString()) : p.Id != 0)
                                || (form["nhanvien"] != "0" ? p.StaffId.ToString() == form["nhanvien"].ToString() : p.Id != 0))
                                & (_staffRepository.FindId(p.StaffId).DepartmentId == maPB | maPB == 0)
                                & (_staffRepository.FindId(p.StaffId).StaffGroupId == maNKD | maNKD == 0)
                                & (_staffRepository.FindId(p.StaffId).HeadquarterId == maCN | maCN == 0)
                                & (p.IsDelete == false))
                               .Select(p => new tbl_AppointmentHistory
                               {
                                   Id = p.Id,
                                   Title = p.Title,
                                   Time = p.Time,
                                   tbl_Customer = _customerRepository.FindId(p.CustomerId),
                                   tbl_Program = _programRepository.FindId(p.ProgramId),
                                   tbl_Task = _taskRepository.FindId(p.TaskId),
                                   tbl_DictionaryService = _dictionaryRepository.FindId(p.tbl_DictionaryService),
                                   tbl_Partner = _partnerRepository.FindId(p.PartnerId),
                                   tbl_Tour = _tourRepository.FindId(p.TourId),
                                   Note = p.Note,
                                   OtherStaff = p.OtherStaff,
                                   tbl_DictionaryStatus = _dictionaryRepository.FindId(p.StatusId),
                                   tbl_Staff = _staffRepository.FindId(p.StaffId),
                                   CreatedDate = p.CreatedDate
                               }).ToList();
                        filename = "[CRMVIETTOUR] Thống kê báo cáo lịch hẹn từ " + Convert.ToDateTime(form["tungay"]).ToString("dd-MM-yyyy") + " đến " + Convert.ToDateTime(form["denngay"]).ToString("dd-MM-yyyy");
                        ExportToursToXlsx(stream, list, filename);
                    }

                    bytes = stream.ToArray();
                }
                return File(bytes, "text/xls", filename + ".xlsx");
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public virtual void ExportToursToXlsx(Stream stream, IList<tbl_AppointmentHistory> tours, string headername)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            using (var xlPackage = new ExcelPackage(stream))
            {

                var worksheet = xlPackage.Workbook.Worksheets.Add("Tours");

                var properties = new[]
                    {
                       "STT",
                       "Tiêu đề",
                       "Ngày hẹn",
                       "Trạng thái",
                       "Khách hàng",
                       "Nhân viên",
                       "Ngày nhập"
                    };

                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[3, i + 1].Value = properties[i];
                }

                worksheet.Cells["a1:g2"].Value = headername.ToUpper();
                worksheet.Cells["a1:g2"].Style.Font.SetFromFont(new Font("Tahoma", 15));
                worksheet.Cells["a1:g2"].Style.Font.Bold = true;
                worksheet.Cells["a1:g2"].Merge = true;
                worksheet.Cells["a1:g2"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["a1:g2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                //worksheet.Cells["a1:g2"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(192, 192, 192));

                int row = 3;
                int stt = 1;
                foreach (var t in tours)
                {
                    row++;
                    int col = 1;

                    worksheet.Cells[row, col].Value = stt;
                    col++;

                    worksheet.Cells[row, col].Value = t.Title;
                    col++;

                    worksheet.Cells[row, col].Value = string.Format("{0:dd-MM-yyyy}", t.Time);
                    col++;

                    worksheet.Cells[row, col].Value = t.tbl_DictionaryStatus.Name;
                    col++;

                    worksheet.Cells[row, col].Value = t.CustomerId != null ? t.tbl_Customer.FullName : "";
                    col++;

                    worksheet.Cells[row, col].Value = t.tbl_Staff.FullName;
                    col++;

                    worksheet.Cells[row, col].Value = string.Format("{0:dd-MM-yyyy}", t.CreatedDate);
                    col++;

                    stt++;
                }
                worksheet.Cells["a3:g" + row].Style.Font.SetFromFont(new Font("Tahoma", 8));

                worksheet.Cells["a3:g3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                worksheet.Cells["a3:g3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["a3:g3"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(192, 192, 192));
                worksheet.Cells["a3:g3"].Style.Font.Bold = true;
                worksheet.Cells["a3:g3"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Row(3).Height = 20;

                worksheet.Cells["a3:g" + row].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["a3:g" + row].Style.Border.Top.Color.SetColor(Color.FromArgb(169, 169, 169));
                worksheet.Cells["a3:g" + row].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["a3:g" + row].Style.Border.Left.Color.SetColor(Color.FromArgb(169, 169, 169));
                worksheet.Cells["a3:g" + row].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["a3:g" + row].Style.Border.Bottom.Color.SetColor(Color.FromArgb(169, 169, 169));
                worksheet.Cells["a3:g" + row].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["a3:g" + row].Style.Border.Right.Color.SetColor(Color.FromArgb(169, 169, 169));

                worksheet.Cells["a3:g" + row].AutoFitColumns();

                xlPackage.Save();
            }
        }

        #endregion
    }
}
