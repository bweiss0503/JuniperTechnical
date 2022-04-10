using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniperTechnical.Models
{
    public class Rate
    {
        public string City { get; set; }
        public string City_Rate { get; set; }
        public string Combined_District_Rate { get; set; }
        public string Combined_Rate { get; set; }
        public string Country { get; set; }
        public string Country_Rate { get; set; }
        public string County { get; set; }
        public string County_Rate { get; set; }
        public bool Freight_Taxable { get; set; }
        public string State { get; set; }
        public string State_Rate { get; set; }
        public string Zip { get; set; }
    }

    public class RootRate
    {
        public Rate Rate { get; set; }
    }
}
