using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using dog7.Models;

namespace dog7.Services
{
    public interface IMyService
    {
        Task do1Async();
    }
    public class MyService : IMyService
    {
        private HttpClient _client;

        public MyService(HttpClient client)
        {
            _client = client;
        }

        public Task do1Async()
        {
            throw new NotImplementedException();
        }

        // public async Task do1Async()
        // {
        //     Console.WriteLine("hi there");

        //     var request = new HttpRequestMessage(HttpMethod.Get,
        //                         "http://localhost:1004/coins");



        //     var response = await _client.SendAsync(request);

        //     if (response.IsSuccessStatusCode)
        //     {
        //         Console.WriteLine("http success");
        //         using var responseStream = await response.Content.ReadAsStreamAsync();
        //         var coins = (List<Coin>)await JsonSerializer.DeserializeAsync<IEnumerable<Coin>>(responseStream);
        //         Console.WriteLine($"{coins[0].name} : {coins[0].price} ");
        //     }
        //     else
        //     {
        //         Console.WriteLine("http error");
        //     }
        // }//ef


    }//ec
}//en