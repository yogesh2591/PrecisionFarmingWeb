using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionFarmingWeb.Models
{
    public class Users
    {
        [Key]
        public string USER_EMAIL { get; set; }
        public string USER_PASSWORD { get; set; }
    }
}
