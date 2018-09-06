using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TheProject.Controller;
using TheProject.Model;

namespace TheProject.Test.Steps
{
    [Binding]
    public class CheckoutSteps
    {
        private Cart cart;
        private Member libraryMember;
        private CheckoutProcessor checkoutProcessor = new CheckoutProcessor();

        [Given(@"I have a cart with (.*) items")]
        public void GivenIHaveACartWithItems(int p0)
        {
            cart = new Cart();

            for (var i = 0; i < p0; i++)
            {
                cart.Books.Add(new Book());
            }
        }

        [Given(@"I am a library member")]
        public void GivenIAmALibraryMember()
        {
            libraryMember = new Member();
        }


        [When(@"I press checkout")]
        public void WhenIPressCheckout()
        {
            checkoutProcessor.Checkout(cart);
        }

        [Then(@"an output message ""(.*)"" should be displayed")]
        public void ThenAnOutputMessageShouldBeDisplayed(string p0)
        {
            Assert.AreEqual(p0, checkoutProcessor.Output);
        }
    }
}
