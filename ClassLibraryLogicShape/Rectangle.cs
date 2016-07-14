using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicShape
{
    public class Rectangle : IShape
    {
        #region Fields
        private int _width;
        private int _height;
        #endregion

        #region Properties

        /// <summary>
        /// Property Width controls input data
        /// </summary>
        public int Width
        {
            get { return _width; }
            set
            {
                if (value > 0)
                    _width = value;
                else
                    throw new ArgumentException(nameof(Rectangle));
            }
        }

        /// <summary>
        /// Property Height checks input data
        /// </summary>
        public int Height
        {
            get { return _height; }
            set
            {
                if (value > 0)
                    _height = value;
                else
                    throw new ArgumentException(nameof(Rectangle));
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method Area finds area of Rectangle
        /// </summary>
        /// <returns>Area</returns>
        public double Area() => Width * Height;

        /// <summary>
        /// Method Perimeter finds perimeter of Rectangle
        /// </summary>
        /// <returns>Perimeter</returns>
        public double Perimeter() => 2*Width + 2*Height;

        #endregion
    }
}
