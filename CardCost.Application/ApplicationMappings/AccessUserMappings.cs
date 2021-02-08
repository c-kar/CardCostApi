using AutoMapper;
using CardCost.Core.Models;
using CardCost.Core.Entities;

namespace CardCost.Application.ApplicationMappings
{
    public static class AccessUserMappings
    {
        public static void Apply(Profile profile)
        {
            profile.CreateMap<AccessUserInput, AccessUser>();
            profile.CreateMap<AccessUser, AccessUserInput>();
        }
    }
}
