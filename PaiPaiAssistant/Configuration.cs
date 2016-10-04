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
        private static Rectangle price;
        private static Rectangle time;
        private static Point increase_button;
        private static Point increase_input;

        private static Point submit_button  ;
        private static Point submit_input;



        private static String CONFIG_BASE_POINT = "postion.start" ;


        public static Rectangle GetPriceRect(Boolean needRresh)
        {
            if(price.IsEmpty|| needRresh)
            {
                price = getRect("postion.price");
            }
            return price;
        }

        public static Rectangle GetTimeRect(Boolean needRresh)
        {
            if (time.IsEmpty || needRresh)
            {
                time = getRect("postion.time");
            }
            return time;
        }

        public static Point GetIncreaseButtonPoint(Boolean needRresh)
        {
            if (increase_button.IsEmpty || needRresh)
            {
                increase_button = getPoint("position.increase.button");
            }
            return increase_button;
        }

        public static Point GetIncreaseInputPoint(Boolean needRresh)
        {
            if (increase_input.IsEmpty || needRresh)
            {
                increase_input = getPoint("position.increase.input");
            }
            return increase_input;
        }

        public static Point GetSubmitInputPoint(Boolean needRresh)
        {
            if (submit_input.IsEmpty || needRresh)
            {
                submit_input = getPoint("position.submit.input");
            }
            return submit_input;
        }

        public static Point GetSubmitButtonPoint(Boolean needRresh)
        {
            if (submit_button.IsEmpty || needRresh)
            {
                submit_button = getPoint("position.submit.button");
            }
            return submit_button;
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
