using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCost.Api.Options.Swagger
{
    public class SwaggerOptions
    {
        public const string SwaggerConfigKey = "SwaggerOptions";

        public string Route { get; set; }
        public string UIEndpoint { get; set; }
        public string Description { get; set; }
    }
}
