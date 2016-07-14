using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicShape
{
    public class Circle : IShape
    {
        #region Fields
        private int _radius;
        #endregion

        #region Properties

        /// <summary>
        /// Property Radius checks input data
        /// </summary>
        public int Radius
        {
            get { return _radius; }
            set
            {
                if (value > 0)
                    _radius = value;
                else
                    throw new ArgumentException(nameof(Circle));
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method Area finds area of Circle
        /// </summary>
        /// <returns>Area</returns>
        public double Area() => Math.PI*Radius*Radius;

        /// <summary>
        /// Method Perimeter finds perimeter of Circle
        /// </summary>
        /// <returns></returns>
        public double Perimeter() => 2*Math.PI*Radius;

        #endregion
    }
}
