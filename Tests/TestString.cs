using TestJob;

namespace Tests
{
    [TestClass]
    public sealed class TestString
    {
        [TestMethod]
        public void TestStringCompressor()
        {
            Assert.AreEqual("abc", StringCompressor.CompressString("abc"));
            Assert.AreEqual("a3", StringCompressor.CompressString("aaa"));
            Assert.AreEqual("ab2", StringCompressor.CompressString("abb"));
            Assert.AreEqual("a4b", StringCompressor.CompressString("aaaab"));
            Assert.AreEqual("a3b2c3d2e", StringCompressor.CompressString("aaabbcccdde"));
        }
    }
}
