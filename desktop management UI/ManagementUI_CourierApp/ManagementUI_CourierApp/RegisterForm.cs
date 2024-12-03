using ManagementUI_CourierApp.Models;
using ManagementUI_CourierApp.Services;
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
                    else
                    {
                        string errorMessage = await responseMessage.Content.ReadAsStringAsync();
                        MessageBox.Show($"Registration failed: {errorMessage}");
                        return false;
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show($"An error occured: {ex.Message}");
                return false;
            }
            

        }
    }
}
