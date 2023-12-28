namespace Solution.Enitities.dbSet
{
     public class Driver: BaseEntity
     {
          public virtual ICollection<Achievement> Achievements{get; set;}
          public Driver()
          { 
               Achievements= new HashSet<Achievement>();
          }

          public string FirstName { get; set; }=string.Empty;
          public string LastName { get; set; }=string.Empty; 
          public int DriverNumber { get; set; }
          public DateTime DateOfBirth { get; set; } 
     }
}