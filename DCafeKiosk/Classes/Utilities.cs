using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCafeKiosk.Utilities
{
    /// <summary>
    /// 유닉스 타임스탬프
    /// </summary>
    class TimeStamp
    {
        /// <summary>
        /// http://gigi.nullneuron.net/gigilabs/converting-tofrom-unix-timestamp-in-c/
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long getUnixTimeStamp(DateTime datetime)
        {
            //-----------------------------------------------------------------
            //var dateTime = new DateTime(2015, 05, 24, 10, 2, 0, DateTimeKind.Local);
            var dateTimeOffset = new DateTimeOffset(datetime);
            var unixDateTime = dateTimeOffset.ToUnixTimeSeconds();
            //-----------------------------------------------------------------
            return unixDateTime;
        }

        public static long getUnixTimeStamp(DateTime datetime, int spanDays = 0)
        {
            datetime.AddDays(spanDays);

            //-----------------------------------------------------------------
            var dateTimeOffset = new DateTimeOffset(datetime);
            var unixDateTime = dateTimeOffset.ToUnixTimeSeconds();
            //-----------------------------------------------------------------
            return unixDateTime;
        }

        public static long getUnixTimeStamp(string dateFormatString, int spanDays = 0)
        {
            DateTime datetime = DateTime.Parse(dateFormatString);
            datetime.AddDays(spanDays);

            //-----------------------------------------------------------------
            var dateTimeOffset = new DateTimeOffset(datetime);
            var unixDateTime = dateTimeOffset.ToUnixTimeSeconds();
            //-----------------------------------------------------------------
            return unixDateTime;
        }

        public static DateTime UnixTimeStampToDateTime(long unixDateTime)
        {
            // Unix timestamp is seconds past epoch
            //-----------------------------------------------------------------
            var localDateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.ToLocalTime();
            //-----------------------------------------------------------------
            return localDateTimeOffset;
        }
    }

    /// <summary>
    /// UTC 시간 문자열 포멧
    /// </summary>
    class DateTimeFormatString
    {
        /// <summary>
        /// 1981-02-22T09:00:00.000000+09
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string getISO8601_RFC3339_UTCFormat(DateTime datetime)
        {
            // 1981-02-22T09:00:00.000000+09
            return datetime.ToString("yyyy-MM-ddThh:mm:ss.ffffffzz");
        }

        /// <summary>
        /// 1981-02-22 09:00:00
        /// 영수증 / 화면에 출력하는 시간 포멧
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string getNowDateTimeFormatString()
        {
            // 1981-02-22 09:00:00
            return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }

    class QRCode
    {
        public static System.Drawing.Bitmap GetQRCodeBitmap(string aUrl)
        {
            QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
            QRCoder.QRCodeData qrCodeData = qrGenerator.CreateQrCode(aUrl, QRCoder.QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);
            System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(10);

            return qrCodeImage;
        }
    }
}
