using JuniperTechnical.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JuniperTechnical
{
    public class TaxService
    {
        private readonly HttpClient _httpClient;
        private readonly string TaxJarUri = "https://api.taxjar.com/";
        private readonly string Key = "5da2f821eee4035db4771edab942a4cc";

        public TaxService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(TaxJarUri)
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Key);
        }

        public async Task<Rate> GetRatesForLocation(LocationRequest location)
        {
            string queryString = BuildQueryString(location);
            var response = await _httpClient.GetAsync($"v2/rates/{location.Zip}/{BuildQueryString(location)}");
            var content = await response.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<RootRate>(content);

            return root.Rate;
        }

        public async Task<Tax> GetTaxForOrder(OrderRequest order)
        {
            var json = JsonConvert.SerializeObject(order);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("v2/taxes", httpContent);
            var content = await response.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<RootTax>(content);

            return root.Tax;
        }

        private string BuildQueryString(LocationRequest location)
        {
            string queryString = "?";
            if (location.Country != null)
                queryString += "country=" + location.Country + "&";
            if (location.State != null)
                queryString += "state=" + location.State + "&";
            if (location.City != null)
                queryString += "city=" + location.City + "&";
            if (location.Street != null)
                queryString += "street=" + location.Street + "&";

            return queryString.Length > 1 ? queryString : null;
        }
    }
}