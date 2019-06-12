using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class LevelGeneratorTest
    {
        [Test]
        public void TestRGBHex()
        {
            //color #FFFFFF
            string hex = "#FFFFFF";
            float r = 1f;
            float g = 1f;
            float b = 1f;
            Color c = new Color(r, g, b);
            string generatedHex = ColorTypeConverter.ToRGBHex(c);

            Assert.AreEqual(hex, generatedHex);
        }
    }
}
