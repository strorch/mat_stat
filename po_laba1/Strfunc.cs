using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace po_laba1
{
    class Strfunc
    {
        static public int str_size(string str)
        {
            int i;
            int count;

            i = 0;
            count = 0;
            if (str == null)
                return (0);
            while (i != str.Length)
            {
                if (str[i] == '\t' || str[i] == ' ')
                    i++;
                while (i != str.Length && str[i] != ' ' && str[i] != '\t')
                {
                    i++;
                    if (i == str.Length || str[i] == ' ' || str[i] == '\t')
                        count++;
                }
            }
            return (count);
        }

        int word_size(string str, int i)
        {
            int count;

            count = 0;
            while (i != str.Length && str[i] != ' ' && str[i] != '\t')
            {
                count++;
                i++;
            }
            return (count);
        }

        static public string[] ft_split_whitespaces(string str)
        {
            string[] arr;
            int i;
            int j;

            arr = new string[str_size(str)];
            i = 0;
            j = 0;
            while (i != str.Length)
            {
                if ((str[i] == '\t' || str[i] == ' ') && (i != str.Length))
                {
                    i++;
                    continue;
                }
                while (i != str.Length && str[i] != ' ' && str[i] != '\t')
                    arr[j] += str[i++];
                j++;
            }
            return (arr);
        }
    }
}
