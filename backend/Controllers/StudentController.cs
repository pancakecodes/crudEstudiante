
namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse <List<GetStudentDto>>>> Get()
        {
            return Ok(await _studentService.GetAllStudents());
        }

         [HttpGet("{id}")]
        public async Task <ActionResult <ServiceResponse<GetStudentDto>>> GetSingle(int id)
        {
            return Ok(await _studentService.GetStudentById(id));
        }

        [HttpPost]
        public async Task <ActionResult<ServiceResponse<List<GetStudentDto>>>> AddStudent (AddStudentDto newStudent)
        {
            return Ok(await _studentService.AddStudent(newStudent));
        }

        [HttpPut]
        public async Task <ActionResult<ServiceResponse<GetStudentDto>>> UpdateStudent (UpdateStudentDto updatedStudent)
        {
            var response = await _studentService.UpdateStudent(updatedStudent);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task <ActionResult<ServiceResponse<GetStudentDto>>> DeleteStudent(int id)
        {
            var response = await _studentService.DeleteStudent(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}