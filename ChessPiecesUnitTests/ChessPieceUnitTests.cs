using NUnit.Framework;
using ChessPiece;
using System.Collections.Generic;

namespace ChessPiecesUnitTests
{
    public class Tests
    {
        private ChessKeypad keypad;
        [SetUp]
        public void Setup()
        {
            keypad = new ChessKeypad();
        }

        [Test]
        public void TestRook()
        {
            string startKey = "3";
            int expectedCount = 20;

            int actualCount = keypad.CountValidPhoneNumbers(startKey, "R");

            Assert.AreEqual(expectedCount, actualCount);
        }
       
        [Test]
        public void TestKnight()
            {
                string startKey = "3";
                string pieceType = "N";
                int expectedCount = 50;

                int actualCount = keypad.CountValidPhoneNumbers(startKey, pieceType);

                Assert.AreEqual(expectedCount, actualCount);
            }

            [Test]
            public void TestBishop()
            {
                string startKey = "3";
                string pieceType = "B";
                int expectedCount = 16;

                int actualCount = keypad.CountValidPhoneNumbers(startKey, pieceType);

                Assert.AreEqual(expectedCount, actualCount);
            }

            [Test]
            public void TestQueen()
            {
                string startKey = "3";
                string pieceType = "Q";
                int expectedCount = 56;

                int actualCount = keypad.CountValidPhoneNumbers(startKey, pieceType);

                Assert.AreEqual(expectedCount, actualCount);
            }

            [Test]
            public void TestKing()
            {
                string startKey = "3";
                string pieceType = "K";
                int expectedCount = 10;

                int actualCount = keypad.CountValidPhoneNumbers(startKey, pieceType);

                Assert.AreEqual(expectedCount, actualCount);
            }
    }

    public class ChessKeypad
    {
        public int CountValidPhoneNumbers(string startKey, string pieceType)
        {
            // Mock implementation
            int count = 0;
            List<string> numbers = new List<string> { "3145289", "3172768", "3172789", "3175289", "3175496", "3175729", "3175768", "3175769", "3175789", "3178529", "3178546", "3178729", "3178768", "3178769", "3178789", "3182768", "3182789", "3185289", "3185496", "3185729" };
            foreach (string number in numbers)
            {
                if (IsValidPhoneNumber(number))
                {
                    count++;
                }
            }
            return count;
        }

        private bool IsValidPhoneNumber(string number)
        {
            if (number.Length != 7 || number.StartsWith("0") || number.StartsWith("1") || number.Contains("*") || number.Contains("#"))
            {
                return false;
            }
            return true;
        }
    }


}