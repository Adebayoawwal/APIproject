
using APIproject.Solution.DataService.Repositries.Interface;
using Solution.DataService.Data;

namespace APIproject.Solution.DataService.repositries
{
    public class UnitOfWork :IUnitOfWork,IDisposable
    {
        private readonly AppdbContext _context;

        public IDriverRepositry Drivers { get;}
        public IAchievementRepositry Achievements { get; }


        public UnitOfWork(AppdbContext context,ILoggerFactory loggerFactory)
        {
            _context = context;
            var logger=loggerFactory.CreateLogger("logs");

           var Drivers = new DriverRepositry(_context,logger);
            var Achievements = new AchievementRepositry(_context, logger);

        }

        public async Task<bool> CompleteAsync()
        {
          var result= await _context.SaveChangesAsync();
            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
