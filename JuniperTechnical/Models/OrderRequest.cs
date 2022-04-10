using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniperTechnical.Models
{
    public class NexusAddress
    {
        public string id { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string street { get; set; }
    }

    public class OrderLineItem
    {
        public string id { get; set; }
        public int quantity { get; set; }
        public string product_tax_code { get; set; }
        public int unit_price { get; set; }
        public int discount { get; set; }
    }

    public class OrderRequest
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }
        public string from_city { get; set; }
        public string from_street { get; set; }
        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        public string to_city { get; set; }
        public string to_street { get; set; }
        public int amount { get; set; }
        public double shipping { get; set; }
        public List<NexusAddress> nexus_addresses { get; set; }
        public List<OrderLineItem> line_items { get; set; }
    }
}