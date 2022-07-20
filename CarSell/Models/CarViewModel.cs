using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSell.Models
{
    public class CarViewModel
    {
        public Car Car { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }
        public IEnumerable<SelectListItem> SelectBrandListItems(IEnumerable<Brand> brands)
        {
            List<SelectListItem> brandsList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "--Select--",
                Value = "0"
            };
            brandsList.Add(sli);
            foreach (Brand b in brands)
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
        public IEnumerable<SelectListItem> SelectModelListItems(IEnumerable<Model> models)
        {
            List<SelectListItem> modelsList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "--Select--",
                Value = "0"
            };
            modelsList.Add(sli);
            foreach (Model m in models)
            {
                sli = new SelectListItem
                {
                    Text = m.Name,
                    Value = m.Id.ToString()
                };
                modelsList.Add(sli);
            }
            return modelsList;
        }
        public IEnumerable<SelectListItem> SelectCurrencyListItems(IEnumerable<Currency> currencies)
        {
            List<SelectListItem> currenciesList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "--Select--",
                Value = "0"
            };
            currenciesList.Add(sli);
            foreach (Currency c in currencies)
            {
                sli = new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                };
                currenciesList.Add(sli);
            }
            return currenciesList;
        }

        private List<Currency> CList = new List<Currency>();
        private List<Currency> CreateList()
        {
            CList.Add(new Currency("USD", "USD"));
            CList.Add(new Currency("INR", "INR"));
            return CList;
        }

        public CarViewModel()
        {
            Currencies = CreateList();
        }

    }
    public class Currency
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public Currency(String id, String value)
        {
            Id = id;
            Name = value;
        }
    }
}
