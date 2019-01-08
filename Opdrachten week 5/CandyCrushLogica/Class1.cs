using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCrushLogica
{
    public class Class1
    {

        public enum RegularCandies { JellyBean, Lozenge, LemonDrop, GumSquare, LollipopHead, JujubeCluster }

        public static bool ScoreRijAanwezig(RegularCandies[,] speelveld)
        {
            int width = speelveld.GetLength(0);
            int height = speelveld.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                int count = 1;
                RegularCandies candy = speelveld[0, i];
                for (int b = 1; b < width; b++)
                {
                    if (candy == speelveld[b, i])
                    {
                        count++;
                        if (count == 3)
                        {
                            Console.WriteLine("Rij: {0}", i + 1);
                            return true;
                        }



                    }
                    else count = 1;
                    candy = speelveld[b, i];

                }
            }
            return false;
        }

        public static bool ScoreKolomAanwezig(RegularCandies[,] speelveld)
        {
            int width = speelveld.GetLength(0);
            int height = speelveld.GetLength(1);
            for (int i = 0; i < width; i++)
            {
                int count = 1;
                RegularCandies candy = speelveld[i, 0];
                for (int b = 1; b < height; b++)
                {
                    if (candy == speelveld[i, b])
                    {
                        count++;
                        if (count == 3)
                        {
                            Console.WriteLine("Kolom: {0}", i + 1);
                            return true;
                        }



                    }
                    else count = 1;
                    candy = speelveld[i, b];

                }
            }
            return false;
        }
    }
}
