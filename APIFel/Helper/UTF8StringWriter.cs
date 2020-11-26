using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace APIFel.Helper
{
    public sealed class UTF8StringWriter : System.IO.StringWriter
    {
        private readonly Encoding encoding;

        public UTF8StringWriter(StringBuilder sb) : base(sb)
        {
            this.encoding = Encoding.UTF8;
        }

        public UTF8StringWriter(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public UTF8StringWriter(StringBuilder sb, Encoding encoding) : base(sb)
        {
            this.encoding = encoding;
        }

        public override Encoding Encoding
        {
            get { return encoding; }
        }
    }
}