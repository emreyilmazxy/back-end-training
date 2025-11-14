using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BankApp.WepApi.Models;
using Xunit;

namespace BankApp.Business.Tests
{
    public class AddAccountRequestValidationTests
    {
        [Fact]
        public void Currency_LengthGreaterThanThree_ShouldFailValidation()
        {
            var model = new AddAccountRequest { Currency = "USDT" };
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(model, new ValidationContext(model), results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(AddAccountRequest.Currency)));
        }

        [Fact]
        public void Currency_LengthWithinRange_ShouldPassValidation()
        {
            var model = new AddAccountRequest { Currency = "USD" };
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(model, new ValidationContext(model), results, true);

            Assert.True(isValid);
        }
    }
}
