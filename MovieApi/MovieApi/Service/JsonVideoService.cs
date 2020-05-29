using MovieApi.Models;
using Newtonsoft.Json;
using System.IO;

namespace MovieApi.Service
{
    public class JsonVideoService : IJsonVideoService
    {
        private static string CAMINHO_JSON = "files/jsonVideos.json";

        public DadosVideo read()
        {
            if (!File.Exists(CAMINHO_JSON))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<DadosVideo>(File.ReadAllText(CAMINHO_JSON));
        }

        public void save(DadosVideo dadosVideo)
        {
            File.WriteAllText(CAMINHO_JSON, JsonConvert.SerializeObject(dadosVideo));
        }
    }
}
