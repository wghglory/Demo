using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09异常处理
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = 10, b = 0;
                int c = a / b;
                Console.WriteLine(c);
            }
            catch (DivideByZeroException ex)
            {

                Console.WriteLine("DivideByZeroException" + ex.Message);
                throw;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception" + ex.Message);
            }
            Console.ReadKey();


            try
            {
                Console.WriteLine("===================================");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                int n = 10, m = 0;
                try
                {
                    Console.WriteLine(n / m);
                }
                catch
                {
                }
                finally
                {
                    Console.WriteLine("111111111111111111111");
                }
            }
            Console.ReadKey();

            #region 异常1

            ////try
            ////{
            ////    //可能发生异常的代码
            ////}
            ////catch
            ////{

            ////    throw; //继续向上抛出异常。
            ////}
            ////finally
            ////{
            ////    //..
            ////}
            ////Person p = new Person();

            ////p = null;

            ////try
            ////{
            ////    //当try块中某行代码发生异常后，从该行代码开始后面的代码都不会继续执行了，
            ////    //程序直接跳转到catch块中进行执行
            ////    p.Name = "张三";
            ////    Console.WriteLine("====================");
            ////    Console.WriteLine(p.Name);
            ////}
            ////catch (Exception ex)
            ////{
            ////    Console.WriteLine(ex.Message);
            ////}
            ////finally
            ////{
            ////    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$4");
            ////}

            ////Console.ReadKey();

            ////==========catch块的几种写法======================
            //try
            //{
            //    int n = 10, m = 0;
            //    int r = n / m;
            //    Console.WriteLine(r);
            //}
            ////第三种：对不同的异常，使用不同的方式来处理（使用多个不同的catch块来捕获异常）
            //catch (NullReferenceException e)
            //{
            //    //空指针异常
            //    Console.WriteLine("空指针异常：{0}", e.Message);
            //}
            //catch (DivideByZeroException e)
            //{
            //    //除数为0的异常
            //    Console.WriteLine("除数为0，详细信息：{0}", e.StackTrace);
            //}
            //catch (ArgumentException e)
            //{
            //    //参数异常
            //    Console.WriteLine("参数异常,详细信息：{0}", e.StackTrace);
            //}
            //catch (Exception e)
            //{
            //    //捕获其余所有的异常
            //    Console.WriteLine(e.StackTrace);
            //}


            ////第一种：    //这种写法可以捕获try块中的所有异常
            ////catch
            ////{
            ////    Console.WriteLine("发生异常了！");
            ////}



            ////    //第二种：
            //////这种写法可以捕获try块中的所有异常
            ////catch (Exception ex)
            ////{
            ////    Console.WriteLine("发生异常了！");
            ////    Console.WriteLine(ex.Message);
            ////    Console.WriteLine(ex.Source);
            ////    Console.WriteLine(ex.StackTrace);
            ////}
            //finally
            //{
            //    Console.WriteLine("finally中的代码@！！");
            //}
            //Console.ReadKey();
            #endregion

            #region 异常2

            //try
            //{
            //    Console.WriteLine("11111111111111111111");
            //    int n = 10, m = 0;
            //    Console.WriteLine(n / m);
            //    Console.WriteLine("22222222222222222222");
            //}
            //catch (Exception)
            //{

            //    Console.WriteLine("333333333333333333");
            //}
            //finally
            //{
            //    //如果希望代码无论如何都要被执行，则一定要将代码放在finally块中
            //    //1.当catch有无法捕获到的异常时，程序崩溃，但在程序崩溃前会执行finally中的代码，而finally块后的代码则由于程序崩溃了无法执行
            //    //2.如果在catch块中又引发了异常，则finally块中的代码也会在继续引发异常之前执行，但是finally块后的代码则不会执行
            //    //3.当catch块中有Return语句时，finally块中的代码会在return 之前执行，但是finally块后的代码不会执行。
            //    Console.WriteLine("44444444444444444444");
            //}
            ////Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            //Console.ReadKey();

            #endregion

            #region 异常3

            //while (true)
            //{
            //    try
            //    {
            //        Console.WriteLine("请输入一个人名：");
            //        string name = Console.ReadLine();
            //        if (name == "黄林")
            //        {
            //            //手动抛出一个异常
            //            throw new Exception("姓名不合法！");
            //        }
            //        else
            //        {
            //            Console.WriteLine("姓名合法：{0}", name);
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //        Console.WriteLine("发生异常了！！");
            //        Console.WriteLine(ex.Message);
            //        Console.WriteLine(ex.StackTrace);
            //    }
            //}

            #endregion

            #region 异常4
            try
            {
                M2();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //e.InnerException
            }
            Console.ReadKey();

            #endregion

        }

        static void M2()
        {
            Console.WriteLine("====================");
            Console.WriteLine("====================");
            try
            {
                M1();
            }
            catch
            {
                Console.WriteLine("M1方法中发生异常了。");
                throw;
            }
            finally
            {
            }

            Console.WriteLine("====================");
            Console.WriteLine("====================");
        }

        static void M1()
        {
            try
            {
                int n = 10, m = 0;
                int r = n / m;
                Console.WriteLine("结果是：{0}", r);
            }
            catch (Exception e)
            {
                Console.WriteLine("捕获了该异常并且已经做了相关处理！！！");
                //在catch中使用throw;语句，并且这种用法只能用在catch块中。
                //这种写法只能在catch块中写。
                //throw;表示将当前异常继续向上抛出。
                //直接把当前异常抛出
                // throw;
                //第2中写法
                throw new Exception("这是我自己定义的异常", e);
            }
        }
    }
    public class Person
    {
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

    }

    public class MyException : Exception
    {

    }
}
