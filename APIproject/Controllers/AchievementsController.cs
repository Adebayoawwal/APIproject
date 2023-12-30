using APIproject.Solution.DataService.Repositries.Interface;
using AutoMapper;

namespace APIproject.Controllers
{
    public class AchievementsController : BaseController
    {
        public AchievementsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
