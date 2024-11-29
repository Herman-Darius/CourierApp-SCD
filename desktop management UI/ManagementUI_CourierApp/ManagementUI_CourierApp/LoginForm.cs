using Newtonsoft.Json;
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
using System.IdentityModel.Tokens.Jwt;
using ManagementUI_CourierApp.Services;
using ManagementUI_CourierApp.Models;

namespace ManagementUI_CourierApp
{
    public partial class LoginForm : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private const string ApiUrl = "http://localhost:8080/login";
        private const string ApiUrlRegister = "http://localhost:8080/register";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Are you sure you want to exit the application?",
            "Exit Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter the name and password.");
                return;
            }

            var user = new
            {
                username = username,
                password = password
            };
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(ApiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response Data: " + responseData);

                    var authResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(responseData);
                    string authenticationToken = authResponse?.Token;
                    Console.WriteLine("Auth token: " + authenticationToken);
                    

                    if (!string.IsNullOrEmpty(authenticationToken))
                    {
                        AuthTokenService.Token = authenticationToken;
                        string role = JwtHelper.GetRoleFromToken(authenticationToken);
                        Console.WriteLine("Extracted Role: " + role);
                        if (role == "ADMIN")
                        {
                            AdminForm adminForm = new AdminForm(username, authResponse.Token);
                            adminForm.Show();
                            this.Hide();
                        }
                        else if (role == "USER")
                        {
                            MainForm mainForm = new MainForm(username);
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Unknown role. Access denied.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Authentication failed: Token not received.");
                    }
                }
                else
                {
                    MessageBox.Show("Login failed. Check your username and password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }



        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            //las asa pana imi dau seama ce sa fac cu butonu de register
            string username = "admin2";
            string email = "darius.herman21@yahoo.com";
            string password = "admin";

            await RegisterUserAsync(username, email, password);
        }

        private async Task RegisterUserAsync(string username, string email, string password)
        {
            using(HttpClient client = new HttpClient())
            {
                var user = new
                {
                    username = username,
                    email = email,
                    password = password
                };

                var json = JsonConvert.SerializeObject(user);
                Console.WriteLine("Request JSON: " + json);
                MessageBox.Show(json);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync(ApiUrlRegister, content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Registration successful!");
                    }
                    else
                    {
                        MessageBox.Show("Registration failed. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
