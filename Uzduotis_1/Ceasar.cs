namespace Uzduotis_1
{
    public static class Ceasar
    {
        public static string Encode(string text, int shift)
        {
            byte[] AsciiArray = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] EncodedArray = new byte[99];
            const int ASCII_MIN = 33;
            const int ASCII_MAX = 126;

            for (int i = 0; i < AsciiArray.Length; i++)
            {
                //33 - 126
                int code = AsciiArray[i] + shift;

                if (code >= ASCII_MIN && code <= ASCII_MAX)
                {
                   EncodedArray[i] = (byte)code;
                }
                else
                {
                    while (code > ASCII_MAX)
                    {
                        code -= ASCII_MAX - ASCII_MIN + 1;
                    }

                    EncodedArray[i] = (byte)code;
                }

            }

            return System.Text.Encoding.UTF8.GetString(EncodedArray);
        }

        public static string Decode(string text, int shift)
        {
            byte[] AsciiArray = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] DecodedArray = new byte[99];
            const int ASCII_MIN = 33;
            const int ASCII_MAX = 126;

            for (int i = 0; i < AsciiArray.Length; i++)
            {
                //33 - 126
                int code = AsciiArray[i] - shift;

                if (code >= ASCII_MIN && code <= ASCII_MAX)
                {
                    DecodedArray[i] = (byte)code;
                }
                else
                {
                    while (code < ASCII_MIN)
                    {
                        code += ASCII_MAX - ASCII_MIN + 1;
                    }

                    DecodedArray[i] = (byte)code;
                }

            }

            return System.Text.Encoding.UTF8.GetString(DecodedArray);
        }
    }
}
