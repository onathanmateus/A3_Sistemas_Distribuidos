using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace sistemas_distribuidos_A3
{
    /// <summary>
    /// Classe para consumir a API do CoinGecko e obter informações sobre moedas.
    /// </summary>
    internal class ServicoMoedasCoinGecko
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Construtor que inicializa o HttpClient.
        /// </summary>
        public ServicoMoedasCoinGecko()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Obtém o JSON de informações completas de uma moeda específica da API do CoinGecko.
        /// </summary>
        /// <param name="nomeMoeda">Nome da moeda para buscar informações.</param>
        /// <returns>JSON com informações da moeda.</returns>
        public async Task<string> ObterJsonMoeda(string nomeMoeda)
        {
            try
            {
                // Constrói a URL da API com o nome da moeda fornecido
                string url = $"https://api.coingecko.com/api/v3/coins/{nomeMoeda}?localization=false&tickers=false&market_data=true&community_data=false&developer_data=false&sparkline=false";

                // Faz a requisição HTTP para obter os dados da moeda
                return await _httpClient.GetStringAsync(url);
            }
            catch (HttpRequestException ex)
            {
                // Em caso de erro na requisição HTTP, lança uma exceção com a mensagem de erro
                throw new Exception($"Erro ao chamar a API do CoinGecko: {ex.Message}");
            }
        }
    }
}