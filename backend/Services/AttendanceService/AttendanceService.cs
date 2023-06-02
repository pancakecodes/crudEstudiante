namespace backend.Services.AttendanceService
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        private readonly DataContext _context;

        public AttendanceService(IMapper mapper, IStudentService studentService, DataContext context)
        {
            _mapper = mapper;
            _context = context;
            _studentService = studentService;
        }

        public async Task<ServiceResponse<List<GetAttendanceDto>>> GetAttendanceHistory(DateTime date)
        {
            var response = new ServiceResponse<List<GetAttendanceDto>>();
            var dbAttendances = await _context.Attendances.ToListAsync();
            var attendancesForDate = dbAttendances.Where(a => a.Date.Date == date.Date).ToList();
            response.Data = attendancesForDate.Select(a => _mapper.Map<GetAttendanceDto>(a)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetAttendanceDto>> AddAttendance(AddAttendanceDto newAttendance)
        {
            var response = new ServiceResponse<GetAttendanceDto>();

            var studentResponse = await _studentService.GetStudentById(newAttendance.StudentId);
            if (studentResponse.Data == null)
            {
                response.Success = false;
                response.Message = $"Student with ID '{newAttendance.StudentId}' not found.";
                return response;
            }

            var attendance = _mapper.Map<Attendance>(newAttendance);

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetAttendanceDto>(attendance);
            return response;
        }

        public async Task<ServiceResponse<GetAttendanceDto>> UpdateAttendance(UpdateAttendanceDto updatedAttendance)
        {
            var response = new ServiceResponse<GetAttendanceDto>();

            var attendance = await _context.Attendances.FindAsync(updatedAttendance.Id);
            if (attendance == null)
            {
                response.Success = false;
                response.Message = $"Attendance with ID '{updatedAttendance.Id}' not found.";
                return response;
            }

            var studentResponse = await _studentService.GetStudentById(updatedAttendance.StudentId);
            if (studentResponse.Data == null)
            {
                response.Success = false;
                response.Message = $"Student with ID '{updatedAttendance.StudentId}' not found.";
                return response;
            }

            _mapper.Map(updatedAttendance, attendance);
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetAttendanceDto>(attendance);
            return response;
        }

        public async Task<ServiceResponse<List<GetAttendanceDto>>> DeleteAttendance(int id)
        {
            var response = new ServiceResponse<List<GetAttendanceDto>>();

            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null)
            {
                response.Success = false;
                response.Message = $"Attendance with ID '{id}' not found.";
                return response;
            }

            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();

            var dbAttendances = await _context.Attendances.ToListAsync();
            response.Data = dbAttendances.Select(a => _mapper.Map<GetAttendanceDto>(a)).ToList();
            return response;
        }
    }
}
