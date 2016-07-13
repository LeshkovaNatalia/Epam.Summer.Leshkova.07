using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace ClassLibraryLogicBook
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        #region Properties

        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }

        #endregion

        #region Ctor

        public Book(string author, string title, int year, int pages)
        {
            Author = author;
            Title = title;
            Year = year;
            Pages = pages;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method SortBooks sorts array of books according to the comparator
        /// </summary>
        public static Book[] SortBooks(Book[] books, IComparer<Book> comparer)
        {
            for (int i = 0; i < books.Length - 1; i++)
            {
                for (int j = i + 1; j < books.Length; j++)
                {
                    if (comparer.Compare(books[i], books[j]) > 0)
                        SwapBooks(ref books[i], ref books[j]);
                }
            }
            return books;
        }

        #region Override Object Methods

        public override string ToString()
        {
            return $"Book record: {Title}, {Author}, {Year}, {Pages}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != this.GetType())
                return false;

            return Equals((Book)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 23;
                
                hash = hash * 29 + Author.GetHashCode();
                hash = hash * 29 + Title.GetHashCode();
                hash = hash * 29 + Year.GetHashCode();
                hash = hash * 29 + Pages.GetHashCode();

                return hash;
            }
        }

        #endregion

        #region Method Equals. Overload operations == | !=

        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return CompareFields(this, other);
        }

        public static bool operator ==(Book lhs, Book rhs)
        {
            if ((object)lhs == null || (object)rhs == null)
                return Equals(lhs, rhs);

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Book lhs, Book rhs)
        {
            if ((object)lhs == null || (object)rhs == null)
                return ! Equals(lhs, rhs);

            return ! lhs.Equals(rhs);
        }

        #endregion

        #region Method CompareTo. Overload operations > | >= | < | <=

        public static bool operator >(Book lhs, Book rhs) => lhs.Pages > rhs.Pages;

        public static bool operator >=(Book lhs, Book rhs) => lhs.Pages >= rhs.Pages;

        public static bool operator <(Book lhs, Book rhs) => lhs.Pages < rhs.Pages;

        public static bool operator <=(Book lhs, Book rhs) => lhs.Pages <= rhs.Pages;

        public int CompareTo(Book other) => String.CompareOrdinal(this.Title, other.Title);
        
        #endregion
        
        #endregion

        #region Private Methods

        /// <summary>
        /// Method CompareFields compares the field of books
        /// </summary>
        private bool CompareFields(Book book, Book other)
        {
            if (this.Author != other.Author)
                return false;
            if (this.Title != other.Title)
                return false;
            if (this.Year != other.Year)
                return false;
            if (this.Pages != other.Pages)
                return false;
            return true;
        }
        
        /// <summary>
        /// Method SwapBooks swaps Books
        /// </summary>
        private static void SwapBooks(ref Book fBook, ref Book sBook)
        {
            Book tempBook = fBook;
            fBook = sBook;
            sBook = tempBook;
        }

        #endregion
    }
}
