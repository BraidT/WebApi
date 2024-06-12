namespace WebApiTests {
    using Core.Util;
    using NUnit.Framework;

    [TestFixture]
    public class EstonianPersonalCodeValidatorTests {
        private EstonianPersonalCodeValidator _validator;

        [SetUp]
        public void Setup() {
            _validator = new EstonianPersonalCodeValidator();
        }

        [TestCase("37001192248", true)]
        [TestCase("49904319997", false)] 
        [TestCase("60101019904", false)]
        [TestCase("36412314751", true)]
        [TestCase("39912319996", false)]
        [TestCase("49902319997", false)]
        [TestCase("60115019904", false)]
        [TestCase("45403132236", true)]
        public void ValidateTests(string personalCode, bool expected) {
            bool result = _validator.Validate(personalCode);
            Assert.AreEqual(expected, result);
        }
    }
}