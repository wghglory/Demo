using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06接口之间的继承
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public interface IF1
    {
        void Fly();
    }

    public interface IF2
    {
        void Swim();
    }

    public interface IF3
    {
        void Jump();
    }

    public interface ISuperMan : IF1, IF2, IF3
    {
        void Fly(string msg);
    }

    class MyClass : ISuperMan
    {

        #region IF1 成员

        public void Fly()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IF2 成员

        public void Swim()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IF3 成员

        public void Jump()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ISuperMan 成员

        public void Fly(string msg)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
