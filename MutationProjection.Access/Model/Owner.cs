namespace MutationProjection.Access.Model
{
    public class Owner
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public IEnumerable<Car>? Cars { get; set; }
    }
}
