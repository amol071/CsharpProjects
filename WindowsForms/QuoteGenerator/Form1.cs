using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuoteGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Fetch a random quote when the form loads
            GetRandomQuote();
        }

        private async void GetRandomQuote()
        {
            try
            {
                // Send HTTP request to fetch a random quote
                string quote = await FetchRandomQuoteAsync();

                // Display the quote in label1
                label1.Text = quote;
            }
            catch (Exception ex)
            {
                // Handle the exception by generating logs
                LogException(ex);
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<string> FetchRandomQuoteAsync()
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://theysaidso.p.rapidapi.com/quote/random?language=en"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", "273ecb3c71msha6a92356031a373p1f6e71jsn04a98d6901a8" },
                        { "X-RapidAPI-Host", "theysaidso.p.rapidapi.com" },
                    },
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        private void LogException(Exception ex)
        {
            try
            {
                // Get the current date
                string currentDate = DateTime.Now.ToString("ddMMyyyy");

                // Create or get the path for the log folder
                string logFolderPath = Path.Combine(Application.StartupPath, "log");
                if (!Directory.Exists(logFolderPath))
                {
                    Directory.CreateDirectory(logFolderPath);
                }

                // Create or open the log file for the current date
                string logFilePath = Path.Combine(logFolderPath, $"log_{currentDate}.txt");
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    // Write the exception details to the log file
                    writer.WriteLine($"[{DateTime.Now}] Exception: {ex.Message}");
                    writer.WriteLine($"StackTrace: {ex.StackTrace}");
                    writer.WriteLine(); // Add an empty line for better readability
                }
            }
            catch (Exception)
            {
                // Ignore any exceptions that occur during logging to prevent further issues
            }
        }
    }
}
