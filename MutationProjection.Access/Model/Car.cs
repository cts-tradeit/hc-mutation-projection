namespace MutationProjection.Access.Model
{
    public class Car
    {
        public int Id { get; set; } 
        public string? LicensePlate { get; set; }
        public int OwnerId { get; set; }

        public Owner? Owner { get; set; }
    }
}
