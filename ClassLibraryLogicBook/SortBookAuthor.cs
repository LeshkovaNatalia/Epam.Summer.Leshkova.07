using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicBook
{
    public class SortBookAuthor : IComparer<Book>
    {
        /// <summary>
        /// Method Compare sorting books ascending Author field
        /// </summary>
        public int Compare(Book x, Book y)
        {
            if (String.CompareOrdinal(x.Author, y.Author) > 0)
                return 1;
            if (String.CompareOrdinal(x.Author, y.Author) < 0)
                return -1;

            return 0;
        }
    }
}
