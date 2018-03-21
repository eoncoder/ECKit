using System;
using System.Collections.Generic;
using System.Text;

namespace ECKit.XUnitTest.Model
{
    class HashHelperLevel2_1aModel
        : HashHelperLevel1_1Model
    {
        public override int Level1_1 { get => base.Level1_1; set => base.Level1_1 = value; }

        public virtual int Level2_1 { get; set; }
        public virtual int Level2_2 { get; set; }
    }
}
