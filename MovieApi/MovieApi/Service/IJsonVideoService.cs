using MovieApi.Models;

namespace MovieApi.Service
{
    interface IJsonVideoService
    {
        DadosVideo read();
        void save(DadosVideo dadosVideo);
    }
}
