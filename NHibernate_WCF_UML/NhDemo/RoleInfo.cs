using System;

namespace NhDemo
{
    public class RoleInfo
    {
        public virtual int ID { get; set; }

        public virtual string RoleName { get; set; }

        public virtual DateTime SubTime { get; set; }

        public virtual DateTime ModifiedOn { get; set; }

        public virtual short DelFlag { get; set; }
    }
}