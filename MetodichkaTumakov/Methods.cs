namespace MetodichkaTumakov
{
    internal class Methods
    {
        public static string Reverse(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static bool CheckWithAs(object obj)
        {
            IFormattable formattableObj = obj as IFormattable;
            if (formattableObj != null)
            {
                return true;
            }
            return false;
        }
        public static bool CheckWithIs(object obj)
        {
            if (obj is IFormattable)
            {
                return true;
            }
            return false; 
        }
        public static void SearchMail(ref string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return;
            }

            int indexAt = s.IndexOf('@');
            if (indexAt == -1)
            {
                s = string.Empty;
                return;
            }

            int indexHach = s.IndexOf('#');
            if (indexHach == -1)
            {
                s = string.Empty;
                return;
            }

            string result = "";
            for (int i = indexHach + 1; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                   result += s[i];
                }
            }
            s = result.Trim();
        }
        
    }
}
