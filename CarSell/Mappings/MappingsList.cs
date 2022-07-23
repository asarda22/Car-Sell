using AutoMapper;
using CarSell.Controllers.Resources;
using CarSell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSell.Mappings
{
    public class MappingsList:Profile
    {
        public MappingsList()
        {
            CreateMap<Model, ModelResource>();
        }
    }
}
