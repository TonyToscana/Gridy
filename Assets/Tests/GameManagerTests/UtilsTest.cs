using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class UtilsTest
    {
        [Test]
        public void TestCloneVector()
        {
            Vector3 originVector = new Vector3(2f, 3f, 4f);

            Vector3 generatedVector = Utils.CloneVector3(originVector);

            Assert.AreEqual(originVector, generatedVector);
        }
    }
}
