using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    class Program
    {
        public static void CountNumberOfOccurance(string paragraph)
        {
            MyMapNode<string, int> hashTabe = new MyMapNode<string, int>(6); //creting object
            string[] words=paragraph.Split(' ');
            foreach (string Word in words)
            {
                if (hashTabe.Exists(Word))
                    hashTabe.Add(Word.ToLower(), hashTabe.Get(Word) + 1);
                else
                    hashTabe.Add(Word.ToLower(), 1);
            }
            Console.WriteLine("Displaying after add operation ");
            hashTabe.Display();
            string s = "avoidable";
            hashTabe.Remove(s);
            Console.WriteLine("Displaying after Remove operation ");
            hashTabe.Display();
        }
        static void Main(string[] args)
        {
            CountNumberOfOccurance("Paranoids are not paranoids because they are paranoids but beacause they keep putting themselves deliberately" +
                "into a paranoids avoidable situations");
        }
    }
}
