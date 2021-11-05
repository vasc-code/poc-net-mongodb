using Application.Boundaries.Cliente.PostCliente;
using Domain.Dtos.Cliente.PostCliente;
using Domain.Interfaces.Cliente;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Repository.Cliente
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMongoCollection<PostClienteInputDto> _db;
        private const string COLLECTION_NAME = "Clientes";

        public ClienteRepository()
        {
            var connection = Environment.GetEnvironmentVariable("ConnectionMongoDB");
            var DBName = Environment.GetEnvironmentVariable("DBName");

            var mongoClient = new MongoClient(connection);
            var database = mongoClient.GetDatabase(DBName);

            _db = database.GetCollection<PostClienteInputDto>(COLLECTION_NAME);
        }

        public async Task<PostClienteOutputDto> PostClienteAsync(PostClienteInputDto input)
        {
            _db.InsertOne(input);

            return new PostClienteOutputDto(
                input.Id.ToString(), 
                input.Name
            );
        }
    }
}
