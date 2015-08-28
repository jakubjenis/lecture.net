using System.Collections.Generic;
using System.Linq;
using Foxconn.Bo;
using Foxconn.Dal;

namespace Foxconn.Wcf
{
    public class FoxconnService : IFoxconnService
    {
        private DatabaseRepository _repository;

        public FoxconnService()
        {
            _repository = new DatabaseRepository();
        }

        public List<Student> GetStudents()
        {
            return _repository.GetStudents();
        }

        public List<Student> GetStudentByName(string name)
        {
            return _repository.GetStudentByName(name);
        }

        public void InsertStudent(Student student)
        {
            _repository.InsertStudent(student);
        }
    }
}
