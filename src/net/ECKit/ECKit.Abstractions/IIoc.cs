using System;
using System.Linq.Expressions;

namespace ECKit.Abstractions
{
    public interface IIoC
    {


        IIoC AddScoped<I, C>()
            where I : class
            where C : class, I;
        IIoC AddScoped<T>() where T : class;

        IIoC AddTransient<I, C>()
            where I : class
            where C : class, I;
        IIoC AddTransient<T>() where T : class;

        IIoC AddSingleton<I, C>()
            where I : class
            where C : class, I;
        IIoC AddSingleton<T>() where T : class;

        T GetService<T>();
        object GetService(Type type);

        /*
        IIoC AddOptions();
        IIoC Configure<T>(Action<T> configureOptions) where T : class;
        */
        void Reset();
        
    }
}
