using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickMaths.General.Enums;

namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Базовый класс парсера.
/// </summary>
/// <typeparam name="TEntity" xml:lang = "ru">
/// Сущность, которую парсер должен вернуть после разбора строки.
/// </typeparam>
public abstract class ParserBase<TEntity>
{
    /// <summary>
    /// 
    /// </summary>
    protected static HashSet<char> _usedOperators;

    static ParserBase() => SetSplitOperators(ArithmeticOperator.Plus, ArithmeticOperator.Multiply, ArithmeticOperator.Divide, ArithmeticOperator.Minus);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="operators"></param>
    public static void SetSplitOperators(params ArithmeticOperator[] operators)
    {
        _usedOperators = new HashSet<char>();

        foreach(var singleOperator in operators)
        {
            _usedOperators.Add((char)singleOperator);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static List<Tuple<ArithmeticOperator, string, int>> SplitOnOperators(string input) 
    {
        const ArithmeticOperator nonValuableOperator = ArithmeticOperator.Plus;

        var splitSymbols =  new StringBuilder("()");

        var newFragment = new StringBuilder();

        if (input is null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        if (input.Length == 0)
        {
            throw new ArgumentException("The length of input string is zero");
        }

        input += (char)nonValuableOperator;

        _usedOperators.ToList().ForEach(charOperator => splitSymbols.Append(charOperator)); 

        int indexToAdd = 0;
        ArithmeticOperator lastOperator = nonValuableOperator;

        var splittedString = new List<Tuple<ArithmeticOperator, string, int>>();
        var bracketStack = new Stack<Tuple<int,Tuple<ArithmeticOperator, string>>>();

        for (int i = 0; i < input.Length; i++)
        {
            if (splitSymbols.ToString().Contains(input[i]))
            {
                if (_usedOperators.Contains(input[i]))
                {
                    splittedString.Insert(indexToAdd, (lastOperator, newFragment.ToString(), bracketStack.Count).ToTuple());
                    
                    newFragment.Clear();
                    lastOperator = (ArithmeticOperator)input[i];
                    indexToAdd = splittedString.Count;
                }
                else if (input[i] == '(')
                {
                    bracketStack.Push((splittedString.Count, (lastOperator, newFragment.Append('(').ToString()).ToTuple()).ToTuple());

                    newFragment.Clear();
                    lastOperator = nonValuableOperator;
                }
                else
                {
                    splittedString.Insert(indexToAdd, (lastOperator, newFragment.ToString(), bracketStack.Count).ToTuple());
                    
                    newFragment.Clear();
                    var bracketFragment = bracketStack.Pop();
                    indexToAdd = bracketFragment.Item1;
                    lastOperator = bracketFragment.Item2.Item1;
                    newFragment = new StringBuilder(bracketFragment.Item2.Item2).Append(')');
                }

                continue;
            }

            newFragment.Append(input[i]);
        }    

        return splittedString;
    }

    /// <summary xml:lang = "ru">
    /// Создает дерево выражений с сущностями типа <typeparamref name="TEntity"/> по входной строке.
    /// </summary>
    /// <param name="input" xml:lang = "ru">
    /// Входная строка, которую нужно распарсить.
    /// </param>
    /// <returns xml:lang = "ru">
    /// Дерево выражений, наполненное сущностями типа <typeparamref name="TEntity"/>.
    /// </returns>
    /// <exception cref="FormatException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract ITreeExpression<TEntity> BuildExpression(string input);

    /// <summary xml:lang = "ru">
    /// Разбирает входную строку и пытается привести её к объекту типа <typeparamref name="TEntity"/>.
    /// </summary>
    /// <param name="inputString" xml:lang = "ru">
    /// Входная строка, которую нужно распарсить.
    /// </param>
    /// <returns xml:lang = "ru">
    /// Объект типа <typeparamref name="TEntity"/>.
    /// </returns>    
    /// <exception cref="FormatException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract TEntity Parse(string inputString);

    /// <summary xml:lang = "ru">
    /// Разбирает входную строку и пытается привести её к объекту типа <typeparamref name="TEntity"/>.
    /// Не генерирует исключений, сообщая результат попытки конвертации.
    /// </summary>
    /// <param name="inputString" xml:lang = "ru">
    /// Входная строка, которую нужно распарсить.
    /// </param>
    /// <param name="result" xml:lang = "ru">
    /// Объектом типа <typeparamref name="TEntity"/>, являющийся результатом парсинга.
    /// </param>
    /// <returns xml:lang = "ru">
    /// <see langword="true"/> если операция успешно выполнена, 
    /// <see langword="false"/> когда конвертирование не удалось.
    /// </returns>
    public abstract bool TryParse(string inputString, out TEntity result);

    /// <summary xml:lang = "ru">
    /// Асинхронно разбирает входную строку и пытается привести её к объекту типа <typeparamref name="TEntity"/>.
    /// </summary>
    /// <param name="inputString" xml:lang = "ru">
    /// Входная строка, которую нужно распарсить.
    /// </param>  
    /// <param name="token" xml:lang = "ru">
    /// Токен отмены операции.
    /// </param>
    /// <returns xml:lang = "ru">
    /// Задача типа <see cref="Task{TResult}"/>, результат которой
    /// является объект типа <typeparamref name="TEntity"/>.
    /// </returns>
    /// <exception cref="FormatException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="OperationCanceledException"/>
    public abstract Task<TEntity> ParseAsync(string inputString, CancellationToken token);
}
