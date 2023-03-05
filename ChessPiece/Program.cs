using System;

namespace ChessPiece
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Valid phone numbers traced with a rook starting at 3:");
            foreach (var phoneNumber in PhoneKeypad.GetPhoneNumbers('R', 0, 2))
            {
                Console.WriteLine(phoneNumber);
            }
            Console.WriteLine("Total: " + PhoneKeypad.GetPhoneNumbers('R', 0, 2).Count);
        }
   
    }
}
