using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Attributes
{
    public class PositionIndexAttribute:Attribute
    {
        public int Index{get;set;}
        public PositionIndexAttribute(int index)
        {
            this.Index = index;
        }
    }
}
