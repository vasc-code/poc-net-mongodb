using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Dtos.Cliente.GetClientes
{
    public class GetClientesOutputDto
    {

        public GetClientesOutputDto(string name)
        {
            Name = name;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}
