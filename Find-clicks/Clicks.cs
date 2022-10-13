using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Find_clicks
{
    public class Clicks
    {
        private string letters = "abcdefghijklmnopqrstuvwxyz";
        string[,] array2d = new string[7, 4];

        public Clicks()
        {
            // populate array 2d
            int cont = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    array2d[i, j] = letters[cont].ToString();
                    cont++;
                    if(cont >= letters.Length)
                    {
                        break;
                    }
                }
            }
        }

        public int ClicksCount(string word)
        {
            // remove special characters
            Regex expression = new Regex("(?:[^a-z]|(?<=['\"])s)", RegexOptions.IgnoreCase);
            word = expression.Replace(word, String.Empty);

            int resp = 0;
            
            int actualX = 0;
            int actualY = 0;

            // iterate for each letter
            foreach (var item in word)
            {
                var position = GetRowColPosition(item.ToString());
                if(position.Item1 != -1 && position.Item2 != -1)
                {
                    // calculate the difference and add to the resp variable
                    resp += Math.Abs(actualX - position.Item1) + Math.Abs(actualY - position.Item2) + 1;

                    // update with the new position
                    actualX = position.Item1;
                    actualY = position.Item2;
                }

            }

            return resp;
        }

        private Tuple<int, int> GetRowColPosition(string letter)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(array2d[i, j] == letter)
                    {
                        return Tuple.Create(i, j);
                    }
                }
            }
            return Tuple.Create(-1,-1);
        }
    }
}
