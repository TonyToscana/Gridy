using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PointsTest
    {
        [Test]
        public void IsSameInstance()
        {
            Points p1 = Points.GetInstance();
            Points p2 = Points.GetInstance();

            Assert.AreSame(p1, p2);
        }
        
        [Test]
        public void TestGetterAndSetter()
        {
            int points = 100;
            Points p1 = Points.GetInstance();
            p1.Set(points);

            int points1 = p1.Number;

            Assert.AreEqual(points, points1);
        }

        [Test]
        public void TestAdd()
        {
            int points = 100;
            int addPoints = 50;
            int totalPoints = points + addPoints;

            Points p1 = Points.GetInstance();
            p1.Set(points);
            p1.Add(addPoints);


            int points1 = p1.Number;

            Assert.AreEqual(totalPoints, points1);
        }

        [Test]
        public void TestSub()
        {
            int points = 100;
            int subPoints = 50;
            int totalPoints = points - subPoints;

            Points p1 = Points.GetInstance();
            p1.Set(points);
            p1.Sub(subPoints);


            int points1 = p1.Number;

            Assert.AreEqual(totalPoints, points1);
        }

        [Test]
        public void TestZero()
        {
            int points = 100;
            Points p1 = Points.GetInstance();
            p1.Set(points);
            p1.Zero();

            int points1 = p1.Number;

            Assert.AreEqual(0, points1);
        }
    }
}
