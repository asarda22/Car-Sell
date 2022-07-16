using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSell.Models
{
    public class ModelViewModel
    {
        public Model Model { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<SelectListItem> SelectListItems(IEnumerable<Brand> brands)
        {
            List<SelectListItem> brandsList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "--Select--",
                Value = "0"
            };
            brandsList.Add(sli);
            foreach(Brand b in brands)
            {
                sli = new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                };
                brandsList.Add(sli);
            }
            return brandsList;
        }
    }
}
