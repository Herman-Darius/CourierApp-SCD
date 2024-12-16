using ManagementUI_CourierApp.Models;
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
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementUI_CourierApp
{
    public partial class MainForm : Form
    {
        private readonly string authToken;
        string currentUser = null;
        private readonly string localHostAddress = "http://localhost:8080";
        private Dictionary<string, DeliveryPackage> packageDict = new Dictionary<string, DeliveryPackage>();
        public MainForm(string username, string token)
        {
            currentUser = username;
            authToken = token;
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await PopulateComboBoxes();
            labelShowCurrentUser.Text = string.Empty;
            labelShowCurrentUser.Text = "Connected as: " + currentUser;
        }

        private void labelShowCurrentUser_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }

        }

        //My methods
       
        
        private void comboBoxNewDeliveries_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAddress = comboBoxNewDeliveries.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedAddress) && packageDict.TryGetValue(selectedAddress, out var selectedPackage))
            {
                DisplayPackageDetails(selectedPackage);
            }
        }


        private async void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedAddress = comboBoxNewDeliveries.SelectedItem?.ToString();
                Console.WriteLine("Asta e adresa varule: " + selectedAddress);

                if (string.IsNullOrEmpty(selectedAddress))
                {
                    MessageBox.Show("Please select a delivery address");
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(localHostAddress);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

                    string apiUrl = $"package/accept-delivery/{Uri.EscapeDataString(selectedAddress)}";

                    var content = new StringContent("{}", Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await client.PostAsync(apiUrl, content);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Delivery accepted successfully!");

                        await PopulateComboBoxes();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to accept delivery: {responseMessage.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while accepting the delivery: {ex.Message}");
            }


        }

        private async void buttonRefresh_Click(object sender, EventArgs e)
        {
            await PopulateComboBoxes();
        }

        private async void buttonComplete_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedAddress = comboBoxMyDeliveries.SelectedItem?.ToString();
                Console.WriteLine("Asta e adresa varule: " + selectedAddress);

                if (packageDict.TryGetValue(selectedAddress, out DeliveryPackage selectedPackage))
                {
                    if (selectedPackage.status.Equals("DELIVERED", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("You can't complete a delivered package.");
                        return;
                    }
                }

                if (string.IsNullOrEmpty(selectedAddress))
                {
                    MessageBox.Show("Please select a delivery address");
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(localHostAddress);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

                    string apiUrl = $"package/complete-delivery/{Uri.EscapeDataString(selectedAddress)}";

                    var content = new StringContent("{}", Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await client.PostAsync(apiUrl, content);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Delivery completed successfully!");

                        await PopulateComboBoxes();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to completed delivery: {responseMessage.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while completing the delivery: {ex.Message}");
            }

        }


        private void comboBoxMyDeliveries_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAddress = comboBoxMyDeliveries.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedAddress) && packageDict.TryGetValue(selectedAddress, out var selectedPackage))
            {
               DisplayPackageDetails(selectedPackage);
            }
        }
        private void DisplayPackageDetails(DeliveryPackage package)
        {
            listBoxCouriers.Items.Clear();
            //MessageBox.Show(package.ToString());
            listBoxCouriers.Items.Add($"Delivery Address: {package.deliveryAddress}");
            listBoxCouriers.Items.Add($"Email: {package.email}");
            listBoxCouriers.Items.Add($"Phone Number: {package.phoneNumber}");
            listBoxCouriers.Items.Add($"Pay on Delivery: {package.payOnDelivery.ToString()}");
            listBoxCouriers.Items.Add($"Status: {package.status}");

            if (package.courier != null)
            {
                listBoxCouriers.Items.Add($"Courier Username: {package.courier.Username}");
                listBoxCouriers.Items.Add($"Courier Name: {package.courier.FirstName} {package.courier.LastName}");
            }
            else
            {
                listBoxCouriers.Items.Add("Courier: Not Assigned");
            }
        }
        public async Task<DeliveryPackage> FetchPackageDetails(string deliveryAddress)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

                string apiUrl = $"package/details/{Uri.EscapeDataString(deliveryAddress)}";

                HttpResponseMessage responseMessage = await client.GetAsync(apiUrl);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseContent = await responseMessage.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Response: {responseContent}");

                    try
                    {
                        return await responseMessage.Content.ReadFromJsonAsync<DeliveryPackage>();
                    }
                    catch (JsonException jsonEx)
                    {
                        MessageBox.Show($"JSON Deserialization Error: {jsonEx.Message}");
                        Console.WriteLine(jsonEx.StackTrace);
                    }
                }
                else
                {
                    MessageBox.Show($"Failed to fetch package details: {responseMessage.StatusCode} - {responseMessage.ReasonPhrase}");
                }
            }
            return null;
        }
        public async Task<List<DeliveryPackage>> FetchDeliveries(string apiUrl)
        {
            //packageDict.Clear();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

                HttpResponseMessage responseMessage = await client.GetAsync(apiUrl);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseContent = await responseMessage.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Response: {responseContent}");

                    try
                    {
                        return await responseMessage.Content.ReadFromJsonAsync<List<DeliveryPackage>>();

                    }
                    catch (JsonException jsonEx)
                    {
                        MessageBox.Show($"JSON Deserialization Error: {jsonEx.Message}");
                        Console.WriteLine(jsonEx.StackTrace);
                    }
                }
                else if (responseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show($"Authorization error: Access is denied. Please check your permissions. {responseMessage}");
                }
                
                else
                {
                    MessageBox.Show($"Failed to fetch data: {responseMessage.StatusCode}");
                }
                return new List<DeliveryPackage>();
            }
        }
        public async Task PopulateComboBoxes()
        {
            try
            {
                var newDeliveries = await FetchDeliveries("/package/new-deliveries");
                packageDict.Clear();
                listBoxCouriers.Items.Clear();
                comboBoxNewDeliveries.Items.Clear();
                comboBoxMyDeliveries.Items.Clear();
                comboBoxMyDeliveries.Text = string.Empty;
                comboBoxNewDeliveries.Text = string.Empty;
                foreach (var delivery in newDeliveries)
                {
                    comboBoxNewDeliveries.Items.Add(delivery.deliveryAddress);
                    packageDict[delivery.deliveryAddress] = delivery;
                }

                var myDeliveries = await FetchDeliveries("/package/my-deliveries");

                foreach (var delivery in myDeliveries)
                {
                    comboBoxMyDeliveries.Items.Add(delivery.deliveryAddress);
                    packageDict[delivery.deliveryAddress] = delivery;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
