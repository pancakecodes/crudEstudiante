namespace backend.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public StudentService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> AddStudent(AddStudentDto newStudent)
        {
            var ServiceResponse = new ServiceResponse<List<GetStudentDto>>();
            var student = _mapper.Map<Student>(newStudent);
          //  student.Id = _context.Students.Max(s => s.Id) + 1;
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            ServiceResponse.Data = _context.Students.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> DeleteStudent(int id)
        {
            var ServiceResponse = new ServiceResponse<List<GetStudentDto>>();

            try
            {
                var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
                if (student == null)
                    throw new Exception($"Student with Id '{id}' not found");

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                ServiceResponse.Data = _context.Students.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
            }
            catch (Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }

            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents()
        {
            var ServiceResponse = new ServiceResponse<List<GetStudentDto>>();
            var dbStudents = await _context.Students.ToListAsync();
            ServiceResponse.Data = dbStudents.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetStudentDto>> GetStudentById(int id)
        {
            var ServiceResponse = new ServiceResponse<GetStudentDto>();
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            ServiceResponse.Data = _mapper.Map<GetStudentDto>(student);
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetStudentDto>> UpdateStudent(UpdateStudentDto updatedStudent)
        {
            var ServiceResponse = new ServiceResponse<GetStudentDto>();

            try
            {
                var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == updatedStudent.Id);
                if (student == null)
                    throw new Exception($"Student with Id '{updatedStudent.Id}' not found");

                _mapper.Map(updatedStudent, student);
                await _context.SaveChangesAsync();

                ServiceResponse.Data = _mapper.Map<GetStudentDto>(student);
            }
            catch (Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }

            return ServiceResponse;
        }
    }
}
