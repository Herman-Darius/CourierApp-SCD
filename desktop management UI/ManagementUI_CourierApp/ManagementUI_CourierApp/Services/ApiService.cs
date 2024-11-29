using ManagementUI_CourierApp.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ManagementUI_CourierApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private string _jwtToken;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/")
            };
        }

        public void SetJwtToken(string token)
        {
            _jwtToken = token;
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<List<DeliveryPackage>> FetchAllDeliveriesAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(_jwtToken))
                {
                    throw new InvalidOperationException("JWT token is not set. Please log in first.");
                }
                Console.WriteLine(_jwtToken);
                var response = await _httpClient.GetAsync("package/get-all");
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var deliveries = JsonSerializer.Deserialize<List<DeliveryPackage>>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return deliveries ?? new List<DeliveryPackage>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"HTTP Request error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error: {ex.Message}", ex);
            }
        }
    }
}