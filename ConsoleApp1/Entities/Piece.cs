namespace ConsoleApp1.Entities
{
    public class Piece(string? name, Operation[] operations)
    {
        public string? Name { get; set; } = name;
        public Operation[] Operations { get; set; } = operations;
    }
}
