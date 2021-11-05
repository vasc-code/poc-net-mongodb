namespace Domain.Dtos.Cliente
{
    public class ClienteInputDto
    {

        public ClienteInputDto(string id,
                               string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
