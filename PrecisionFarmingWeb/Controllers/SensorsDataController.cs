using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrecisionFarmingWeb.Models;

namespace PrecisionFarmingWeb.Controllers
{
  
    public class SensorsDataController : Controller
    {
        [Route("api/SensorData/GPS")]
        [HttpGet]
        public IActionResult GetSitesGPSSensorsData(string SITE_ID)
        {
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var GpsSensorData = (from gps in dbContext.GPS_SENSOR
                                         join gpsdata in dbContext.GPS_SENSOR_DATA on
                                         gps.SENSOR_ID equals gpsdata.SENSOR_ID
                                         where (gps.CURRENT_READING_SEQ_NO == gpsdata.ID) && (gps.SITE_ID == SITE_ID)
                                         select new
                                         {
                                             gps.SENSOR_ID,
                                             gps.SENSOR_STATUS,
                                             gpsdata.LATITUDE,
                                             gpsdata.LONGITUDE,
                                             gpsdata.SIGNAL_STRENGTH,
                                             gpsdata.PUBLISH_AT
                                         }).ToList();

                    if (GpsSensorData != null || GpsSensorData.Count == 0)
                    {
                        return Ok(GpsSensorData);
                    }
                    else
                    {
                        return NotFound("No Data Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        //[Route("api/SensorData/GPS/Date")]
        //[HttpPost]
        //public IActionResult GetSitesGPSSensorsDataByDate([FromBody]Filter filter)
        //{
        //    try
        //    {
        //        using (var dbContext = new DatabaseContext())
        //        {
        //            var GpsSensorData = (from gps in dbContext.GPS_SENSOR
        //                                 join gpsdata in dbContext.GPS_SENSOR_DATA on
        //                                 gps.SENSOR_ID equals gpsdata.SENSOR_ID
        //                                 where (gps.SITE_ID == filter.SiteID) && (gpsdata.PUBLISH_AT > DateTime.Parse(filter.FromDate) && gpsdata.PUBLISH_AT < DateTime.Parse( filter.ToDate)) 
        //                                 select new
        //                                 {
        //                                     gps.SENSOR_ID,
        //                                     gps.SENSOR_STATUS,
        //                                     gpsdata.LATITUDE,
        //                                     gpsdata.LONGITUDE,
        //                                     gpsdata.SIGNAL_STRENGTH,
        //                                     gpsdata.PUBLISH_AT
        //                                 }).ToList();

        //            if (GpsSensorData != null || GpsSensorData.Count == 0)
        //            {
        //                return Ok(GpsSensorData);
        //            }
        //            else
        //            {
        //                return NotFound("No Data Found");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
        //    }
        //}

        [Route("api/SensorData/PH")]
        [HttpGet]
        public IActionResult GetSitesPHSensorsData(string SITE_ID)
        {
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var PhSensorData = (from ph in dbContext.PH_SENSOR
                                         join phdata in dbContext.PH_SENSOR_DATA on
                                         ph.SENSOR_ID equals phdata.SENSOR_ID
                                         where (ph.CURRENT_READING_SEQ_NO == phdata.ID) && (ph.SITE_ID == SITE_ID)
                                         select new
                                         {
                                             ph.SENSOR_ID,
                                             ph.SENSOR_STATUS,
                                             phdata.PH_LEVEL,
                                             phdata.SIGNAL_STRENGTH,
                                             phdata.PUBLISH_AT
                                         }).ToList();

                    if (PhSensorData != null || PhSensorData.Count == 0)
                    {
                        return Ok(PhSensorData);
                    }
                    else
                    {
                        return NotFound("No Data Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("api/SensorData/TH")]
        [HttpGet]
        public IActionResult GetSitesTHSensorsData(string SITE_ID)
        {
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var ThSensorData = (from th in dbContext.TEMP_HUMIDITY_SENSOR
                                         join thdata in dbContext.TEMP_HUMIDITY_SENSOR_DATA on
                                         th.SENSOR_ID equals thdata.SENSOR_ID
                                         where (th.CURRENT_READING_SEQ_NO == thdata.ID) && (th.SITE_ID == SITE_ID)
                                         select new
                                         {
                                             th.SENSOR_ID,
                                             th.SENSOR_STATUS,
                                             thdata.TEMP_CELSIUS,
                                             thdata.TEMP_FAR,
                                             thdata.HUMIDITY,
                                             thdata.SIGNAL_STRENGTH,
                                             thdata.PUBLISH_AT
                                         }).ToList();

                    if (ThSensorData != null || ThSensorData.Count == 0)
                    {
                        return Ok(ThSensorData);
                    }
                    else
                    {
                        return NotFound("No Data Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}