using APIproject.Solution.DataService.Repositries.Interface;
using APIproject.Solution.Enitities.Dto.Requests;
using APIproject.Solution.Enitities.Dto.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solution.Enitities.dbSet;

namespace APIproject.Controllers
{
    public class AchievementsController : BaseController
    {
        public AchievementsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriverAchievement(Guid driverId)
        {
            var DriverAchievements = await _unitOfWork.Achievements.GetDriverAchievementAsync(driverId);
            if(DriverAchievements == null)
                return NotFound("Achievement not Found  ");

            var result =_mapper.Map<DriverAchievementResponse>(DriverAchievements);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievement  achievement)
        {
            if (ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Achievement>(achievement);
            await _unitOfWork.Achievements.Add(result);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetDriverAchievement), new {driverId=result.DriverId},result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateAchievement([FromBody] UpdateDriverAchievementRequest achievement)
        {
            if (ModelState.IsValid) 
                return BadRequest();
            var result = _mapper.Map<Achievement>(achievement);
            await _unitOfWork.Achievements.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

    }
}
