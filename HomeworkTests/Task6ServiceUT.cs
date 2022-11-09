using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework.Task6;

namespace HomeworkTests
{
    [TestClass]
    public class Task6ServiceUT

    {
        // **************** //
        //  Initialization  //
        // **************** //

       // [TestMethod("Should init dictionary")]
        public void ShouldInitDict()
        {
            var d = Dict.Instance();
            Assert.AreNotEqual(0, d.Size());
        }

       // [TestMethod("Should have translation for default words")]
        public void ShouldHaveTranslationsForDefaults()
        {
            var d = Dict.Instance();
            Assert.AreEqual("идти", d.GetTranslations("go"));
        }
    }
}
