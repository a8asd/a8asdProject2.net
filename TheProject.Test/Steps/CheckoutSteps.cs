using System;
using TechTalk.SpecFlow;
using TheProject.Model;

namespace TheProject.Test.Steps
{
    [Binding]
    public class CheckoutSteps
    {
        private Cart cart;
        private CheckoutProcessor checkoutProcessor;

        [Given(@"I have a cart with (.*) items")]
        public void GivenIHaveACartWithItems(int p0)
        {
            cart = new Cart();
        }

        [Given(@"I am a library member")]
        public void GivenIAmALibraryMember()
        {
            libraryMember = new Member();
        }
s

        [When(@"I press checkout")]
        public void WhenIPressCheckout()
        {
            checkoutProcessor.Checkout(cart);
        }
        
        [Then(@"an error message ""(.*)"" should be displayed")]
        public void ThenAnErrorMessageShouldBeDisplayed(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
