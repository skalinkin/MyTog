using NUnit.Framework;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace Kalinkin.MyTog.UITest.Specs
{
    [TestFixture(Platform.Android)]
    public partial class ShouldWorkFeature
    {
        private readonly Platform _platform;
        protected static IApp app;

        public ShouldWorkFeature(Platform platform)
        {
            _platform = platform;
        }
        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(_platform);
            FeatureContext.Current.Add("App", app);
        }
    }
}