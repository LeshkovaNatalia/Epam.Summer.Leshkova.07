using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicBook
{
    public class SortBookYear : IComparer<Book>
    {
        /// <summary>
        /// Method Compare sorting books ascending Year field
        /// </summary>
        public int Compare(Book x, Book y)
        {
            if (x.Year > y.Year)
                return 1;
            if (x.Year < y.Year)
                return -1;

            return 0;
        }
    }
}
