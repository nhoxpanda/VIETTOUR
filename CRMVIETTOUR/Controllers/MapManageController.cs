﻿using CRM.Core;
using CRM.Infrastructure;
using CRMVIETTOUR.Models;
using CRMVIETTOUR.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMVIETTOUR.Controllers
{
    [Authorize]
    public class MapManageController : BaseController
    {
        //
        // GET: /MapManage/

        #region Init

        private IGenericRepository<tbl_Tags> _tagRepository;
        private IGenericRepository<tbl_PartnerNote> _partnerNoteRepository;
        private IGenericRepository<tbl_Dictionary> _dictionaryRepository;
        private IGenericRepository<tbl_DocumentFile> _documentFileRepository;
        private IGenericRepository<tbl_Partner> _partnerRepository;
        private IGenericRepository<tbl_ServicesPartner> _servicesPartnerRepository;
        private IGenericRepository<tbl_Staff> _staffRepository;
        private DataContext _db;

        public MapManageController(IGenericRepository<tbl_Dictionary> dictionaryRepository,
            IGenericRepository<tbl_PartnerNote> partnerNoteRepository,
            IGenericRepository<tbl_DocumentFile> documentFileRepository,
            IGenericRepository<tbl_Tags> tagRepository,
            IGenericRepository<tbl_Partner> partnerRepository,
            IGenericRepository<tbl_ServicesPartner> servicesPartnerRepository,
            IGenericRepository<tbl_Staff> staffRepository,
            IBaseRepository baseRepository)
            : base(baseRepository)
        {
            this._partnerNoteRepository = partnerNoteRepository;
            this._documentFileRepository = documentFileRepository;
            this._dictionaryRepository = dictionaryRepository;
            this._partnerRepository = partnerRepository;
            this._servicesPartnerRepository = servicesPartnerRepository;
            this._tagRepository = tagRepository;
            this._staffRepository = staffRepository;
            _db = new DataContext();
        }

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult _Partial_ListPartner()
        {
            var model = _partnerRepository.GetAllAsQueryable().AsEnumerable().Where(p => p.DictionaryId == 1047)
                .Select(p => new PartnerViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Code = p.Code,
                    xMap = p.xMap,
                    yMap = p.yMap,
                    AddressMap = p.AddressMap
                });
            return PartialView("_Partial_ListPartner", model);
        }

        public JsonResult ListPartner(int id)
        {
            var model = _partnerRepository.GetAllAsQueryable().AsEnumerable().Where(p => p.DictionaryId == id);
            return Json(new
            {
                data = model.Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    xMap = p.xMap,
                    yMap = p.yMap,
                    AddressMap = p.AddressMap
                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ListPartnerInPartial(int id)
        {
            var model = _partnerRepository.GetAllAsQueryable().AsEnumerable().Where(p => p.DictionaryId == id)
                .Select(p => new PartnerViewModel
                {
                    Id = p.Id,
                    xMap = p.xMap,
                    yMap = p.yMap,
                    AddressMap = p.AddressMap
                }).ToList();
            return PartialView("_Partial_ListPartner", model);
        }

        public JsonResult LoadMarker(int idService, string name, string idTags)
        {
            var model = _partnerRepository.GetAllAsQueryable()
                            .Where(p => p.IsDelete == false && p.DictionaryId == (idService == 0 ? p.DictionaryId : idService)
                                    && (name != "" ? p.Name.Contains(name) : p.Id != 0)
                                    && (idTags != "" ? p.TagsLocationId.Contains(idTags) : p.Id != 0)
                                    && p.tbl_Dictionary.IsDelete == false)
                            .Select(p => new MapViewModel
                            {
                                Id = p.Id,
                                Name = p.Name,
                                xMap = p.xMap,
                                yMap = p.yMap,
                                AddressMap = p.AddressMap,
                                Icon = p.tbl_Dictionary.Icon
                            }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }



    }
}
