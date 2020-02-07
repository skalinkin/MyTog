using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace UITest.Steps
{
    [Binding]
    public class ShouldWorkSteps
    {
        readonly IApp app;
        [Given(@"Application lunched")]
        public void GivenApplicationLunched()
        {
        }
        
        [Then(@"No errors")]
        public void ThenNoErrors()
        {
        }
    }
}
