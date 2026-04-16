using TestJob.Logger;

namespace Tests;

[TestClass]
public class TestLog
{
    string log1Transformed = "10-14-2025\t15:14:49.523\tINFO\tDEFAULT\tВерсия программы: '3.4.0.48729'";
    string log2Transformed = "10-14-2025\t15:14:51.5882\tINFO\tMobileComputer.GetDeviceId\t Код устройства: '@MINDEO-M40-D-410244015546'";

    [TestMethod]
    public void TestLogTransformation()
    {
        Logger logger = new Logger();

        string input = File.ReadAllText("LogFile1.log");
        bool isSuccess = logger.TryTransformLog(input, out string res);
        Assert.IsTrue(isSuccess);
        Assert.AreEqual(log1Transformed, res);

        input = File.ReadAllText("LogFile2.log");
        isSuccess = logger.TryTransformLog(input, out string res2);
        Assert.IsTrue(isSuccess);
        Assert.AreEqual(log2Transformed, res2);

        input = File.ReadAllText("LogWithError.log");
        isSuccess = logger.TryTransformLog(input, out string res3);
        Assert.IsFalse(isSuccess);
        Assert.AreEqual(input, res3);


        Assert.IsNotNull(new object());
    }
}
