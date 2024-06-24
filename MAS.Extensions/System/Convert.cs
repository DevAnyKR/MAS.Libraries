using System.Threading.Tasks;

namespace System
{
    public static partial class Extension
    {
        /// <summary>
        /// 지정한 형식으로 변환합니다.
        /// </summary>
        /// <typeparam name="Type"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public static Type ConvertTo<Type>(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) str = null;
            Type type = default(Type);
            ComponentModel.TypeConverter tc = ComponentModel.TypeDescriptor.GetConverter(typeof(Type));
            if (tc.CanConvertFrom(str.GetType()))
                type = (Type)tc.ConvertFrom(str);
            else
            {
                tc = ComponentModel.TypeDescriptor.GetConverter(str.GetType());
                if (tc.CanConvertTo(typeof(Type)))
                    type = (Type)tc.ConvertTo(str, typeof(Type));
                else
                    throw new NotSupportedException();
            }
            return type;
        }
        /// <summary>
        /// String 형을 Double 형으로 변환합니다. Null 또는 빈 문자열일 경우 null을 반환합니다.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static double ToDouble(this string @this)
        {
            if (string.IsNullOrWhiteSpace(@this)) @this = null;
            return Convert.ToDouble(@this);
        }
        /// <summary>
        /// String 형을 Double 형으로 변환합니다. Null 또는 빈 문자열일 경우 def 값을 반환합니다.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static double ToDouble(this string @this, double def)
        {
            if (string.IsNullOrWhiteSpace(@this)) return Convert.ToDouble(def);
            else return Convert.ToDouble(@this);
        }
        /// <summary>
        /// 10진수 부동소수점 형을 Double 형으로 변환합니다.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static double ToDouble(this decimal @this)
        {
            return Convert.ToDouble(@this);
        }

        public static Int16 ToInt16(this string @this)
        {
            if (string.IsNullOrWhiteSpace(@this)) @this = null;
            return Convert.ToInt16(@this);
        }
        public static Int32 ToInt32(this string @this)
        {
            if (string.IsNullOrWhiteSpace(@this)) @this = null;
            return Convert.ToInt32(@this);
        }
        public static UInt16 ToUInt16(this string @this)
        {
            if (string.IsNullOrWhiteSpace(@this)) @this = null;
            return Convert.ToUInt16(@this);
        }
        public static UInt32 ToUInt32(this string @this)
        {
            if (string.IsNullOrWhiteSpace(@this)) @this = null;
            return Convert.ToUInt32(@this);
        }
        /// <summary>
        /// Double 형을 10진수 부동소수점 형으로 변환합니다.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this double @this)
        {
            return Convert.ToDecimal(@this);
        }
        /// <summary>
        /// 비동기를 메서드 체인으로 만듭니다.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="fn"></param>
        /// <returns></returns>
        public static async Task<TResult> MapAsync<TSource, TResult>(this Task<TSource> @this, Func<TSource, Task<TResult>> fn) => await fn(await @this);
        /// <summary>
        /// String 형을 지정된 Enum 형으로 변환합니다.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEnum TryParse<TEnum>(this string value) where TEnum : struct
        {
            Enum.TryParse(value, out TEnum result);
            return result;
        }
    }
}
