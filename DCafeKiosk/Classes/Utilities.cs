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
        public static int getUnixTimeStamp(DateTime datetime)
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(datetime)).TotalSeconds;

            /*
            DateTime foo = DateTime.UtcNow;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
            */

            return unixTimestamp;
        }

        public static int getUnixTimeStamp(DateTime datetime, int spanDays = 0)
        {
            datetime.AddDays(spanDays);

            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(datetime)).TotalSeconds;

            return unixTimestamp;
        }

        public static int getUnixTimeStamp(string dateFormatString, int spanDays = 0)
        {
            DateTime datetime = DateTime.Parse(dateFormatString);
            datetime.AddDays(spanDays);

            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(datetime)).TotalSeconds;

            return unixTimestamp;
        }

        public static DateTime UnixTimeStampToDateTime(Int32 unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
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
