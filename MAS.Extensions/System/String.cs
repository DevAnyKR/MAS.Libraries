using System.Collections;
using System.Text;

namespace System
{
    public static partial class Extension
    {
        public static string ToBase64(this string src)
        {
            string base64enc = Convert.ToBase64String(Encoding.UTF8.GetBytes(src));
            return base64enc;
        }
        /// <summary>
        /// Hex 문자열을 Base64 문자열로 변환합니다.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string HexToBase64String(this string input)
        {
            return Convert.ToBase64String(input.HexToByte());
        }

        public static string Base64ToHexString(this string strInput)
        {
            try
            {
                var bytes = Convert.FromBase64String(strInput);
                var hex = BitConverter.ToString(bytes);
                return hex.Replace("-", "").ToLower();
            }
            catch (Exception)
            {
                return "-1";
            }
        }
        /// <summary>
        /// 16진수 문자열을 byte[]로 변환합니다.
        /// </summary>
        /// <param name="inputHex"></param>
        /// <returns></returns>
        public static byte[] HexToByte(this string inputHex)
        {
            var resultantArray = new byte[inputHex.Length / 2];
            for (var i = 0; i < resultantArray.Length; i++)
            {
                resultantArray[i] = Convert.ToByte(inputHex.Substring(i * 2, 2), 16);
            }
            return resultantArray;
        }
        /// <summary>
        /// byte[]를 16진수 문자열 형태로 변환합니다.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToHexString(this Byte[] input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in input)
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
        /// <summary>
        /// BitArray to BinString(1010101010)
        /// </summary>
        /// <remarks>BitArray 값을 100010101 형태의 문자로 변환 합니다</remarks>
        /// <param name="arr"></param>
        /// <returns>String</returns>
        public static string BitToString(this BitArray arr)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = arr.Length; i > 0; i--)
                sb.Append(arr[i - 1] ? "1" : "0");
            return sb.ToString();
        }
        /// <summary>
        /// 문자를 HEX 문자로 변경합니다.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToHexStringNoSpace(this string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char b in input.ToCharArray())
                sb.Append(((byte)b).ToString("X2"));
            return sb.ToString();
        }
        /// <summary>
        /// String to Int
        /// </summary>
        /// <remarks>BitArray 에서 정수(Int32)로 변경 합니다.</remarks>
        /// <param name="arr"></param>
        /// <returns>Int32</returns>
        public static int BitToInt(this BitArray arr)
        {
            byte[] buf = new byte[4];
            arr.CopyTo(buf, 0);
            return BitConverter.ToInt32(buf, 0);
        }
        /// <summary>
        /// byte[] to string
        /// </summary>
        /// <remarks>Byte[] 에서 문자열을 추출 합니다. 인코딩은 Default 를 사용 합니다</remarks>
        /// <param name="input"></param>
        /// <returns>문자열</returns>
        public static string ToString(this byte[] input)
        {
            return Encoding.Default.GetString(input);
        }

        /// <summary>
        /// string.IsNullOrEmpty()와 동일
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }
        /// <summary>
        /// 입력문자열이 숫자인지 확인합니다.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string s)
        {
            return double.TryParse(s, out _);
        }
        public static string DefaultIfEmpty(this string s, string value)
        {
            if (s.IsNullOrEmpty()) return value;
            else return s;
        }

    }
}
