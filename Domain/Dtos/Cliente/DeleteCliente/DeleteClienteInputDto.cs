using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Dtos.Cliente.DeleteCliente
{
    public class DeleteClienteInputDto
    {
        public DeleteClienteInputDto(ObjectId id)
        {
            Id = id;
        }

        [BsonId]
        public ObjectId Id { get; set; }
    }
}
