namespace AlgoRythmMaze.Domain.Models
{
    public class Badge
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        //condition for which they receive it? - 1 - 3 - 10 successful projects
    }
}
