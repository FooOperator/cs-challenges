using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Has basic string analysis methods.
/// </summary>
public static class StringAnalyzer
{
    /// <summary>
    /// Receives a string and concatenates its initials to a dot except for the final initial of the string.  
    /// </summary>
    /// <returns>
    /// Returns: 
    ///     A string containing each initial of <paramref name="fullString"/> followed by a dot.
    /// </returns>
    public static string GetInitials(string fullString)
    {
        string initials = "";

        foreach (string word in fullString.Split(" "))
        {
            initials += word[0] + ".";

        }

        return initials.Substring(0, initials.Length - 1);
    }
    /// <summary>
    /// Receives a string and counts how many words it has. Words are at least one character long, after or before white-space.
    /// </summary>
    /// <returns>
    ///     Returns: A count for the amount of words contained in <param name="fullString"></param>
    ///     
    /// </returns>
    public static int GetWordCount(string fullString)
    {
        int wordCount = 0;

        foreach (string word in fullString.Split(" ")) { wordCount++; }

        return wordCount;
    }
    /// <summary>
    /// Receives a string and counts how many times each distinct letter appears.
    /// </summary>
    /// <returns>
    ///     Returns: A key/value pair of letters/times it appears in the string.
    /// </returns>
    public static Dictionary<char, int> GetLetterCount(string fullString)
    {
        string loweredString = fullString.ToLower();
        char[] letters = loweredString.Distinct().ToArray();
        Dictionary<char, int> letterCount = new Dictionary<char, int>();

        foreach (char letter in letters)
        {
            int count = loweredString.Count(c => c == letter);
            letterCount.Add(letter, count);
        }

        return letterCount;
    }
    /// <summary>
    /// Receives a string and determines whether or not it is a palindrome. Palindromes are defined 
    /// as strings that read the same if you reverse them, disregarding marks (!, ?).
    /// </summary>
    /// <returns>
    ///     Returns: A bool. True means its a palindrome.
    /// </returns>
    public static bool IsItAPalindrome(string fullString)
    {
        string str = fullString.ToLower();
        char[] reverseArray = str.Reverse().ToArray();
        string reverseString = new string(reverseArray);
        return reverseString == str ? true : false;
    }
}
