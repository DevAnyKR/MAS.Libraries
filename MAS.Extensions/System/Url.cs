namespace System
{
    public static partial class Extension
    {
        public static string UrlPathEncode(this string src)
        {
            string data = System.Web.HttpUtility.UrlPathEncode(src);
            return data;
        }
        /// <summary>
        /// URL Path Encoding
        /// </summary>
        /// <remarks>URL문자를 Path 인코딩 합니다. 특수문자가 %2d 처럼 데이터가 변형됩니다.</remarks>
        /// <returns>String</returns>
        public static string UrlEncode(this string src)
        {
            string data = System.Web.HttpUtility.UrlEncode(src, System.Text.Encoding.UTF8);
            return data;
        }
        /// <summary>
        /// URL Path Decoding
        /// </summary>
        /// <remarks>인코딩된 URL Path 형태에서 원본으로 디코딩 합니다</remarks>
        /// <returns>String</returns>
        public static string UrlDecode(this string src)
        {
            string data = System.Web.HttpUtility.UrlDecode(src, System.Text.Encoding.UTF8);
            return data;
        }
    }
}
