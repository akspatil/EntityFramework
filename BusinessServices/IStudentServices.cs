using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IStudentServices
    {
        StudentEntity GetStudentById(long studentId);
        IEnumerable<StudentEntity> GetAllStudents();
        long AddStudentDetails(StudentEntity student);
        bool UpdateStudentDetails(long studentId, StudentEntity student);
        bool DeleteStudentDetails(long studentId);
    }
}
