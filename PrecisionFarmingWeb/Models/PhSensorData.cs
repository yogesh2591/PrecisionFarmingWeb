using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionFarmingWeb.Models
{
    public class PhSensorData
    {
        [Key]
        public int ID { get; set; }
        public string SENSOR_ID { get; set; }
        public double PH_LEVEL { get; set; }
        public int SIGNAL_STRENGTH { get; set; }
        public DateTime PUBLISH_AT { get; set; }
    }
}
