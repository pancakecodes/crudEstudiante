using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<Student, GetStudentDto>(); 
           CreateMap<AddStudentDto, Student>();
           CreateMap<UpdateStudentDto, Student>();
           CreateMap<Grade, GetGradeDto>();
           CreateMap<AddGradeDto, Grade>();
           CreateMap<UpdateGradeDto, Grade>();
           CreateMap<Attendance, GetAttendanceDto>();
           CreateMap<AddAttendanceDto, Attendance>();
           CreateMap<UpdateAttendanceDto, Attendance>();
        }
    }
}