namespace Application.Boundaries.Cliente.GetClienteById
{
    public class GetClienteByIdOutput
    {
        public GetClienteByIdOutput(string id,
                                    string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
