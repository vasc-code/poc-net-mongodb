using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Dtos.Cliente.GetClienteById
{
    public class GetClienteByIdInputDto
    {
        public GetClienteByIdInputDto(ObjectId id)
        {
            Id = id;
        }

        [BsonId]
        public ObjectId Id { get; set; }
    }
}
