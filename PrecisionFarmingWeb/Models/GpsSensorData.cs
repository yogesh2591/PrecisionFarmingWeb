using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionFarmingWeb.Models
{
    public class GpsSensorData
    {
        [Key]
        public int ID { get; set; }
        public string SENSOR_ID { get; set; }
        public double LATITUDE { get; set; }
        public double LONGITUDE { get; set; }
        public int SIGNAL_STRENGTH { get; set; }
        public string PUBLISH_AT { get; set; }
    }
}
