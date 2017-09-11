using System;
using System.Collections.Generic;

namespace MunichProject.Infrastructure
{
    public class Singleton
    {
        #region Singleton Object

        private static readonly IDictionary<Type, object> _instances;

        static Singleton()
        {
            _instances = new Dictionary<Type, object>();
        }

        public static IDictionary<Type, object> Instances
        {
            get { return _instances; }
        }

        #endregion
    }

    public class Singleton<T> : Singleton
    {
        static T _instance;

        public static T Instance
        {
            get { return _instance; }
            set
            {
                _instance = value;
                Instances[typeof(T)] = value;
            }
        }
    }
}