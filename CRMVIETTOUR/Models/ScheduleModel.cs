using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMVIETTOUR.Models
{
    public class ScheduleModel
    {
        public ScheduleModel()
        {
            source = new List<Models.source>();
        }
        public List<source> source { get; set; }
        public string navigate { get; set; }
        public string scale { get; set; }
        public string maxScale { get; set; }
        public string minScale { get; set; }
        public int itemsPerPage { get; set; }
        public bool useCookie { get; set; }
    }
    public class values
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public string label { get; set; }
        public string customClass { get; set; }
    }
    public class source
    {
        public source()
        {
            values = new List<values>();
        }
        public string desc { get; set; }
        public List<values> values { get; set; }
    }
}