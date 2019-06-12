using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TimerTest
    {
        [Test]
        public void TestFormatTime()
        {
            string validResult = "02:23:45";
            float seconds = 2 * 3600 + 23 * 60 + 45;

            string result = Timer.formatTime(seconds);

            Assert.AreEqual(validResult, result);
        }
    }
}
