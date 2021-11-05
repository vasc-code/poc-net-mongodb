using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Application.Boundaries.Cliente.PostCliente
{
    public class PostClienteInputDto
    {
        public PostClienteInputDto(string name)
        {
            Name = name;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}
