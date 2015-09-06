using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _06foreach循环2
{
    class Program
    {
        static void Main(string[] args)
        {
            //IEnumerator<string>

            Person p = new Person();

            IEnumerator etor = p.GetEnumerator();
            while (etor.MoveNext())
            {
                Console.WriteLine(etor.Current.ToString());
            }
            //etor.Reset();
            //while (etor.MoveNext())
            //{
            //    Console.WriteLine(etor.Current.ToString());
            //}
            Console.WriteLine("ok");


            //Person p = new Person();
            //foreach (string item in p)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("ok");


            //Person p = new Person();
            //foreach (var item in p)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("ok");

            //Hashtable hash = new Hashtable();
            //hash.Add("hl", "huanglin");
            //hash.Add("xzl", "xuzhenglong");
            //foreach (DictionaryEntry item in hash)
            //{

            //}
            //Dictionary<int, string> dict = new Dictionary<int, string>();
            //dict.Add(1001, "huanglin");
            //dict.Add(1002, "xuzhenglong");
            //foreach (var item in dict)
            //{

            //}

            Console.ReadKey();

        }
    }

    public class MyClass : IEnumerable<string>
    {

        #region IEnumerable<string> 成员

        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable 成员

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class MyClass1 : IEnumerable
    {

        #region IEnumerable 成员

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }


    //1.需要让该类型实现一个名字叫IEnumerable的接口,实现该接口的主要目的是为了让当前类型中增加一个名字叫GetEnumerator()的方法
    public class Person : IEnumerable
    {
        private string[] Friends = new string[] { "黄林", "许正龙", "彭德怀", "杨硕" };

        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }

        #region IEnumerable 成员

        //这个方法的作用就是返回一个“枚举器”
        public IEnumerator GetEnumerator()
        {
            //1.在这个方法中该写什么代码？？？
            return new PersonEnumerator(this.Friends);
        }

        #endregion
    }

    //这个类型就是一个“枚举器”
    //希望一个类型被“枚举”，“遍历”，就要实现了类，该类就是一个“枚举器”
    public class PersonEnumerator : IEnumerator
    {
        public PersonEnumerator(string[] fs)
        {
            _friends = fs;
        }
        private string[] _friends;

        //一般下标都是一开始指向了第一条的前一条。
        private int index = -1;


        #region IEnumerator 成员

        public object Current
        {
            get
            {
                if (index >= 0 && index < _friends.Length)
                {
                    return _friends[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public bool MoveNext()
        {
            if (index + 1 < _friends.Length)
            {
                index++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            index = -1;
        }

        #endregion
    }

    public interface IFace1
    {
        void F1();
    }

    public interface IFace2
    {
        int F1();
    }

    public class C1:IFace1,IFace2
    {

        #region IFace1 成员

        public void F1()
        {
            throw new NotImplementedException();
        }

        #endregion


        #region IFace2 成员

        int IFace2.F1()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
