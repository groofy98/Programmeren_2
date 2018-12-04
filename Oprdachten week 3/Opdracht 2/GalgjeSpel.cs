using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_2
{
    class GalgjeSpel
    {
        public string geheimWoord;
        public string geradenWoord;
        public List<char> ingevoerdeLetters = new List<char>();

        public void Init(string geheimWoord)
        {
            this.geheimWoord = geheimWoord;
            foreach (char c in geheimWoord)
                geradenWoord += '.';
        }

        public bool RaadLetter(char letter)
        {
            bool temp = false;
            char[] geradenChar = geradenWoord.ToCharArray();
            for(int i = 0; i < geheimWoord.Length; i++ )
            {
                if (geheimWoord[i] == letter)
                {
                    temp = true;
                    geradenChar[i] = letter;
                }
            }
            geradenWoord = new string(geradenChar);
            return temp;
        }

        public bool IsGeraden()
        {
            return (geheimWoord.Equals(geradenWoord));
        }

    }


}
