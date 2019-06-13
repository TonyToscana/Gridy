using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

namespace Tests
{
    public class EnemyTest
    {
        [Test]
        public void TestGetHealthMethod()
        {
            EnemyLogic enemy = new EnemyLogic();

            Assert.AreEqual(100, enemy.GetHealth());
        }
        // A Test behaves as an ordinary method
        [Test]
        public void EnemyRecievesDamageCorrectly()
        {
            EnemyLogic enemy = new EnemyLogic();
            enemy.Damage(10);

            Assert.AreEqual(90, enemy.GetHealth());
        }
    }
}
