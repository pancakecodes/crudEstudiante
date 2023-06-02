
namespace backend.Dtos.Grade
{
    public class AddGradeDto
    {
        public int StudentId { get; set; }
        public string Subject { get; set; }
        public int TotalGrade { get; set; }
        public string LetterGrade { get; set; } 

    }
}