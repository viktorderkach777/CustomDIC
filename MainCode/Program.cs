﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Container;

namespace MainCode
{
    class Program
    {
        static void Main(string[] args)
        {
            DIC dc = new DIC();

            dc.Register<ISomeInterface, UsefulClass >(); //A1, R1:A1
            dc.Register<MyAbstractClass, SomeClassRealization>();//A2, R2:A2

            //Console.WriteLine(dc.Resolve<ISomeInterface>().IsDoingNothingMethod());
            //Console.WriteLine(dc.Resolve<MyAbstractClass>().UselessMethod());


            Console.WriteLine(dc.Resolve<ISomeInterface>().IsDoingNothingMethod());//A1, R2:A2
            Console.WriteLine(dc.Resolve<MyAbstractClass>().UselessMethod());//R1:A1, A2
        }
    }

    public interface ISomeInterface
    {
        bool IsDoingNothingMethod();
    }

    public class SomeClassRealization : ISomeInterface
    {
        public bool IsDoingNothingMethod()
        {
            return true;
        }
    }

    public abstract class MyAbstractClass
    {
        public abstract bool UselessMethod();
    }


    public class UsefulClass : MyAbstractClass
    {
        public override bool UselessMethod()
        {
            return false;
        }       
    }
}
