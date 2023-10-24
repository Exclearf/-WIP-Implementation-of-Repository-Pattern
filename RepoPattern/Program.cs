using RepoPattern.Controllers;
using RepoPattern.Models;
using RepoPattern.Repository;
using RepoPattern.Services;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace RepoPattern
{
    public class Program
    {
        private static HttpClient client = new();
        private static InputController inputController = new();
        private static RequestRepository requestRepository = new();
        private static InputService inputService = new (requestRepository);

        static void Main(string[] args)
        {
            inputController.Start(inputService);
        }
/*
        public static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:7072/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var exr = new Exercise();
            try
            {
                var response = await client.PostAsJsonAsync("api/Exercises", exr);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }*/
    }
}