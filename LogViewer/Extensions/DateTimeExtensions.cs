using System;

namespace LogViewer.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ToDateTime(this string dateTime)
        {
            return DateTime.Parse(dateTime);
        }

        public static string ToSqLiteDateTime(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
    }
}