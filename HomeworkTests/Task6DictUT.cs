using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework.Task6;

namespace HomeworkTests
{
    [TestClass]
    public class Task6DictUT

    {
        // **************** //
        //  Initialization  //
        // **************** //

        [TestMethod("Should init dictionary")]
        public void ShouldInitDict()
        {
            var d = Dict.Instance();
            Assert.AreNotEqual(0, d.Size());
        }

        [TestMethod("Should have translation for default words")]
        public void ShouldHaveTranslationsForDefaults()
        {
            var d = Dict.Instance();
            Assert.IsTrue(d.GetTranslations("go").Contains("идти"));
        }


        // *************** //
        // Add translation //
        // *************** //

        [TestMethod("Should add new pair")]
        public void ShouldAddNewPair()
        {
            var d = Dict.Instance();
            d.Add("developer", "разработчик");
            Assert.IsTrue(d.GetTranslations("developer").Contains("разработчик"));
            Assert.IsTrue(d.GetTranslations("разработчик").Contains("developer"));
        }


        [TestMethod("Should add value to existing pair")]
        public void ShouldAddValueToExistingPair()
        {
            var d = Dict.Instance();
            d.Add("developer", "разработчик");
            d.Add("developer", "застройщик");
            Assert.IsTrue(d.GetTranslations("developer").Contains("разработчик"));
            Assert.IsTrue(d.GetTranslations("developer").Contains("застройщик"));
            Assert.IsTrue(d.GetTranslations("застройщик").Contains("developer"));
        }


        // *************** //
        // Get translation //
        // *************** //

        [TestMethod("Should translate")]
        public void ShouldTranslate()
        {
            var d = Dict.Instance();
            Assert.IsTrue(d.GetTranslations("walk").Contains("гулять"));
            Assert.IsTrue(d.GetTranslations("walk").Contains("идти"));
        }

        [TestMethod("Should return empty set")]
        public void ShouldReturnEmptySet()
        {
            var d = Dict.Instance();
            Assert.AreEqual(0, d.GetTranslations("abc").Count);
        }

        [TestMethod("Should return same for subsequent calls")]
        public void ShouldReturnSame()
        {
            var d = Dict.Instance();
            Assert.IsTrue(d.GetTranslations("идти").IsSubsetOf(d.GetTranslations("идти")));
            Assert.IsFalse(d.GetTranslations("идти").IsProperSubsetOf(d.GetTranslations("идти")));
        }
    }
}
