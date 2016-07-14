using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryLogicShape
{
    public class Square:IShape
    {
        #region Fields
        private int _side;
        #endregion

        #region Properties

        /// <summary>
        /// Property Side checks input data
        /// </summary>
        public int Side
        {
            get { return _side; }
            set
            {
                if (value > 0)
                    _side = value;
                else
                    throw new ArithmeticException(nameof(Square));
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method Perimeter finds perimeter of Square
        /// </summary>
        /// <returns>Perimeter</returns>
        public double Perimeter() => 4 * Side;

        /// <summary>
        /// Method Area finds area of Square
        /// </summary>
        /// <returns>Area</returns>
        public double Area() => Side * Side;

        #endregion
    }
}
