﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Wytn.Util
{
    /// <summary>
    /// 驗證碼 Utility
    /// </summary>
    public static class CaptchaUtil
    {
        /// <summary>
        /// 圖片寬度
        /// </summary>
        private const int _imageWidth = 65;

        /// <summary>
        /// 圖片高度
        /// </summary>
        private const int _imageHeight = 24;

        /// <summary>
        /// 數值越高越亮 越低越暗 0-255
        /// </summary>
        private const int _textColorDepth = 80;

        /// <summary>
        /// 數值越高越亮 越低越暗 0-255
        /// </summary>
        private const int _interferenceColorDepth = 200;

        /// <summary>
        /// 驗證碼會隨機產生的字元，如果要用英數大小寫，會避開 l1Oo0 之類的。
        /// </summary>
        private const string _chars = "0123456789";

        /// <summary>
        /// 亂數產生器
        /// </summary>
        private static readonly Random _random = new Random();

        /// <summary>
        /// 背景顏色
        /// </summary>
        private static readonly Color _backGroundColor = Color.White;

        /// <summary>
        /// 隨機每個驗證碼字元的字體列表
        /// </summary>
        private static readonly List<Font> _fonts = new string[]  {
                    "Arial", "Arial Black", "Calibri", "Cambria", "Verdana",
                    "Trebuchet MS", "Palatino Linotype", "Georgia", "Constantia",
                    "Consolas", "Comic Sans MS", "Century Gothic", "Candara",
                    "Courier New", "Times New Roman"
                }.Select(f => new Font(f, 14, FontStyle.Bold | FontStyle.Italic)).ToList();

        /// <summary>
        /// 產生驗證碼的圖片
        /// </summary>
        /// <param name="text">驗證碼</param>
        /// <returns>圖片</returns>
        public static byte[] GenerateCaptchaImage(string text)
        {
            using (var bmpOut = new Bitmap(_imageWidth, _imageHeight))
            {
                float orientationAngle = _random.Next(0, 359);
                var g = Graphics.FromImage(bmpOut);
                var gradientBrush = new LinearGradientBrush(
                    new Rectangle(0, 0, _imageWidth, _imageHeight),
                    _backGroundColor, _backGroundColor,
                    orientationAngle
                );
                g.FillRectangle(gradientBrush, 0, 0, _imageWidth, _imageHeight);

                int tempRndAngle = 0;
                // 用迴圈目的為讓每一個字的顏色跟角度都不一樣
                for (int i = 0; i < text.Length; i++)
                {
                    // 改變角度
                    tempRndAngle = _random.Next(-5, 5);
                    g.RotateTransform(tempRndAngle);

                    // 改變顏色
                    g.DrawString(
                        text[i].ToString(),
                        _fonts[_random.Next(0, _fonts.Count)],
                        new SolidBrush(GetRandomColor(_textColorDepth)),
                        i * _imageWidth / (text.Length + 1) * 1.2f,
                        (float)_random.NextDouble()
                    );

                    g.RotateTransform(-tempRndAngle);
                }

                InterferenceLines(ref g, 6);

                ArraySegment<byte> bmpBytes;
                using (var ms = new MemoryStream())
                {
                    bmpOut.Save(ms, ImageFormat.Gif);
                    ms.TryGetBuffer(out bmpBytes);
                    bmpOut.Dispose();
                    ms.Dispose();
                }

                return bmpBytes.ToArray();
            }
        }

        /// <summary>
        /// 隨機產生驗證碼
        /// </summary>
        /// <param name="textLength">要幾個字元</param>
        /// <returns>驗證碼</returns>
        public static string GenerateRandomText(int textLength)
        {
            var result = new string(Enumerable.Repeat(_chars, textLength)
                  .Select(s => s[_random.Next(s.Length)]).ToArray());
            return result.ToUpper();
        }

        /// <summary>
        /// 隨機劃出干擾線
        /// </summary>
        /// <param name="g">畫布</param>
        /// <param name="lines">干擾線數量</param>
        private static void InterferenceLines(ref Graphics g, int lines)
        {
            for (var i = 0; i < lines; i++)
            {
                var pan = new Pen(GetRandomColor(_interferenceColorDepth));
                var points = new Point[_random.Next(2, 5)];
                for (int pi = 0; pi < points.Length; pi++)
                {
                    points[pi] = new Point(_random.Next(0, _imageWidth), _random.Next(0, _imageHeight));
                }
                // 用多個點建立扭曲的弧線
                g.DrawCurve(pan, points);
            }
        }

        /// <summary>
        /// 隨機產生顏色
        /// </summary>
        /// <param name="depth">顏色深度</param>
        /// <returns>顏色</returns>
        private static Color GetRandomColor(int depth)
        {
            int red = _random.Next(depth);
            int green = _random.Next(depth);
            int blue = (red + green > 400) ? 0 : 400 - red - green;
            blue = (blue > depth) ? depth : blue;
            return Color.FromArgb(red, green, blue);
        }
    }
}
