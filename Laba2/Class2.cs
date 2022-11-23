using System;
using System.Collections.Generic;
using System.Text;

namespace Laba2
{
    public static class ExtensionMethods
    {
        public static int Do_Investment(this Factory Factory, int value)
        {
            Random rnd = new Random();
            int num = rnd.Next(2, 5);
            int result = value * num;
            return result;
        }
    }

}
