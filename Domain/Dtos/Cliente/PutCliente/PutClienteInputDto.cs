using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Application.Boundaries.Cliente.PostCliente
{
    public class PutClienteInputDto
    {
        public PutClienteInputDto(ObjectId id, 
                                  string name,
                                  DateTime? birthDate,
                                  string zipCode)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            ZipCode = zipCode;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ZipCode { get; set; }
    }
}
