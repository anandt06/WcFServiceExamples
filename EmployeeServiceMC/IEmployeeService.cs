using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeServiceMC
{
    //[ServiceContract]
    //public interface IEmployeeService
    //{
    //    [OperationContract]
    //    Employee GetEmployee(int Id);

    //    [OperationContract]
    //    void SaveEmployee(Employee Employee);
    //}

    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        EmployeeInfo GetEmployee(EmployeeRequest employeeRequest);

        [OperationContract]
        void SaveEmployee(EmployeeInfo Employee);
    }
}
