using System;
using System.Windows.Forms;

namespace Hospital_Management.Views
{
    public partial class SplashForm : Form
    {
        private string[] loadingMessages = new string[]
        {
            "Initializing application...",
            "Loading modules...",
            "Connecting to database...",
            "Preparing user interface...",
            "Almost ready..."
        };

        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            progressBar.Value += 2;

            // Update loading message based on progress
            int messageIndex = progressBar.Value / 25;
            if (messageIndex < loadingMessages.Length)
            {
                lblLoading.Text = loadingMessages[messageIndex];
            }

            // When progress reaches 100, open login form
            if (progressBar.Value >= 100)
            {
                timer.Stop();
                
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();

                // Close splash when login closes
                loginForm.FormClosed += (s, args) => this.Close();
            }
        }
    }
}
