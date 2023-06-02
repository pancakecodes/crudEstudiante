
namespace backend.Models
{
    
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Student")]
         public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }

    }
}