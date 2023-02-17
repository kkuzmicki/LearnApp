using LearnAppClientWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LearnAppClientWPF.Utilities
{
    static class HttpHelper
    {
        static public async Task<UserModel> GetUserWithEmailAddressAndPassword(string email = "", string password = "")
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            
                HttpClient client = new();
                using HttpResponseMessage response = await client.GetAsync($"http://localhost:5000/api/Users/byPassword?email={email}&password={password}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);

            //var deptList = JsonSerializer.Deserialize<IList<UserModel>>(responseBody);
            UserModel receivedUser = JsonSerializer.Deserialize<UserModel>(responseBody)!;
            return receivedUser;
        }
    }
}
