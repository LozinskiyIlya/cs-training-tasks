using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeworkTests
{
    [TestClass]
    public class Task1UT

    {
        [TestMethod("Should work without args")]
        public void ShouldWorkWithoutArgs()
        {
            Task1.Program.Main(new string[] { });
        }

        [TestMethod("Should work with 1 arg")]
        public void ShouldWorkWith1Arg()
        {
            Task1.Program.Main(new string[] { "10" });
        }

        [TestMethod("Should work with 4 args")]
        public void ShouldWorkWith4Args()
        {
            Task1.Program.Main(new string[] { "10", "20", "30", "40" });
        }
    }
}
