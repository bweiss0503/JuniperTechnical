using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniperTechnical.Models
{
    public class TaxLineItem
    {
        public double City_Amount { get; set; }
        public double City_Tax_Rate { get; set; }
        public double City_Taxable_Amount { get; set; }
        public double Combined_Tax_Rate { get; set; }
        public double County_Amount { get; set; }
        public double County_Tax_Rate { get; set; }
        public double County_Taxable_Amount { get; set; }
        public string Id { get; set; }
        public double Special_District_Amount { get; set; }
        public double Special_District_Taxable_Amount { get; set; }
        public double Special_Tax_Rate { get; set; }
        public double State_Amount { get; set; }
        public double State_Sales_Tax_Rate { get; set; }
        public double State_Taxable_Amount { get; set; }
        public double Tax_Collectable { get; set; }
        public double Taxable_Amount { get; set; }
    }

    public class Breakdown
    {
        public double City_Tax_Collectable { get; set; }
        public double City_Tax_Rate { get; set; }
        public double City_Taxable_Amount { get; set; }
        public double Combined_Tax_Rate { get; set; }
        public double County_Tax_Collectable { get; set; }
        public double County_Tax_Rate { get; set; }
        public double County_Taxable_Amount { get; set; }
        public List<TaxLineItem> Line_Items { get; set; }
        public double Special_District_Tax_Collectable { get; set; }
        public double Special_District_Taxable_Amount { get; set; }
        public double Special_Tax_Rate { get; set; }
        public double State_Tax_Collectable { get; set; }
        public double State_Tax_Rate { get; set; }
        public double State_Taxable_Amount { get; set; }
        public double Tax_Collectable { get; set; }
        public double Taxable_Amount { get; set; }
    }

    public class Jurisdictions
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string State { get; set; }
    }

    public class Tax
    {
        public double Amount_To_Collect { get; set; }
        public Breakdown Breakdown { get; set; }
        public bool Freight_Taxable { get; set; }
        public bool Has_Nexus { get; set; }
        public Jurisdictions Jurisdictions { get; set; }
        public double Order_Total_Amount { get; set; }
        public double Rate { get; set; }
        public double Shipping { get; set; }
        public string Tax_Source { get; set; }
        public double Taxable_Amount { get; set; }
    }

    public class RootTax
    {
        public Tax Tax { get; set; }
    }
}
