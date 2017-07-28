﻿using CRM.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMVIETTOUR.Utilities
{
    public static class GenerateCode
    {
        private static DataContext _db = new DataContext();

        public static string StaffCode()
        {
            var staf = _db.tbl_Staff.Where(p => p.IsVietlike == true).AsEnumerable().ToList();
            if (staf.Count() > 0 && staf.Last() != null)
            {
                string num = staf.Last().Code.Substring(2);
                int codenum = Int32.Parse(num);
                codenum++;
                string newcode = "NV" + codenum.ToString("D4");
                return newcode;
            }
            else
            {
                return "NV0001";
            }
        }

        public static string CustomerCode()
        {
            var staf = _db.tbl_Customer.AsEnumerable().Where(p => p.Code != "OTHERCOMPANY").ToList();
            if (staf.Count() > 0 && staf.Last() != null)
            {
                string num = staf.Last().Code.Substring(2);
                int codenum = Int32.Parse(num);
                codenum++;
                string newcode = "KH" + codenum.ToString("D4");
                return newcode;
            }
            else
            {
                return "KH0001";
            }
        }

        public static string TourCode()
        {
            var staf = _db.tbl_Tour.AsEnumerable().ToList();
            if (staf.Count() > 0 && staf.Last() != null)
            {
                string num = staf.Last().Code.Substring(4);
                int codenum = Int32.Parse(num);
                codenum++;
                string newcode = "VM" + codenum.ToString("D4");
                return newcode;
            }
            else
            {
                return "VM0001";
            }
        }

        public static string ContractCode()
        {
            var staf = _db.tbl_Contract.AsEnumerable().ToList();
            if (staf.Count() > 0 && staf.Last() != null)
            {
                string num = staf.Last().Code.Substring(2);
                int codenum = Int32.Parse(num);
                codenum++;
                string newcode = "HD" + codenum.ToString("D4");
                return newcode;
            }
            else
            {
                return "HD0001";
            }
        }

        public static string OpportunityCode()
        {
            var staf = _db.tbl_Opportunity.AsEnumerable().ToList();
            if (staf.Count() > 0 && staf.Last() != null)
            {
                string num = staf.Last().Code.Substring(2);
                int codenum = Int32.Parse(num);
                codenum++;
                string newcode = "CH" + codenum.ToString("D4");
                return newcode;
            }
            else
            {
                return "CH0001";
            }
        }

        public static string PartnerCode(int id)
        {
            string kq = "";
            if (id == 0) // chưa chọn dịch vụ
            {
                var staf = _db.tbl_Partner.AsEnumerable().ToList();
                if (staf.Count() > 0 && staf.Last() != null)
                {
                    string num = staf.Last().Code.Substring(2);
                    int codenum = Int32.Parse(num);
                    codenum++;
                    kq = "NH" + codenum.ToString("D4");
                }
                else
                {
                    kq = "NH0001";
                }
                return kq;
            }
            else // đã chọn dịch vụ
            {
                var item = _db.tbl_Dictionary.Find(id);
                var staf = _db.tbl_Partner.AsEnumerable().Where(p => p.DictionaryId == item.Id && p.IsDelete == false).ToList();
                if (staf.Count() > 0)
                {
                    string num = staf.Last().Code.Substring(2);
                    int codenum = Int32.Parse(num);
                    codenum++;
                    kq = item.Note + codenum.ToString("D4");
                }
                else
                {
                    kq = item.Note + "0001";
                }
                return kq;
            }
        }

        public static string QuotationCode()
        {
            var staf = _db.tbl_Quotation.AsEnumerable().ToList();
            if (staf.Count() > 0 && staf.Last() != null)
            {
                string num = staf.Last().Code.Substring(2);
                int codenum = Int32.Parse(num);
                codenum++;
                string newcode = "BG" + codenum.ToString("D4");
                return newcode;
            }
            else
            {
                return "BG0001";
            }
        }

        public static string ProgramCode()
        {
            var staf = _db.tbl_Program.AsEnumerable().ToList();
            if (staf.Count() > 0 && staf.Last() != null)
            {
                string num = staf.Last().Code.Substring(2);
                int codenum = Int32.Parse(num);
                codenum++;
                string newcode = "CT" + codenum.ToString("D4");
                return newcode;
            }
            else
            {
                return "CT0001";
            }
        }

        public static string DocumentCode()
        {
            var staf = _db.tbl_DocumentFile.AsEnumerable().ToList();
            if (staf.Count() > 0 && staf.Last() != null)
            {
                string num = staf.Last().Code.Substring(2);
                int codenum = Int32.Parse(num);
                codenum++;
                string newcode = "TL" + codenum.ToString("D4");
                return newcode;
            }
            else
            {
                return "TL0001";
            }
        }
    }
}