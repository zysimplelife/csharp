﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaiPaiAssistant
{
    class Configuration
    {
        private static Rectangle price;
        private static Rectangle time;
        private static Point increase_button;
        private static Point increase_input;

        private static Point submit_button;
        private static Point submit_input;

        private static Dictionary<String, Point> pointMap = new Dictionary<string, Point>();
        private static Dictionary<String, Rectangle> rectMap = new Dictionary<string, Rectangle>();

        public static String CONFIG_PRICE_RECT = "postion.price";
        public static String CONFIG_TIME_RECT = "postion.time";
        public static String CONFIG_INC_IN_POINT = "position.increase.input";
        public static String CONFIG_INC_BTN_POINT = "position.increase.button";
        public static String CONFIG_SUBMIT_IN_POINT = "position.submit.input";
        public static String CONFIG_SUBMIT_BTN_POINT = "position.submit.button";
        public static String CONFIG_VERIFICATION_IN_POINT = "position.verification.input";
        public static String CONFIG_VERIFICATION_REFESH_POINT = "position.verification.refresh";
        public static String CONFIG_CONFIRM_BTN_POINT = "position.confirm.button";
        public static String CONFIG_CANCEL_BTN_POINT = "position.cancel.button";
        public static String CONFIG_BEFORE_TARGET = "position.click.beforeTarget";


        public static int BeforeTarget()
        {
            return Int32.Parse(ConfigurationManager.AppSettings[CONFIG_BEFORE_TARGET]);
        }


        public static Point GetScreenPoint(String key, IntPtr pWnd)
        {
            Point point = GetClientPoint(key);

            Rectangle wndRect = ScreenUtils.getClientRect(pWnd);

            return new Point(point.X + wndRect.X, point.Y + wndRect.Y);
        }

        public static Point GetClientPoint(string key)
        {
            Point point = new Point();

            if (!pointMap.TryGetValue(key, out point))
            {
                point = getPoint(key);
                pointMap.Add(key, point);
            }

            return point;
        }

        public static Rectangle getRectangleFromConfig(String key)
        {
            Rectangle rect = new Rectangle();

            if (!rectMap.TryGetValue(key, out rect))
            {
                rect = getRect(key);
                rectMap.Add(key, rect);
            }

            return rect;

        }

        public static Rectangle GetScreenRect(String key, IntPtr pWnd)
        {
            Rectangle rect = getRectangleFromConfig(key);
            Point point = new Point(0, 0);
            ScreenUtils.ClientToScreen(pWnd, ref point);
            rect.X += point.X;
            rect.Y += point.Y;
            return rect;
        }



        private static Rectangle getRect(String configKey)
        {

            String position = ConfigurationManager.AppSettings[configKey];
            String[] points = position.Split(',');

            Int32 x = Int32.Parse(points[0]);
            Int32 y = Int32.Parse(points[1]);
            Int32 width = Int32.Parse(points[2]);
            Int32 height = Int32.Parse(points[3]);

            return new Rectangle(x, y, width, height);
        }


        private static Point getPoint(String configKey)
        {
            String position = ConfigurationManager.AppSettings[configKey];
            String[] points = position.Split(',');
            return new Point(Int32.Parse(points[0]), Int32.Parse(points[1]));
        }
    }
}
