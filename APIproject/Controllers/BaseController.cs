using APIproject.Solution.DataService.Repositries.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace APIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController:ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseController(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
