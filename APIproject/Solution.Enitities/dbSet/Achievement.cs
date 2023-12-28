
namespace Solution.Enitities.dbSet
{
    
    public class Achievement: BaseEntity
    {
        public int RaceWins { get; set; }
        public int PolePosition { get; set; }
        public int FastestLap{ get; set; }
        public int WorldChampions  { get; set; }
        public int DriverId { get; set; }
        public virtual Driver? Driver{get; set;}
    }
    
}
    