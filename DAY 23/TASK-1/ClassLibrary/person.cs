using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class person
    {
        public string name;
        public int x, y;

        public person()
        {
            x = 10;
            y = 20;
        }

        public static person operator +(person a)
        {
            person p1 = new person();
            p1.x += a.x;
            p1.y += a.y;
            return p1;
        }
    }
}
