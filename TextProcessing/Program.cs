using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextProcessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the full path of the text file: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("The file does not exist. Exiting...");
                return;
            }

            // Read all lines
            string[] lines = File.ReadAllLines(filePath);

            // Dictionary to hold word counts
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (string line in lines)
            {
                // Remove punctuation and convert to lowercase
                string cleanedLine = Regex.Replace(line, @"[^\w\s]", "").ToLower();

                // Split by whitespace into words
                string[] words = cleanedLine.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    if (wordCounts.ContainsKey(word))
                    {
                        wordCounts[word]++;
                    }
                    else
                        wordCounts[word] = 1;
                }
            }

            // Output word counts
            Console.WriteLine("\n Word occurrences:");
            foreach (var pair in wordCounts.OrderBy(p=>p.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
            // Output number of unique words
            Console.WriteLine($"\nTotal number of unique words: {wordCounts.Count}");
            Console.ReadKey();
        }
       
    }
}
+ This version of this program is a lot easier to use and to understand.  
+ The code starts by asking for a full file path and checks if the file exists this helps prevent crashing this is a great improvement as the code no longer confuses the user with its little reasoning for why the crashing happens.  
+ The code is also more organised and uses clear and easy to understand variable names (filePath, wordCounts, and cleanedLine) so it’s easier for a collaborator to follow.  
+ It is also skipping null words and sorts the results alphabetically, which makes the output look a lot cleaner which is a substantial improvement.  
+ There’s still room to make it better however for example it could show the top few most common words or include comments explaining how aspects of the code work such as the use of regular expressions.  
+ This would increase the user friendliness drastically but overall it’s a big step up and much more user/collabration friendly.  
