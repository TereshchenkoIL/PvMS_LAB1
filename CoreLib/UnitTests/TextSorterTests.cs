using CoreLib;

namespace UnitTests
{
    public class TextSorterTests
    {
        private TextSorter _sorter;

        [SetUp]
        public void SetUp()
        {
            _sorter = new TextSorter();
        }

        [Test]
        public void SortWords_WhenCalled_SortWordsReverseAlphabetical()
        {
            var str = "adfgdf cghmn buiokfg dnlrh";

            var res  = _sorter.SortWords(str);

            Assert.That(res, Is.EqualTo("dnlrh cghmn buiokfg adfgdf"));
        }
    }
}
