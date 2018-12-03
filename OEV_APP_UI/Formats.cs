using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OEV_APP_UI
{
    class Formats
    {
        public string FormatTime(string ToFormat)
        {
            string res = "x" ;
            switch (ToFormat.Length)
            {
                case 1:
                    res = "0" + ToFormat + ":00";
                    break;
                case 2:
                    res = ToFormat + ":00";
                    break;
                case 3:
                    res = FormatThree(ToFormat);
                    break;  
                case 4:
                    res = FormatFour(ToFormat);
                    break;
                
            }

            return res;
        }

        private string FormatThree(string ToFormat)
        {
            string res = "x" ;
            char[] cArray = ToFormat.ToCharArray();
            string text = cArray[0].ToString() + cArray[1].ToString();
            int check = Convert.ToInt32(text);
            if (check > 24)
            {
                res = "0" + cArray[0].ToString() + ":" + cArray[1] + cArray[2];
            }
            else if (Convert.ToInt32(cArray[1] + cArray[2]) > 60)
            {
                res = cArray[0].ToString() + cArray[1] + ":" + cArray[2] + "0";
            }
            else
            {
                  
            }
            return res;
        }
        private string FormatFour(string ToFormat)
        {
            string res;
            char[] cArray = ToFormat.ToCharArray();
            res = cArray[0].ToString() + cArray[1].ToString() + ":" + cArray[2].ToString() + cArray[3].ToString();
            return res;
        }
    }


}

