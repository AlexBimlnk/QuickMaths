using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.BL.Functions
{
    /// <summary>
    /// Поддерживает создание производных.
    /// </summary>
    public interface IDerivativable
    {
        /// <summary>
        /// Рассчитать производную.
        /// </summary>
        public IFunction Derivative();
    }
}
