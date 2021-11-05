namespace Application.Boundaries.Cliente.PostCliente
{
    public class PostClienteOutput
    {
        public PostClienteOutput(string id,
                                 string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
