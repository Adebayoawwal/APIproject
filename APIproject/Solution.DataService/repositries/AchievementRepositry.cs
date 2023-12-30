using APIproject.Solution.DataService.Repositries.Interface;
using Microsoft.EntityFrameworkCore;
using Solution.DataService.Data;
using Solution.Enitities.dbSet;
using System.Collections.Generic;

namespace APIproject.Solution.DataService.repositries
{
    public class AchievementRepositry : GenericRepositry<Achievement>, IAchievementRepositry
    {
        public AchievementRepositry(AppdbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);

            }
            catch (Exception e)
            {
                _Logger.LogError(e, "{Repo} GetDriverAchievementAsync Function Error", typeof(AchievementRepositry));
                throw;
            }
        }




        public async Task<IEnumerable<Achievement>> All()
        {

            try
            {
                return _dbSet.Where(x => x.status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedDate)
                    .ToList();
            }
            catch (Exception e)
            {
                _Logger.LogError(e, "{Repo} All Function Error", typeof(AchievementRepositry));
                throw;
            }
        }


        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null)
                    return false;
                result.status = 0;
                result.UpdatedDate = DateTime.UtcNow;
                return true;
            }
            catch (Exception e)
            {
                _Logger.LogError(e, "{Repo} Delete Function Error", typeof(AchievementRepositry));
                throw;
            }
        }

        public async Task<bool> Update(Achievement achievement)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);
                if (result == null)
                    return false;
                result.UpdatedDate = DateTime.UtcNow;
                result.FastestLap = achievement.FastestLap;
                result.WorldChampions = achievement.WorldChampions;
                result.PolePosition = achievement.PolePosition;
                result.RaceWins = achievement.RaceWins;

                return true;
            }
            catch (Exception e)
            {
                _Logger.LogError(e, "{Repo} Update Function Error", typeof(AchievementRepositry));
                throw;
            }
        }
    }
}
