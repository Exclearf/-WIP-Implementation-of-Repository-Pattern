using RepoPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattern.Repository
{
    internal class RequestRepository : IRequestRepository
    {
        HttpClient client = new();

        public RequestRepository() {
            client.BaseAddress = new Uri("https://localhost:7072/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(2);
        }

        public async Task Add(Exercise exercise)
        {
            int maxRetries = 3;
            int currentRetry = 0;

            while (currentRetry < maxRetries)
            {
                try
                {
                    var response = await client.PostAsJsonAsync("api/Exercises", exercise);
                    response.EnsureSuccessStatusCode();
                    break; // Successful response, exit the loop
                }
                catch (HttpRequestException)
                {
                    // Handle the exception or log it
                    currentRetry++;
                    if (currentRetry >= maxRetries)
                    {
                        await Console.Out.WriteLineAsync("WTF");
                    }
                }
            }
            return;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Get(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public void GetAll(int id)
        {
            throw new NotImplementedException();
        }
    }
}
