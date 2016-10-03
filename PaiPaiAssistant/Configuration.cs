using System;
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
        private static Rectangle priceRect;
        private static Rectangle timeRect;


        public static Rectangle GetPriceRect(Boolean needRresh)
        {
            if(priceRect.IsEmpty|| needRresh)
            {
                priceRect = getRect("postion.price");
            }
            return priceRect;
        }

        public static Rectangle GetTimeRect(Boolean needRresh)
        {
            if (timeRect.IsEmpty || needRresh)
            {
                timeRect = getRect("postion.time");
            }
            return timeRect;
        }

        private static Rectangle getRect(String configKey)
        {
            String start = ConfigurationManager.AppSettings["postion.start"];
            String[] startPoint = start.Split(',');


            String position = ConfigurationManager.AppSettings[configKey];
            String[] points = position.Split(',');

            ScreenUtils pc = new ScreenUtils();

            Int32 x = Int32.Parse(startPoint[0]) + Int32.Parse(points[0]);
            Int32 y = Int32.Parse(startPoint[1]) + Int32.Parse(points[1]);
            Int32 width = Int32.Parse(points[2]);
            Int32 height = Int32.Parse(points[3]);

            return new Rectangle(x, y, width, height);
        }
    }
}
