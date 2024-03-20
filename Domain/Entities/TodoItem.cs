namespace Domain.Entities
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool isComplete { get; set; }
    }
}
