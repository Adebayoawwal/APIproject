using APIproject.Solution.DataService.Repositries.Interface;
using Microsoft.EntityFrameworkCore;
using Solution.DataService.Data;
using Solution.Enitities.dbSet;
using SQLitePCL;

namespace APIproject.Solution.DataService.repositries.@interface
{
    public class DriverRepositry : GenericRepositry<Driver>, IDriverRepositry
    {
        public DriverRepositry(AppdbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable <Driver>>  All()
        {

            try
            {
                return _dbSet.Where(x => x.status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedDate)
                    .ToList();
            }
            catch (Exception e) {
                _Logger.LogError(e, "{Repo} All Function Error",typeof(DriverRepositry));
                throw;
            }
        }


        public async Task<bool> Delete(Guid id)
        {
            try
            {
             var result=await _dbSet.FirstOrDefaultAsync(x =>x.Id==id);
                if (result == null)
                    return false;
                result.status = 0;
                result.UpdatedDate = DateTime.UtcNow;
                return true;
            }
            catch(Exception e) {
                _Logger.LogError(e, "{Repo} Delete Function Error", typeof(DriverRepositry));
                throw;
            }
        }

        public async Task<bool> Update(Driver driver)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == driver.Id);
                if (result == null)
                    return false;
                result.UpdatedDate = DateTime.UtcNow;
                result.DriverNumber= driver.DriverNumber;
                result.FirstName= driver.FirstName;
                result.LastName= driver.LastName;
                result.DateOfBirth= driver.DateOfBirth;
                return true;
            }
            catch (Exception e)
            {
                _Logger.LogError(e, "{Repo} Update Function Error", typeof(DriverRepositry));
                throw;
            }
        }
    }
}
