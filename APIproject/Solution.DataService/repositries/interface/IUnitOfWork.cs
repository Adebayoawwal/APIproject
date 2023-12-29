namespace APIproject.Solution.DataService.Repositries.Interface
{
    public interface IUnitOfWork
  {
        IDriverRepositry Drivers { get;  }
        IAchievementRepositry Achievements { get; }



        Task CompleteAsync();
  }
}
