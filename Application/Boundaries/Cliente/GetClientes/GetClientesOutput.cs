namespace Application.Boundaries.Cliente.GetClientes
{
    public class GetClientesOutput
    {
        public GetClientesOutput(string id,
                                 string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
