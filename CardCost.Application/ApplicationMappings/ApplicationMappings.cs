using AutoMapper;

namespace CardCost.Application.ApplicationMappings
{
    public class ApplicationMappings : Profile
    {
        public ApplicationMappings()
        {
            AccessUserMappings.Apply(this);
            IINListMappings.Apply(this);
            CCMatrixMapping.Apply(this);
        }
    }
}
