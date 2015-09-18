using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BIANMA
{
    internal enum CharacterSet
    {
        A,
        B,
        C
    }
    public static class Code128
    {
        /* 
             *  128  尺寸要求 
             *  最小模块宽度 x  最大1.016mm，最小0.250mm 一个系统中的x应为一恒定值  标准是1mm,放大系数0.25~1.2 
             *  左右侧空白区最小宽度为 10x 
             *  条高通常为32mm，实际可以根据具体要求 
             *   
             * 最大物理长度不应超过 165mm，可编码的最大数据字符数为48，其中包括应用标识符和作为分隔符使用的FNC1字符，但不包括辅助字符和校验符 
             *  
             * AI中FNC1同样作为分隔符使用 
             *  
             * ASCII 
             * 0~31 StartA  专有 
             * 96~127 StartB 专有 
         *  
         * EAN128不使用空格（ASCII码32） 
        */

        /// <summary>  
        /// Code128条空排列集合，1代表条b，0代表空s，Index对应符号字符值S  
        /// </summary>  
        internal static readonly List<string> BSList = new List<string>()  
         {  
                 "212222" , "222122" , "222221" , "121223" , "121322" , "131222" , "122213" , "122312" , "132212" , "221213" ,  
                 "221312" , "231212" , "112232" , "122132" , "122231" , "113222" , "123122" , "123221" , "223211" , "221132" ,  
                 "221231" , "213212" , "223112" , "312131" , "311222" , "321122" , "321221" , "312212" , "322112" , "322211" ,  
                 "212123" , "212321" , "232121" , "111323" , "131123" , "131321" , "112313" , "132113" , "132311" , "211313" ,  
                 "231113" , "231311" , "112133" , "112331" , "132131" , "113123" , "113321" , "133121" , "313121" , "211331" ,  
                 "231131" , "213113" , "213311" , "213131" , "311123" , "311321" , "331121" , "312113" , "312311" , "332111" ,  
                 "314111" , "221411" , "431111" , "111224" , "111422" , "121124" , "121421" , "141122" , "141221" , "112214" ,  
                 "112412" , "122114" , "122411" , "142112" , "142211" , "241211" , "221114" , "413111" , "241112" , "134111" ,  
                 "111242" , "121142" , "121241" , "114212" , "124112" , "124211" , "411212" , "421112" , "421211" , "212141" ,  
                 "214121" , "412121" , "111143" , "111341" , "131141" , "114113" , "114311" , "411113" , "411311" , "113141" ,  
                 "114131" , "311141" , "411131" , "211412" , "211214" , "211232" , "2331112"  
         };

        internal const byte FNC3_AB = 96, FNC2_AB = 97, SHIFT_AB = 98, CODEC_AB = 99, CODEB_AC = 100, CODEA_BC = 101;
        internal const byte FNC4_A = 101, FNC4_B = 100;
        internal const byte FNC1 = 102, StartA = 103, StartB = 104, StartC = 105;
        internal const byte Stop = 106;

        /// <summary>  
        /// 获取字符在字符集A中对应的符号字符值S  
        /// </summary>  
        /// <param name="c"></param>  
        /// <returns></returns>  
        internal static byte GetSIndexFromA(char c)
        {
            byte sIndex = (byte)c;
            //字符集A中 符号字符值S 若ASCII<32,则 S=ASCII+64 ,若95>=ASCII>=32,则S=ASCII-32  
            if (sIndex < 32)
            {
                sIndex += 64;
            }
            else if (sIndex < 96)
            {
                sIndex -= 32;
            }
            else
            {
                throw new NotImplementedException();
            }
            return sIndex;
        }
        /// <summary>  
        /// 获取字符在字符集B中对应的符号字符值S  
        /// </summary>  
        /// <param name="c"></param>  
        /// <returns></returns>  
        internal static byte GetSIndexFromB(char c)
        {
            byte sIndex = (byte)c;
            if (sIndex > 31 && sIndex < 128)
            {
                sIndex -= 32;//字符集B中ASCII码 减去32后就等于符号字符值  
            }
            else
            {
                throw new NotImplementedException();
            }
            return sIndex;
        }
        internal static byte GetSIndex(CharacterSet characterSet, char c)
        {
            switch (characterSet)
            {
                case CharacterSet.A:
                    return GetSIndexFromA(c);
                case CharacterSet.B:
                    return GetSIndexFromB(c);
                default:
                    throw new NotImplementedException();
            }
        }
        /// <summary>  
        /// 判断指定字符是否仅属于指定字符集  
        /// </summary>  
        /// <param name="characterSet"></param>  
        /// <param name="c"></param>  
        /// <returns></returns>  
        internal static bool CharOnlyBelongsTo(CharacterSet characterSet, char c)
        {
            switch (characterSet)
            {
                case CharacterSet.A:
                    return (byte)c < 32;
                case CharacterSet.B:
                    return (byte)c > 95 && (byte)c < 128;
                default:
                    throw new NotImplementedException();
            }
        }
        /// <summary>  
        /// 判断指定字符是否不属于指定字符集  
        /// </summary>  
        /// <param name="characterSet"></param>  
        /// <param name="c"></param>  
        /// <returns></returns>  
        internal static bool CharNotBelongsTo(CharacterSet characterSet, char c)
        {
            switch (characterSet)
            {
                case CharacterSet.A:
                    return (byte)c > 95;
                case CharacterSet.B:
                    return (byte)c < 32 && (byte)c > 127;
                default:
                    throw new NotImplementedException();
            }
        }
        /// <summary>  
        /// 当编码转换时，获取相应的切换符对应的符号字符值  
        /// </summary>  
        /// <param name="newCharacterSet"></param>  
        /// <returns></returns>  
        internal static byte GetCodeXIndex(CharacterSet newCharacterSet)
        {
            switch (newCharacterSet)
            {
                case CharacterSet.A:
                    return CODEA_BC;
                case CharacterSet.B:
                    return CODEB_AC;
                default:
                    return CODEC_AB;
            }
        }
        /// <summary>  
        /// 获取转换后的字符集  
        /// </summary>  
        /// <param name="characterSet"></param>  
        /// <returns></returns>  
        internal static CharacterSet GetShiftCharacterSet(CharacterSet characterSet)
        {
            switch (characterSet)
            {
                case CharacterSet.A:
                    return CharacterSet.B;
                case CharacterSet.B:
                    return CharacterSet.A;
                default:
                    throw new NotImplementedException();
            }
        }
        /// <summary>  
        /// 获取应采用的字符集  
        /// </summary>  
        /// <param name="data"></param>  
        /// <param name="startIndex">判断开始位置</param>  
        /// <returns></returns>  
        internal static CharacterSet GetCharacterSet(string data, int startIndex)
        {
            CharacterSet returnSet = CharacterSet.B;
            if (Regex.IsMatch(data.Substring(startIndex), @"^\d{4,}"))
            {
                returnSet = CharacterSet.C;
            }
            else
            {
                byte byteC = GetProprietaryChar(data, startIndex);
                returnSet = byteC < 32 ? CharacterSet.A : CharacterSet.B;
            }
            return returnSet;
        }
        /// <summary>  
        /// 从指定位置开始，返回第一个大于95(并且小于128)或小于32的字符对应的值  
        /// </summary>  
        /// <param name="data"></param>  
        /// <param name="startIndex"></param>  
        /// <returns>如果没有任何字符匹配，则返回255</returns>  
        internal static byte GetProprietaryChar(string data, int startIndex)
        {
            byte returnByte = byte.MaxValue;
            for (int i = startIndex; i < data.Length; i++)
            {
                byte byteC = (byte)data[i];
                if (byteC < 32 || byteC > 95 && byteC < 128)
                {
                    returnByte = byteC;
                    break;
                }
            }
            return returnByte;
        }
        /// <summary>  
        /// 获取字符串从指定位置开始连续出现数字的个数  
        /// </summary>  
        /// <param name="data"></param>  
        /// <param name="startIndex"></param>  
        /// <returns></returns>  
        internal static int GetDigitLength(string data, int startIndex)
        {
            int digitLength = data.Length - startIndex;//默认设定从起始位置开始至最后都是数字  
            for (int i = startIndex; i < data.Length; i++)
            {
                if (!char.IsDigit(data[i]))
                {
                    digitLength = i - startIndex;
                    break;
                }
            }
            return digitLength;
        }
    }

    public interface IBarCode
    {
        string RawData { get; }
        /// <summary>  
        /// 条形码对应的数据  
        /// </summary>  
        string EncodedData { get; }
        /// <summary>  
        /// 当前条形码标准  
        /// </summary>  
        string BarCodeType { get; }

        /// <summary>  
        /// 得到条形码对应的图片  
        /// </summary>  
        /// <returns></returns>  
        Image GetBarCodeImage();
    }
    public abstract class BaseCode128 : IBarCode
    {
        protected Color backColor = Color.White;//条码背景色  
        protected Color barColor = Color.Black;//条码和原始数据字体颜色

        /// <summary>  
        /// 当前条形码种类
        /// </summary>  
        public string BarCodeType
        {
            get { return System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name; }
        }

        /// <summary>  
        /// 条形码对应的编码数据  
        /// </summary>
        protected string _EncodedData;
        public string EncodedData
        {
            get { return this._EncodedData; }
        }

        /// <summary>  
        /// 【原始数据】
        /// </summary>
        protected string _RawData;
        public string RawData
        {
            get { return this._RawData; }
        }

        /// <summary>  
        /// 在条形码下面显示数据；如果为空，则取【原始数据】  
        /// </summary>
        protected string _PresentationData = null;
        public string PresentationData
        {
            get { return string.IsNullOrEmpty(this._PresentationData) ? this._RawData : this._PresentationData; }
        }

        /// <summary>  
        /// 条码单位宽度；单位Pix，默认为1  
        /// </summary>
        protected byte _BarCellWidth = 1;
        public byte BarCellWidth
        {
            get { return this._BarCellWidth; }
            set
            {
                if (value == 0)
                {
                    this._BarCellWidth = 1;
                }
                else
                {
                    this._BarCellWidth = value;
                }
            }
        }

        /// <summary>  
        /// 条码高度，必须至少是条码宽度的0.15倍或6.35mm，两者取大者；默认按照实际为32，单位mm  
        /// </summary>
        protected byte _BarHeight = 32;
        public byte BarHeight
        {
            get { return this._BarHeight; }
            set
            {
                this._BarHeight = value;
            }
        }

        /// <summary>  
        /// 是否在条形码下面显示【原始数据】
        /// </summary>
        protected bool _IsDisplayFontData = true;
        public bool IsDisplayFontData
        {
            get { return this._IsDisplayFontData; }
            set { this._IsDisplayFontData = value; }
        }

        /// <summary>
        /// 【原始数据】与条形码的空间间隔；单位Pix，默认为4
        /// </summary>
        protected byte _FontPadding = 4;
        public byte FontPadding
        {
            get { return this._FontPadding; }
            set { this._FontPadding = value; }
        }

        /// <summary>  
        /// 【原始数据】字体大小；单位Pix，默认为16
        /// </summary>
        protected float _FontSize = 16;
        public float FontSize
        {
            get { return this._FontSize; }
            set { this._FontSize = value; }
        }

        /// <summary>  
        /// 【原始数据】字体布局位置；默认水平居中 
        /// </summary>
        protected StringAlignment _FontAlignment = StringAlignment.Center;
        public StringAlignment FontAlignment
        {
            get { return this._FontAlignment; }
            set { this._FontAlignment = value; }
        }

        public BaseCode128(string rawData)
        {
            this._RawData = rawData;
            if (string.IsNullOrEmpty(this._RawData))
            {
                throw new Exception("空字符串无法生成条形码");
            }
            this._RawData = this._RawData.Trim();
            if (!this.RawDataCheck())
            {
                throw new Exception(rawData + " 不符合 " + this.BarCodeType + " 标准");
            }
            this._EncodedData = this.GetEncodedData();
        }

        protected int GetBarCodePhyWidth()
        {
            //在212222这种BS单元下，要计算bsGroup对应模块宽度的倍率  
            //应该要将总长度减去1（因为Stop对应长度为7），然后结果乘以11再除以6，与左右空白相加后再加上2（Stop比正常的BS多出2个模块组）  
            int bsNum = (this._EncodedData.Length - 1) * 11 / 6 + 2;
            return bsNum * this._BarCellWidth;
        }

        /// <summary>  
        /// 数据输入正确性验证  
        /// </summary>  
        /// <returns></returns>  
        protected abstract bool RawDataCheck();

        /// <summary>  
        /// 获取当前Data对应的编码数据(条空组合)  
        /// </summary>  
        /// <returns></returns>  
        protected abstract string GetEncodedData();

        /// <summary>  
        /// 获取完整的条形码  
        /// </summary>  
        /// <returns></returns>  
        public Image GetBarCodeImage()
        {
            Image barImage = this.GetBarOnlyImage();
            int width = barImage.Width;
            int height = barImage.Height;
            if (this._IsDisplayFontData)
            {
                height += this._FontPadding + (int)this._FontSize;
            }

            Image image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            g.Clear(this.backColor);
            g.DrawImage(barImage, 0, 0, barImage.Width, barImage.Height);

            if (this._IsDisplayFontData)
            {
                Font drawFont = new Font(new FontFamily("Times New Roman"), this._FontSize, FontStyle.Regular, GraphicsUnit.Pixel);
                Brush drawBrush = new SolidBrush(this.barColor);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = this._FontAlignment;
                RectangleF reF = new RectangleF(0, barImage.Height + this._FontPadding, width, this._FontSize);
                g.DrawString(this.PresentationData, drawFont, drawBrush, reF, drawFormat);

                drawFont.Dispose();
                drawBrush.Dispose();
                drawFormat.Dispose();
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //结束绘制  
            g.Dispose();
            image.Dispose();
            return Image.FromStream(ms);
        }
        /// <summary>  
        /// 获取仅包含条形码的图像  
        /// </summary>  
        /// <returns></returns>  
        private Image GetBarOnlyImage()
        {
            int width = (int)this.GetBarCodePhyWidth();
            Bitmap image = new Bitmap(width, this._BarHeight);
            int ptr = 0;
            for (int i = 0; i < this._EncodedData.Length; i++)
            {
                int w = (int)char.GetNumericValue(this._EncodedData[i]);
                w *= this._BarCellWidth;
                Color c = i % 2 == 0 ? this.barColor : this.backColor;
                for (int j = 0; j < w; j++)
                {
                    for (int h = 0; h < this._BarHeight; h++)
                    {
                        image.SetPixel(ptr, h, c);
                    }
                    ptr++;
                }
            }
            return image;
        }
    }

    public class Code128Auto : BaseCode128
    {
        public Code128Auto(string rawData)
            : base(rawData)
        {
        }

        protected override bool RawDataCheck()
        {
            //Code128对应的ASCII码范围是0~127  
            foreach (char c in this._RawData)
            {
                if ((byte)c > 127)
                {
                    return false;
                }
            }
            return true;
        }
        
        protected override string GetEncodedData()
        {
            StringBuilder tempBuilder = new StringBuilder();

            CharacterSet nowCharacterSet = Code128.GetCharacterSet(this._RawData, 0);

            int checkNum;//校验字符  
            switch (nowCharacterSet)
            {
                case CharacterSet.A:
                    tempBuilder.Append(Code128.BSList[Code128.StartA]);//加上起始符StartA  
                    checkNum = Code128.StartA;
                    break;
                case CharacterSet.B:
                    tempBuilder.Append(Code128.BSList[Code128.StartB]);//加上起始符StartB  
                    checkNum = Code128.StartB;
                    break;
                default:
                    tempBuilder.Append(Code128.BSList[Code128.StartC]);//加上起始符StartC  
                    checkNum = Code128.StartC;
                    break;
            }
            int nowWeight = 1, nowIndex = 0;
            this.GetEncodedData(tempBuilder, nowCharacterSet, ref nowIndex, ref nowWeight, ref checkNum);

            checkNum %= 103;
            tempBuilder.Append(Code128.BSList[checkNum]);//加上校验符  
            tempBuilder.Append(Code128.BSList[Code128.Stop]);//加上结束符  
            return tempBuilder.ToString();
        }
        /// <summary>  
        /// 通用方法  
        /// </summary>  
        /// <param name="tempBuilder"></param>  
        /// <param name="sIndex"></param>  
        /// <param name="nowWeight"></param>  
        /// <param name="checkNum"></param>  
        private void EncodingCommon(StringBuilder tempBuilder, byte sIndex, ref int nowWeight, ref int checkNum)
        {
            tempBuilder.Append(Code128.BSList[sIndex]);
            checkNum += nowWeight * sIndex;
            nowWeight++;
        }
        /// <summary>  
        /// 获取编码后的数据  
        /// </summary>  
        /// <param name="tempBuilder">编码数据容器</param>  
        /// <param name="nowCharacterSet">当前字符集</param>  
        /// <param name="i">字符串索引</param>  
        /// <param name="nowWeight">当前权值</param>  
        /// <param name="checkNum">当前检验值总和</param>  
        private void GetEncodedData(StringBuilder tempBuilder, CharacterSet nowCharacterSet, ref int i, ref int nowWeight, ref int checkNum)
        {//因为可能存在字符集C，所以i与nowWeight可能存在不一致关系，所以要分别定义  
            byte sIndex;
            switch (nowCharacterSet)
            {
                case CharacterSet.A:
                case CharacterSet.B:
                    for (; i < this._RawData.Length; i++)
                    {
                        if (char.IsDigit(this._RawData[i]))
                        {
                            //数字  
                            int digitLength = Code128.GetDigitLength(this._RawData, i);
                            if (digitLength >= 4)
                            {
                                //转入CodeC  
                                if (digitLength % 2 != 0)
                                {//奇数位数字，在第一个数字之后插入CodeC字符  
                                    sIndex = Code128.GetSIndex(nowCharacterSet, (this._RawData[i]));
                                    this.EncodingCommon(tempBuilder, sIndex, ref nowWeight, ref checkNum);
                                    i++;
                                }
                                nowCharacterSet = CharacterSet.C;
                                sIndex = Code128.GetCodeXIndex(nowCharacterSet);//插入CodeC切换字符  
                                this.EncodingCommon(tempBuilder, sIndex, ref nowWeight, ref checkNum);
                                this.GetEncodedData(tempBuilder, nowCharacterSet, ref i, ref nowWeight, ref checkNum);
                                return;
                            }
                            else
                            {
                                //如果小于4位数字，则直接内部循环结束  
                                for (int j = 0; j < digitLength; j++)
                                {
                                    sIndex = Code128.GetSIndex(nowCharacterSet, (this._RawData[i]));
                                    this.EncodingCommon(tempBuilder, sIndex, ref nowWeight, ref checkNum);
                                    i++;
                                }
                                i--;//因为上面循环结束后继续外部循环会导致i多加了1，所以要减去1  
                                continue;
                            }
                        }
                        else if (Code128.CharNotBelongsTo(nowCharacterSet, this._RawData[i]))
                        {//当前字符不属于目前的字符集  
                            byte tempByte = Code128.GetProprietaryChar(this._RawData, i + 1);//获取当前字符后第一个属于A,或B的字符集  
                            CharacterSet tempCharacterSet = Code128.GetShiftCharacterSet(nowCharacterSet);
                            if (tempByte != byte.MaxValue && Code128.CharOnlyBelongsTo(nowCharacterSet, (char)tempByte))
                            {
                                //加入转换符  
                                sIndex = Code128.SHIFT_AB;
                                this.EncodingCommon(tempBuilder, sIndex, ref nowWeight, ref checkNum);

                                sIndex = Code128.GetSIndex(tempCharacterSet, this._RawData[i]);
                                this.EncodingCommon(tempBuilder, sIndex, ref nowWeight, ref checkNum);
                                continue;
                            }
                            else
                            {
                                //加入切换符  
                                nowCharacterSet = tempCharacterSet;
                                sIndex = Code128.GetCodeXIndex(nowCharacterSet);
                                this.EncodingCommon(tempBuilder, sIndex, ref nowWeight, ref checkNum);
                                this.GetEncodedData(tempBuilder, nowCharacterSet, ref i, ref nowWeight, ref checkNum);
                                return;
                            }
                        }
                        else
                        {
                            sIndex = Code128.GetSIndex(nowCharacterSet, this._RawData[i]);
                            this.EncodingCommon(tempBuilder, sIndex, ref nowWeight, ref checkNum);
                        }
                    }
                    break;
                default:
                    for (; i < this._RawData.Length; i += 2)
                    {
                        if (i != this._RawData.Length - 1 && char.IsDigit(this._RawData, i) && char.IsDigit(this._RawData, i + 1))
                        {
                            sIndex = byte.Parse(this._RawData.Substring(i, 2));
                            this.EncodingCommon(tempBuilder, sIndex, ref nowWeight, ref checkNum);
                        }
                        else
                        {
                            nowCharacterSet = Code128.GetCharacterSet(this._RawData, i);
                            //插入转换字符  
                            sIndex = Code128.GetCodeXIndex(nowCharacterSet);
                            this.EncodingCommon(tempBuilder, sIndex, ref nowWeight, ref checkNum);
                            this.GetEncodedData(tempBuilder, nowCharacterSet, ref i, ref nowWeight, ref checkNum);
                            return;
                        }
                    }
                    break;
            }
        }
    }
}
