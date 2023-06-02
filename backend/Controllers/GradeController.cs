namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetGradeDto>>>> Get()
        {
            return Ok(await _gradeService.GetAllGrades());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetGradeDto>>> GetSingle(int id)
        {
            return Ok(await _gradeService.GetGradeById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetGradeDto>>>> AddGrade(AddGradeDto newGrade)
        {
            return Ok(await _gradeService.AddGrade(newGrade));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetGradeDto>>> UpdateGrade(UpdateGradeDto updatedGrade)
        {
            var response = await _gradeService.UpdateGrade(updatedGrade);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetGradeDto>>> DeleteGrade(int id)
        {
            var response = await _gradeService.DeleteGrade(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
