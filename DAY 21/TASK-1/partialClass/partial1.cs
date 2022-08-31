using System;
using System.Collections.Generic;
using System.Text;

namespace partialClass
{
    public partial class partialCls
    {
        private string book;
        private int publish_year;

        public partialCls(string a, int b)
        {
            this.book = a;
            this.publish_year = b;
        }
    }
}
