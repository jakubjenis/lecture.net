using System.Collections.Generic;
using System.ServiceModel;
using Foxconn.Bo;

namespace Foxconn.Wcf
{
    [ServiceContract]
    public interface IFoxconnService
    {
        [OperationContract]
        List<Student> GetStudents();

        [OperationContract]
        List<Student> GetStudentByName(string name);

        [OperationContract]
        void InsertStudent(Student student);
    }
}
