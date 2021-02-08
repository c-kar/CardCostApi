using CardCost.Core.Entities;
using System.Collections.Generic;

namespace CardCost.Infrastructure.Data.MockData
{
    public class IINListMockData
    {
        public List<Iinlist> Iinlist { get; set; }
        public static IINListMockData Current { get; } = new IINListMockData();

        public IINListMockData()
        {
            Iinlist = new List<Iinlist>
            {
                new Iinlist()
                {
                    Id = 1,
                    Country = "GE",
                    Iin = "430765"
                },
                new Iinlist()
                {
                    Id = 2,
                    Country = "DK",
                    Iin = "430678"
                },
                new Iinlist()
                {
                    Id = 3,
                    Country = "GR",
                    Iin = "430589"
                }
            };
        }
    }
}
