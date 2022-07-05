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
    /// <param name="input"></param>
    /// <returns></returns>
    public static List<List<Tuple<ArithmeticOperator, string>>> SplitOnOperators(string input) 
    {
        const char endInputStringChar = '+';
        
        var operatorsPriority = new Dictionary<char, int> 
        {
            {(char) ArithmeticOperator.Minus, 1 },
            {(char) ArithmeticOperator.Plus, 1 },
            {(char) ArithmeticOperator.Multiply, 0 },
            {(char) ArithmeticOperator.Divide, 0 },

        };

        input = input + endInputStringChar;

        int startIndex = 0;

        List<Tuple<ArithmeticOperator, string>>? stack = null;

        var lq = new List<List<Tuple<ArithmeticOperator, string>>>();

        for (int i = 0; i < input.Length; i++)
        {
            if (operatorsPriority.ContainsKey(input[i]))
            {
                string newFragment = input.Substring(startIndex, i - startIndex);

                (stack = stack ?? new List<Tuple<ArithmeticOperator, string>>()).Add(((ArithmeticOperator)input[i], newFragment).ToTuple());

                if (operatorsPriority[input[i]] == 1)
                {
                    lq.Add(stack);

                    stack = null;
                }

                startIndex = i + 1;
                continue;
            }

        }    

        return lq;
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
