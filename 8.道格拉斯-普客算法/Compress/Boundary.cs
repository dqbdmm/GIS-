using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compress
{
    public class Boundary
    {
            public float xMin;
            public float xMax;
            public float yMin;
            public float yMax;
            public Boundary()        //构造函数,初始化字段
            {
                xMin = float.MaxValue;
                yMin = float.MaxValue;
                xMax = float.MinValue;
                yMax = float.MinValue;
            }
    }
}
