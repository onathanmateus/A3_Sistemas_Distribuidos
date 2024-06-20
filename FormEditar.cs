using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistemas_distribuidos_A3
{
    public partial class FormEditar : Form
    {
        private string _idMoeda;

        public FormEditar(string idMoeda, string nomeMoeda)
        {
            InitializeComponent();
            _idMoeda = idMoeda;
            txtNomeAtual.Text = nomeMoeda;
        }

        private async void btnSalvarAlteracao_Click(object sender, EventArgs e)
        {
            string novoNome = txtNovoNome.Text.Trim();


            if (string.IsNullOrEmpty(novoNome))
            {
                MessageBox.Show("Por favor, insira um novo nome para a moeda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var collection = Program.GetDatabase().GetCollection<BsonDocument>("Moedas");
                var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(_idMoeda));
                var update = Builders<BsonDocument>.Update.Set("name", novoNome);

                var result = await collection.UpdateOneAsync(filter, update);

                if (result.ModifiedCount > 0)
                {
                    MessageBox.Show("Nome da moeda atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Fecha o formulário após a atualização
                }
                else
                {
                    MessageBox.Show("Nenhuma modificação foi feita.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar o nome da moeda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
