using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Attributes
{
    public class SegmentIdAttribute:Attribute
    { 
        public string Id{get;set;}
        public SegmentIdAttribute(string  id)
        {
            this.Id = id;
        }
    }
}
