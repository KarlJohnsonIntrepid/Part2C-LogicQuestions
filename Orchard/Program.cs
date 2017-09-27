using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Orchard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Complied with .net 4.0.");
            Console.WriteLine("Unit test project contains more advanced testing for the examples");
            Console.WriteLine("---------------------------------");

            //Question 1 -  emordnilaP
            var pResult = Palindrome.IsPalindrome("emordnilaP");
            var pResult2 = Palindrome.IsPalindrome("Kayak");
            var pResult3 = Palindrome.IsPalindrome("No lemon, no melon");

            Console.WriteLine("Question 1 - Is a palindrome");
            Console.WriteLine("emordnilaP" + " - " + pResult);
            Console.WriteLine("Kayak" + " - " + pResult2);
            Console.WriteLine("No lemon, no melon" + " - " + pResult2);
            Console.WriteLine("---------------------------------");

            //Question 2 - Insta-gram
            var iResult = Instagram.Check("uncopyrightable");
            var iResult2 = Instagram.Check("Caucasus");
            var iResult3 = Instagram.Check("authorising");

            Console.WriteLine("Question 2 - Insta-gram");
            Console.WriteLine("uncopyrightable" + " - " + iResult);
            Console.WriteLine("Caucasus" + " - " + iResult2);
            Console.WriteLine("authorising" + " - " + iResult3);
            Console.WriteLine("---------------------------------");


            //Question 4 - Magic eightball
            var eightball = new MagicEightBall();
            var mResult = eightball.AskQuestion("Will I pass the test?");
            var mRresult2 = eightball.AskQuestion("Will I pass the test?");
            var mRresult3 = eightball.AskQuestion("Is this enough to pass the test?");

            Console.WriteLine("Question 3 - Magic Eight Ball");
            Console.WriteLine("Will I pass the test?" + " - " + mResult);
            Console.WriteLine("Will I pass the test?" + " - " + mRresult2);
            Console.WriteLine("Is this enough to pass the test?" + " - " + mRresult3);
            Console.WriteLine("---------------------------------");

            Console.ReadLine();
        }

    }

    public class Instagram
    {
        // Given any inputted string, assess if the string is a heterogram, isogram or neither.
        //Conditions
        //• "HETEROGRAM" if all letters occur exactly once
        //• "ISOGRAM" if all letters occur an equal number of times, but is not a heterogram
        //• "NOTAGRAM" if neither a heterogram and an Isogram
        //• Non alpha characters are ignored
        //Test cases
        //{[q: 'uncopyrightable', a: 'HETEROGRAM'], [q: 'Caucasus', a: 'ISOGRAM'], [q:
        //'authorising', a: 'NOTAGRAM']
        //    }

        public static string Check(string s)
        {
            //remove all non-alpha-numeric chars
            //It is assumed that this is case insenstive as in the tests Caucasus is an Isogram
            s = Regex.Replace(s, @"[^A-Za-z0-9]+", "").ToLower();

            //Empty strings can be assumed to be ....
            if (string.IsNullOrEmpty(s)) return "NOTAGRAM";

            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            //count number of times each char is repeated in the string and to a dictionary
            foreach (var c in s.ToCharArray())
            {
                if (dictionary.ContainsKey(c))
                {
                    dictionary[c] = dictionary[c] + 1;
                }
                else
                {
                    dictionary.Add(c, 1);
                }
            }

            //Are all the counts the same? if not then return
            if (dictionary.Values.Distinct().Count() != 1) return "NOTAGRAM";

            //All counts are the same so choose the first count and find out if it is one
            if (dictionary.First().Value == 1)
            {
                return "HETEROGRAM";
            }

            //All counts are the same and greater than one
            return "ISOGRAM";
        }
    }

    public class Palindrome
    {
        /// <summary>
        /// Given any inputted string, determine if the string is a palindrome.
        /// Conditions
        /// Return "TRUE" if the characters read the same backward as forward
        /// Return "FALSE" if the characters read differently backward as forward
        /// "UNDETERMINED" for an empty string
        /// Ignore non-alphanumeric characters, case-insensitive
        /// Test cases
        /// {[q: 'emordnilaP', a: 'FALSE'], [q: '', a: 'UNDETERMINED'], [q: 'Kayak', a:
        /// 'TRUE'], [q: 'No lemon, no melon', a: 'TRUE']
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string IsPalindrome(string s)
        {

            //remove all non-alpha-numeric chars and make all lower case
            s = Regex.Replace(s, @"[^A-Za-z0-9]+", "").ToLower();

            //We make the assumtion that if a string is all non-alphanumeric characters
            //then it is an empty string as it does not contain any alphanumeric characters which we are interested in

            if (string.IsNullOrEmpty(s)) return "UNDETERMINED";

            //convert string to char array for comparison
            var chars = s.ToCharArray();

            //Does the reverse string array equal the original
            if (chars.Reverse().SequenceEqual(chars))
            {
                return "TRUE";
            }

            return "FALSE";
        }
    }

    /// <summary>
    /// Given any question, randomly select one of the following responses: "It is certain", "It is decidedly
    ///so", "Without a doubt", "Yes – definitely", "You may rely on it", "As I see it", "Yes", "Most Likely",
    ///"Outlook good", "Yes", "Signs point to yes"
    /// </summary>
    public class MagicEightBall
    {
        private List<string> _responses { get; set; }
        private Dictionary<string, string> _questionResponses { get; set; }
        private Random _random {get;set;}

        public MagicEightBall()
        {
            CreateList();
        }

        private void CreateList()
        {
            //Initialise the clase
            _responses = new List<string>()
            {
                "It is certain",
                "It is decidedly so",
                "Without a doubt",
                "Yes – definitely",
                "You may rely on it",
                "As I see it",
                "Yes",
                "Most Likely",
                "Outlook good",
                "Yes",  //Note -- Yes is added twice in the questions so it is added twice here
                "Signs point to yes"
            };

            _questionResponses = new Dictionary<string, string>();
            _random = new Random();
        }

        /// <summary>
        /// Random response is return each time. Unless the question has already been asked.
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public string AskQuestion(string q)
        {
            if (!q.Contains('?'))
            {
                return "Not A Question";
            }

            //find question, ignore text after question mark
            var question = RemovePuncuationFromString(q.Substring(0, q.IndexOf('?')));

            if (_questionResponses.ContainsKey(question))
            {
                //find the current question
                return _questionResponses[question];
            }
            else
            {
                //Find a random response and return it to the add to the dictionary
                _questionResponses[question] = _responses[_random.Next(_responses.Count() - 1)].ToString(); ;

                return _questionResponses[question];
            }
        }

        private string RemovePuncuationFromString(string s)
        {
            //https://stackoverflow.com/questions/421616/how-can-i-strip-punctuation-from-a-string
            //remove puncuation / remove spaces
            return new string(s.Where(c => !char.IsPunctuation(c)).ToArray()).Replace(" ", "").ToLower();
        }
    }
}

