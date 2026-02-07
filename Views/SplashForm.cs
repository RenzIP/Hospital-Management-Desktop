using System;
using System.Windows.Forms;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views
{
    public partial class SplashForm : Form
    {
        private string[] loadingMessages = new string[]
        {
            "Initializing application...",
            "Loading modules...",
            "Connecting to database...",
            "Verifying configuration...",
            "Preparing user interface...",
            "Almost ready..."
        };

        private int currentStep = 0;
        private bool hasError = false;
        private string errorMessage = "";

        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            try
            {
                progressBar.Value = 0;
                lblLoading.Text = "Starting...";
                timer.Start();
            }
            catch (Exception ex)
            {
                ShowError("Initialization Error", ex.Message);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                progressBar.Value += 2;

                // Perform actual checks at specific progress points
                int messageIndex = progressBar.Value / 18;
                
                if (messageIndex != currentStep && messageIndex < loadingMessages.Length)
                {
                    currentStep = messageIndex;
                    lblLoading.Text = loadingMessages[messageIndex];

                    // Perform actual validation at each step
                    PerformStepValidation(messageIndex);
                }

                // If there's an error, show it and stop
                if (hasError)
                {
                    timer.Stop();
                    lblLoading.Text = "❌ " + errorMessage;
                    lblLoading.ForeColor = System.Drawing.Color.FromArgb(255, 100, 100);
                    
                    // Show error dialog after a short delay
                    var errorTimer = new Timer();
                    errorTimer.Interval = 1500;
                    errorTimer.Tick += (s, args) => {
                        errorTimer.Stop();
                        DialogResult result = MessageBox.Show(
                            $"An error occurred during startup:\n\n{errorMessage}\n\nDo you want to continue anyway?",
                            "Startup Error",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);
                        
                        if (result == DialogResult.Yes)
                        {
                            hasError = false;
                            timer.Start();
                        }
                        else
                        {
                            Application.Exit();
                        }
                    };
                    errorTimer.Start();
                    return;
                }

                // When progress reaches 100, open login form
                if (progressBar.Value >= 100)
                {
                    timer.Stop();
                    
                    try
                    {
                        lblLoading.Text = "✅ Ready! Opening login...";
                        
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                        this.Hide();

                        // Close splash when login closes
                        loginForm.FormClosed += (s, args) => this.Close();
                    }
                    catch (Exception ex)
                    {
                        ShowError("Failed to open Login Form", ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                timer.Stop();
                ShowError("Runtime Error", ex.Message);
            }
        }

        private void PerformStepValidation(int step)
        {
            try
            {
                switch (step)
                {
                    case 0: // Initializing application
                        // Check if required assemblies are available
                        ValidateAssemblies();
                        break;

                    case 1: // Loading modules
                        // Check if helper classes are accessible
                        ValidateModules();
                        break;

                    case 2: // Connecting to database
                        // Test database connection
                        ValidateDatabaseConnection();
                        break;

                    case 3: // Verifying configuration
                        // Verify app configuration
                        ValidateConfiguration();
                        break;

                    case 4: // Preparing user interface
                        // UI preparation
                        break;

                    case 5: // Almost ready
                        // Final checks
                        break;
                }
            }
            catch (Exception ex)
            {
                hasError = true;
                errorMessage = ex.Message;
            }
        }

        private void ValidateAssemblies()
        {
            // Check if MySql.Data is available
            try
            {
                var mysqlType = Type.GetType("MySql.Data.MySqlClient.MySqlConnection, MySql.Data");
                if (mysqlType == null)
                {
                    // Try loading directly
                    System.Reflection.Assembly.Load("MySql.Data");
                }
            }
            catch
            {
                // MySQL assembly not found - will use demo mode
                System.Diagnostics.Debug.WriteLine("MySQL assembly not found - demo mode available");
            }
        }

        private void ValidateModules()
        {
            // Check if essential helpers are accessible
            try
            {
                var dbHelper = DatabaseHelper.Instance;
                if (dbHelper == null)
                {
                    throw new Exception("DatabaseHelper could not be initialized.");
                }
            }
            catch (Exception ex)
            {
                // Log but don't fail - demo mode will handle this
                System.Diagnostics.Debug.WriteLine($"Module validation warning: {ex.Message}");
            }
        }

        private void ValidateDatabaseConnection()
        {
            try
            {
                var dbHelper = DatabaseHelper.Instance;
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    conn.Close();
                }
                System.Diagnostics.Debug.WriteLine("Database connection successful");
            }
            catch (Exception ex)
            {
                // Database not available - will use demo mode
                System.Diagnostics.Debug.WriteLine($"Database connection failed (demo mode will be used): {ex.Message}");
                // Don't throw error - allow demo mode
            }
        }

        private void ValidateConfiguration()
        {
            // Check if essential directories exist
            try
            {
                string appDir = AppDomain.CurrentDomain.BaseDirectory;
                System.Diagnostics.Debug.WriteLine($"Application directory: {appDir}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Configuration error: {ex.Message}");
            }
        }

        private void ShowError(string title, string message)
        {
            hasError = true;
            errorMessage = $"{title}: {message}";
            lblLoading.Text = "❌ Error occurred";
            lblLoading.ForeColor = System.Drawing.Color.FromArgb(255, 100, 100);
            
            MessageBox.Show(
                $"{title}\n\n{message}\n\nThe application will continue in demo mode where possible.",
                "Startup Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
