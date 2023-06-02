
namespace backend.Dtos.Attendance
{
    public class AddAttendanceDto
    {
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
    }
}