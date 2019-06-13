using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class JsonHelperTest
    {
        private int[] Items = { 1, 2, 3 };
        // A Test behaves as an ordinary method
        [Test]
        public void TestToJson()
        {
            string expectedResult = "{\"Items\":[1,2,3]}";
            string json = JsonHelper.ToJson<int>(Items);

            Assert.AreEqual(expectedResult, json);
        }

        [Test]
        public void TestToJsonPrettyPrintFalse()
        {
            string expectedResult = "{\"Items\":[1,2,3]}";
            string json = JsonHelper.ToJson(Items, false);
            Debug.Log(json);

            Assert.AreEqual(expectedResult, json);
        }

        [Test]
        public void TestToJsonPrettyPrintTrue()
        {
            string expectedResult = "{\n    \"Items\": [\n        1,\n        2,\n        3\n    ]\n}";
            string json = JsonHelper.ToJson(Items, true);
            Debug.Log(JsonUtility.ToJson(Items, true));

            Assert.AreEqual(expectedResult, json);
        }

        [Test]
        public void TestJsonFromJson()
        {
            string json = JsonHelper.ToJson(Items);
            var expectedResult = Items;
            var result = JsonHelper.FromJson<int>(json);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
