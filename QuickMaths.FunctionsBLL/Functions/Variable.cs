namespace QuickMaths.FunctionsBLL.Functions;

/// <summary>
/// Переменная.
/// </summary>
public class Variable : IFunction
{
    public Variable(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException(null, nameof(name));

        Name = name;
    }
    public Variable(string name, double value)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException(null, nameof(name));

        Name = name;
        Value = value;
    }


    public string Name { get; init; }
    public double Value { get; set; }


    public double Calculate() => Value;
    public IFunction Derivative() => new NumberFunction(1);
    public override string ToString() => Name;
}
