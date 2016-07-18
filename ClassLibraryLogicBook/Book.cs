using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace ClassLibraryLogicBook
{
    public sealed class Book : IEquatable<Book>, IComparable<Book>, IComparable
    {
        #region Fields
        private int _year;
        private int _pages;
        #endregion

        #region Properties

        public string Author { get; set; }
        public string Title { get; set; }

        public int Year
        {
            get { return _year; }
            private set
            {
                if (value > 0)
                    _year = value;
                else
                    throw new ArgumentNullException(nameof(value));
            }
        }

        public int Pages
        {
            get { return _pages; }
            private set
            {
                if (value > 0)
                    _pages = value;
                else
                    throw new ArgumentNullException(nameof(value));
            }
        }

        #endregion

        #region Ctor

        public Book()
        {
            
        }

        public Book(string author, string title, int year, int pages)
        {
            Author = author;
            Title = title;
            Year = year;
            Pages = pages;
        }

        public Book(Book book)
        {
            Book b = new Book();
            b.Author = book.Author;
            b.Title = book.Title;
            b.Year = book.Year;
            b.Pages = book.Pages;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Method SortBooks sorts array of books according to the comparator
        /// </summary>
        public static void SortBooks(Book[] books, IComparer<Book> comparer)
        {
            for (int i = 0; i < books.Length - 1; i++)
            {
                for (int j = i + 1; j < books.Length; j++)
                {
                    if (comparer.Compare(books[i], books[j]) > 0)
                        SwapBooks(ref books[i], ref books[j]);
                }
            }
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

        /// <summary>
        /// Realisation of method Equals of interface IEquatable<Book>
        /// </summary>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return CompareFields(this, other);
        }

        /// <summary>
        /// Overload operator Equality
        /// </summary>
        /// <param name="lhs">Left operand</param>
        /// <param name="rhs">Right operand</param>
        /// <returns>True if left operand == right operand</returns>
        public static bool operator ==(Book lhs, Book rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                return Equals(lhs, rhs);

            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Overload operator Inequality
        /// </summary>
        /// <param name="lhs">Left operand</param>
        /// <param name="rhs">Right operand</param>
        /// <returns>True if left operand != right operand</returns>
        public static bool operator !=(Book lhs, Book rhs) => !(lhs == rhs);
        
        #endregion

        #region Method CompareTo. Overload operations > | >= | < | <=

        /// <summary>
        /// Overload operator GreaterThan
        /// </summary>
        /// <param name="lhs">Left operand</param>
        /// <param name="rhs">Right operand</param>
        /// <returns>True if left operand > right operand</returns>
        public static bool operator >(Book lhs, Book rhs)
        {
            CheckBooks(lhs, rhs);

            return lhs.Pages > rhs.Pages;
        }

        /// <summary>
        /// Overload operator GreaterThanOrEqual
        /// </summary>
        /// <param name="lhs">Left operand</param>
        /// <param name="rhs">Right operand</param>
        /// <returns>True if left operand >= right operand</returns>
        public static bool operator >=(Book lhs, Book rhs)
        {
            CheckBooks(lhs, rhs);

            return lhs.Pages >= rhs.Pages;
        }

        /// <summary>
        /// Overload operator LessThan
        /// </summary>
        /// <param name="lhs">Left operand</param>
        /// <param name="rhs">Right operand</param>
        /// <returns>True if left operand < right operand</returns>
        public static bool operator <(Book lhs, Book rhs)
        {
            CheckBooks(lhs, rhs);

            return lhs.Pages < rhs.Pages;
        }

        /// <summary>
        /// Overload operator LessThanOrEqual
        /// </summary>
        /// <param name="lhs">Left operand</param>
        /// <param name="rhs">Right operand</param>
        /// <returns>True if left operand <= right operand</returns>
        public static bool operator <=(Book lhs, Book rhs)
        {
            CheckBooks(lhs, rhs);

            return lhs.Pages <= rhs.Pages;
        }

        /// <summary>
        /// Realisation of method CompareTo of interface IComparable<Book>
        /// </summary>
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            return String.CompareOrdinal(this.Title, other.Title);
        }

        /// <summary>
        /// Realisation of method CompareTo of interface IComparable
        /// </summary>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
                throw new ArgumentNullException(nameof(obj));

            Book otherBook = obj as Book;
            if (otherBook != null)
                return this.Pages.CompareTo(otherBook.Pages);
            else
                throw new ArgumentException("Object is not a Book");
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Method CheckBooks check is book null
        /// </summary>
        private static void CheckBooks(Book fBook, Book sBook)
        {
            if (fBook == null)
                throw new ArgumentNullException(nameof(fBook));
            if (sBook == null)
                throw new ArgumentNullException(nameof(sBook));
        }

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
