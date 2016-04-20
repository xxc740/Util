using System;
using System.Collections.Generic;
using System.Linq;

namespace Util
{
    /// <summary>
    /// 类型转换
    /// </summary>
    public static class ConverHelper
    {
        #region 数值转换
        /// <summary>
        /// 转换为整型
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static int ToInt(object data)
        {
            if (data == null)
                return 0;
            int result;
            var success = int.TryParse(data.ToString(), out result);
            if (success)
                return result;
            try
            {
                return Convert.ToInt32(ToDouble(data, 0));
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// 转换为可空整型
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static int? ToIntOrNull(object data)
        {
            if (data == null)
                return 0;

            int result;
            bool isValid = int.TryParse(data.ToString(), out result);
            if (isValid)
                return result;

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double ToDouble(object data)
        {
            if (data == null)
                return 0;

            double result;
            return double.TryParse(data.ToString(), out result) ? result : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static double ToDouble(object data, int digits)
        {
            return Math.Round(ToDouble(data), digits);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double? ToDoubleOrNull(object data)
        {
            if (data == null)
                return null;
            double result;
            bool isValid = double.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object data)
        {
            if (data == null)
                return 0;
            decimal result;
            return decimal.TryParse(data.ToString(), out result) ? result : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object data, int digits)
        {
            return Math.Round(ToDecimal(data), digits);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static decimal? ToDecimalOrNull(object data)
        {
            if (data == null)
                return null;
            decimal result;
            bool isValid = decimal.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static decimal? ToDecimalOrNull(object data, int digits)
        {
            var result = ToDecimalOrNull(data);
            if (result == null)
                return null;
            return Math.Round(result.Value, digits);
        }

        #endregion

        #region Guid转换
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Guid ToGuid(object data)
        {
            if (data == null)
                return Guid.Empty;
            Guid result;
            return Guid.TryParse(data.ToString(), out result) ? result : Guid.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Guid? ToGuidOrNull(object data)
        {
            if (data == null)
                return null;
            Guid result;
            bool isValid = Guid.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static List<Guid> ToGuidList(string guid)
        {
            var listGuid = new List<Guid>();
            if (string.IsNullOrWhiteSpace(guid))
                return listGuid;
            var arrayGuid = guid.Split(',');
            listGuid.AddRange(from item in arrayGuid where !string.IsNullOrWhiteSpace(item) select new Guid(item));
            return listGuid;
        }

        #endregion

        #region 日期转换
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime ToDate(object data)
        {
            if (data == null)
                return DateTime.MinValue;
            DateTime result;
            return DateTime.TryParse(data.ToString(), out result) ? result : DateTime.MinValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime? ToDateOrNull(object data)
        {
            if (data == null)
                return null;
            DateTime result;
            bool isValid = DateTime.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        #endregion
        #region 布尔转换
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool ToBool(object data)
        {
            if (data == null)
                return false;
            bool? value = GetBool(data);
            if (value != null)
                return value.Value;
            bool result;
            return bool.TryParse(data.ToString(), out result) && result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool? ToBoolOrNull(object data)
        {
            if (data == null)
                return null;
            bool? value = GetBool(data);
            if (value != null)
                return value.Value;
            bool result;
            bool isValid = bool.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }
        #endregion

        #region 字符串转换
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToString(object data)
        {
            return data == null ? string.Empty : data.ToString().Trim();
        }
        #endregion

        #region 通用转换
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T To<T>(object data)
        {
            if (data == null || string.IsNullOrWhiteSpace(data.ToString()))
                return default(T);
            Type type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
            try
            {
                if (type.Name.ToLower() == "guid")
                    return (T)(object)new Guid(data.ToString());
                if (data is IConvertible)
                    return (T)Convert.ChangeType(data, type);
                return (T)data;
            }
            catch
            {
                return default(T);
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static bool? GetBool(object data)
        {
            switch (data.ToString().Trim().ToLower())
            {
                case "0":
                    return false;
                case "1":
                    return true;
                case "是":
                    return true;
                case "否":
                    return false;
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    return null;
            }
        }
    }
}

