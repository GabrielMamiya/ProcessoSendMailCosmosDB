using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using MongoDB.Driver;
using MongoDB.Bson;
using projetoSendRelatorios.Code.DTO;

namespace projetoSendRelatorios.Code.DAL
{
    public class OperariosDAL
    {
        public static List<OperariosDTO> buscaDadosOperariosNoBanco(string database,string collection){

            List<OperariosDTO> nomeDosOperarios = new List<OperariosDTO>();

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(BLL.ConnectionString.connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            Console.WriteLine("Estabelecendo conexao com o Cosmos DB Mongo Client API\n");

            IMongoDatabase db = mongoClient.GetDatabase(database);
            var collectionOperarios = db.GetCollection<BsonDocument>(collection);
            Console.WriteLine("Inicializando conexao com o database...\n");

            var operarios = collectionOperarios.Find(new BsonDocument()).ToList();
            Console.WriteLine("Selecionando a collection...\n");

            operarios.ForEach(item =>
            {
                //Console.WriteLine(item);
            });

            var collectionOperariosDTO = db.GetCollection<OperariosDTO>(collection);

            var operarios2 = collectionOperariosDTO.Find(new BsonDocument()).ToList();

            operarios2.ForEach(item =>
            {
                nomeDosOperarios.Add(item);
            });
            Console.WriteLine("Finalizando conexao com o banco e retornando itens...\n");
            return nomeDosOperarios;

		}
    }
}
