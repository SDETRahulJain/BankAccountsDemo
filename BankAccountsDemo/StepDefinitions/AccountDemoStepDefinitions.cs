using System;
using TechTalk.SpecFlow;
using BankAccountsDemo.Models;
using BankAccountsDemo.Util;
using RestSharp;
using Newtonsoft.Json;

namespace BankAccountsDemo.StepDefinitions
{
    [Binding]
    public class AccountDemoStepDefinitions
    {
        ScenarioContext scenarioContext;
        string accountNumber = string.Empty;
        private RestResponse response;
        CreateAccountRequest createAccountRequest;

        public AccountDemoStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            createAccountRequest = new CreateAccountRequest();

        }

        [Given(@"Account Initial Balance is (.*)")]
        public void GivenAccountInitialBalanceIs(int p0)
        {
            createAccountRequest.InitialBalance = p0;
        }

        [Given(@"Account name is '([^']*)'")]
        public void GivenAccountNameIs(string accountName)
        {
            createAccountRequest.AccountName = accountName;
        }

        [Given(@"Address is '([^']*)'")]
        public void GivenAddressIs(string address)
        {
            createAccountRequest.Address = address;
        }

        [When(@"POST endpoint triggered to create new account with above details")]
        public void WhenPOSTEndpointTriggeredToCreateNewAccountWithAboveDetails()
        {
            var url = "/account/create";
            var requestBody = createAccountRequest;
            response = ApiHelper.ExecutePostRequest(url, requestBody);

        }

        [Then(@"Verify the response code is Ok")]
        public void ThenVerifyTheResponseCodeIs()
        {
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Then(@"Verify no error is returned")]
        public void ThenVerifyNoErrorIsReturned()
        {
            Assert.IsEmpty(response.Content);
        }

        [Then(@"Verify the success message ""([^""]*)""")]
        public void ThenVerifyTheSuccessMessage(string message)
        {
            Assert.IsTrue(response.Content.Contains(message));
        }

        [Then(@"Verify the account details are correctly returned in the JSON response for expected (.*)")]
        public void ThenVerifyTheAccountDetailsAreCorrectlyReturnedInTheJSONResponse(string accountNumber)
        {
            var newAccount = ApiHelper.DeserializeResponse<Account>(response);
            var expectedAccount = accountNumber;

            Assert.AreEqual(expectedAccount, newAccount.AccountNumber);
        }

        [Given(@"Account with number '([^']*)' exists")]
        public void GivenAccountWithNumberExists(string accountNumber)
        {
            var url = "/account/Info";
            var requestBody = accountNumber;
            response = ApiHelper.ExecuteGetRequest(url, requestBody);
            ThenVerifyTheAccountDetailsAreCorrectlyReturnedInTheJSONResponse(accountNumber);

        }

        [When(@"PUT endpoint triggered to deposit (.*) in Y(.*)")]
        public void WhenPUTEndpointTriggeredToDepositTo(string amount, string accountNumber)
        {
            var url = "/account/deposit";
            var requestBody = new DepositRequest
            {
                AccountNumber = accountNumber,
                Amount = decimal.Parse(amount)
            };
            response = ApiHelper.ExecutePutRequest(url, requestBody);

        }

        [Then(@"Verify the new balance is (.*) in the response")]
        public void ThenVerifyTheNewBalanceIsInTheResponse(int expectedAmount)
        {
            var newAccount = ApiHelper.DeserializeResponse<Account>(response);

            Assert.AreEqual(expectedAmount, newAccount.Balance);
        }

        [When(@"PUT endpoint triggered to withdraw (.*) from Y(.*)")]
        public void WhenPUTEndpointTriggeredToWithdrawFromX(string amount, string accountNumber)
        {
            var url = "/account/withdraw";
            var requestBody = new WithdrawRequest
            {
                AccountNumber = accountNumber,
                Amount = decimal.Parse(amount)
            };
            response = ApiHelper.ExecutePutRequest(url, requestBody);
        }


        [When(@"DELETE endpoint triggered with '([^']*)'")]
        public void WhenDELETEEndpointTriggeredWith(string accountNumber)
        {
            var url = $"/account/delete/{accountNumber}";
            response = ApiHelper.ExecuteDeleteRequest(url);
        }
    }
}
