using Projeto_Sprint5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Projeto_Sprint5.HttpClients
{
    public class CepApiClient
    {
        private readonly HttpClient _httpClient;
        public CepApiClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<Cep> GetCepAsync(string cep)
        {
            var resposta = await _httpClient.GetAsync($"{cep}/json/");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsAsync<Cep>();
        }
    }
}
