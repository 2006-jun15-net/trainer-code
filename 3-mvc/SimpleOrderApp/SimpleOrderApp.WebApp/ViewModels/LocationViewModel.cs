using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleOrderApp.WebApp.ViewModels
{
    public class LocationViewModel
    {
        [Display(Name = "Location Name")]
        public string Name { get; set; }

        [Range(0, 99999)]
        public int Stock { get; set; }
    }
}
