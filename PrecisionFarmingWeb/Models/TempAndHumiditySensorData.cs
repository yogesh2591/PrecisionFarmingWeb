using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionFarmingWeb.Models
{
    public class TempAndHumiditySensorData
    {
        [Key]
        public int ID { get; set; }
        public string SENSOR_ID { get; set; }
        public double TEMP_CELSIUS { get; set; }
        public int SIGNAL_STRENGTH { get; set; }
        public string PUBLISH_AT { get; set; }
        public double TEMP_FAR { get; set; }
        public double HUMIDITY { get; set; }
    }
}
