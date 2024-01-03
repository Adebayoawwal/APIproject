using APIproject.Solution.DataService.Repositries.Interface;
using APIproject.Solution.Enitities.Dto.Requests;
using APIproject.Solution.Enitities.Dto.responses;
using APIproject.Solution.Enitities.Dto.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solution.Enitities.dbSet;

namespace APIproject.Controllers
{
    public class DriversController : BaseController
    {
        public DriversController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var Driver = await _unitOfWork.Drivers.GetById(driverId);
            if (Driver == null)
                return NotFound("Driver not Found  ");

            var result = _mapper.Map<GetDriverResponses>(Driver);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequests  driver)
        {
            if (ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Driver>(driver);
            await _unitOfWork.Drivers.Add(result);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id}, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateAchievement([FromBody]UpdateDriverRequests driver)
        {
            if (ModelState.IsValid)
                return BadRequest();
            var result = _mapper.Map<Driver>(driver);
            await _unitOfWork.Drivers.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var Driver = await _unitOfWork.Drivers.All();
      

            var result = _mapper.Map<IEnumerable<GetDriverResponses>>(Driver);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            var Driver = await _unitOfWork.Drivers.GetById(driverId);
            if (Driver == null)
                return NotFound("Driver not Found  ");

            await _unitOfWork.Drivers.Delete(driverId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
