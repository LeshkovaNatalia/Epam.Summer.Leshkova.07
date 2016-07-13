using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicBook
{
    public class SortBookPages : IComparer<Book>
    {
        /// <summary>
        /// Method Compare sorting books ascending Pages field
        /// </summary>
        public int Compare(Book x, Book y)
        {
            if (x.Pages > y.Pages)
                return 1;
            if (x.Pages < y.Pages)
                return -1;

            return 0;
        }
    }
}
