using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Windows.Forms;
using sistemas_distribuidos_A3;

static class Program
{

    private static IMongoDatabase _database;
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
        const string connectionUri = "mongodb+srv://nathan3272:nathan3272@a3sistemas.kxbvtla.mongodb.net/?retryWrites=true&w=majority&appName=A3Sistemas";

        var settings = MongoClientSettings.FromConnectionString(connectionUri);

        // Definir o campo ServerApi do objeto settings para definir a versão da API estável no cliente
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);

        // Criar um novo cliente e conectar ao servidor
        var client = new MongoClient(settings);

        // Definir o banco de dados
        _database = client.GetDatabase("Moedas");

        // Enviar um ping para confirmar uma conexão bem-sucedida
        try
        {
            var result = _database.RunCommand<BsonDocument>(new BsonDocument("ping", 1));
            Console.WriteLine("Conexão com o banco de dados feita com sucesso !");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao se conectar com o banco de dados: {ex}");
        }
    }

    public static bool Create(BsonDocument document)
    {
        try
        {
            var collection = _database.GetCollection<BsonDocument>("Moedas");

            // Verificar se um documento com o mesmo "id" já existe na coleção
            var filter = Builders<BsonDocument>.Filter.Eq("id", document["id"]);
            var existingDocument = collection.Find(filter).FirstOrDefault();

            if (existingDocument != null)
            {
                Console.WriteLine("A moeda já existe no banco de dados.");
                return false;
            }
            else
            {
                // Inserir o documento na coleção
                collection.InsertOne(document);
                Console.WriteLine("Moeda inserida com sucesso no banco de dados!");
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao inserir moeda no banco de dados: {ex}");
            return false;
        }
    }
    public static IMongoDatabase GetDatabase()
    {
        return _database;
    }

    public static bool Delete(string dadosMoeda)
    {
        try
        {
            var collection = _database.GetCollection<BsonDocument>("Moedas");

            // Construir o filtro para encontrar o documento com o nome da moeda especificada
            var filter = Builders<BsonDocument>.Filter.Eq("id", dadosMoeda);

            // Remover o documento
            var result = collection.DeleteOne(filter);

            if (result.DeletedCount > 0)
            {
                Console.WriteLine("Moeda deletada com sucesso do banco de dados!");
                return true;
            }
            else
            {
                Console.WriteLine("A moeda não foi encontrada no banco de dados.");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao deletar moeda do banco de dados: {ex}");
            return false;
        }
    }

}
