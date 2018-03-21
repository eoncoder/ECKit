using ECKit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace ECKit
{
    public class SingletonIoC
        : IIoC
    {

        #region Singleton
        private static SingletonIoC _Instance = null;
        public static IIoC Instance
        {
            get        
            {
                if (_Instance == null)
                {
                    _Instance = new SingletonIoC();
                }

                return _Instance;
            }
        }
        #endregion

        private IServiceProvider _Provider = null;
        protected IServiceProvider     Provider
        {
            get
            {
                if ( _Provider == null )
                {
                    BuildProvider();
                }
                return _Provider;
            }
        }
        protected IServiceCollection   _Collection = null;

        public SingletonIoC()
        {
            Reset();
        }

        public void BuildProvider()
        {
            _Provider = _Collection.BuildServiceProvider();
        }

        public void Reset()
        {
            _Collection = new ServiceCollection();
            _Provider = null;
        }

        public IIoC AddScoped<I, C>()
            where I : class
            where C : class, I
        {
            _Collection.AddScoped<I,C>();
            return this;
        }

        public IIoC AddScoped<T>() where T : class
        {
            _Collection.AddScoped<T>();
            return this;
        }

        public IIoC AddTransient<I, C>()
            where I : class
            where C : class, I
        {
            _Collection.AddTransient<I,C>();
            return this;
        }

        public IIoC AddTransient<T>() where T : class
        {
            _Collection.AddTransient<T>();
            return this;
        }

        public IIoC AddSingleton<I, C>()
            where I : class
            where C : class, I
        {
            _Collection.AddSingleton<I, C>();
            return this;
        }

        public IIoC AddSingleton<T>() where T : class
        {
            _Collection.AddSingleton<T>();
            return this;
        }

        public object GetService(Type type)
        {
            return Provider.GetService(type);
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        /*
        public IIoC AddOptions()
        {
            _Collection.AddOptions();
            return this;
        }

        public IIoC Configure<T>(Action<T> configureOptions) where T : class
        {
            _Collection.Configure<T>(configureOptions);
            return this;
        }
        */
    }
}
