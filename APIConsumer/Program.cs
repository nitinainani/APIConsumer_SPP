using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main(string[] args)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        using (var httpClient = new HttpClient(clientHandler))
        {
            using (var response = await httpClient.GetAsync(@"https://localhost:7088/api/DogBreed/mastiff-tibetan"))
            {

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    JArray jArray = JArray.Parse(apiResponse);
                    var image = jArray[0];
                    Console.WriteLine(image);
                }
            }
        }
    }
}

