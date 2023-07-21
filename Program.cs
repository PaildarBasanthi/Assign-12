using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a piece of text:");
            string inputText = Console.ReadLine();

            int wordCount = CountWords(inputText);
            List<string> emailAddresses = GetEmailAddresses(inputText);
            List<string> mobileNumbers = ExtractMobileNumbers(inputText);

            Console.WriteLine("Word Count: " + wordCount);
            Console.WriteLine("Email Addresses found:");
            foreach (string email in emailAddresses)
            {
                Console.WriteLine(email);
            }

            Console.WriteLine("Mobile Numbers found:");
            foreach (string number in mobileNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Enter a custom regular expression:");
            string customRegexPattern = Console.ReadLine();
            List<string> customMatches = PerformCustomRegexSearch(inputText, customRegexPattern);

            Console.WriteLine("Custom Regex Search will be:");
            foreach (string match in customMatches)
            {
                Console.WriteLine(match);
            }
        }

        static int CountWords(string text)
        {
            // Split the text by spaces to count words
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        static List<string> GetEmailAddresses(string text)
        {
            List<string> emailAddresses = new List<string>();
            string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
            MatchCollection matches = Regex.Matches(text, emailPattern);

            foreach (Match match in matches)
            {
                emailAddresses.Add(match.Value);
            }

            return emailAddresses;
        }

        static List<string> ExtractMobileNumbers(string text)
        {
            List<string> mobileNumbers = new List<string>();
            string mobilePattern = @"\b\d{10}\b";
            MatchCollection matches = Regex.Matches(text, mobilePattern);

            foreach (Match match in matches)
            {
                mobileNumbers.Add(match.Value);
            }

            return mobileNumbers;
        }

        static List<string> PerformCustomRegexSearch(string text, string pattern)
        {
            List<string> customMatches = new List<string>();
            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                customMatches.Add(match.Value);
            }

            return customMatches;
        }
    }
}
