using APIFel.Model;
using System.ServiceModel;

namespace APIFel.Services
{
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        Login Login();
    }
}
