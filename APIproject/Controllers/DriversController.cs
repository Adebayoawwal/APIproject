using APIproject.Solution.DataService.Repositries.Interface;
using AutoMapper;

namespace APIproject.Controllers
{
    public class DriversController : BaseController
    {
        public DriversController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
