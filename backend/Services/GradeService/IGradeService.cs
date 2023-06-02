
namespace backend.Services.GradeService
{
    public interface IGradeService
    {
        Task <ServiceResponse<List<GetGradeDto>>> GetAllGrades();

        Task <ServiceResponse<GetGradeDto>> GetGradeById(int id);

        Task <ServiceResponse<List<GetGradeDto>>> AddGrade(AddGradeDto newGrade);

        Task <ServiceResponse<GetGradeDto>> UpdateGrade(UpdateGradeDto updatedGrade);

        Task <ServiceResponse<List<GetGradeDto>>> DeleteGrade(int id);
    }
}