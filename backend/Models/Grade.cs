
namespace backend.Models
{
    public class Grade
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public string Subject { get; set; } 
        public int TotalGrade { get; set; }
        public string LetterGrade { get; set; }
    }
}