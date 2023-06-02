namespace backend.Services.GradeService
{
    public class GradeService : IGradeService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public GradeService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetGradeDto>>> GetAllGrades()
        {
            var serviceResponse = new ServiceResponse<List<GetGradeDto>>();
            var dbGrades = await _context.Grades.ToListAsync();
            serviceResponse.Data = dbGrades.Select(g =>
            {
                g.LetterGrade = CalculateLetterGrade(g.TotalGrade);
                return _mapper.Map<GetGradeDto>(g);
            }).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetGradeDto>> GetGradeById(int id)
        {
            var serviceResponse = new ServiceResponse<GetGradeDto>();
            var grade = await _context.Grades.FindAsync(id);
            if (grade is null)
                throw new Exception($"Grade with Id '{id}' not found");
            grade.LetterGrade = CalculateLetterGrade(grade.TotalGrade);
            serviceResponse.Data = _mapper.Map<GetGradeDto>(grade);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetGradeDto>>> AddGrade(AddGradeDto newGrade)
        {
            var serviceResponse = new ServiceResponse<List<GetGradeDto>>();
            var grade = _mapper.Map<Grade>(newGrade);
            grade.LetterGrade = CalculateLetterGrade(grade.TotalGrade);
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Grades.Select(g => _mapper.Map<GetGradeDto>(g)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetGradeDto>> UpdateGrade(UpdateGradeDto updatedGrade)
        {
            var serviceResponse = new ServiceResponse<GetGradeDto>();
            var grade = await _context.Grades.FindAsync(updatedGrade.Id);
            if (grade is null)
                throw new Exception($"Grade with Id '{updatedGrade.Id}' not found");
            grade.TotalGrade = updatedGrade.TotalGrade;
            grade.LetterGrade = CalculateLetterGrade(grade.TotalGrade);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetGradeDto>(grade);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetGradeDto>>> DeleteGrade(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetGradeDto>>();
            var grade = await _context.Grades.FindAsync(id);
            if (grade is null)
                throw new Exception($"Grade with Id '{id}' not found");
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Grades.Select(g => _mapper.Map<GetGradeDto>(g)).ToListAsync();
            return serviceResponse;
        }

        private string CalculateLetterGrade(int totalGrade)
        {
            if (totalGrade >= 90 && totalGrade <= 100)
                return "A";
            else if (totalGrade >= 80 && totalGrade <= 89)
                return "B";
            else if (totalGrade >= 70 && totalGrade <= 79)
                return "C";
            else
                return "F";
        }
    }
}
