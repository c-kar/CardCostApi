using AutoMapper;
using CardCost.Core.Models;
using CardCost.Core.Entities;

namespace CardCost.Application.ApplicationMappings
{
    public static class IINListMappings
    {
        public static void Apply(Profile profile)
        {
            profile.CreateMap<CardCostModel, Iinlist>();
        }
    }
}
