using QuickMaths.FunctionsBLL.Functions;
using QuickMaths.General.Abstractions;

using Xunit;

namespace QuickMaths.FunctionsBLL.Tests.Functions;

public class LinearFunctionTestsData
{
    public static TheoryData<LinearFunction, IFunction, bool> EqualsLFAndOtherFunctionData = new()
    {
        // LinearFunction
        {
            new LinearFunction(new VariableFunction("x"), new NumberFunction(1)),
            new LinearFunction(new VariableFunction("y"), new NumberFunction(2)),
            false
        },
        {
            new LinearFunction(new VariableFunction("x"), new NumberFunction(1)),
            new LinearFunction(new VariableFunction("x"), new NumberFunction(1)),
            true
        },
        // NumberFunction
        {
            new LinearFunction(new NumberFunction(1)),
            new NumberFunction(1),
            true
        },
        {
            new LinearFunction(new NumberFunction(2)),
            new NumberFunction(1),
            false
        },
        {
            new LinearFunction(new VariableFunction("x"), new NumberFunction(1)),
            new NumberFunction(1),
            false
        },
        // VariableFunction
        {
            new LinearFunction(new VariableFunction("x"), new NumberFunction(1)),
            new VariableFunction("x"),
            true
        },
        {
            new LinearFunction(new VariableFunction("x"), new NumberFunction(2)),
            new VariableFunction("x"),
            false
        },
        {
            new LinearFunction(new VariableFunction("y"), new NumberFunction(1)),
            new VariableFunction("x"),
            false
        }
    };
}