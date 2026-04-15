using TestJob;

namespace Tests
{
    [TestClass]
    public sealed class TestClass
    {
        [TestMethod]
        public void TestStringCompressor()
        {
            Assert.AreEqual("a3b2c3d2e", StringCompressor.CompressString("aaabbcccdde"));
        }
    }
}
