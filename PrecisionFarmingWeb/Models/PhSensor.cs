using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionFarmingWeb.Models
{
    public class PhSensor
    {
        [Key]
        public int GID { get; set; }
        public string SENSOR_ID { get; set; }
        public double SENSOR_STATUS { get; set; }
        public int CURRENT_READING_SEQ_NO { get; set; }
        public string SITE_ID { get; set; }
    }
}
