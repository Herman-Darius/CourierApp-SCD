using ManagementUI_CourierApp.Models;
using ManagementUI_CourierApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementUI_CourierApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to leave?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text) ||
            string.IsNullOrWhiteSpace(textBoxPassword.Text) ||
            string.IsNullOrWhiteSpace(textBoxConfirmPassword.Text) ||
            string.IsNullOrWhiteSpace(textBoxEmailAddress.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }
            if (!IsValidEmail(textBoxEmailAddress.Text))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            
            if (!IsValidPassword(textBoxPassword.Text))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain one uppercase letter, one number, and one special character.");
                return;
            }
            if (textBoxPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }
            Courier newCourier = new Courier
            {
                Username = textBoxUsername.Text,
                Password = textBoxPassword.Text,
                FirstName = textBoxFirstName.Text,
                LastName = textBoxLastName.Text,
                Email = textBoxEmailAddress.Text
            };

            bool success = await Register(newCourier);
            if (success)
            {
                this.Close();
            }
        }

        //My methods
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            return Regex.IsMatch(email, emailPattern);
        }
        private bool IsValidPassword(string password)
        {
            string passwordPattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
            return Regex.IsMatch(password, passwordPattern);
        }

        private bool IsValidUsername(string username)
        {
            string usernamePattern = @"^[a-zA-Z0-9]{5,15}$";
            return Regex.IsMatch(username, usernamePattern);
        }
        public async Task<bool> Register(Courier newCourier)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8080");
                    HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/register", newCourier);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Registration successful!");
                        return true;
                    }
                    else if (responseMessage.StatusCode == HttpStatusCode.Conflict)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.");
                        return false;
                    }
                    else
                    {
                        string errorMessage = await responseMessage.Content.ReadAsStringAsync();
                        if (string.IsNullOrWhiteSpace(errorMessage))
                        {
                            errorMessage = "Username already exists.";
                        }
                        MessageBox.Show($"Registration failed: {errorMessage}");

                        return false;
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show($"An error occured: {ex.Message}");
                return false;
            }
            

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
