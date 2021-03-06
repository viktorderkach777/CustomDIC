﻿using System;
using System.Collections.Generic;

namespace Container
{
    public class InvalidAbstractionType:Exception
    {
        public override string Message => "Parameter is either Interface or Abstract class";
    }

    public class RequestNotRegisteredTypeException : Exception
    {
        public override string Message => "This type doesn't exist";
    }

    public class NoParentException : Exception
    {
        public override string Message => "This type doesn't inherits or implements current abstraction";
    }


    public class DIC
    {
        public IDictionary<Type, Type> TypesStorage { get; private set; }

        public DIC()
        {
            TypesStorage = new Dictionary<Type, Type>();
        }

        public void Register <T1, T2>()
        {
            var type1 = typeof(T1);
            var type2 = typeof(T2);

            if (type2.IsAbstract || type2.IsInterface)
            {
                throw new InvalidAbstractionType();
            }

            if (!type1.IsAbstract && !type1.IsInterface)
            {
                throw new InvalidAbstractionType();
            }
           
            var res = type1.IsAssignableFrom(type2);

            if (!res)
            {
                throw new NoParentException();
            }

            TypesStorage.Add(type1, type2);
        }

        public T1 Resolve<T1>()
        {
            var type1 = typeof(T1);

            if (!TypesStorage.ContainsKey(type1))
            {
                throw new RequestNotRegisteredTypeException();
            }

            var myType = TypesStorage[typeof(T1)];
            var instance = Activator.CreateInstance(myType);
            return (T1)instance;
        }
    }
}
