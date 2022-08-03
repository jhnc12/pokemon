using Newtonsoft.Json;
using Pokemon.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Services
{
    public class PokemonServices
    {
        private const string Url = "https://pokeapi.co/api/v2/pokemon/?limit=100";
        private readonly HttpClient _client = new HttpClient();
        public async Task<List<PokemonModel>> GetPokemon()
        {
            var ListPokemon = new List<PokemonModel>();
            try
            {
                string rescontent = await _client.GetStringAsync(Url);
                var retorno = JsonConvert.DeserializeObject<PokemonReturn>(rescontent);
                ListPokemon = retorno.results;
            }
            catch (Exception ex)
            {

            }
            return ListPokemon;
        }
        public async Task<DetalhesModel> GetDetail(string _url)
        {
            var detalhes = new DetalhesModel();
            try
            {
                string rescontent = await _client.GetStringAsync(_url);
                var retorno = JsonConvert.DeserializeObject<DetalhesModel>(rescontent);
                detalhes = retorno;
            }
            catch (Exception ex)
            {

            }
            return detalhes;
        }
    }
}
