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
using System.Net.Http.Json;
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
        private string authToken;
        private const string ApiUrl = "http://localhost:8080/package/create";
        private readonly string localHostAddress = "http://localhost:8080";
        private readonly HttpClient _httpClient;
        private Dictionary<string, Courier> couriersDict = new Dictionary<string, Courier>();
        private readonly string CURRENT_USER;

        public AdminForm(string username, string token)
        {
            AuthTokenService.Token = token;
            authToken = token;
            InitializeComponent();
            apiService = new ApiService();
            apiService.SetJwtToken(authToken);
            CURRENT_USER = username;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080")
            };

        }

        private async void AdminForm_Load_1(object sender, EventArgs e)
        {
            labelShowCurrentUser.Text = "Connected as: " + CURRENT_USER;
            await PopulateCourierComboBoxes();

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

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

                try
                {
                    HttpResponseMessage response = await client.PostAsync(ApiUrl, content);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(authToken);

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

        private async void btnAssignCourier_Click(object sender, EventArgs e)
        {
            try
            {
                string courierUsername = comboBoxCourier.SelectedItem.ToString();
                //string managerUsername = comboBoxManager.SelectedItem.ToString();

                if (string.IsNullOrEmpty(AuthTokenService.Token))
                {
                    MessageBox.Show("You are not authenticated.");
                    return;
                }

                string result = await AssignCourierToManager(courierUsername);
                await PopulateCourierComboBoxes();
                MessageBox.Show(result);


            } catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnGetCouriers_Click(object sender, EventArgs e)
        {
            /*try
            {
                int adminId = int.Parse(textAdminId.Text);

                if (string.IsNullOrEmpty(AuthTokenService.Token))
                {
                    MessageBox.Show("You are not authenticated. Please log in first.");
                    return;
                }

                List<CourierDTO> couriers = await GetCouriersManagedByAdmin(adminId);

                listBoxCourierDetails.Items.Clear();

                foreach (CourierDTO courier in couriers)
                {
                    listBoxCourierDetails.Items.Add(courier.Username);
                }

                if (listBoxCourierDetails.Items.Count > 0)
                {
                    listBoxCourierDetails.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }*/
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _httpClient.Dispose();
            _jwtToken = null;
        }

        private async void buttonRemoveManagement_Click(object sender, EventArgs e)
        {
            try
            {
                string courierUsername = comboBoxCourier.SelectedItem.ToString();

                if (string.IsNullOrEmpty(AuthTokenService.Token))
                {
                    MessageBox.Show("You are not authenticated. Please log in first.");
                    return;
                }

                string result = await RevokeManagement(courierUsername);
                await PopulateCourierComboBoxes();
                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void comboBoxManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedUsername = comboBoxManager.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedUsername) && couriersDict.TryGetValue(selectedUsername, out var selectedCourier))
            {
                DisplayCourierDetails(selectedCourier);
            }
        }

        private void comboBoxCourier_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedUsername = comboBoxCourier.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedUsername) && couriersDict.TryGetValue(selectedUsername, out var selectedCourier))
            {
                DisplayCourierDetails(selectedCourier);
            }

        }

        private async void buttonPromoteCourier_Click(object sender, EventArgs e)
        {
            string courierUsername = comboBoxCourier.SelectedItem.ToString();
            string result = await PromoteCourier(courierUsername);
            await PopulateCourierComboBoxes();
            MessageBox.Show(result);
        }

        private async void buttonDemoteManager_Click(object sender, EventArgs e)
        {
            string courierUsername = comboBoxManager.SelectedItem.ToString();
            string result = await DemoteCourier(courierUsername);
            await PopulateCourierComboBoxes();
            MessageBox.Show(result);
        }

        private async void buttonDeleteCourier_Click(object sender, EventArgs e)
        {
            string courierUsername = comboBoxCourier.SelectedItem.ToString();
            string result = await DeleteCourier(courierUsername);
            await PopulateCourierComboBoxes();
            MessageBox.Show(result);
        }
        //My methods
        private async Task<string> DeleteCourier(string courierUsername)
        {
            var url = $"/courier/delete/{courierUsername}";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthTokenService.Token);

            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadAsStringAsync()
                : $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
        }
        private async Task<string> DemoteCourier(string courierUsername)
        {
            var url = $"/courier/{courierUsername}/demote";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthTokenService.Token);

            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadAsStringAsync()
                : $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
        }
        private async Task<string> PromoteCourier(string courierUsername)
        {
            var url = $"/courier/{courierUsername}/promote";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthTokenService.Token);

            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadAsStringAsync()
                : $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
        }
        private async Task<string> RevokeManagement(string courierUsername)
        {
            try
            {
                var url = $"/courier/revoke-management/{courierUsername}";
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
        private async Task<string> AssignCourierToManager(string courierUsername)
        {
            try
            {
                var url = $"/courier/take-management/{courierUsername}";
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
               // MessageBox.Show($"Error: {ex.Message}");
                return $"Error: {ex.Message}";
            }
        }
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
        public async Task<List<Courier>> FetchCouriersByRole(string role)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(localHostAddress);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

                HttpResponseMessage response = await client.GetAsync($"/courier/get-all/{role}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<Courier>>();
                }
                else
                {
                    MessageBox.Show($"Failed to fetch couriers for role {role}: {response.StatusCode}");
                    return new List<Courier>();
                }
            }
        }
        public async Task PopulateCourierComboBoxes()
        {
            try
            {

                listBoxCourierDetails.Items.Clear();
                couriersDict.Clear();
                var adminCouriers = await FetchCouriersByRole("ADMIN");
                comboBoxManager.Items.Clear();
                comboBoxManager.Text = string.Empty;
                foreach (var courier in adminCouriers)
                {
                    couriersDict[courier.Username] = courier;
                    comboBoxManager.Items.Add($"{courier.Username}");
                }

                var userCouriers = await FetchCouriersByRole("USER");
                comboBoxCourier.Items.Clear();
                comboBoxCourier.Text = string.Empty;
                foreach (var courier in userCouriers)
                {
                    couriersDict[courier.Username] = courier;
                    comboBoxCourier.Items.Add($"{courier.Username}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void DisplayCourierDetails(Courier courier)
        {
            listBoxCourierDetails.Items.Clear();

            listBoxCourierDetails.Items.Add($"First Name: {courier.FirstName}");
            listBoxCourierDetails.Items.Add($"Last Name: {courier.LastName}");
            listBoxCourierDetails.Items.Add($"Username: {courier.Username}");
            listBoxCourierDetails.Items.Add($"Email: {courier.Email}");
            listBoxCourierDetails.Items.Add($"Role: {courier.Role}");
            if (courier.ManagerUsername != null)
            {
                listBoxCourierDetails.Items.Add($"Manager Username: {courier.ManagerUsername}");
            }
            else
            {
                listBoxCourierDetails.Items.Add("Manager Username: None");
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

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                AuthTokenService.Token = string.Empty;
                authToken = null;
                MessageBox.Show("You have been logged out successfully!");

                this.Close();

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            
        }
    }
}
