using System.Runtime.Serialization;

namespace IBLL
{
    [DataContract]
    public class UserInfo
    {
        [DataMember]
        public int Id { get; set; }


        [DataMember]
        public string UName { get; set; }
    }
}