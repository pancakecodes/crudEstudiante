
namespace backend.Dtos.Grade
{
    public class GetGradeDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Subject { get; set; } 
        public int TotalGrade { get; set; }
        public string LetterGrade { get; set; } 
    }
}