using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    interface ISay
    {
        void Write(string message);
    }

    class ChinaSay : ISay
    {
        public void Write(string message)
        {
            Console.WriteLine(string.Format("早上，中国人说：{0}", message));
        }
    }
    class USASay : ISay
    {
        public void Write(string message)
        {
            Console.WriteLine(String.Format("早上，美国人说：{0}", message));
        }
    }

    class Person
    {

        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {


            int temp = 0;
            int[] arrA = { 2, 8, 1, 3 };
            int countN = 0;
            for (int i = 0; i < arrA.Length - 1; i++)//外层循环三次
            {
                for (int j = 0; j < arrA.Length - 1 - i; j++)//内层 3次 2次 1次
                {
                    countN++;
                    if (arrA[j] > arrA[j + 1])
                    {
                        temp = arrA[j];
                        arrA[j] = arrA[j + 1];
                        arrA[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine(countN);

            foreach (var item in arrA)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();

            Program pg = new Program();
            int x;
            int y;
            //此处x,y没有进行初始化，则编译不通过。
            //pg.GetRefValue(ref x, ref y);
            int z, v;
            z = v = 0;
            z++;
            v--;
            Console.WriteLine(z);
            Console.WriteLine(v);

            pg.GetRefValue(ref z, ref v);

            //ref  关键字方法体外必须赋值，方法体内可以不赋值
            // out关键字 方法体外可以没有默认值  方法体内必须赋值
            pg.GetValue(out x, out y);
            Console.WriteLine("x={0},y={1}", x, y);
            #region  encode默认编码
            string a = "abcde某某某";
            int m = 1, n = 1, s;

            m = a.Length;
            n = System.Text.Encoding.Default.GetBytes(a).Length;

            Console.WriteLine("m {0}  n {1}", m, n);
            #endregion
            #region 赋值问题 对象指向
            //Person person1 = new Person();
            //person1.Age = 10;
            //Person person2 = new Person();// person1;
            //person2 = person1;
            //person1.Age++;

            //Console.WriteLine(person2.Age); 
            #endregion
            // ChinaSay chinaSay= new ChinaSay();
            // chinaSay.Write("早上好");
            //ISay  isay=new ChinaSay();
            // Factory fac = new Factory(isay);
            // fac.Write("早上好");

            //冒泡排序
            #region 冒泡排序
            //int test = 0;//定义一个中间变量，用来交换值
            //int[] arr = { 8, 2, 45, 1, 9, 89 };//定义一个无序数组，用来排序
            //for (int i = 0; i < arr.Length - 1; i++)//我们外层循环需要循环n-1次   
            //{
            //    Console.WriteLine("i的值"+i);
            //    for (int j = 0; j < arr.Length - 1 - i; j++)//这里-i的原因是  每次循环 俩俩比较  大的冒泡浮出水面   最大的已经移到最后了  不用比较那么多次了
            //    {
            //        Console.WriteLine("J的值"+j);
            //        Console.WriteLine("判断两个值大小是否要交换值");
            //        if (arr[j] > arr[j + 1])//判断两个值大小是否要交换值
            //        {
            //           // Console.WriteLine("如果数组第二个数小于前一个数，那么把第二个小的数先存放在 test中");
            //            test = arr[j + 1];//如果数组第二个数小于前一个数，那么把第二个小的数先存放在 test中
            //           // Console.WriteLine(test);
            //         //   Console.WriteLine("把前一个大的数放到后面");
            //            arr[j + 1] = arr[j];//把前一个大的数放到后面
            //         //   Console.WriteLine(arr[j + 1]);
            //         //   Console.WriteLine("再把我们存放在test中的小的数放到前面");
            //            arr[j] = test;//再把我们存放在test中的小的数放到前面
            //        //    Console.WriteLine(arr[j]);
            //        }
            //        foreach (var item in arr)//遍历这个排序后的数组
            //        {
            //            Console.Write(item + " ");//输出
            //        }

            //        //  Console.WriteLine("本次"+ arr[j]+"'"+ arr[j + 1]);
            //    }
            //} 
            //foreach (var item in arr)//遍历这个排序后的数组
            //{
            //    Console.Write(item + " ");//输出
            //}
            #endregion
            Console.ReadKey();


            Console.ReadKey();
        }

        public void GetRefValue(ref int x, ref int y)
        {

        }

        public void GetValue(out int x, out int y)
        {
            x = 1000;
            y = 1;
        }
    }

    class Factory : ISay
    {
        ISay _isay;
        public Factory(ISay isay)
        {
            this._isay = isay;
        }



        #region ISay 成员

        public void Write(string message)
        {
            this._isay.Write(message);
        }
        #endregion

    }

}
