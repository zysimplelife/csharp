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

        private static Point submit_button  ;
        private static Point submit_input;

        private static Dictionary<String, Point> pointMap = new Dictionary<string, Point>();
        private static Dictionary<String, Rectangle> rectMap = new Dictionary<string, Rectangle>();


        public static String CONFIG_BASE_POINT = "postion.start";
        public static String CONFIG_PRICE_RECT = "postion.price";
        public static String CONFIG_TIME_RECT = "postion.time";
        public static String CONFIG_INC_IN_POINT = "position.increase.input";
        public static String CONFIG_INC_BTN_POINT = "position.increase.button";
        public static String CONFIG_SUBMIT_IN_POINT = "position.submit.input";
        public static String CONFIG_SUBMIT_BTN_POINT = "position.submit.button";



        public static Point GetClientPoint(String key,IntPtr pWnd)
        {
             Point point = new Point();

            if (!pointMap.TryGetValue(key,out point))
            {
                point = getPoint(key);
                pointMap.Add(key,point);
            }
            Rectangle wndRect = ScreenUtils.getWndRect(pWnd);

            return new Point(point.X + wndRect.X, point.Y + wndRect.Y);
        }






        public static Rectangle GetPriceRect()
        {
            if(price.IsEmpty)
            {
                price = getRect("postion.price");
            }
            return price;
        }

        public static Rectangle GetTimeRect()
        {
            if (time.IsEmpty)
            {
                time = getRect("postion.time");
            }
            return time;
        }



        private static Rectangle getRect(String configKey)
        {
            String start = ConfigurationManager.AppSettings[CONFIG_BASE_POINT];
            String[] startPoint = start.Split(',');


            String position = ConfigurationManager.AppSettings[configKey];
            String[] points = position.Split(',');


            Int32 x = Int32.Parse(startPoint[0]) + Int32.Parse(points[0]);
            Int32 y = Int32.Parse(startPoint[1]) + Int32.Parse(points[1]);
            Int32 width = Int32.Parse(points[2]);
            Int32 height = Int32.Parse(points[3]);

            return new Rectangle(x, y, width, height);
        }


        private static Point getPoint(String configKey)
        {
            String start = ConfigurationManager.AppSettings[CONFIG_BASE_POINT];
            String[] startPoint = start.Split(',');


            String position = ConfigurationManager.AppSettings[configKey];
            String[] points = position.Split(',');


            Int32 x = Int32.Parse(startPoint[0]) + Int32.Parse(points[0]);
            Int32 y = Int32.Parse(startPoint[1]) + Int32.Parse(points[1]);
        

            return new Point(x, y);
        }
    }
}
