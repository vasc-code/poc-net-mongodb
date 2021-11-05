namespace Application.Boundaries.Cliente.GetCliente
{
    public class GetClienteOutput
    {
        public GetClienteOutput(string id,
                             string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
