using System;

namespace Application.Boundaries.Cliente.PutCliente
{
    public class PutClienteInput
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ZipCode { get; set; }
    }
}
