namespace ConsoleApp1.Entities
{
    public class Machine(int lotDuration, string name)
    {
        public string Name { get; set; } = name;
        public string[]? AvailableTime { get; set; } = new string[lotDuration];
    }
}
