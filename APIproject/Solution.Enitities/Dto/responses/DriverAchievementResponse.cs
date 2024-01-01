namespace APIproject.Solution.Enitities.Dto.Responses
{
    public class DriverAchievementResponse
    {
        public int RaceWins { get; set; }
        public int PolePosition { get; set; }
        public int FastestLap { get; set; }
        public int WorldChampionship { get; set; }
        public Guid DriverId { get; set; }
    }
}
