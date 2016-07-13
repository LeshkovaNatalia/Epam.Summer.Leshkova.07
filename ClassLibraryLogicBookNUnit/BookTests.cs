using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibraryLogicBook;
using NUnit.Framework;

namespace ClassLibraryLogicBookNUnit
{
    [TestFixture]
    public class BookTests
    {
        private readonly Book[] books = new Book[3]
        {
            new Book("Richter", "CLR via C#", 2013, 896),
            new Book("Albahari", "C# 5.0 in nutshell", 2014, 1008),
            new Book("Bertrand Meyer", "Basics of Object Oriented Programming", 2005, 500)
        };

        [Test]
        public void BookTest_EqualsBook_ReturnTrue()
        {
            Book fBook = new Book("Richter", "CLR via C#", 2013, 896);
            Book sBook = new Book("Richter", "CLR via C#", 2013, 896);

            bool expected = true;
            
            bool actual = (fBook == sBook);

            Assert.AreEqual(expected, actual, "{0} != {1}", expected, actual);
        }

        [Test]
        public void BookTest_RefEqualsBook_ReturnTrue()
        {
            Book fBook = new Book("Richter", "CLR via C#", 2013, 896);
            Book sBook = fBook;

            bool expected = true;

            bool actual = (fBook == sBook);

            Assert.AreEqual(expected, actual, "{0} != {1}", expected, actual);
        }

        [Test]
        public void BookTest_CompareHashCodeBook_ReturnTrue()
        {
            Book fBook = new Book("Richter", "CLR via C#", 2013, 896);
            Book sBook = new Book("Richter", "CLR via C#", 2013, 896);

            bool expected = true;

            bool actual = (fBook.GetHashCode() == sBook.GetHashCode());

            Assert.AreEqual(expected, actual, "{0} != {1}", expected, actual);
        }

        [Test]
        public void BookTest_CompareHashCodeBook_ReturnFalse()
        {
            Book fBook = new Book("Richter", "CLR via C#", 2013, 896);
            Book sBook = new Book("Albahari", "C# 5.0 in nutshell", 2014, 1008);

            bool expected = false;

            bool actual = (fBook.GetHashCode() == sBook.GetHashCode());

            Assert.AreEqual(expected, actual, "{0} != {1}", expected, actual);
        }
        
        [Test]
        public void BookTest_BookGreaterThan_ReturnFalse()
        {
            Book fBook = new Book("Richter", "CLR via C#", 2013, 896);
            Book sBook = new Book("Albahari", "C# 5.0 in nutshell", 2014, 1008);

            bool expected = false;

            bool actual = (fBook > sBook);

            Assert.AreEqual(expected, actual, "{0} != {1}", expected, actual);
        }

        [Test]
        public void BookTest_SortYear_ReturnSorted()
        {
            Book[] testBooks = new Book[books.Length];
            books.CopyTo(testBooks, 0);

            Book[] expected = new Book[3]
            {
                new Book("Bertrand Meyer", "Basics of Object Oriented Programming", 2005, 500),
                new Book("Richter", "CLR via C#", 2013, 896),
                new Book("Albahari", "C# 5.0 in nutshell", 2014, 1008)
            };
            
            Book[] actual = Book.SortBooks(testBooks, new SortBookYear());

            Assert.AreEqual(expected[0], actual[0], "{0} != {1}", expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1], "{0} != {1}", expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2], "{0} != {1}", expected[2], actual[2]);
        }

        [Test]
        public void BookTest_SortAuthor_ReturnSorted()
        {
            Book[] testBooks = new Book[books.Length];
            books.CopyTo(testBooks, 0);

            Book[] expected = new Book[3]
            {
                new Book("Albahari", "C# 5.0 in nutshell", 2014, 1008),
                new Book("Bertrand Meyer", "Basics of Object Oriented Programming", 2005, 500),
                new Book("Richter", "CLR via C#", 2013, 896)
            };
            
            Book[] actual = Book.SortBooks(testBooks, new SortBookAuthor());

            Assert.AreEqual(expected[0], actual[0], "{0} != {1}", expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1], "{0} != {1}", expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2], "{0} != {1}", expected[2], actual[2]);
        }

        [Test]
        public void BookTest_SortPages_ReturnSorted()
        {
            Book[] testBooks = new Book[books.Length];
            books.CopyTo(testBooks, 0);

            Book[] expected = new Book[3]
            {
                new Book("Bertrand Meyer", "Basics of Object Oriented Programming", 2005, 500),
                new Book("Richter", "CLR via C#", 2013, 896),
                new Book("Albahari", "C# 5.0 in nutshell", 2014, 1008)
            };

            Book[] actual = Book.SortBooks(testBooks, new SortBookPages());

            Assert.AreEqual(expected[0], actual[0], "{0} != {1}", expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1], "{0} != {1}", expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2], "{0} != {1}", expected[2], actual[2]);
        }

        [Test]
        public void BookTest_DefaultSortTitle_ReturnSorted()
        {
            Book[] testBooks = new Book[books.Length];
            books.CopyTo(testBooks, 0);

            Book[] expected = new Book[3]
            {
                new Book("Bertrand Meyer", "Basics of Object Oriented Programming", 2005, 500),
                new Book("Albahari", "C# 5.0 in nutshell", 2014, 1008),
                new Book("Richter", "CLR via C#", 2013, 896)
            };

            Array.Sort(testBooks);
            Book[] actual = testBooks;

            Assert.AreEqual(expected[0], actual[0], "{0} != {1}", expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1], "{0} != {1}", expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2], "{0} != {1}", expected[2], actual[2]);
        }
    }
}
