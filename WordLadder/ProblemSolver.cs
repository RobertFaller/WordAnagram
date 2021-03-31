using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ProblemSolver
{
    public static int Solver(string StartWord, string EndWord, HashSet<string> Data, int Length)
    {

        //Check the Data actually contains the target word
        if (!Data.Contains(EndWord))
        {
            return 0;
        }

        //Initiate the count of number of words
        int count = 0;

        //Initiate List to store the queued values, and store the starting word
        List<string> queuedValues = new List<string>();
        queuedValues.Add(StartWord);

        //While the queuedValues is not empty we will continue.
        while (queuedValues.Count() != 0)
        {
            //Increment the count
            count++;

            // store the current queue size
            int QueueSize = queuedValues.Count();

            //Iterate through based on the Queue Size
            for (int i = 0; i < QueueSize; i++)
            {
                //Convert the QueuedValue to a Character Array, so that we can compare the different word matches.
                char[] word = queuedValues[0].ToCharArray();
                //Remove the word from the Queued Values
                queuedValues.RemoveAt(0);

                //iterate through each character one at a time
                for (int pos = 0; pos < Length; pos++)
                {
                    //Store the original character
                    char original_char = word[pos];

                    //replace each character with every possible option within the alphabet
                    for (char letter = 'a'; letter <= 'z'; letter++)
                    {
                        //change the letter in the current position
                        word[pos] = letter;

                        //joing the chars together so that we can match against the endWord
                        if (string.Join("", word).Equals(EndWord))
                            return count;

                        //Check the data to see if it contains the new word being used
                        if (!Data.Contains(string.Join("", word)))
                            continue;

                        //remove any incorrect words from the Data list
                        Data.Remove(string.Join("", word));

                        //add the values to the Queued Values
                        queuedValues.Add(string.Join("", word));
                    }

                    //Return the original character to the word.
                    word[pos] = original_char;
                }
            }
        }
        return 0;
    }

    //Get the word list, and store as a Hashset to iterate through.
    public static HashSet<string> GetWordList(int Length)
    {
        HashSet<string> words = new HashSet<string>();

        //read the data lines from the file, but keep only those 4 characters.
        HashSet<string> Allwords = File.ReadLines("C:\\Zellis\\Dictionary.txt").Where(x => x.Length == Length).ToHashSet();

        //Convert all values to lowercase, to ensure compatability.
        foreach (var a in Allwords)
        {
            var n = a.ToLower();
            words.Add(n);
        }

        return words;
    }
}