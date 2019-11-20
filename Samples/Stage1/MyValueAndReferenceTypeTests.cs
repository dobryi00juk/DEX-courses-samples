using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Stage1
{
    [TestFixture]
    public class MyValueAndReferenceTypeTests
    {
        [Test(ExpectedResult = false)]
        public bool Show()
        {
            var st = new CloneableStruct(1, true, "test");
            var clone = (CloneableStruct) st.Clone();

            st.Field3 = "some string";
                
            return Equals(st, clone);
        }

        struct CloneableStruct : ICloneable
        {
            public int Field1 { get; set; }
            public bool Field2 { get; set; }
            public string Field3 { get; set; }

            public CloneableStruct(int f1, bool f2, string f3)
            {
                Field1 = f1;
                Field2 = f2;
                Field3 = f3;
            }
            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

    }
}