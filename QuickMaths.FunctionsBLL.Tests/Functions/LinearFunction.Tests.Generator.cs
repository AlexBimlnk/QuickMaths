using Xunit;

using QuickMaths.FunctionsBLL.Functions;
using QuickMaths.General.Abstractions;

namespace QuickMaths.FunctionsBLL.Tests.Functions;

internal class LinearFunctionTestsData
{
    public static TheoryData<LinearFunction, IFunction> GetKoefData
    {
        get
        {
            var data = new TheoryData<LinearFunction, IFunction>();


            return data;
        }
    }
    public static TheoryData<LinearFunction, IFunction> GetArgumentData
    {
        get
        {
            var data = new TheoryData<LinearFunction, IFunction>();


            return data;
        }
    }

    public static TheoryData<NumberFunction, IFunction, bool> EqualsLFAndOtherFunctionData
    {
        get
        {
            var data = new TheoryData<NumberFunction, IFunction, bool>();


            return data;
        }
    }
    public static TheoryData<NumberFunction, object, bool> EqualsLFAndObjectData
    {
        get
        {
            var data = new TheoryData<NumberFunction, object, bool>();


            return data;
        }
    }
    public static TheoryData<LinearFunction, int> GetHashCodeData
    {
        get
        {
            var data = new TheoryData<LinearFunction, int>();


            return data;
        }
    }
    public static TheoryData<LinearFunction, string> ToStringData
    {
        get
        {
            var data = new TheoryData<LinearFunction, string>();


            return data;
        }
    }
}
