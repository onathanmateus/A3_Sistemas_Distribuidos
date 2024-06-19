using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using sistemas_distribuidos_A3;

namespace sistemas_distribuidos_A3
{
    public partial class MainForm : Form
    {
        private ServicoMoedasCoinGecko _servicoMoedasCoinGecko;

        /// <summary>
        /// Construtor do formul�rio principal.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _servicoMoedasCoinGecko = new ServicoMoedasCoinGecko();
        }

        /// <summary>
        /// Evento acionado ao clicar no bot�o "Buscar".
        /// </summary>
        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obt�m o nome da moeda digitado pelo usu�rio
            string nomeMoeda = txtNomeMoeda.Text.Trim().ToLower();

            // Verifica se o nome da moeda foi fornecido
            if (string.IsNullOrEmpty(nomeMoeda))
            {
                MessageBox.Show("Por favor, insira o nome de uma moeda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obt�m o JSON da moeda a partir do servi�o CoinGecko
                string jsonMoeda = await _servicoMoedasCoinGecko.ObterJsonMoeda(nomeMoeda);

                // Converte o JSON em um objeto JObject para facilitar a manipula��o
                var dadosMoeda = JsonConvert.DeserializeObject<JObject>(jsonMoeda);

                // Limpa o RichTextBox
                richTextBoxMoedas.Clear();

                // Adiciona os dados filtrados ao RichTextBox com efeito de digita��o
                await AdicionarItensComEfeitoDeDigitacao(richTextBoxMoedas, dadosMoeda);
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra uma exce��o
                MessageBox.Show($"Ocorreu um erro inesperado ao buscar informa��es da moeda. Por favor, revise o nome que voc� inseriu.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Evento acionado ao clicar no botão "Salvar".
        /// </summary>
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            // Obtém o nome da moeda digitado pelo usuário
            string nomeMoeda = txtNomeMoeda.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(nomeMoeda))
            {
                MessageBox.Show("Por favor, insira o nome de uma moeda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtém o JSON da moeda a partir do serviço "CoinGecko"
            string jsonMoeda = await _servicoMoedasCoinGecko.ObterJsonMoeda(nomeMoeda);

            try
            {
                // Chama o método Create para salvar no MongoDB
                var resultado = Program.Create(jsonMoeda);
                
                if (resultado)
                {
                    MessageBox.Show("Moeda salva com sucesso no banco de dados.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("A moeda já existe no banco de dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Limpa o RichTextBox
                richTextBoxMoedas.Clear();

                // Limpa o local onde foi digitado para pesquisa
                txtNomeMoeda.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar a moeda no banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Adiciona os itens ao RichTextBox com efeito de digita��o.
        /// </summary>
        /// <param name="richTextBox">O RichTextBox para adicionar os itens.</param>
        /// <param name="jObject">O JObject contendo os dados da moeda.</param>
        private async Task AdicionarItensComEfeitoDeDigitacao(RichTextBox richTextBox, JObject jObject)
        {
            if (jObject != null)
            {
                // Adiciona o ID, s�mbolo e nome da moeda
                await DigitarLinhaRichTextBox(richTextBox, $"ID: {jObject["id"]}");
                await DigitarLinhaRichTextBox(richTextBox, $"S�mbolo: {jObject["symbol"]}");
                await DigitarLinhaRichTextBox(richTextBox, $"Nome: {jObject["name"]}");

                // Adiciona informa��es de mercado
                var marketData = jObject["market_data"];
                if (marketData != null)
                {
                    await DigitarLinhaRichTextBox(richTextBox, $"Valor atual (BRL): {FormatarValor(marketData["current_price"]?["brl"])}");
                    await DigitarLinhaRichTextBox(richTextBox, $"Maior valor 24h (BRL): {FormatarValor(marketData["high_24h"]?["brl"])}");
                    await DigitarLinhaRichTextBox(richTextBox, $"Menor valor 24h (BRL): {FormatarValor(marketData["low_24h"]?["brl"])}");
                }

                // Adiciona informa��es de fornecimento
                await DigitarLinhaRichTextBox(richTextBox, $"Oferta Circulante: {FormatarNumeroInteiro(marketData["circulating_supply"])}");
                await DigitarLinhaRichTextBox(richTextBox, $"Oferta M�xima: {FormatarNumeroInteiro(marketData["max_supply"])}");

            }
        }

        /// <summary>
        /// Simula a digita��o de uma linha no RichTextBox.
        /// </summary>
        /// <param name="richTextBox">O RichTextBox para adicionar a linha.</param>
        /// <param name="linha">A linha a ser adicionada.</param>
        private async Task DigitarLinhaRichTextBox(RichTextBox richTextBox, string linha)
        {
            foreach (char c in linha)
            {
                richTextBox.AppendText(c.ToString());
                await Task.Delay(10); // Tempo de espera
                Application.DoEvents(); // Permite a atualiza��o da interface durante o loop
            }
            richTextBox.AppendText(Environment.NewLine); // Adiciona uma nova linha no final
        }

        /// <summary>
        /// Formata um valor decimal para o formato monet�rio brasileiro.
        /// </summary>
        /// <param name="valor">O valor a ser formatado.</param>
        /// <returns>O valor formatado como string.</returns>
        private string FormatarValor(JToken valor)
        {
            if (valor == null || !decimal.TryParse(valor.ToString(), out decimal valorDecimal))
            {
                return "N/A";
            }
            return valorDecimal.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
        }

        /// <summary>
        /// Formata um valor decimal como n�mero inteiro com separadores de milhar.
        /// </summary>
        /// <param name="valor">O valor a ser formatado.</param>
        /// <returns>O valor formatado como string.</returns>
        private string FormatarNumeroInteiro(JToken valor)
        {
            if (valor == null || !decimal.TryParse(valor.ToString(), out decimal valorDecimal))
            {
                return "N/A";
            }
            return valorDecimal.ToString("#,##0", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
        }
    }
}
