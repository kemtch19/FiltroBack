using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FiltroBack.Services
{
    public class SlackNotifier
    {
        private readonly HttpClient _httpClient;
        private readonly string _webhookUrl;
        public SlackNotifier(HttpClient httpClient, string webhookUrl)
        {
            _webhookUrl = webhookUrl;
            _httpClient = httpClient;
        }
        public async Task NotifyAsync(string message)
        {
            // Configuración del mensaje hacia slack
            var payload = new { text = $"‼️Actualmente tenemos un bug en proceso.. \n\nEl cual tiene como error: {message} \n\n Fecha y hora: {DateTime.Now}" };
            var jsonPayload = JsonContent.SerializeObject(payload);
            var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            //var client = new SlackTaskClient(_webhookUrl);

            try
            {
                var response = await _httpClient.PostAsync(_webhookUrl, httpContent);
                Console.WriteLine(httpContent.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error sending message to Slack: {ex.Message}");
            }
        }
    }
}