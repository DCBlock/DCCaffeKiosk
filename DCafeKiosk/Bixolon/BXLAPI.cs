using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

using System.Windows.Forms;

namespace DCafeKiosk
{
    class BXLAPI
    {
        // PAGE MODE
        public const int BXL_PRINTER_PAGEMODE_OUT	= 0;
        public const int BXL_PRINTER_PAGEMODE_IN    = 1;

        public const int BXL_PRINTER_PD_0		= 0;
        public const int BXL_PRINTER_PD_LEFT90	= 1;
        public const int BXL_PRINTER_PD_180		= 2;
        public const int BXL_PRINTER_PD_RIGHT90 = 3;

        // CASH DRAWER
        public const int BXL_CASHDRAWER_PIN2    = 0;
        public const int BXL_CASHDRAWER_PIN5    = 1;

        // BCD TEXT ENCODING
        public const int BXL_TEXT_ENCODE_PC437          = 437;	// 437 (USA, Standard Europe)
        public const int BXL_TEXT_ENCODE_PC866          = 866;	// 866 (Cyrillic #2)
        public const int BXL_TEXT_ENCODE_PC852          = 852;	// 852 (Latin 2)
        public const int BXL_TEXT_ENCODE_PC857          = 857;	// 857 (Turkish)
        public const int BXL_TEXT_ENCODE_PC850          = 850;	// 850 (Multilingual)
        public const int BXL_TEXT_ENCODE_PC860          = 860;	// 860 (Portuguese)
        public const int BXL_TEXT_ENCODE_PC863          = 863;	// 863 (Canadian-French)
        public const int BXL_TEXT_ENCODE_PC865          = 865;	// 865 (Nordic)
        public const int BXL_TEXT_ENCODE_PC1250         = 1250;	// 1250 (Czech)
        public const int BXL_TEXT_ENCODE_WPC1251        = 1251;	// 1251 (Cyrillic)
        public const int BXL_TEXT_ENCODE_WPC1252        = 1252;	// 1252 (Latin I)
        public const int BXL_TEXT_ENCODE_PC858          = 858;	// 858 (Euro)
        public const int BXL_TEXT_ENCODE_PC862          = 862;	// 862 (Hebrew DOS code)
        public const int BXL_TEXT_ENCODE_WPC1254        = 1254;	// 1254 (Turkish)
        public const int BXL_TEXT_ENCODE_WPC1257        = 1257;	// 1257 (Baltic)
        public const int BXL_TEXT_ENCODE_PC775          = 775;	// 775 (Baltic)
        public const int BXL_TEXT_ENCODE_PC737          = 737;	// 737 (Greek)
        public const int BXL_TEXT_ENCODE_WPC1253        = 1253;	// 1253 (Greek)
        public const int BXL_TEXT_ENCODE_WPC1255        = 1255;	// 1255 (Hebrew New Code)
        public const int BXL_TEXT_ENCODE_PC855          = 855;	// 855 (Cyrillic)
        public const int BXL_TEXT_ENCODE_PC928          = 928;	// 928 (Greek)
        public const int BXL_TEXT_ENCODE_PC1258         = 1258;	// 1258 (Vietnam)
        public const int BXL_TEXT_ENCODE_TCVN           = 49;	// TCVN-3 (Vietnamese)
        public const int BXL_TEXT_ENCODE_TCVN_CAPITAL   = 50;	// TCVN-3 (Vietnamese)
        public const int BXL_TEXT_ENCODE_VISCII         = 51;	// VISCII (Vietnamese)

        // ERROR RESULTS
        public const int BXL_SUCCESS				= 0;
        public const int BXL_READBUFFER_EMPTY		= -1;
        public const int BXL_CONNECT_FAIL			= -100;
        public const int BXL_NOT_OPENED				= -101;
        public const int BXL_NOT_SUPPORT		    = -107;
        public const int BXL_INVALID_PARAM			= -108;
        public const int BXL_BUFFER_ERROR			= -109;
        public const int BXL_NO_PRINT_DATA			= -110;
        public const int BXL_COMPLETE_ERROR			= -111;
        public const int BXL_NO_TRANSACTION_START	= -112;
        public const int BXL_TEXT_ENCODING_ERROR	= -120;
        public const int BXL_PAGE_MODE_ALREADY_IN	= -130;
        public const int BXL_NOT_IN_PAGE_MODE		= -131;
        public const int BXL_REGISTRY_ERROR			= -200;
        public const int BXL_WRITE_ERROR			= -300;
        public const int BXL_READ_ERROR				= -301;
        public const int BXL_BMP_LOAD_ERROR			= -400;
        public const int BXL_BMP_BUFFER_SIZE_ERROR	= -401;
        public const int BXL_BC_DATA_ERROR			= -500;
        public const int BXL_BC_NOT_SUPPORT         = -501;

        public const int BXL_STS_NORMAL		        = 0;
        public const int BXL_STS_PAPEREMPTY	        = 1;
        public const int BXL_STS_COVEROPEN	        = 2;
        public const int BXL_STS_PAPER_NEAR_END     = 4;
        public const int BXL_STS_AUTOCUTTER_ERROR   = 8;
        public const int BXL_STS_CASHDRAWER_HIGH	= 16;
        public const int BXL_STS_ERROR		        = 32;
        public const int BXL_STS_NOT_OPEN	        = 64;
        public const int BXL_STS_BATTERY_LOW        = 128;
        public const int BXL_STS_PAPER_TO_BE_TAKEN  = 256;
        public const int BXL_STS_CASHDRAWER_LOW     = 512;

        //Alignment
        public const int BXL_ALIGNMENT_LEFT	        = 0;
        public const int BXL_ALIGNMENT_CENTER	    = 1;
        public const int BXL_ALIGNMENT_RIGHT	    = 2;

        //Text Attribute
        public const int BXL_FT_DEFAULT			    = 0;
        public const int BXL_FT_FONTB			    = 1; 
        public const int BXL_FT_BOLD			    = 2;
        public const int BXL_FT_UNDERLINE		    = 4;
        public const int BXL_FT_UNDERTHICK	        = 6;
        public const int BXL_FT_REVERSE			    = 8;
        public const int BXL_FT_UPSIDEDOWN          = 10;
        public const int BXL_FT_FONTC               = 16;
        public const int BXL_FT_RED_COLOR           = 64;


        //Text Size
        public const int BXL_TS_0WIDTH		= 0;
        public const int BXL_TS_1WIDTH		= 16;
        public const int BXL_TS_2WIDTH		= 32;
        public const int BXL_TS_3WIDTH		= 48;
        public const int BXL_TS_4WIDTH		= 64;
        public const int BXL_TS_5WIDTH		= 80;
        public const int BXL_TS_6WIDTH		= 96;
        public const int BXL_TS_7WIDTH		= 112;

        public const int BXL_TS_0HEIGHT	= 0;
        public const int BXL_TS_1HEIGHT	= 1;
        public const int BXL_TS_2HEIGHT	= 2;
        public const int BXL_TS_3HEIGHT	= 3;
        public const int BXL_TS_4HEIGHT	= 4;
        public const int BXL_TS_5HEIGHT	= 5;
        public const int BXL_TS_6HEIGHT	= 6;
        public const int BXL_TS_7HEIGHT	= 7;

        // IMAGE WIDTH
        public const int BXL_WIDTH_FULL = -1;
        public const int BXL_WIDTH_NONE = -2;

        // QRCODE ECC TYPE
        public const int BXL_QRCODE_MODEL1 = 49;
        public const int BXL_QRCODE_MODEL2 = 50;
        // QRCODE ECC LEVEL
        public const int BXL_QRCODE_ECC_LEVEL_L = 48;
        public const int BXL_QRCODE_ECC_LEVEL_M = 49;
        public const int BXL_QRCODE_ECC_LEVEL_Q = 50;
        public const int BXL_QRCODE_ECC_LEVEL_H = 51;
        // PDF417 TYPE
        public const int BXL_PDF417_TYPE1 = 49;
        public const int BXL_PDF417_TYPE2 = 50;
        // PDF417 ECC LEVEL
        public const int BXL_PDF417_ECC_LEVEL_0 = 48;
        public const int BXL_PDF417_ECC_LEVEL_1 = 49;
        public const int BXL_PDF417_ECC_LEVEL_2 = 50;
        public const int BXL_PDF417_ECC_LEVEL_3 = 51;
        public const int BXL_PDF417_ECC_LEVEL_4 = 52;
        public const int BXL_PDF417_ECC_LEVEL_5 = 53;
        public const int BXL_PDF417_ECC_LEVEL_6 = 54;
        public const int BXL_PDF417_ECC_LEVEL_7 = 55;
        public const int BXL_PDF417_ECC_LEVEL_8 = 56;

        // GS1 DATABAR
        public const int BXL_GS1DATABAR_STACKED								= 0;
        public const int BXL_GS1DATABAR_STACKED_OMNIDIRECTIONAL				= 1;

        // COMPOSITE SYMBOLOGY (LINEAR)
        public const int BXL_COMPOSITE_LINE_EAN8 = 65;
        public const int BXL_COMPOSITE_LINE_EAN13 = 66;
        public const int BXL_COMPOSITE_LINE_UPCA = 67;
        public const int BXL_COMPOSITE_LINE_UPCE = 69;
        public const int BXL_COMPOSITE_LINE_GS1DATABAR_OMNIDIRECTIONAL = 70;
        public const int BXL_COMPOSITE_LINE_GS1DATABAR_TRUNCATED = 71;
        public const int BXL_COMPOSITE_LINE_GS1DATABAR_STACKED = 72;
        public const int BXL_COMPOSITE_LINE_GS1DATABAR_STACKED_OMNIDIRECTIONAL = 73;
        public const int BXL_COMPOSITE_LINE_GS1DATABAR_LIMITED = 74;
        public const int BXL_COMPOSITE_LINE_GS1DATABAR_EXPANDED = 75;
        public const int BXL_COMPOSITE_LINE_GS1_128 = 77;
        // COMPOSITE SYMBOLOGY (2D)
        public const int BXL_COMPOSITE_2D_AUTO  = 65;
        public const int BXL_COMPOSITE_2D_CC_C  = 66;

        // BARCODE
        public const int BXL_BCS_PDF417			            = 200;
        public const int BXL_BCS_QRCODE_MODEL2 	            = 202;
        public const int BXL_BCS_QRCODE_MODEL1 	            = 203; 
        public const int BXL_BCS_DATAMATRIX		            = 204;
        public const int BXL_BCS_MAXICODE_MODE2	            = 205;
        public const int BXL_BCS_MAXICODE_MODE3	            = 206;
        public const int BXL_BCS_MAXICODE_MODE4	            = 207;
        public const int BXL_BCS_2D_GS1DATABAR_STACKED      = 208;
        public const int BXL_BCS_2D_GS1DATABAR_STACKED_OMNIDIRECTIONAL = 209;
        public const int BXL_BCS_COMPOSITE_SYMBOLE_EAN8     = 210;
        public const int BXL_BCS_COMPOSITE_SYMBOLE_EAN13    = 211;
        public const int BXL_BCS_COMPOSITE_SYMBOLE_UPCA     = 212;
        public const int BXL_BCS_COMPOSITE_SYMBOLE_UPCE     = 213;
        public const int BXL_BCS_COMPOSITE_SYMBOLE_GS1DATABAR_OMNIDIRECTIONAL           = 214;
        public const int BXL_BCS_COMPOSITE_SYMBOLE_GS1DATABAR_TRUNCATED                 = 215;
        public const int BXL_BCS_COMPOSITE_SYMBOLE_GS1DATABAR_STACKED                   = 216;
        public const int BXL_BCS_COMPOSITE_SYMBOLE_GS1DATABAR_STACKED_OMNIDIRECTIONAL   = 217;
        public const int BXL_BCS_COMPOSITE_SYMBOLE_GS1DATABAR_LIMITED                   = 218;
        public const int BXL_BCS_COMPOSITE_SYMBOLE_GS1DATABAR_EXPANDED                  = 219;
        public const int BXL_BCS_COMPOSITE_SYMBOLE_GS1_128                              = 220;

        public const int BXL_BCS_UPCA			    = 101;
        public const int BXL_BCS_UPCE			    = 102;
        public const int BXL_BCS_EAN8			    = 103;
        public const int BXL_BCS_EAN13			    = 104;
        public const int BXL_BCS_JAN8			    = 105;
        public const int BXL_BCS_JAN13			    = 106;
        public const int BXL_BCS_ITF			    = 107;
        public const int BXL_BCS_CODABAR		    = 108;
        public const int BXL_BCS_CODE39			    = 109;
        public const int BXL_BCS_CODE93			    = 110;
        public const int BXL_BCS_CODE128		    = 111;

        public const int BXL_BCS_1D_GS1_128                    = 112;
        public const int BXL_BCS_1D_GS1DATABAR_OMNIDIRECTION   = 113;
        public const int BXL_BCS_1D_GS1DATABAR_TRUNCATED       = 114;
        public const int BXL_BCS_1D_GS1DATABAR_LIMITED         = 115;

        //Barcode text position
        public const int BXL_BC_TEXT_NONE		= 0;
        public const int BXL_BC_TEXT_ABOVE	    = 1;
        public const int BXL_BC_TEXT_BELOW	    = 2;

        //CharaterSet
        public const int BXL_CS_PC437			= 0;	// (USA, Standard Europe)
        public const int BXL_CS_KATAKANA		= 1;	// Katakana
        public const int BXL_CS_PC850			= 2;	// 850 (Multilingual)
        public const int BXL_CS_PC860			= 3;	// 860 (Portuguese)
        public const int BXL_CS_PC863			= 4;	// 863 (Canadian-French)
        public const int BXL_CS_PC865			= 5;	// 865 (Nordic)
        public const int BXL_CS_WPC1252		    = 16;   // 1252 (Latin I)
        public const int BXL_CS_PC866			= 17;   // 866 (Cyrillic #2)
        public const int BXL_CS_PC852			= 18;	// 852 (Latin 2)
        public const int BXL_CS_PC858			= 19;	// 858 (Euro)
        public const int BXL_CS_PC862			= 21;	// 862 (Hebrew DOS code)
        public const int BXL_CS_PC864			= 22;	// NOT Supported / 864 (Arabic)
        public const int BXL_CS_THAI42			= 23;	// THAI42
        public const int BXL_CS_WPC1253		    = 24;	// 1253 (Greek)
        public const int BXL_CS_WPC1254		    = 25;	// 1254 (Turkish)
        public const int BXL_CS_WPC1257		    = 26;	// 1257 (Baltic)
        public const int BXL_CS_FARSI			= 27;	// NOT Supported / FARSI
        public const int BXL_CS_WPC1251		    = 28;	// 1251 (Cyrillic)
        public const int BXL_CS_PC737			= 29;	// 737 (Greek)
        public const int BXL_CS_PC775			= 30;	// 775 (Baltic)
        public const int BXL_CS_THAI14			= 31;	// THAI14
        public const int BXL_CS_WPC1255		    = 33;	// 1255 (Hebrew New Code)
        public const int BXL_CS_THAI11			= 34;	// THAI11
        public const int BXL_CS_THAI18			= 35;	// THAI18
        public const int BXL_CS_PC855			= 36;	// 855 (Cyrillic)
        public const int BXL_CS_PC857			= 37;	// 857 (Turkish)
        public const int BXL_CS_PC928			= 38;	// 928 (Greek)
        public const int BXL_CS_THAI16			= 39;	// THAI16
        public const int BXL_CS_WPC1256		    = 40;	// NOT Supported / 1256 (Arabic)
        public const int BXL_CS_PC1258			= 41;	// 1258 (Vietnam)
        public const int BXL_CS_KHMER			= 42;	// NOT Supported / KHMER(Cambodia)
        public const int BXL_CS_PC1250			= 47;	// 1250 (Czech)
        public const int BXL_CS_LATIN9			= 48;	// Latin 9
        public const int BXL_CS_TCVN			= 49;	// TCVN-3 (Vietnamese)
        public const int BXL_CS_TCVN_CAPITAL	= 50;	// TCVN-3 (Vietnamese)
        public const int BXL_CS_VISCII          = 51;	// VISCII (Vietnamese)
        public const int BXL_CS_USER			= 255;  // User Code Page
        public const int BXL_CS_UTF8            = 65001;// UTF-8
        public const int BXL_CS_KS5601          = 949;	// KOREAN
        public const int BXL_CS_BIG5			= 950;	// CHINESE (BIG5)
        public const int BXL_CS_GB2312			= 936;	// Simplified CHINESE (GB2312)
        public const int BXL_CS_SHIFT_JIS		= 932;	// JAPAN (Shift JIS)

        //International CharacterSet
        public const int BXL_ICS_USA			= 0;
        public const int BXL_ICS_FRANCE		    = 1;
        public const int BXL_ICS_GERMANY		= 2;
        public const int BXL_ICS_UK				= 3;
        public const int BXL_ICS_DENMARK1	    = 4;
        public const int BXL_ICS_SWEDEN		    = 5;
        public const int BXL_ICS_ITALY			= 6;
        public const int BXL_ICS_SPAIN			= 7;
        public const int BXL_ICS_JAPAN			= 8;
        public const int BXL_ICS_NORWAY		    = 9;
        public const int BXL_ICS_DENMARK2	    = 10;
        public const int BXL_ICS_SPAIN2			= 11;
        public const int BXL_ICS_LATIN			= 12;	
        public const int BXL_ICS_KOREA			= 13;
        public const int BXL_ICS_SLOVENIA       = 14;
        public const int BXL_ICS_CHINA          = 15;

        // INTERFACE TYPE
        public const int ISerial	    = 0;
        public const int IParallel	    = 1;
        public const int IUsb		    = 2;
        public const int ILan		    = 3;
        public const int IWLan          = 4;
        public const int IBluetooth     = 5;

		public delegate int BxlCallBackDelegate(int status);

        public static bool Is64Bit()
        {
            bool retVal = true;
            if (System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") == "x86")
                retVal = false;
            return retVal;
        }

        public static int PrinterOpen(int nInterface, string szPortName, int nBaudRate, int nDataBits, int nParity, int nStopBits)
        {
            if (Is64Bit())
                return BXLAPI_x64.PrinterOpen(nInterface, szPortName, nBaudRate, nDataBits, nParity, nStopBits);
            else
                return BXLAPI_x86.PrinterOpen(nInterface, szPortName, nBaudRate, nDataBits, nParity, nStopBits);
        }

        public static int ConnectSerial(string szPortName, int nBaudRate, int nDataBits, int nParity, int nStopBits)
        {
            if (Is64Bit())
                return BXLAPI_x64.ConnectSerial(szPortName, nBaudRate, nDataBits, nParity, nStopBits);
            else
                return BXLAPI_x86.ConnectSerial(szPortName, nBaudRate, nDataBits, nParity, nStopBits);
        }

        public static int ConnectUsb()
        {
            if (Is64Bit())
                return BXLAPI_x64.ConnectUsb();
            else
                return BXLAPI_x86.ConnectUsb();
        }

        public static int ConnectParallel(string szPortName)
        {
            if (Is64Bit())
                return BXLAPI_x64.ConnectParallel(szPortName);
            else
                return BXLAPI_x86.ConnectParallel(szPortName);
        }

        public static int ConnectNet(string szIpAddr, int nPortNum)
        {
            if (Is64Bit())
                return BXLAPI_x64.ConnectNet(szIpAddr, nPortNum);
            else
                return BXLAPI_x86.ConnectNet(szIpAddr, nPortNum);
        }

        public static int PrinterClose()
        {
            if (Is64Bit())
                return BXLAPI_x64.PrinterClose();
            else
                return BXLAPI_x86.PrinterClose();
        }

        public static int InitializePrinter()
        {
            if (Is64Bit())
                return BXLAPI_x64.InitializePrinter();
            else
                return BXLAPI_x86.InitializePrinter();
        }   

        public static int GetStat()
        {
            if (Is64Bit())
                return BXLAPI_x64.GetStat();
            else
                return BXLAPI_x86.GetStat();
        }

        public static int GetPrinterCurrentStatus()
        {
            if (Is64Bit())
                return BXLAPI_x64.GetPrinterCurrentStatus();
            else
                return BXLAPI_x86.GetPrinterCurrentStatus();
        }

        public static int CheckPrinter()
        {
            if (Is64Bit())
                return BXLAPI_x64.CheckPrinter();
            else
                return BXLAPI_x86.CheckPrinter();
        }
        
        public static int PrintText(string Data, int Alignment, int Attribute, int TextSize)
        {
            if (Is64Bit())
                return BXLAPI_x64.PrintText(Data, Alignment, Attribute, TextSize);
            else
                return BXLAPI_x86.PrintText(Data, Alignment, Attribute, TextSize);
        }

        public static int PrintTextW(string Data, int Alignment, int Attribute, int TextSize, int lCodePage)
        {
            if (Is64Bit())
                return BXLAPI_x64.PrintTextW(Data, Alignment, Attribute, TextSize, lCodePage);
            else
                return BXLAPI_x86.PrintTextW(Data, Alignment, Attribute, TextSize, lCodePage);
        }

        public static int PrintTextInImage(string Data, string FontName, bool Italic, bool Bold, bool Underline, int FontSize, int Alignment)
        {
            if (Is64Bit())
                return BXLAPI_x64.PrintTextInImage(Data, FontName, Italic, Bold, Underline, FontSize, Alignment);
            else
                return BXLAPI_x86.PrintTextInImage(Data, FontName, Italic, Bold, Underline, FontSize, Alignment);
        }

        public static int PrintTextInImageW(string Data, string FontName, bool Italic, bool Bold, bool Underline, int FontSize, int Alignment)
        {
            if (Is64Bit())
                return BXLAPI_x64.PrintTextInImageW(Data, FontName, Italic, Bold, Underline, FontSize, Alignment);
            else
                return BXLAPI_x86.PrintTextInImageW(Data, FontName, Italic, Bold, Underline, FontSize, Alignment);
        }

        public static int LineFeed(int nFeed)
        {
            if (Is64Bit())
                return BXLAPI_x64.LineFeed(nFeed);
            else
                return BXLAPI_x86.LineFeed(nFeed);
        }

        public static int PrintBitmap(string FileName, int Width, int Alignment, int Level, bool bDithering)
        {
            if (Is64Bit())
                return BXLAPI_x64.PrintBitmap(FileName, Width, Alignment, Level, bDithering);
            else
                return BXLAPI_x86.PrintBitmap(FileName, Width, Alignment, Level, bDithering);
        }

        public static int GetBitmapBuffer(string FileName, int Width, int Level, bool bDithering, Byte[] pOutBuffer, uint cbBuf, ref uint pcbNeeded)
        {
            if (Is64Bit())
                return BXLAPI_x64.GetPrintBitmapBuf(FileName, Width, Level, bDithering, pOutBuffer, cbBuf, ref pcbNeeded);
            else
                return BXLAPI_x86.GetPrintBitmapBuf(FileName, Width, Level, bDithering, pOutBuffer, cbBuf, ref pcbNeeded);
        }

        public static int PrintBarcode(string Data, int Symbology, int Height, int Width, int Alignment, int TextPosition)
        {
            if (Is64Bit())
                return BXLAPI_x64.PrintBarcode(Data, Symbology, Height, Width, Alignment, TextPosition);
            else
                return BXLAPI_x86.PrintBarcode(Data, Symbology, Height, Width, Alignment, TextPosition);
        }

        public static int PrintPDF417(string Data, int Type, int ColumnNumber, int RowNumber, int ModuleWidth, int ModuleHeight, int EccLevel, int Alignment)
        {
            if (Is64Bit())
                return BXLAPI_x64.PrintPDF417(Data, Type, ColumnNumber, RowNumber, ModuleWidth, ModuleHeight, EccLevel, Alignment);
            else
                return BXLAPI_x86.PrintPDF417(Data, Type, ColumnNumber, RowNumber, ModuleWidth, ModuleHeight, EccLevel, Alignment);
        }

        public static int PrintQRCode(string Data, int Model, int ModuleSize, int EccLevel, int Alignment)
        {
            if (Is64Bit())
                return BXLAPI_x64.PrintQRCode(Data, Model, ModuleSize, EccLevel, Alignment);
            else
                return BXLAPI_x86.PrintQRCode(Data, Model, ModuleSize, EccLevel, Alignment);
        }

        public static int PrintQRCodeW(string Data, int Model, int ModuleSize, int EccLevel, int Alignment)
        {
            if (Is64Bit())
                return BXLAPI_x64.PrintQRCodeW(Data, Model, ModuleSize, EccLevel, Alignment);
            else
                return BXLAPI_x86.PrintQRCodeW(Data, Model, ModuleSize, EccLevel, Alignment);
        }

        public static int PrintDataMatrix(string Data, int ModuleSize, int Alignment)
        {
            if (Is64Bit())
                return BXLAPI_x64.PrintDataMatrix(Data, ModuleSize, Alignment);
            else
                return BXLAPI_x86.PrintDataMatrix(Data, ModuleSize, Alignment);
        }

        public static int PrintGS1DataBar(string Data, int Symbology, int ModuleSize, int Alignment)
        {
            if (Is64Bit())
                return BXLAPI_x64.PrintGS1DataBar(Data, Symbology, ModuleSize, Alignment);
            else
                return BXLAPI_x86.PrintGS1DataBar(Data, Symbology, ModuleSize, Alignment);
        }

        public static int PrintCompositeSymbology(string Data1d, int Symbol1d, string Data2d, int Symbol2d, int ModuleSize, int Alignment)
        {
            if (Is64Bit())
                return BXLAPI_x64.PrintCompositeSymbology(Data1d, Symbol1d, Data2d, Symbol2d, ModuleSize, Alignment);
            else
                return BXLAPI_x86.PrintCompositeSymbology(Data1d, Symbol1d, Data2d, Symbol2d, ModuleSize, Alignment);
        }

        public static int SetCharacterSet(int Value)
        {
            if (Is64Bit())
                return BXLAPI_x64.SetCharacterSet(Value);
            else
                return BXLAPI_x86.SetCharacterSet(Value);
        }

        public static int SetInterChrSet(int Value)
        {
            if (Is64Bit())
                return BXLAPI_x64.SetInterChrSet(Value);
            else
                return BXLAPI_x86.SetInterChrSet(Value);
        }

        public static int GetCharacterSet()
        {
            if (Is64Bit())
                return BXLAPI_x64.GetCharacterSet();
            else
                return BXLAPI_x86.GetCharacterSet();
        }

        public static int GetInterChrSet()
        {
            if (Is64Bit())
                return BXLAPI_x64.GetInterChrSet();
            else
                return BXLAPI_x86.GetInterChrSet();
        }

        public static int SetUpsideDown(int mode)
        {
            if (Is64Bit())
                return BXLAPI_x64.SetUpsideDown(mode);
            else
                return BXLAPI_x86.SetUpsideDown(mode);
        }

        public static int SetLeftMargin(int margin)
        {
            if (Is64Bit())
                return BXLAPI_x64.SetLeftMargin(margin);
            else
                return BXLAPI_x86.SetLeftMargin(margin);
        }

        public static int SetPrintWidth(int width)
        {
            if (Is64Bit())
                return BXLAPI_x64.SetPrintWidth(width);
            else
                return BXLAPI_x86.SetPrintWidth(width);
        }

        public static int CutPaper()
        {
            if (Is64Bit())
                return BXLAPI_x64.CutPaper();
            else
                return BXLAPI_x86.CutPaper();
        }

        public static int DirectIO(Byte[] Data, uint uiWrite, ref Byte pRequest, ref uint uiRead)
        {
            if (Is64Bit())
                return BXLAPI_x64.DirectIO(Data, uiWrite, ref pRequest, ref uiRead);
            else
                return BXLAPI_x86.DirectIO(Data, uiWrite, ref pRequest, ref uiRead);
        }

        public static int WriteBuff(Byte[] pBuffer, int nNumberOfBytesToWrite, ref int lWritten)
        {
            if (Is64Bit())
                return BXLAPI_x64.WriteBuff(pBuffer, nNumberOfBytesToWrite, ref lWritten);
            else
                return BXLAPI_x86.WriteBuff(pBuffer, nNumberOfBytesToWrite, ref lWritten);
        }

        public static int ReadBuff(Byte[] pBuffer, int nNumberOfBytesToWrite, ref int lReaded)
        {
            if (Is64Bit())
                return BXLAPI_x64.ReadBuff(pBuffer, nNumberOfBytesToWrite, ref lReaded);
            else
                return BXLAPI_x86.ReadBuff(pBuffer, nNumberOfBytesToWrite, ref lReaded);
        }

        public static int TransactionStart()
        {
            if (Is64Bit())
                return BXLAPI_x64.TransactionStart();
            else
                return BXLAPI_x86.TransactionStart();
        }

        public static int TransactionEnd(bool SendCompletedCheck, int Timeout)
        {
            if (Is64Bit())
                return BXLAPI_x64.TransactionEnd(SendCompletedCheck, Timeout);
            else
                return BXLAPI_x86.TransactionEnd(SendCompletedCheck, Timeout);
        }


        public static int ClearScreen()
        {
            if (Is64Bit())
                return BXLAPI_x64.ClearScreen();
            else
                return BXLAPI_x86.ClearScreen();
        }

        public static int ClearLine(int line)
        {
            if (Is64Bit())
                return BXLAPI_x64.ClearLine(line);
            else
                return BXLAPI_x86.ClearLine(line);
        }

        public static int DisplayString(string Data)
        {
            if (Is64Bit())
                return BXLAPI_x64.DisplayString(Data);
            else
                return BXLAPI_x86.DisplayString(Data);
        }

        public static int DisplayStringW(string Data, int codepage)
        {
            if (Is64Bit())
                return BXLAPI_x64.DisplayStringW(Data, codepage);
            else
                return BXLAPI_x86.DisplayStringW(Data, codepage);
        }

        public static int DisplayStringAtLine(int line, string Data)
        {
            if (Is64Bit())
                return BXLAPI_x64.DisplayStringAtLine(line, Data);
            else
                return BXLAPI_x86.DisplayStringAtLine(line, Data);
        }

        public static int DisplayStringAtLineW(int line, string Data, int codepage)
        {
            if (Is64Bit())
                return BXLAPI_x64.DisplayStringAtLineW(line, Data, codepage);
            else
                return BXLAPI_x86.DisplayStringAtLineW(line, Data, codepage);
        }

        public static int DisplayImage(int index, int x, int y)
        {
            if (Is64Bit())
                return BXLAPI_x64.DisplayImage(index, x, y);
            else
                return BXLAPI_x86.DisplayImage(index, x, y);
        }

        public static int StoreImageFile(string fileName, int index)
        {
            if (Is64Bit())
                return BXLAPI_x64.StoreImageFile(fileName, index);
            else
                return BXLAPI_x86.StoreImageFile(fileName, index);
        }

        public static int SetInternationalCharacterset(int characterSet)
        {
            if (Is64Bit())
                return BXLAPI_x64.SetInternationalCharacterset(characterSet);
            else
                return BXLAPI_x86.SetInternationalCharacterset(characterSet);
        }

        public static int OpenDrawer(int pinNumber)
        {
            if (Is64Bit())
                return BXLAPI_x64.OpenDrawer(pinNumber);
            else
                return BXLAPI_x86.OpenDrawer(pinNumber);
        }

        public static int SetPagemode(long pageMode)
        {
            if (Is64Bit())
                return BXLAPI_x64.SetPagemode(pageMode);
            else
                return BXLAPI_x86.SetPagemode(pageMode);
        }

        public static int SetPagemodePrintArea(int x, int y, int width, int height)
        {
            if (Is64Bit())
                return BXLAPI_x64.SetPagemodePrintArea(x, y, width, height);
            else
                return BXLAPI_x86.SetPagemodePrintArea(x, y, width, height);
        }

        public static int SetPagemodeDirection(int direction)
        {
            if (Is64Bit())
                return BXLAPI_x64.SetPagemodeDirection(direction);
            else
                return BXLAPI_x86.SetPagemodeDirection(direction);
        }

        public static int SetPagemodePosition(int x, int y)
        {
            if (Is64Bit())
                return BXLAPI_x64.SetPagemodePosition(x, y);
            else
                return BXLAPI_x86.SetPagemodePosition(x, y);
        }
        public static int BidiSetCallBack(BxlCallBackDelegate status)
        {
            if (Is64Bit())
                return BXLAPI_x64.BidiSetCallBack(status);
            else
                return BXLAPI_x86.BidiSetCallBack(status);
        }

        public static int BidiCancelCallBack()
        {
            if (Is64Bit())
                return BXLAPI_x64.BidiCancelCallBack();
            else
                return BXLAPI_x86.BidiCancelCallBack();
        }
    }

    class BXLAPI_x86
    {
        [DllImport("BXLPAPI.dll")]
        public static extern int PrinterOpen(
            int nInterface,
            [MarshalAs(UnmanagedType.LPStr)]string szPortName,
            int nBaudRate,
            int nDataBits,
            int nParity,
            int nStopBits);

        [DllImport("BXLPAPI.dll")]
        public static extern int ConnectSerial(
            [MarshalAs(UnmanagedType.LPStr)]string szPortName,
            int nBaudRate,
            int nDataBits,
            int nParity,
            int nStopBits);

        [DllImport("BXLPAPI.dll")]
        public static extern int ConnectUsb();

        [DllImport("BXLPAPI.dll")]
        public static extern int ConnectParallel([MarshalAs(UnmanagedType.LPStr)]string szPortName);

        [DllImport("BXLPAPI.dll")]
        public static extern int ConnectNet([MarshalAs(UnmanagedType.LPStr)]string szIpAddr, int nPortNum);

        [DllImport("BXLPAPI.dll")]
        public static extern int PrinterClose();

        [DllImport("BXLPAPI.dll")]
        public static extern int InitializePrinter();

        [DllImport("BXLPAPI.dll")]
        public static extern int GetStat();

        [DllImport("BXLPAPI.dll")]
        public static extern int GetPrinterCurrentStatus();

        [DllImport("BXLPAPI.dll")]
        public static extern int CheckPrinter();

        [DllImport("BXLPAPI.dll")]
        public static extern int PrintText([MarshalAs(UnmanagedType.LPStr)]string Data, int Alignment, int Attribute, int TextSize);

        [DllImport("BXLPAPI.dll")]
        public static extern int PrintTextW([MarshalAs(UnmanagedType.LPWStr)]string Data, int Alignment, int Attribute, int TextSize, int lCodePage);

        [DllImport("BXLPAPI.dll")]
        public static extern int PrintTextInImage([MarshalAs(UnmanagedType.LPStr)]string Data, [MarshalAs(UnmanagedType.LPStr)]string FontName, bool Italic, bool Bold, bool Underline, int FontSize, int Alignment);

        [DllImport("BXLPAPI.dll")]
        public static extern int PrintTextInImageW([MarshalAs(UnmanagedType.LPWStr)]string Data, [MarshalAs(UnmanagedType.LPWStr)]string FontName, bool Italic, bool Bold, bool Underline, int FontSize, int Alignment);

        [DllImport("BXLPAPI.dll")]
        public static extern int LineFeed(int nFeed);

        [DllImport("BXLPAPI.dll")]
        public static extern int PrintBitmap([MarshalAs(UnmanagedType.LPStr)]string fileName, int Width, int Alignment, int Level, bool bDithering);
        
        [DllImport("BXLPAPI.dll")]
        public static extern int PrintBitmapW([MarshalAs(UnmanagedType.LPWStr)]string fileName, int Width, int Alignment, int Level, bool bDithering);

        [DllImport("BXLPAPI.dll")]
        public static extern int GetPrintBitmapBuf([MarshalAs(UnmanagedType.LPWStr)]string FileName, int Width, int Level, bool bDithering, Byte[] pOutBuffer, uint cbBuf, ref uint pcbNeeded);

        [DllImport("BXLPAPI.dll")]
        public static extern int PrintBarcode([MarshalAs(UnmanagedType.LPWStr)]string Data, int Symbology, int Height, int Width, int Alignment, int TextPosition);

        [DllImport("BXLPAPI.dll")]
        public static extern int PrintPDF417([MarshalAs(UnmanagedType.LPWStr)]string Data, int Type, int ColumnNumber, int RowNumber, int ModuleWidth, int ModuleHeight, int EccLevel, int Alignment);

        [DllImport("BXLPAPI.dll")]
        public static extern int PrintQRCode([MarshalAs(UnmanagedType.LPWStr)]string Data, int Model, int ModuleSize, int EccLevel, int Alignment);

        [DllImport("BXLPAPI.dll")]
        public static extern int PrintQRCodeW([MarshalAs(UnmanagedType.LPWStr)]string Data, int Model, int ModuleSize, int EccLevel, int Alignment);

        [DllImport("BXLPAPI.dll")]
        public static extern int PrintDataMatrix([MarshalAs(UnmanagedType.LPWStr)]string Data, int ModuleSize, int Alignment);

        [DllImport("BXLPAPI.dll")]
        public static extern int PrintGS1DataBar([MarshalAs(UnmanagedType.LPWStr)]string Data, int Symbology, int ModuleSize, int Alignment);

        [DllImport("BXLPAPI.dll")]
        public static extern int PrintCompositeSymbology([MarshalAs(UnmanagedType.LPWStr)]string Data1d, int Symbol1d, [MarshalAs(UnmanagedType.LPWStr)]string Data2d, int Symbol2d, int ModuleSize, int Alignment);

        [DllImport("BXLPAPI.dll")]
        public static extern int SetCharacterSet(int Value);

        [DllImport("BXLPAPI.dll")]
        public static extern int SetInterChrSet(int Value);

        [DllImport("BXLPAPI.dll")]
        public static extern int GetCharacterSet();

        [DllImport("BXLPAPI.dll")]
        public static extern int GetInterChrSet();	

        [DllImport("BXLPAPI.dll")]
        public static extern int SetUpsideDown(int mode);

        [DllImport("BXLPAPI.dll")]
        public static extern int SetLeftMargin(int margin);

        [DllImport("BXLPAPI.dll")]
        public static extern int SetPrintWidth(int width);

        [DllImport("BXLPAPI.dll")]
        public static extern int CutPaper();

        [DllImport("BXLPAPI.dll")]
        public static extern int DirectIO(Byte[] Data, uint uiWrite, ref Byte pRequest, ref uint uiRead);

        [DllImport("BXLPAPI.dll")]
        public static extern int WriteBuff(Byte[] pBuffer, int nNumberOfBytesToWrite, ref int lWritten);

        [DllImport("BXLPAPI.dll")]
        public static extern int ReadBuff(Byte[] pBuffer, int nNumberOfBytesToWrite, ref int lReaded);

        [DllImport("BXLPAPI.dll")]
        public static extern int TransactionStart();

        [DllImport("BXLPAPI.dll")]
        public static extern int TransactionEnd(bool SendCompletedCheck, int Timeout);

        [DllImport("BXLPAPI.dll")]
        public static extern int ClearScreen();

        [DllImport("BXLPAPI.dll")]
        public static extern int ClearLine(int line);

        [DllImport("BXLPAPI.dll")]
        public static extern int DisplayString([MarshalAs(UnmanagedType.LPStr)]string Data);

        [DllImport("BXLPAPI.dll")]
        public static extern int DisplayStringW([MarshalAs(UnmanagedType.LPWStr)]string Data, int codepage);

        [DllImport("BXLPAPI.dll")]
        public static extern int DisplayStringAtLine(int line, [MarshalAs(UnmanagedType.LPStr)]string Data);

        [DllImport("BXLPAPI.dll")]
        public static extern int DisplayStringAtLineW(int line, [MarshalAs(UnmanagedType.LPWStr)]string Data, int codepage);

        [DllImport("BXLPAPI.dll")]
        public static extern int DisplayImage(int index, int x, int y);

        [DllImport("BXLPAPI.dll")]
        public static extern int StoreImageFile([MarshalAs(UnmanagedType.LPStr)]string fileName, int index);

        [DllImport("BXLPAPI.dll")]
        public static extern int SetInternationalCharacterset(int characterSet);

        [DllImport("BXLPAPI.dll")]
        public static extern int OpenDrawer(int pinNumber);

        [DllImport("BXLPAPI.dll")]
        public static extern int SetPagemode(long pageMode);

        [DllImport("BXLPAPI.dll")]
        public static extern int SetPagemodePrintArea(int x, int y, int width, int height);

        [DllImport("BXLPAPI.dll")]
        public static extern int SetPagemodeDirection(int direction);

        [DllImport("BXLPAPI.dll")]
        public static extern int SetPagemodePosition(int x, int y);

        [DllImport("BXLPAPI.dll")]
        public static extern int BidiCancelCallBack();

        [DllImport("BXLPAPI.dll")]
        public static extern int BidiSetCallBack(BXLAPI.BxlCallBackDelegate status);
    }

    class BXLAPI_x64
    {
        [DllImport("BXLPAPI_x64.dll")]
        public static extern int PrinterOpen(
            int nInterface,
            [MarshalAs(UnmanagedType.LPStr)]string szPortName,
            int nBaudRate,
            int nDataBits,
            int nParity,
            int nStopBits);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int ConnectSerial(
            [MarshalAs(UnmanagedType.LPStr)]string szPortName,
            int nBaudRate,
            int nDataBits,
            int nParity,
            int nStopBits);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int ConnectUsb();

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int ConnectParallel([MarshalAs(UnmanagedType.LPStr)]string szPortName);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int ConnectNet([MarshalAs(UnmanagedType.LPStr)]string szIpAddr, int nPortNum);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int PrinterClose();

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int InitializePrinter();

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int GetStat();

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int GetPrinterCurrentStatus();

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int CheckPrinter();

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int PrintText([MarshalAs(UnmanagedType.LPStr)]string Data, int Alignment, int Attribute, int TextSize);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int PrintTextW([MarshalAs(UnmanagedType.LPWStr)]string Data, int Alignment, int Attribute, int TextSize, int lCodePage);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int PrintTextInImage([MarshalAs(UnmanagedType.LPStr)]string Data, [MarshalAs(UnmanagedType.LPStr)]string FontName, bool Italic, bool Bold, bool Underline, int FontSize, int Alignment);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int PrintTextInImageW([MarshalAs(UnmanagedType.LPWStr)]string Data, [MarshalAs(UnmanagedType.LPWStr)]string FontName, bool Italic, bool Bold, bool Underline, int FontSize, int Alignment);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int LineFeed(int nFeed);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int PrintBitmap([MarshalAs(UnmanagedType.LPStr)]string fileName, int Width, int Alignment, int Level, bool bDithering);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int PrintBitmapW([MarshalAs(UnmanagedType.LPWStr)]string fileName, int Width, int Alignment, int Level, bool bDithering);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int GetPrintBitmapBuf([MarshalAs(UnmanagedType.LPStr)]string FileName, int Width,  int Level, bool bDithering, Byte[] pOutBuffer, uint cbBuf, ref uint pcbNeeded);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int PrintBarcode([MarshalAs(UnmanagedType.LPStr)]string Data, int Symbology, int Height, int Width, int Alignment, int TextPosition);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int PrintPDF417([MarshalAs(UnmanagedType.LPStr)]string Data, int Type, int ColumnNumber, int RowNumber, int ModuleWidth, int ModuleHeight, int EccLevel, int Alignment);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int PrintQRCode([MarshalAs(UnmanagedType.LPStr)]string Data, int Model, int ModuleSize, int EccLevel, int Alignment);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int PrintQRCodeW([MarshalAs(UnmanagedType.LPWStr)]string Data, int Model, int ModuleSize, int EccLevel, int Alignment);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int PrintDataMatrix([MarshalAs(UnmanagedType.LPStr)]string Data, int ModuleSize, int Alignment);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int PrintGS1DataBar([MarshalAs(UnmanagedType.LPStr)]string Data, int Symbology, int ModuleSize, int Alignment);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int PrintCompositeSymbology([MarshalAs(UnmanagedType.LPWStr)]string Data1d, int Symbol1d, [MarshalAs(UnmanagedType.LPWStr)]string Data2d, int Symbol2d, int ModuleSize, int Alignment);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int SetCharacterSet(int Value);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int SetInterChrSet(int Value);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int GetCharacterSet();

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int GetInterChrSet();

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int SetUpsideDown(int mode);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int SetLeftMargin(int margin);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int SetPrintWidth(int width);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int CutPaper();

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int DirectIO(Byte[] Data, uint uiWrite, ref Byte pRequest, ref uint uiRead);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int WriteBuff(Byte[] pBuffer, int nNumberOfBytesToWrite, ref int lWritten);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int ReadBuff(Byte[] pBuffer, int nNumberOfBytesToWrite, ref int lReaded);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int TransactionStart();

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int TransactionEnd(bool SendCompletedCheck, int Timeout);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int ClearScreen();

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int ClearLine(int line);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int DisplayString([MarshalAs(UnmanagedType.LPStr)]string Data);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int DisplayStringW([MarshalAs(UnmanagedType.LPWStr)]string Data, int codepage);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int DisplayStringAtLine(int line, [MarshalAs(UnmanagedType.LPStr)]string Data);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int DisplayStringAtLineW(int line, [MarshalAs(UnmanagedType.LPWStr)]string Data, int codepage);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int DisplayImage(int index, int x, int y);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int StoreImageFile([MarshalAs(UnmanagedType.LPStr)]string fileName, int index);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int SetInternationalCharacterset(int characterSet);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int OpenDrawer(int pinNumber);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int SetPagemode(long pageMode);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int SetPagemodePrintArea(int x, int y, int width, int height);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int SetPagemodeDirection(int direction);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int SetPagemodePosition(int x, int y);

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int BidiCancelCallBack();

        [DllImport("BXLPAPI_x64.dll")]
        public static extern int BidiSetCallBack(BXLAPI.BxlCallBackDelegate status);
    }
}
