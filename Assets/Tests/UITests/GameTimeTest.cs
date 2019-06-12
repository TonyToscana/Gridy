using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GameTimeTest
    {
        [Test]
        public void IsSameInstance()
        {
            GameTime p1 = GameTime.GetInstance();
            GameTime p2 = GameTime.GetInstance();

            Assert.AreSame(p1, p2);
        }

        [Test]
        public void TestGetterAndSetter()
        {
            float seconds = 128;
            GameTime p1 = GameTime.GetInstance();
            p1.Set(seconds);

            float seconds1 = p1.Seconds;

            Assert.AreEqual(seconds, seconds1);
        }

        [Test]
        public void TestAdd()
        {
            float seconds = 128;
            float addSeconds = 52;
            float totalSeconds = seconds + addSeconds;

            GameTime p1 = GameTime.GetInstance();
            p1.Set(seconds);
            p1.Add(addSeconds);


            float seconds1 = p1.Seconds;

            Assert.AreEqual(totalSeconds, seconds1);
        }

        [Test]
        public void TestSub()
        {
            float seconds = 128;
            float subSeconds = 8;
            float totalSeconds = seconds - subSeconds;

            GameTime p1 = GameTime.GetInstance();
            p1.Set(seconds);
            p1.Sub(subSeconds);


            float seconds1 = p1.Seconds;

            Assert.AreEqual(totalSeconds, seconds1);
        }

        [Test]
        public void TestZero()
        {
            float seconds = 128;
            GameTime p1 = GameTime.GetInstance();
            p1.Set(seconds);
            p1.Zero();

            float seconds1 = p1.Seconds;

            Assert.AreEqual(0, seconds1);
        }
    }
}
