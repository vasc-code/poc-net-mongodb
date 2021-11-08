using System;

namespace Application.Boundaries.Cliente.PostCliente
{
    public class PostClienteOutput
    {
        public PostClienteOutput(string id, 
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
        public DateTime? BirthDate { get; set; }
        public string ZipCode { get; set; }
    }
}
