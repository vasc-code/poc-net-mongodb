using Application.Boundaries.Cliente.PostCliente;
using Domain.Dtos.Cliente.DeleteCliente;
using Domain.Dtos.Cliente.GetClienteById;
using Domain.Dtos.Cliente.GetClientes;
using Domain.Dtos.Cliente.PostCliente;
using Domain.Dtos.Cliente.PutCliente;
using Domain.Interfaces.Cliente;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Cliente
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMongoDatabase _database;
        private const string COLLECTION_NAME = "Clientes";

        public ClienteRepository()
        {
            var connection = Environment.GetEnvironmentVariable("ConnectionMongoDB");
            var DBName = Environment.GetEnvironmentVariable("DBName");

            var mongoClient = new MongoClient(connection);
            _database = mongoClient.GetDatabase(DBName);
        }

        public async Task<PostClienteOutputDto> PostClienteAsync(PostClienteInputDto input)
        {
            var db = _database.GetCollection<PostClienteInputDto>(COLLECTION_NAME);

            await db.InsertOneAsync(input);

            return new PostClienteOutputDto(
                input.Id.ToString(), 
                input.Name,
                input.BirthDate,
                input.ZipCode
            );
        }
        public async Task<PutClienteOutputDto> PutClienteAsync(PutClienteInputDto input)
        {
            var db = _database.GetCollection<PutClienteInputDto>(COLLECTION_NAME);

            await db.ReplaceOneAsync(c => c.Id == input.Id, input).ConfigureAwait(false);

            return new PutClienteOutputDto(
                input.Id.ToString(), 
                input.Name,
                input.BirthDate,
                input.ZipCode
            );
        }

        public async Task<IEnumerable<GetClientesOutputDto>> GetClientesAsync()
        {
            var db = _database.GetCollection<GetClientesOutputDto>(COLLECTION_NAME);

            var clientes = (await db.FindAsync(e => true).ConfigureAwait(false)).ToList();

            return clientes;
        }

        public async Task<GetClienteByIdOutputDto> GetClienteByIdAsync(GetClienteByIdInputDto input)
        {
            var db = _database.GetCollection<GetClienteByIdOutputDto>(COLLECTION_NAME);

            var cliente = await db.Find(e => e.Id == input.Id).SingleOrDefaultAsync().ConfigureAwait(false);

            return cliente;
        }

        public async Task<bool> DeleteClienteAsync(DeleteClienteInputDto input)
        {
            var db = _database.GetCollection<DeleteClienteInputDto>(COLLECTION_NAME);

            var cliente = await db.DeleteOneAsync(e => e.Id == input.Id).ConfigureAwait(false);

            return cliente.DeletedCount > 0;
        }
    }
}
