using System;

namespace Domain.Dtos.Cliente.PutCliente
{
    public class PutClienteOutputDto
    {
        public PutClienteOutputDto(string id,
                                   string name,
                                   DateTime? birthDate,
                                   string zipCode)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            ZipCode = zipCode;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
