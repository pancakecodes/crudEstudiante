

namespace backend.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; } = "Sabrina";
        public string LastName { get; set; } = "Green";
    }
}