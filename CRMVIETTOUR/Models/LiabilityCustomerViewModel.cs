using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMVIETTOUR.Models
{
    public class LiabilityCustomerViewModel
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Sale { get; set; }
        public string Guide { get; set; }
        public string Note { get; set; }
        public string Price1 { get; set; }
        public string Date1 { get; set; }
        public string Price2 { get; set; }
        public string Date2 { get; set; }
        public string TotalContract { get; set; }
        public string TotalVisa { get; set; }
        public string TotalReturn { get; set; }
        public string FullNote { get; set; }
        public string IsContract { get; set; }
        public string IsBill { get; set; }
        public string IsPPVS { get; set; }
        public int CustomerId { get; set; }
        public int TourId { get; set; }
    }
}