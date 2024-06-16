using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Windows.Forms;
using sistemas_distribuidos_A3;

static class Program
{
    /// <summary>
    /// Ponto de entrada principal para o aplicativo.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Conectar ao MongoDB
        ConectarMongoDB();

        // Iniciar o formulário principal da aplicação
        Application.Run(new MainForm());
    }

    static void ConectarMongoDB()
    {
        const string connectionUri = "mongodb+srv://andrelincolnfs2014:flamengo@a3sistemas.ategztm.mongodb.net/?retryWrites=true&w=majority&appName=A3sistemas";

        var settings = MongoClientSettings.FromConnectionString(connectionUri);

        // Definir o campo ServerApi do objeto settings para definir a versão da API estável no cliente
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);

        // Criar um novo cliente e conectar ao servidor
        var client = new MongoClient(settings);

        // Enviar um ping para confirmar uma conexão bem-sucedida
        try
        {
            var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
            Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao conectar ao MongoDB: {ex}");
        }
    }
}
