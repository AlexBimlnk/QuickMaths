using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuickMaths.BL.Functions
{
    //Todo: Test for (composite) function 
    public class CompositeFunctionTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("4","(4)")]
        [InlineData("x","(x)")]
        [InlineData("4*x", "(4*x)")]
        [InlineData("4*(4 + x)", "(4*(4 + x))")]
        [InlineData("4*(4 + 4*x)", "(4*(4 + 4*x))")]
        [InlineData("(4 + 4*x)*(4 + 4*x)", "((4 + 4*x)*(4 + 4*x))")]
        [InlineData("15*x+4*x+x", "(15*x + 4*x + x)")]
        [InlineData("15x+4*x+x", "(15*x + 4*x + x)")] //Todo: Автоматическое расставление пропущенных символов
        [InlineData("15/x+4*x+x", "(15/x + 4*x + x)")] //Реализация парсинга других мат. операторов
        [InlineData("15/(x+4*x+x)", "(15/(x + 4*x + x))")] 
        public void ToString_String_ReturnStringAsFunction(string inputString, string outputString = "")
        {
            CompositeFunction compositeFunction = null;
            Action action = () => compositeFunction = new CompositeFunction(inputString);

            try
            {
                action();

                Assert.Equal(compositeFunction.ToString(), outputString);
            }
            catch
            {
                Assert.Throws<ArgumentException>(action);
            }
        }

        //ToDo: Тесты для производных
        [Theory]
        [InlineData("1", null)]
        [InlineData("x", "(1)")]
        [InlineData("4*x", "(4)")]
        [InlineData("4*(4 + x)", "(4*x)")]
        [InlineData("4*(4 + 4*x)", "(4*4*x))")]
        [InlineData("(4 + 4*x)*(4 + 4*x)", "((4*x)*(4 + 4*x)+(4 + 4*x)*(4*x))")]
        [InlineData("15*x+4*x+x", "(15 + 4 + 1)")]
        public void Derivative_NaN_ReturnDerivativeFunction(string inputString, string outputString = "")
        {
            CompositeFunction compositeFunction = null;
            Action action = () => compositeFunction = new CompositeFunction(inputString);

            try
            {
                action();
                string result = compositeFunction.Derivative().ToString();
                Assert.Equal(result, outputString);
            }
            catch
            {
                Assert.Throws<ArgumentException>(action);
            }
        }
    }
}
