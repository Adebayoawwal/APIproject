namespace APIproject.Solution.Enitities.Dto.Requests
{
    public class CreateDriverAchievementRequest
    {
        public int Wins { get; set; }
        public int PolePosition { get; set; }
        public int FastestLap { get; set; }
        public int WorldChampionship { get; set; }
        public Guid DriverId { get; set; }
    }
}
