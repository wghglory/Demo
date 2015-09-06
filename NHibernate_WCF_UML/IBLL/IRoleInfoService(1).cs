using System.Runtime.Serialization;
using System.ServiceModel;

namespace IBLL
{
    [ServiceContract]
    public interface IRoleInfoService
    {
        [OperationContract]
        UserInfo GetUser(int id);
    }
}