using System;
using Container;

namespace MainCode
{
    class Program
    {
        static void Main(string[] args)
        {
            DIC dc = new DIC();

            dc.Register<IBaseInterface, SomeClassRealization>(); 
            dc.Register<MyAbstractClass,  UsefulClass> ();

            Console.WriteLine(dc.Resolve<ISomeInterface>().IsDoingNothingMethod());
            Console.WriteLine(dc.Resolve<MyAbstractClass>().UselessMethod());      
        }
    }

    public interface ISomeInterface : IBaseInterface
    {       
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
