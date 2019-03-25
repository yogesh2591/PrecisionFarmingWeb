using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionFarmingWeb.Models
{
    public class Site
    {
        [Key]
        public string SITE_ID { get; set; }
        public string SITE_NAME { get; set; }
        public string SITE_LOCATION { get; set; }
        public string SITE_OWNER { get; set; }
    }
}
