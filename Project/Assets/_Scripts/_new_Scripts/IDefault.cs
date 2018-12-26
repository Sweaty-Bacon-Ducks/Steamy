using System;
namespace Steamy
{
    public interface IDefault<T>
    {
        T CreateFromDefaults();
    }
}
