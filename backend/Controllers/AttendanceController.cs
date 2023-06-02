
namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet("history/{date}")]
        public async Task<ActionResult<ServiceResponse<List<GetAttendanceDto>>>> GetAttendanceHistory(DateTime date)
        {
            var response = await _attendanceService.GetAttendanceHistory(date);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetAttendanceDto>>> AddAttendance(AddAttendanceDto newAttendance)
        {
            var response = await _attendanceService.AddAttendance(newAttendance);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetAttendanceDto>>> UpdateAttendance(UpdateAttendanceDto updatedAttendance)
        {
            var response = await _attendanceService.UpdateAttendance(updatedAttendance);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetAttendanceDto>>>> DeleteAttendance(int id)
        {
            var response = await _attendanceService.DeleteAttendance(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
