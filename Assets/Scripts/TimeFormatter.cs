using System;

namespace Game.Common
{
    /// <summary>
    /// Класс для форматирования даты и времени. Нужен для того, чтобы во всем приложении был одинаковый формат.
    /// </summary>
    public static class TimeFormatter
    {
        public static string DateToText(DateTime dateTime)
        {
            return dateTime.ToString("T");
        }

        public static string DateToText(TimeSpan timeSpan)
        {
            //return timeSpan.ToString("hh:mm:ss");
            return timeSpan.ToString(@"hh\:mm\:ss");
        }
    }
}