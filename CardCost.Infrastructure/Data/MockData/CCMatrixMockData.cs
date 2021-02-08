using CardCost.Core.Entities;
using System.Collections.Generic;

namespace CardCost.Infrastructure.Data.MockData
{
    public class CCMatrixMockData
    {
        public List<Ccmatrix> CCMatrix { get; set; }
        public static CCMatrixMockData Current { get; } = new CCMatrixMockData();

        public CCMatrixMockData()
        {
            CCMatrix = new List<Ccmatrix>
            {
                new Ccmatrix()
                {
                    Id = 1,
                    Country = "GE",
                    Cost = 12
                },
                new Ccmatrix()
                {
                    Id = 2,
                    Country = "ES",
                    Cost = 15
                },
                new Ccmatrix()
                {
                    Id = 3,
                    Country = "OTHERS",
                    Cost = 10
                }
            };
        }
    }
}
