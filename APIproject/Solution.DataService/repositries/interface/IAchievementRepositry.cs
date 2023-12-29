using Solution.Enitities.dbSet;

namespace APIproject.Solution.DataService.Repositries.Interface
{
    public interface IAchievementRepositry:IGenericRepositry<Achievement>
   {
        Task<Achievement?> GetDriverAchievementAsync(Guid DriverId);
    }
}
