using Exercise.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FE.Services
{
    public class CustomerServices
    {
        private readonly HttpClient _httpClient;

        public CustomerServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CustomerVM>> GetCustomersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CustomerVM>>("api/customers");
        }

        public async Task<CustomerVM> GetCustomerByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CustomerVM>($"api/customers/{id}");
        }

        public async Task AddCustomerAsync(CustomerVM customer)
        {
            await _httpClient.PostAsJsonAsync("api/customers", customer);
        }

        public async Task UpdateCustomerAsync(CustomerVM customer)
        {
            await _httpClient.PutAsJsonAsync($"api/customers/{customer.CustomerID}", customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/customers/{id}");
        }
    }
}
