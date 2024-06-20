using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MongoDB.Bson;
using sistemas_distribuidos_A3;
using MongoDB.Driver;
using System.Globalization;

namespace sistemas_distribuidos_A3
{
    public partial class MainForm : Form
    {
        private ServicoMoedasCoinGecko _servicoMoedasCoinGecko;

        /// <summary>
        /// Construtor do formulário principal.
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
            // Obtém o nome da moeda digitado pelo usuário
            string nomeMoeda = txtNomeMoeda.Text.Trim().ToLower();

            // Verifica se o nome da moeda foi fornecido
            if (string.IsNullOrEmpty(nomeMoeda))
            {
                MessageBox.Show("Por favor, insira o nome de uma moeda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtém o JSON da moeda a partir do serviço CoinGecko
                string jsonMoeda = await _servicoMoedasCoinGecko.ObterJsonMoeda(nomeMoeda);

                // Converte o JSON em um objeto JObject para facilitar a manipulação
                var dadosMoeda = JsonConvert.DeserializeObject<JObject>(jsonMoeda);

                // Limpa o RichTextBox
                richTextBoxMoedas.Clear();

                // Filtra as informações necessárias
                var dadosFiltrados = new JObject
                {
                    ["id"] = dadosMoeda["id"],
                    ["symbol"] = dadosMoeda["symbol"],
                    ["name"] = dadosMoeda["name"],
                    ["current_price"] = dadosMoeda["market_data"]?["current_price"]?["brl"],
                    ["high_24h"] = dadosMoeda["market_data"]?["high_24h"]?["brl"],
                    ["low_24h"] = dadosMoeda["market_data"]?["low_24h"]?["brl"],
                    ["circulating_supply"] = dadosMoeda["market_data"]?["circulating_supply"],
                    ["max_supply"] = dadosMoeda["market_data"]?["max_supply"]
                };

                // Chama o método para adicionar os itens filtrados ao RichTextBox com efeito de digitação
                await AdicionarItensComEfeitoDeDigitacao(richTextBoxMoedas, dadosFiltrados);
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra uma exceção
                MessageBox.Show($"Ocorreu um erro inesperado ao buscar informações da moeda. Por favor, revise o nome que você inseriu.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Converte o JSON em um objeto JObject para facilitar a manipulação
                var dadosMoeda = JsonConvert.DeserializeObject<JObject>(jsonMoeda);

                // Filtra as informações necessárias
                var dadosFiltrados = new JObject
                {
                    ["id"] = dadosMoeda["id"],
                    ["symbol"] = dadosMoeda["symbol"],
                    ["name"] = dadosMoeda["name"],
                    ["current_price"] = dadosMoeda["market_data"]?["current_price"]?["brl"],
                    ["high_24h"] = dadosMoeda["market_data"]?["high_24h"]?["brl"],
                    ["low_24h"] = dadosMoeda["market_data"]?["low_24h"]?["brl"],
                    ["circulating_supply"] = dadosMoeda["market_data"]?["circulating_supply"],
                    ["max_supply"] = dadosMoeda["market_data"]?["max_supply"]
                };

                // Converte o JObject filtrado para BsonDocument
                var bsonDocument = BsonDocument.Parse(dadosFiltrados.ToString());

                // Chama o método Create para salvar no MongoDB
                var resultado = Program.Create(bsonDocument);

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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Obtém o nome da moeda digitado pelo usuário
            string dadosMoeda = txtNomeMoeda2.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(dadosMoeda))
            {
                MessageBox.Show("Por favor, insira o nome de uma moeda para deletar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Chama o método Delete para remover do MongoDB
                var resultado = Program.Delete(dadosMoeda);

                if (resultado)
                {
                    MessageBox.Show("Moeda deletada com sucesso do banco de dados.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("A moeda não foi encontrada no banco de dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Limpa o RichTextBox
                txtNomeMoeda2.Clear();

                // Limpa o local onde foi digitado para pesquisa
                txtNomeMoeda2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao deletar a moeda do banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpa o RichTextBox
                richTextBoxMoedas.Clear();

                // Busca todas as moedas no banco de dados
                var moedas = await BuscarTodasMoedasAsync();

                // Adiciona as moedas ao RichTextBox
                foreach (var moeda in moedas)
                {
                    // Converte o BsonDocument em JObject
                    var jObject = BsonDocumentToJObject(moeda);

                    // Chama o método para adicionar os itens ao RichTextBox com efeito de digitação
                    await AdicionarItensComEfeitoDeDigitacao(richTextBoxMoedas, jObject);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar as moedas do banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private JObject BsonDocumentToJObject(BsonDocument document)
        {
            // Criar um JObject vazio
            var jObject = new JObject();

            // Iterar sobre cada elemento no BsonDocument
            foreach (var element in document.Elements)
            {
                // Tratar especificamente o campo _id para convertê-lo em string
                if (element.Name == "_id")
                {
                    jObject.Add(element.Name, element.Value.ToString());
                }
                else
                {
                    // Converter os outros elementos para JToken
                    var jToken = JToken.Parse(element.Value.ToJson());
                    jObject.Add(element.Name, jToken);
                }
            }

            return jObject;
        }

        private async Task<List<BsonDocument>> BuscarTodasMoedasAsync()
        {
            var collection = Program.GetDatabase().GetCollection<BsonDocument>("Moedas");
            var filter = new BsonDocument();
            var moedas = await collection.Find(filter).ToListAsync();
            return moedas;
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
                // Adiciona o ID, símbolo e nome da moeda
                await DigitarLinhaRichTextBox(richTextBox, $"ID: {jObject["id"]}");
                await DigitarLinhaRichTextBox(richTextBox, $"Símbolo: {jObject["symbol"]}");
                await DigitarLinhaRichTextBox(richTextBox, $"Nome: {jObject["name"]}");

                // Adiciona informações de mercado
                await DigitarLinhaRichTextBox(richTextBox, $"Valor atual (BRL): {FormatarValor(jObject["current_price"])}");
                await DigitarLinhaRichTextBox(richTextBox, $"Maior valor 24h (BRL): {FormatarValor(jObject["high_24h"])}");
                await DigitarLinhaRichTextBox(richTextBox, $"Menor valor 24h (BRL): {FormatarValor(jObject["low_24h"])}");

                // Adiciona informações de fornecimento
                await DigitarLinhaRichTextBox(richTextBox, $"Oferta Circulante: {FormatarNumeroInteiro(jObject["circulating_supply"])}");
                await DigitarLinhaRichTextBox(richTextBox, $"Oferta Máxima: {FormatarNumeroInteiro(jObject["max_supply"])}");

                // Adiciona uma quebra de linha adicional ao final dos dados da moeda
                richTextBox.AppendText(Environment.NewLine);
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
                await Task.Delay(10); // Tempo de espera em milisegundos.
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

        private async Task SaveDocumentToDatabase(string id, BsonDocument document)
        {
            var collection = Program.GetDatabase().GetCollection<BsonDocument>("Moedas");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));
            var update = Builders<BsonDocument>.Update
                .Set("symbol", document["symbol"])
                .Set("name", document["name"])
                .Set("current_price", document["current_price"])
                .Set("high_24h", document["high_24h"])
                .Set("low_24h", document["low_24h"])
                .Set("circulating_supply", document["circulating_supply"])
                .Set("max_supply", document["max_supply"]);

            await collection.UpdateOneAsync(filter, update);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox textBox1 = this.Controls["textBox1"] as TextBox;

            if (textBox1 != null)
            {
                // Cria uma nova instância de Form1 e passa o texto do TextBox
                FormEditar form1 = new FormEditar(textBox1.Text);

                // Abre a nova instânciaS
                form1.Show();

            }

        }        
    }
}
