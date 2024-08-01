using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebDigger
{
    internal class ApiService
    {
        // Instance of http client.
        private readonly HttpClient _client;

        // default constuctor
        public ApiService()
        {

        }

        // Constructor inits http client.
        public ApiService(HttpClient httpClient)
        {
            _client = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        // Get json via http request.
        public async Task<string> GetResponseJsonAsync(string url)
        {
            try
            {
                // Send GET request and receive response
                HttpResponseMessage response = await _client.GetAsync(url);
                // Ensure successful response
                response.EnsureSuccessStatusCode();
                // Read response content as JSON string
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                // Log or handle any errors that occur during the request
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw; // Rethrow the exception for the caller to handle
            }
        }

        // Simulate a 1 second delay between every request to api provider.(Rules)
        public static void Pause()
        {
            System.Threading.Thread.Sleep(1000);
        }



    }
}
