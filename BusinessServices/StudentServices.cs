using BusinessEntities;
using DataModel.UnitofWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Transactions;

namespace BusinessServices
{
    public class StudentServices : IStudentServices
    {
        private UnitOfWork _unitOfWork;
        public StudentServices()
        {
            _unitOfWork = new UnitOfWork();
        }




        public StudentEntity GetStudentById(long studentId)
        {
            var student = _unitOfWork.StudentRepository.GetById(studentId);
            if (student != null)
            {
                var config = new MapperConfiguration(c => { c.CreateMap<StudentDetail, StudentEntity>(); });
                IMapper mapper = config.CreateMapper();

                StudentEntity newStudent = Mapper.Map<StudentDetail, StudentEntity>(student);
                return newStudent;
            }
            return null;
        }

        public IEnumerable<StudentEntity> GetAllStudents()
        {
            var students = _unitOfWork.StudentRepository.GetAll().ToList();
            if (students.Any())
            {
                var config = new MapperConfiguration(c => { c.CreateMap<StudentDetail, StudentEntity>(); });
                IMapper mapper = config.CreateMapper();

                List<StudentEntity> allStudents = Mapper.Map<List<StudentDetail>, List<StudentEntity>>(students);
                return allStudents;
            }
            return null;
        }

        public long AddStudentDetails(StudentEntity student)
        {
            using (var scope = new TransactionScope())
            {
                StudentDetail studentDetails = new StudentDetail
                {
                    FirstName = student.Firstname,
                    LastName = student.Lastname,
                    PhoneNumber = student.PhoneNumber,
                    EnrolledHours = student.EnrolledHours,
                    EmailId = student.EmailId,
                    Suburb = student.Suburb
                };
                _unitOfWork.StudentRepository.Insert(studentDetails);
                _unitOfWork.Save();
                scope.Complete();
                return studentDetails.StudentId;
            }
        }

        public bool UpdateStudentDetails(long studentId, StudentEntity studentEntity)
        {
            bool success = false;
            if (studentEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var student = _unitOfWork.StudentRepository.GetById(studentId);
                    if (student != null)
                    {
                        student.FirstName = studentEntity.Firstname;
                        student.LastName = studentEntity.Lastname;
                        student.PhoneNumber = studentEntity.PhoneNumber;
                        student.EnrolledHours = studentEntity.EnrolledHours;
                        student.Suburb = studentEntity.Suburb;
                        student.EmailId = studentEntity.EmailId;
                        _unitOfWork.StudentRepository.Update(student);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteStudentDetails(long studentId)
        {
            var success = false;
            if (studentId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var student = _unitOfWork.StudentRepository.GetById(studentId);
                    if (student != null)
                    {
                        _unitOfWork.StudentRepository.Delete(student.StudentId);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
