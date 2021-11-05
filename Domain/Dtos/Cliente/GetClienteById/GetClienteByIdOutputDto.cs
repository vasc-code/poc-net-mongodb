using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Dtos.Cliente.GetClienteById
{
    public class GetClienteByIdOutputDto
    {
        public GetClienteByIdOutputDto(string name)
        {
            Name = name;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}
