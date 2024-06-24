namespace System
{
    public static partial class Extension
    {
        /// <summary>
        /// 월의 첫번째 날짜 객체
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime FirstDateOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
        /// <summary>
        /// 월의 마지막 날짜 객체
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime LastDateOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }
        /// <summary>
        /// 월의 일 수
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int DaysInMonth(this DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month);
        }
        /// <summary>
        /// 문자열이 DateTime 형인지 검사합니다.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            else
            {
                return DateTime.TryParse(s, out _);
            }
        }
        /// <summary>
        /// DateTime 형을 문자열로 변환합니다.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToDateTimeString(this DateTime date, string format = "yyyy-MM-dd")
        {
            return $"{date.Month}/{date.Day}/{date.Year}";
        }
        /// <summary>
        /// YYYYMMDD를 날짜 형식으로 변환합니다.
        /// </summary>
        /// <param name="input">YYYYMMDD</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime data;
            Int32 dbl;
            if (Int32.TryParse(input, out dbl))
            {
                if (input.Length == 8)
                {
                    input = string.Format("{0}-{1}-{2}",
                        input.Substring(0, 4),
                        input.Substring(4, 2),
                        input.Substring(6, 2));
                }
            }

            if (!DateTime.TryParse(input, out data))
                return DateTime.Now;
            else
                return data;
        }
    }
}