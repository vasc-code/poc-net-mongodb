namespace Domain.Dtos.Cliente.PostCliente
{
    public class PostClienteOutputDto
    {
        public PostClienteOutputDto(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
