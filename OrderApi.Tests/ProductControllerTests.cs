using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderApi.Tests
{
    [TestClass]
    public class ProductControllerTests
    {
       
        [TestInitialize]
        public void TestInitialize()
        {
        }
        [TestMethod]
        public void GivenAProductOrder_WhenThePayloadIsValid_ThenVerifyTheControllerReturnsOk()
        {
            //given

            //when

            //then
        }
        [TestMethod]
        public void GivenAProductOrder_WhenTheClientHasOutstandingOrdersWithATotalValueInExcessOfOneHundredEuro_ThenVerifyTheControllerReturnsBadRequest()
        {
            //given

            //when

            //then
        }
    }
}
