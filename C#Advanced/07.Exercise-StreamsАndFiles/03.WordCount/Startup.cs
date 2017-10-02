using System.IO;

namespace _03.WordCount
{
    public class Startup
    {
        static void Main(string[] args)
        {
            using (StreamReader wordsList = new StreamReader("../../words.txt"))
            {
                using (StreamReader text = new StreamReader("../../text.txt"))
                {
                    using (StreamWriter result = new StreamWriter("../../results.txt"))
                    {
                        
                    }
                }
            }


        }
    }
}
