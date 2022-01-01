using System;
using System.ComponentModel.DataAnnotations;
using AgendaApi.Validations;
using Xunit;

namespace AgendaApiTests.Validations
{
    public class ValidConsultationDateTests
    {
        private readonly ValidConsultationDate _dateValidator = new ValidConsultationDate();

        [Theory]
        [InlineData("2021-12-30T12:30:00.000Z", true)]
        [InlineData("2021-12-30T12:30:00.025Z", false)]
        [InlineData("2021-12-30T12:34:11.937Z", false)]
        [InlineData("2021-12-30T12:00:00.000Z", true)]
        [InlineData("2021-12-30T06:00:00.000Z", false)]
        [InlineData("2021-12-30T20:00:00.000Z", false)]
        public void ConsultationDates(DateTime dateTime, bool isValid)
        {
            var result = _dateValidator.IsValid(dateTime);
            Assert.Equal(isValid, result);
        }
    }
}