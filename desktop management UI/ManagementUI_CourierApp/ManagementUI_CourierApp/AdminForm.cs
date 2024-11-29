using ManagementUI_CourierApp.DTOs;
using ManagementUI_CourierApp.Models;
using ManagementUI_CourierApp.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ManagementUI_CourierApp
{
    public partial class AdminForm : Form
    {
        private string _jwtToken;
        private ApiService apiService;
        private List<DeliveryPackage> deliveries;
        private string Token;
        private const string ApiUrl = "http://localhost:8080/package/create";
        private readonly HttpClient _httpClient;

        public AdminForm(string username, string token)
        {
            AuthTokenService.Token = token;
            Token = token;
            InitializeComponent();
            apiService = new ApiService();
            apiService.SetJwtToken(Token);
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080")
            };

        }

        private async void AdminForm_Load_1(object sender, EventArgs e)
        {
           
            
        }

        private async void buttonTest_Click(object sender, EventArgs e)
        {
            string deliveryAddress = "Strada Dornei nr21";
             string email = "darius.face19@yahoo.com";
             string phoneNumber = "1234567890";
             await CreateDummyDelivery(deliveryAddress, email, phoneNumber);

            //var deliveries = await apiService.FetchAllDeliveriesAsync();
           // Console.WriteLine(deliveries.Count);

        }

        private async Task CreateDummyDelivery(string deliveryAddress, string email, string phoneNumber)
        {
            using (HttpClient client = new HttpClient())
            {
                var delivery = new
                {
                    deliveryAddress = deliveryAddress,
                    email = email,
                    phoneNumber = phoneNumber
                };

                var json = JsonConvert.SerializeObject(delivery);
                Console.WriteLine("Request JSON: " + json);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

                try
                {
                    HttpResponseMessage response = await client.PostAsync(ApiUrl, content);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(Token);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Registration successful!");
                    }
                    else
                    {
                        MessageBox.Show($"Registration failed. Status Code: {response.StatusCode}, Response: {responseBody}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        
        // de aici mai am de lucru
        private async Task<string> AssignCourierToAdmin(int courierId, int adminId)
        {
            try
            {
               
                var url = $"/courier/assign?courierId={courierId}&adminId={adminId}";

                var request = new HttpRequestMessage(HttpMethod.Post, url);

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthTokenService.Token);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private async Task<List<CourierDTO>> GetCouriersManagedByAdmin(int adminId)
        {
            var url = $"/courier/{adminId}/couriers";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthTokenService.Token);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();

                var couriers = JsonConvert.DeserializeObject<List<CourierDTO>>(jsonResponse);

                return couriers;
            }
            else
            {
                MessageBox.Show($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                return new List<CourierDTO>();
            }
        }

        private async void btnAssignCourier_Click(object sender, EventArgs e)
        {
            try
            {
                int courierId = int.Parse(textCourierId.Text);
                int adminId = int.Parse(textAdminId.Text);

                if (string.IsNullOrEmpty(AuthTokenService.Token))
                {
                    MessageBox.Show("You are not authenticated. Please log in first.");
                    return;
                }

                string result = await AssignCourierToAdmin(courierId, adminId);
                richTextBox1.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnGetCouriers_Click(object sender, EventArgs e)
        {
            try
            {
                int adminId = int.Parse(textAdminId.Text);

                if (string.IsNullOrEmpty(AuthTokenService.Token))
                {
                    MessageBox.Show("You are not authenticated. Please log in first.");
                    return;
                }

                List<CourierDTO> couriers = await GetCouriersManagedByAdmin(adminId);

                listBoxCouriers.Items.Clear();

                foreach (CourierDTO courier in couriers)
                {
                    listBoxCouriers.Items.Add(courier.Username);
                }

                if (listBoxCouriers.Items.Count > 0)
                {
                    listBoxCouriers.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _httpClient.Dispose();
            _jwtToken = null;
        }


    }
}
