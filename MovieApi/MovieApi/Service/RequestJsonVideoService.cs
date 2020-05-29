using MovieApi.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MovieApi.Service
{
    public class RequestJsonVideoService
    {
        private static string CAMINHO_JSON = "https://imdb8.p.rapidapi.com/title/get-videos";
        private HttpClient client { get; set; }

        public RequestJsonVideoService()
        {
            client = new HttpClient();
        }

        public async Task<DadosVideo> GetDadosVideo()
        {
            var response = await CreateHttpClienteRequest();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DadosVideo>(responseBody);
        }

        private async Task<HttpResponseMessage> CreateHttpClienteRequest()
        {
            var builder = new UriBuilder(CAMINHO_JSON);
            var query = HttpUtility.ParseQueryString(builder.Query);

            query["limit"] = "25";
            query["region"] = "PT";
            query["tconst"] = "tt0944947";
            builder.Query = query.ToString();

            client.DefaultRequestHeaders.Add("x-rapidapi-host", "imdb8.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-key", "662179b8efmshc9ef6bc611aa329p1e2dc0jsn0556aee23b54");
            client.DefaultRequestHeaders.Add("useQueryString", "true");

            string url = builder.ToString();

            return await client.GetAsync(url);
        }
    }
}
