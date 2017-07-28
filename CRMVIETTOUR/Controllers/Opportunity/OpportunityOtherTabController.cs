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
    public class OpportunityOtherTabController : BaseController
    {
        // GET: OpportunityOtherTab
        #region Init

        private IGenericRepository<tbl_Staff> _staffRepository;
        private IGenericRepository<tbl_Opportunity> _opportunityRepository;
        private IGenericRepository<tbl_OpportunityRequest> _opportunityRequestRepository;
        private IGenericRepository<tbl_OpportunityTransaction> _opportunityTransactionRepository;
        private IGenericRepository<tbl_AppointmentHistory> _appointmentHistoryRepository;
        private IGenericRepository<tbl_DocumentFile> _documentFileRepository;
        private IGenericRepository<tbl_ContactHistory> _contactHistoryRepository;
        private IGenericRepository<tbl_CustomerContact> _customerContactRepository;
        private IGenericRepository<tbl_Competitor> _competitorRepository;
        private IGenericRepository<tbl_Dictionary> _dictionaryRepository;
        private IGenericRepository<tbl_Customer> _customerRepository;
        private DataContext _db;

        public OpportunityOtherTabController(
            IGenericRepository<tbl_Opportunity> opportunityRepository,
            IGenericRepository<tbl_OpportunityRequest> opportunityRequestRepository,
            IGenericRepository<tbl_OpportunityTransaction> opportunityTransactionRepository,
            IGenericRepository<tbl_Staff> staffRepository,
            IGenericRepository<tbl_AppointmentHistory> appointmentHistoryRepository,
            IGenericRepository<tbl_DocumentFile> documentFileRepository,
            IGenericRepository<tbl_ContactHistory> contactHistoryRepository,
            IGenericRepository<tbl_CustomerContact> customerContactRepository,
            IGenericRepository<tbl_Competitor> competitorRepository,
            IGenericRepository<tbl_Dictionary> dictionaryRepository,
            IGenericRepository<tbl_Customer> customerRepository,
            IBaseRepository baseRepository)
            : base(baseRepository)
        {
            this._staffRepository = staffRepository;
            this._opportunityRepository = opportunityRepository;
            this._appointmentHistoryRepository = appointmentHistoryRepository;
            this._documentFileRepository = documentFileRepository;
            this._contactHistoryRepository = contactHistoryRepository;
            this._customerContactRepository = customerContactRepository;
            this._competitorRepository = competitorRepository;
            this._dictionaryRepository = dictionaryRepository;
            this._customerRepository = customerRepository;
            this._opportunityRequestRepository = opportunityRequestRepository;
            this._opportunityTransactionRepository = opportunityTransactionRepository;
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

        #region Nhật ký xử lý
        #endregion

        #region Lịch hẹn
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> CreateAppointment(tbl_AppointmentHistory model, FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1133);
                model.OpportunityId = Convert.ToInt32(Session["idOpportunity"].ToString());
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.StaffId = clsPermission.GetUser().StaffID;
                model.OtherStaff = form["OtherStaff"];

                if (await _appointmentHistoryRepository.Create(model))
                {
                    UpdateHistory.SaveHistory(1133, "Thêm mới lịch hẹn: " + model.Title + ", cơ hội: " + _opportunityRepository.FindId(model.OpportunityId).Code);

                    var list = _appointmentHistoryRepository.GetAllAsQueryable().AsEnumerable()
                            .Where(p => p.OpportunityId == model.OpportunityId && p.IsDelete == false)
                            .OrderByDescending(p => p.CreatedDate)
                            .Select(p => new tbl_AppointmentHistory
                            {
                                Id = p.Id,
                                Title = p.Title,
                                Time = p.Time,
                                tbl_DictionaryStatus = _dictionaryRepository.FindId(p.StatusId),
                                tbl_Staff = _staffRepository.FindId(p.StaffId),
                                Note = p.Note,
                                StatusId = p.StatusId,
                                OtherStaff = p.OtherStaff
                            }).ToList();
                    return PartialView("~/Views/OpportunityTabInfo/_LichHen.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_LichHen.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_LichHen.cshtml");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> EditAppointment(int id)
        {
            var model = await _appointmentHistoryRepository.GetById(id);
            return PartialView("_Partial_EditAppointment", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> UpdateAppointment(tbl_AppointmentHistory model, FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1133);
                model.ModifiedDate = DateTime.Now;
                model.OtherStaff = form["OtherStaff"];

                if (await _appointmentHistoryRepository.Update(model))
                {
                    UpdateHistory.SaveHistory(1133, "Cập nhật lịch hẹn: " + model.Title + ", cơ hội: " + _opportunityRepository.FindId(model.OpportunityId).Code);
                    var list = _appointmentHistoryRepository.GetAllAsQueryable().AsEnumerable()
                            .Where(p => p.OpportunityId == model.OpportunityId).Where(p => p.IsDelete == false)
                            .OrderByDescending(p => p.CreatedDate)
                            .Select(p => new tbl_AppointmentHistory
                            {
                                Id = p.Id,
                                Title = p.Title,
                                Time = p.Time,
                                StatusId = p.StatusId,
                                tbl_DictionaryStatus = _dictionaryRepository.FindId(p.StatusId),
                                tbl_Staff = _staffRepository.FindId(p.StaffId),
                                Note = p.Note,
                                OtherStaff = p.OtherStaff
                            }).ToList();
                    return PartialView("~/Views/OpportunityTabInfo/_LichHen.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_LichHen.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_LichHen.cshtml");
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            int opId = _appointmentHistoryRepository.FindId(id).OpportunityId ?? 0;
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1133);
                var listId = id.ToString().Split(',').ToArray();
                //
                var item = _appointmentHistoryRepository.FindId(id);
                UpdateHistory.SaveHistory(1133, "Xóa lịch hẹn: " + item.Title + ", cơ hội: " + _opportunityRepository.FindId(item.OpportunityId).Code);
                //
                if (await _appointmentHistoryRepository.DeleteMany(listId, false))
                {
                    var list = _appointmentHistoryRepository.GetAllAsQueryable().AsEnumerable()
                            .Where(p => p.OpportunityId == opId).Where(p => p.IsDelete == false)
                            .OrderByDescending(p => p.CreatedDate)
                            .Select(p => new tbl_AppointmentHistory
                            {
                                Id = p.Id,
                                Title = p.Title,
                                StatusId = p.StatusId,
                                Time = p.Time,
                                tbl_DictionaryStatus = _dictionaryRepository.FindId(p.StatusId),
                                tbl_Staff = _staffRepository.FindId(p.StaffId),
                                Note = p.Note,
                                OtherStaff = p.OtherStaff
                            }).ToList();
                    return PartialView("~/Views/OpportunityTabInfo/_LichHen.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_LichHen.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_LichHen.cshtml");
            }
        }
        #endregion

        #region Nhật ký giao dịch
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> CreateTransaction(tbl_OpportunityTransaction model, FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1137);
                model.OpportunityId = Convert.ToInt32(Session["idOpportunity"].ToString());
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.StaffId = clsPermission.GetUser().StaffID;

                if (await _opportunityTransactionRepository.Create(model))
                {
                    UpdateHistory.SaveHistory(1137, "Thêm mới nhật ký giao dịch: " + model.Name + ", cơ hội: " + _opportunityRepository.FindId(model.OpportunityId).Code);

                    var list = _opportunityTransactionRepository.GetAllAsQueryable().AsEnumerable()
                            .Where(p => p.OpportunityId == model.OpportunityId && p.IsDelete == false)
                            .OrderByDescending(p => p.CreatedDate)
                            .Select(p => new tbl_OpportunityTransaction
                            {
                                Id = p.Id,
                                Name = p.Name,
                                TypeId = p.TypeId,
                                tbl_Dictionary = _dictionaryRepository.FindId(p.TypeId),
                                TransactionDate = p.TransactionDate,
                                CreatedDate = p.CreatedDate,
                                StaffId = p.StaffId,
                                tbl_Staff = _staffRepository.FindId(p.StaffId)
                            }).ToList();
                    return PartialView("~/Views/OpportunityTabInfo/_NhatKyGiaoDich.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_NhatKyGiaoDich.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_NhatKyGiaoDich.cshtml");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> EditTransaction(int id)
        {
            var model = await _opportunityTransactionRepository.GetById(id);
            return PartialView("_Partial_EditTransaction", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> UpdateTransaction(tbl_OpportunityTransaction model, FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1137);
                model.ModifiedDate = DateTime.Now;

                if (await _opportunityTransactionRepository.Update(model))
                {
                    UpdateHistory.SaveHistory(1137, "Cập nhật nhật ký giao dịch: " + model.Name + ", cơ hội: " + _opportunityRepository.FindId(model.OpportunityId).Code);
                    var list = _opportunityTransactionRepository.GetAllAsQueryable().AsEnumerable()
                            .Where(p => p.OpportunityId == model.OpportunityId).Where(p => p.IsDelete == false)
                            .OrderByDescending(p => p.CreatedDate)
                            .Select(p => new tbl_OpportunityTransaction
                            {
                                Id = p.Id,
                                Name = p.Name,
                                TypeId = p.TypeId,
                                tbl_Dictionary = _dictionaryRepository.FindId(p.TypeId),
                                TransactionDate = p.TransactionDate,
                                CreatedDate = p.CreatedDate,
                                StaffId = p.StaffId,
                                tbl_Staff = _staffRepository.FindId(p.StaffId)
                            }).ToList();
                    return PartialView("~/Views/OpportunityTabInfo/_NhatKyGiaoDich.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_NhatKyGiaoDich.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_NhatKyGiaoDich.cshtml");
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteTransaction(int id)
        {
            int opId = _opportunityTransactionRepository.FindId(id).OpportunityId ?? 0;
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1137);
                var listId = id.ToString().Split(',').ToArray();
                //
                var item = _opportunityTransactionRepository.FindId(id);
                UpdateHistory.SaveHistory(1137, "Xóa nhật ký giao dịch: " + item.Name + ", cơ hội: " + _opportunityRepository.FindId(item.OpportunityId).Code);
                //
                if (await _opportunityTransactionRepository.DeleteMany(listId, false))
                {
                    var list = _opportunityTransactionRepository.GetAllAsQueryable().AsEnumerable()
                            .Where(p => p.OpportunityId == opId).Where(p => p.IsDelete == false)
                            .OrderByDescending(p => p.CreatedDate)
                            .Select(p => new tbl_OpportunityTransaction
                            {
                                Id = p.Id,
                                Name = p.Name,
                                TypeId = p.TypeId,
                                tbl_Dictionary = _dictionaryRepository.FindId(p.TypeId),
                                TransactionDate = p.TransactionDate,
                                CreatedDate = p.CreatedDate,
                                StaffId = p.StaffId,
                                tbl_Staff = _staffRepository.FindId(p.StaffId)
                            }).ToList();
                    return PartialView("~/Views/OpportunityTabInfo/_NhatKyGiaoDich.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_NhatKyGiaoDich.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_NhatKyGiaoDich.cshtml");
            }
        }
        #endregion

        #region Người liên hệ
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> CreateContact(tbl_CustomerContact model, FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1134);
                int idO = Convert.ToInt32(Session["idOpportunity"]);
                Random rd = new Random();
                model.Code = rd.Next(1111, 9999).ToString();
                model.CustomerId = _opportunityRepository.FindId(idO).CustomerId ?? 0;
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.IsDelete = false;
                model.TagsId = form["TagsId"];

                if (await _customerContactRepository.Create(model))
                {
                    UpdateHistory.SaveHistory(1134, "Thêm mới người liên hệ: " + model.FullName
                        + " của cơ hội " + _opportunityRepository.FindId(idO).Code);

                    var list = _customerContactRepository.GetAllAsQueryable().AsEnumerable()
                                .Where(p => p.CustomerId == model.CustomerId).Where(p => p.IsDelete == false)
                                .OrderByDescending(p => p.CreatedDate)
                                .Select(p => new tbl_CustomerContact
                                {
                                    Id = p.Id,
                                    FullName = p.FullName,
                                    Address = p.Address,
                                    Mobile = p.Mobile,
                                    IdentityCard = p.IdentityCard,
                                    PassportCard = p.PassportCard,
                                    CompanyPhone = p.CompanyPhone,
                                    TagsId = p.TagsId,
                                    Email = p.Email,
                                    Birthday = p.Birthday,
                                    Position = p.Position
                                }).ToList();
                    return PartialView("~/Views/OpportunityTabInfo/_NguoiLienHe.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_NguoiLienHe.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_NguoiLienHe.cshtml");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> EditContact(int id)
        {
            var model = await _customerContactRepository.GetById(id);
            return PartialView("_Partial_EditContact", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> UpdateContact(tbl_CustomerContact model, FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1134);
                model.ModifiedDate = DateTime.Now;
                model.TagsId = form["TagsId"];

                if (await _customerContactRepository.Update(model))
                {
                    var list = _customerContactRepository.GetAllAsQueryable().AsEnumerable()
                                .Where(p => p.CustomerId == model.CustomerId).Where(p => p.IsDelete == false)
                                .OrderByDescending(p => p.CreatedDate)
                                .Select(p => new tbl_CustomerContact
                                {
                                    Id = p.Id,
                                    FullName = p.FullName,
                                    Address = p.Address,
                                    Mobile = p.Mobile,
                                    IdentityCard = p.IdentityCard,
                                    PassportCard = p.PassportCard,
                                    CompanyPhone = p.CompanyPhone,
                                    TagsId = p.TagsId,
                                    Email = p.Email,
                                    Birthday = p.Birthday,
                                    Position = p.Position
                                }).ToList();
                    return PartialView("~/Views/OpportunityTabInfo/_NguoiLienHe.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_NguoiLienHe.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_NguoiLienHe.cshtml");
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteContact(int id)
        {
            int cusId = _customerContactRepository.FindId(id).CustomerId;
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1134);
                var listId = id.ToString().Split(',').ToArray();
                //
                var item = _customerContactRepository.FindId(id);
                UpdateHistory.SaveHistory(1134, "Xóa người liên liên hệ: " + item.FullName + ", khách hàng: " + _customerRepository.FindId(cusId).Code);
                //
                if (await _customerContactRepository.DeleteMany(listId, false))
                {
                    var list = _customerContactRepository.GetAllAsQueryable().AsEnumerable()
                                .Where(p => p.CustomerId == cusId).Where(p => p.IsDelete == false)
                                .OrderByDescending(p => p.CreatedDate)
                                .Select(p => new tbl_CustomerContact
                                {
                                    Id = p.Id,
                                    FullName = p.FullName,
                                    Address = p.Address,
                                    Mobile = p.Mobile,
                                    IdentityCard = p.IdentityCard,
                                    PassportCard = p.PassportCard,
                                    CompanyPhone = p.CompanyPhone,
                                    TagsId = p.TagsId,
                                    Email = p.Email,
                                    Birthday = p.Birthday,
                                    Position = p.Position
                                }).ToList();
                    return PartialView("~/Views/OpportunityTabInfo/_NguoiLienHe.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_NguoiLienHe.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_NguoiLienHe.cshtml");
            }
        }
        #endregion

        #region Đối thủ
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> CreateCompetitor(tbl_Competitor model, FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1135);
                model.OpportunityId = Convert.ToInt32(Session["idOpportunity"].ToString());
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.StaffId = clsPermission.GetUser().StaffID;

                if (await _competitorRepository.Create(model))
                {
                    UpdateHistory.SaveHistory(1135, "Thêm mới đối thủ: " + model.Name + ", cơ hội: " + _opportunityRepository.FindId(model.OpportunityId).Code);

                    var list = _competitorRepository.GetAllAsQueryable().AsEnumerable()
                            .Where(p => p.OpportunityId == model.OpportunityId && p.IsDelete == false)
                            .OrderByDescending(p => p.CreatedDate)
                            .Select(p => new tbl_Competitor
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Advantage = p.Advantage,
                                Disadvantage = p.Disadvantage,
                                CreatedDate = p.CreatedDate,
                                StaffId = p.StaffId,
                                tbl_Staff = _staffRepository.FindId(p.StaffId)
                            }).ToList();
                    return PartialView("~/Views/OpportunityTabInfo/_DoiThu.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_DoiThu.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_DoiThu.cshtml");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> EditCompetitor(int id)
        {
            var model = await _competitorRepository.GetById(id);
            return PartialView("_Partial_EditCompetitor", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> UpdateCompetitor(tbl_Competitor model, FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1135);
                model.ModifiedDate = DateTime.Now;

                if (await _competitorRepository.Update(model))
                {
                    UpdateHistory.SaveHistory(1135, "Cập nhật đối thủ: " + model.Name + ", cơ hội: " + _opportunityRepository.FindId(model.OpportunityId).Code);
                    var list = _competitorRepository.GetAllAsQueryable().AsEnumerable()
                            .Where(p => p.OpportunityId == model.OpportunityId).Where(p => p.IsDelete == false)
                            .OrderByDescending(p => p.CreatedDate)
                            .Select(p => new tbl_Competitor
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Advantage = p.Advantage,
                                Disadvantage = p.Disadvantage,
                                CreatedDate = p.CreatedDate,
                                StaffId = p.StaffId,
                                tbl_Staff = _staffRepository.FindId(p.StaffId)
                            }).ToList();
                    return PartialView("~/Views/OpportunityTabInfo/_DoiThu.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_DoiThu.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_DoiThu.cshtml");
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteCompetitor(int id)
        {
            int opId = _competitorRepository.FindId(id).OpportunityId ?? 0;
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1135);
                var listId = id.ToString().Split(',').ToArray();
                //
                var item = _competitorRepository.FindId(id);
                UpdateHistory.SaveHistory(1135, "Xóa đối thủ: " + item.Name + ", cơ hội: " + _opportunityRepository.FindId(item.OpportunityId).Code);
                //
                if (await _competitorRepository.DeleteMany(listId, false))
                {
                    var list = _competitorRepository.GetAllAsQueryable().AsEnumerable()
                            .Where(p => p.OpportunityId == opId).Where(p => p.IsDelete == false)
                            .OrderByDescending(p => p.CreatedDate)
                            .Select(p => new tbl_Competitor
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Advantage = p.Advantage,
                                Disadvantage = p.Disadvantage,
                                CreatedDate = p.CreatedDate,
                                StaffId = p.StaffId,
                                tbl_Staff = _staffRepository.FindId(p.StaffId)
                            }).ToList();
                    return PartialView("~/Views/OpportunityTabInfo/_DoiThu.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_DoiThu.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_DoiThu.cshtml");
            }
        }
        #endregion

        #region Yêu cầu/phản hồi
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> CreateRequest(tbl_OpportunityRequest model, FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1136);
                model.OpportunityId = Convert.ToInt32(Session["idOpportunity"].ToString());
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.StaffId = clsPermission.GetUser().StaffID;

                if (await _opportunityRequestRepository.Create(model))
                {
                    UpdateHistory.SaveHistory(1136, "Thêm mới yêu cầu/phản hồi: " + model.Name + ", cơ hội: " + _opportunityRepository.FindId(model.OpportunityId).Code);

                    var list = _opportunityRequestRepository.GetAllAsQueryable().AsEnumerable()
                            .Where(p => p.OpportunityId == model.OpportunityId && p.IsDelete == false)
                            .OrderByDescending(p => p.CreatedDate)
                            .Select(p => new tbl_OpportunityRequest
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Request = p.Request,
                                CreatedDate = p.CreatedDate,
                                StaffId = p.StaffId,
                                tbl_Staff = _staffRepository.FindId(p.StaffId)
                            }).ToList();
                    return PartialView("~/Views/OpportunityTabInfo/_YeuCauPhanHoi.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_YeuCauPhanHoi.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_YeuCauPhanHoi.cshtml");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> EditRequest(int id)
        {
            var model = await _opportunityRequestRepository.GetById(id);
            return PartialView("_Partial_EditRequest", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> UpdateRequest(tbl_OpportunityRequest model, FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1136);
                model.ModifiedDate = DateTime.Now;

                if (await _opportunityRequestRepository.Update(model))
                {
                    UpdateHistory.SaveHistory(1136, "Cập nhật yêu cầu: " + model.Name + ", cơ hội: " + _opportunityRepository.FindId(model.OpportunityId).Code);
                    var list = _opportunityRequestRepository.GetAllAsQueryable().AsEnumerable()
                            .Where(p => p.OpportunityId == model.OpportunityId).Where(p => p.IsDelete == false)
                            .OrderByDescending(p => p.CreatedDate)
                            .Select(p => new tbl_OpportunityRequest
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Request = p.Request,
                                CreatedDate = p.CreatedDate,
                                StaffId = p.StaffId,
                                tbl_Staff = _staffRepository.FindId(p.StaffId)
                            }).ToList();
                    return PartialView("~/Views/OpportunityTabInfo/_YeuCauPhanHoi.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_YeuCauPhanHoi.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_YeuCauPhanHoi.cshtml");
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteRequest(int id)
        {
            int opId = _opportunityRequestRepository.FindId(id).OpportunityId ?? 0;
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1136);
                var listId = id.ToString().Split(',').ToArray();
                //
                var item = _opportunityRequestRepository.FindId(id);
                UpdateHistory.SaveHistory(1136, "Xóa yêu cầu: " + item.Name + ", cơ hội: " + _opportunityRepository.FindId(item.OpportunityId).Code);
                //
                if (await _opportunityRequestRepository.DeleteMany(listId, false))
                {
                    var list = _opportunityRequestRepository.GetAllAsQueryable().AsEnumerable()
                            .Where(p => p.OpportunityId == opId).Where(p => p.IsDelete == false)
                            .OrderByDescending(p => p.CreatedDate)
                            .Select(p => new tbl_OpportunityRequest
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Request= p.Request,
                                CreatedDate = p.CreatedDate,
                                StaffId = p.StaffId,
                                tbl_Staff = _staffRepository.FindId(p.StaffId)
                            }).ToList();
                    return PartialView("~/Views/OpportunityTabInfo/_YeuCauPhanHoi.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_YeuCauPhanHoi.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_YeuCauPhanHoi.cshtml");
            }
        }
        #endregion

        #region Tài liệu mẫu

        [HttpPost]
        public ActionResult UploadFileOpportunity(HttpPostedFileBase FileName)
        {
            if (FileName != null && FileName.ContentLength > 0)
            {
                Session["OpportunityFile"] = FileName;
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> CreateDocument(tbl_DocumentFile model, FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1138);
                string id = Session["idOpportunity"].ToString();
                if (ModelState.IsValid)
                {
                    model.Code = GenerateCode.DocumentCode();
                    model.OpportunityId = Convert.ToInt32(id);
                    model.CreatedDate = DateTime.Now;
                    model.IsRead = false;
                    model.ModifiedDate = DateTime.Now;
                    model.CustomerId = _opportunityRepository.FindId(model.OpportunityId).CustomerId;
                    if (form["TagsId"] != null && form["TagsId"] != "")
                    {
                        model.TagsId = form["TagsId"].ToString();
                    }
                    model.StaffId = clsPermission.GetUser().StaffID;
                    //file
                    HttpPostedFileBase FileName = Session["OpportunityFile"] as HttpPostedFileBase;
                    string FileSize = Common.ConvertFileSize(FileName.ContentLength);
                    String newName = FileName.FileName.Insert(FileName.FileName.LastIndexOf('.'), String.Format("{0:_ddMMyyyy}", DateTime.Now));
                    String path = Server.MapPath("~/Upload/file/" + newName);
                    FileName.SaveAs(path);
                    //end file
                    if (newName != null && FileSize != null)
                    {
                        model.FileName = newName;
                        model.FileSize = FileSize;
                    }

                    if (await _documentFileRepository.Create(model))
                    {
                        UpdateHistory.SaveHistory(1138, "Thêm mới tài liệu, code: " + model.Code + " - " + model.FileName);

                        Session["OpportunityFile"] = null;
                        var list = _db.tbl_DocumentFile.AsEnumerable()
                                      .Where(p => (p.OpportunityId.ToString() == id || p.CustomerId == model.CustomerId) && p.IsDelete == false)
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
                        return PartialView("~/Views/OpportunityTabInfo/_TaiLieuMau.cshtml", list);
                    }
                    else
                    {
                        return PartialView("~/Views/OpportunityTabInfo/_TaiLieuMau.cshtml");
                    }
                }
            }
            catch { }
            return PartialView("~/Views/OpportunityTabInfo/_TaiLieuMau.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> EditInfoDocument(int id)
        {
            var model = await _documentFileRepository.GetById(id);
            ViewBag.DictionaryId = new SelectList(_dictionaryRepository.GetAllAsQueryable()
                .Where(p => p.DictionaryCategoryId == 1 && p.IsDelete == false), "Id", "Name", model.DictionaryId);
            return PartialView("_Partial_EditDocument", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> UpdateDocument(tbl_DocumentFile model, FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1138);
                if (ModelState.IsValid)
                {
                    model.IsRead = true;
                    model.ModifiedDate = DateTime.Now;
                    if (form["TagsId"] != null && form["TagsId"] != "")
                    {
                        model.TagsId = form["TagsId"].ToString();
                    }
                    if (Session["OpportunityFile"] != null)
                    {
                        //file
                        HttpPostedFileBase FileName = Session["OpportunityFile"] as HttpPostedFileBase;
                        string FileSize = Common.ConvertFileSize(FileName.ContentLength);
                        String newName = FileName.FileName.Insert(FileName.FileName.LastIndexOf('.'), String.Format("{0:_ddMMyyyy}", DateTime.Now));
                        String path = Server.MapPath("~/Upload/file/" + newName);
                        FileName.SaveAs(path);
                        //end file

                        if (FileName != null && FileSize != null)
                        {
                            String pathOld = Server.MapPath("~/Upload/file/" + model.FileName);
                            if (System.IO.File.Exists(pathOld))
                                System.IO.File.Delete(pathOld);
                            model.FileName = newName;
                            model.FileSize = FileSize;
                        }
                    }
                    if (await _documentFileRepository.Update(model))
                    {
                        UpdateHistory.SaveHistory(1138, "Cập nhật tài liệu của cơ hội: " + model.Code);
                        Session["OpportunityFile"] = null;
                        var list = _documentFileRepository.GetAllAsQueryable().AsEnumerable()
                             .Where(p => (p.OpportunityId == model.OpportunityId || p.CustomerId == model.CustomerId) && p.IsDelete == false)
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
                        return PartialView("~/Views/OpportunityTabInfo/_TaiLieuMau.cshtml", list);
                    }
                    else
                    {
                        return PartialView("~/Views/OpportunityTabInfo/_TaiLieuMau.cshtml");
                    }
                }
            }
            catch
            {
            }

            return PartialView("~/Views/OpportunityTabInfo/_TaiLieuMau.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteDocument(int id)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1138);
                var doc = _documentFileRepository.FindId(id);
                int opId = doc.OpportunityId ?? 0;
                int cusId = doc.CustomerId ?? 0;
                //file
                tbl_DocumentFile documentFile = _documentFileRepository.FindId(id) ?? new tbl_DocumentFile();
                String path = Server.MapPath("~/Upload/file/" + documentFile.FileName);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                //end file
                var listIds = id.ToString().Split(',').ToArray();
                //
                var item = _documentFileRepository.FindId(id);
                UpdateHistory.SaveHistory(1138, "Xóa tài liệu: " + item.Code);
                //
                if (await _documentFileRepository.DeleteMany(listIds, false))
                {
                    var list = _db.tbl_DocumentFile.AsEnumerable()
                        .Where(p => (p.OpportunityId == opId || p.CustomerId == cusId) && p.IsDelete == false)
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
                    return PartialView("~/Views/OpportunityTabInfo/_TaiLieuMau.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_TaiLieuMau.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_TaiLieuMau.cshtml");
            }
        }

        #endregion

        #region Lịch sử liên hệ
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> CreateHistory(tbl_ContactHistory model, FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1140);
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.StaffId = clsPermission.GetUser().StaffID;
                model.OtherStaffId = model.StaffId;
                model.Opportunity = Int32.Parse(Session["idOpportunity"].ToString());
                if (await _contactHistoryRepository.Create(model))
                {
                    UpdateHistory.SaveHistory(1140, "Thêm mới lịch sử liên hệ: " + model.Request + ", cơ hội: " + _opportunityRepository.FindId(model.Opportunity).Code);

                    var list = _db.tbl_ContactHistory.AsEnumerable()
                        .Where(p => p.Opportunity == model.Opportunity).Where(p => p.IsDelete == false)
                        .OrderByDescending(p => p.CreatedDate)
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
                    return PartialView("~/Views/OpportunityTabInfo/_LichSuLienHe.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_LichSuLienHe.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_LichSuLienHe.cshtml");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> EditHistory(int id)
        {
            var m = await _contactHistoryRepository.GetById(id);
            return PartialView("_Partial_EditHistory", await _contactHistoryRepository.GetById(id));
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> UpdateHistoryC(tbl_ContactHistory model, FormCollection form)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1140);
                model.ModifiedDate = DateTime.Now;
                model.OtherStaffId = model.StaffId;
                if (await _contactHistoryRepository.Update(model))
                {
                    UpdateHistory.SaveHistory(1140, "Cập nhật lịch sử liên hệ: " + model.Request + ", cơ hội: " + _opportunityRepository.FindId(model.Opportunity).Code);

                    var list = _db.tbl_ContactHistory.AsEnumerable()
                        .Where(p => p.Opportunity == model.Opportunity).Where(p => p.IsDelete == false)
                        .OrderByDescending(p => p.CreatedDate)
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
                    return PartialView("~/Views/OpportunityTabInfo/_LichSuLienHe.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_LichSuLienHe.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_LichSuLienHe.cshtml");
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteHistory(int id)
        {
            try
            {
                Permission(clsPermission.GetUser().PermissionID, 1140);
                int oppId = _contactHistoryRepository.FindId(id).Opportunity ?? 0;
                var listId = id.ToString().Split(',').ToArray();
                //
                var item = _contactHistoryRepository.FindId(id);
                UpdateHistory.SaveHistory(1140, "Xóa lịch sử liên hệ: " + item.Request + ", cơ hội: " + _opportunityRepository.FindId(item.Opportunity).Code);
                //
                if (await _contactHistoryRepository.DeleteMany(listId, false))
                {
                    var list = _db.tbl_ContactHistory.AsEnumerable()
                        .Where(p => p.Opportunity == oppId).Where(p => p.IsDelete == false)
                        .OrderByDescending(p => p.CreatedDate)
                        .Select(p => new tbl_ContactHistory
                        {
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
                    return PartialView("~/Views/OpportunityTabInfo/_LichSuLienHe.cshtml", list);
                }
                else
                {
                    return PartialView("~/Views/OpportunityTabInfo/_LichSuLienHe.cshtml");
                }
            }
            catch
            {
                return PartialView("~/Views/OpportunityTabInfo/_LichSuLienHe.cshtml");
            }
        }
        #endregion
    }
}