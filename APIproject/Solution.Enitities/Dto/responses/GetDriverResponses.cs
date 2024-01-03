namespace APIproject.Solution.Enitities.Dto.responses
{
    public class GetDriverResponses
    {
        public Guid DriverId { get; set; }
        public string FullName { get; set; }
        public int DriverNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
