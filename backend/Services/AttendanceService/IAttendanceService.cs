
namespace backend.Services.AttendanceService
{
    public interface IAttendanceService
    {
        Task<ServiceResponse<List<GetAttendanceDto>>> GetAttendanceHistory(DateTime date);
        Task<ServiceResponse<GetAttendanceDto>> AddAttendance(AddAttendanceDto newAttendance);
        Task<ServiceResponse<GetAttendanceDto>> UpdateAttendance(UpdateAttendanceDto updatedAttendance);
        Task<ServiceResponse<List<GetAttendanceDto>>> DeleteAttendance(int id);
    }
}
