using System;
using System.Linq;
using System.Text;

namespace StringRandomizer
{
    class Randomizer
    {
        #region private Members
        int length;
        private const int max_length = 16;
        char[] originalDataArray = new char[max_length];
        private Random randomGenerator = new Random((DateTime.UtcNow).Millisecond);
        #endregion

        #region public Methods
        public char[] getRandomDataByBruteForce(String originalData)
        {
            length = max_length - originalData.Length;
            originalDataArray= originalData.ToCharArray();
            StringBuilder randomStingBuilder = new StringBuilder(originalData);

            for (byte i = 0; i < length; i++)
            {
                randomStingBuilder.Append((char)randomGenerator.Next(97, 122));
            }
            originalDataArray = randomStingBuilder.ToString().ToCharArray();
            
            //This will keep swapping indexes everytime, a random index is swapped with index i. Thus maintaining the data.
            //Random. next takes up 2 ranges. The range keeps changing,so that index which is already swapped is not selected.
            for (byte i = 0; i < originalDataArray.Length - 1; i++)
            {
                int j = randomGenerator.Next(i, originalDataArray.Length);
                char temp = originalDataArray[i];
                originalDataArray[i] = originalDataArray[j];
                originalDataArray[j] = temp;
            }
            return originalDataArray;
        }

        //This orders the given string or character array randomly. This is using the technique of LINQ.
        public char[] getRandomDataByLinq(String originalData)
        {
            length = max_length - originalData.Length;
            originalDataArray = originalData.ToCharArray();
            StringBuilder randomStingBuilder = new StringBuilder(originalData);

            for (byte i = 0; i < length; i++)
                randomStingBuilder.Append((char)randomGenerator.Next(97, 122));
            
            return (randomStingBuilder.ToString().ToCharArray()).OrderBy(x => randomGenerator.Next()).ToArray();
        }

        public char[] getRandomDummyData(String originalData,int requiredLength)
        {
            length = requiredLength - originalData.Length;
            originalDataArray = originalData.ToCharArray();
            StringBuilder randomStingBuilder = new StringBuilder(originalData);

            for (byte i = 0; i < length; i++)
                randomStingBuilder.Append((char)randomGenerator.Next(97, 122));

            return (randomStingBuilder.ToString().ToCharArray()).OrderBy(x => randomGenerator.Next()).ToArray();
        }
        #endregion

        static void Main(string[] args)
        {
            Randomizer new_object = new Randomizer();
            String data = "MICROSOFT";
            Console.WriteLine(new_object.getRandomDataByLinq(data));
            Console.WriteLine(new_object.getRandomDataByBruteForce(data));
            Console.WriteLine(new_object.getRandomDummyData(data, 50));
        }
    }
}
