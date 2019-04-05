using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrecisionFarmingWeb.Models;

namespace PrecisionFarmingWeb.Controllers
{
    [Route("api/Sites")]
    public class SItesController : Controller
    {
        public ActionResult GetAction()
        {
            try

            {
                using (var dbContext = new DatabaseContext())
                {

                    var sitesData = (from site in dbContext.SITES
                                     select new
                                     {
                                         site.SITE_ID,
                                         site.SITE_LOCATION,
                                         site.SITE_NAME,
                                         site.SITE_OWNER
                                     }).ToList();

                    if (sitesData != null)
                    {
                        return Ok(sitesData);
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