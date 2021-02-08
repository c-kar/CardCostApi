using AutoMapper;
using CardCost.Core.Models.Base;
using CardCost.Core.Entities;

namespace CardCost.Application.ApplicationMappings
{
    public static class CCMatrixMapping
    {
        public static void Apply(Profile profile)
        {
            profile.CreateMap<BaseModel, Ccmatrix>();
        }
    }
}
