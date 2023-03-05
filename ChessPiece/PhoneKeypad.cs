using System;
using System.Collections.Generic;
using System.Text;

namespace ChessPiece
{
    public class PhoneKeypad
    {
        private static readonly char[,] KEYPAD = {
        {'1', '2', '3'},
        {'4', '5', '6'},
        {'7', '8', '9'},
        {'*', '0', '#'}
    };

        private static readonly Dictionary<char, List<(int, int)>> MOVES = new Dictionary<char, List<(int, int)>> {
        {'R', new List<(int, int)> {(0, 1)}},
        {'L', new List<(int, int)> {(0, -1)}},
        {'U', new List<(int, int)> {(-1, 0)}},
        {'D', new List<(int, int)> {(1, 0)}},
        {'N', new List<(int, int)> {(-2, 1), (-2, -1), (-1, 2), (-1, -2), (1, 2), (1, -2), (2, 1), (2, -1)}},
        {'B', new List<(int, int)> {(0, 1), (0, -1), (-1, 0), (1, 0)}}
    };

        private static bool IsValidPosition(int row, int col)
        {
            return row >= 0 && row < 4 && col >= 0 && col < 3 && KEYPAD[row, col] != '*' && KEYPAD[row, col] != '#';
        }

    
        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 7)
            {
                return false;
            }
            if (phoneNumber[0] == '0' || phoneNumber[0] == '1')
            {
                return false;
            }
            if (phoneNumber.Contains('*') || phoneNumber.Contains('#'))
            {
                return false;
            }
            return true;
        }

        private static void TracePhoneNumber(int row, int col, string phoneNumber, HashSet<string> phoneNumbers, char move, int depth)
        {
            phoneNumber += KEYPAD[row, col];
            if (depth == 6)
            {
                if (IsValidPhoneNumber(phoneNumber))
                {
                    phoneNumbers.Add(phoneNumber);
                }
                return;
            }
            foreach (var delta in MOVES[move])
            {
                int newRow = row + delta.Item1;
                int newCol = col + delta.Item2;
                if (IsValidPosition(newRow, newCol))
                {
                    foreach (var nextMove in MOVES.Keys)
                    {
                        if (nextMove != move || nextMove == 'N')
                        {  // Knights can't move twice in a row
                            TracePhoneNumber(newRow, newCol, phoneNumber, phoneNumbers, nextMove, depth + 1);
                        }
                    }
                }
            }
        }

        public static HashSet<string> GetPhoneNumbers(char piece, int row, int col)
        {
            HashSet<string> phoneNumbers = new HashSet<string>();
            TracePhoneNumber(row, col, "", phoneNumbers, piece, 0);
            return phoneNumbers;
        }
    }
}
