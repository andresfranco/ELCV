using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net.Http;
using ELCV.UI.Models;
using Newtonsoft.Json;

namespace ELCV.Integration.Test
{
    public class CountriesControllerTest
    {
        private HttpClient client;

        public CountriesControllerTest()
        {
            client = new TestClassProvider().Client;
        }
      
        [Fact]
        public async Task GetAllCountries_ReturnOKResponse()
        {

            var response = await client.GetAsync("/api/countries");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Theory]
        //Inline data must exist in the database
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetCountryById_ValidId(int id )
        {
            var response = await client.GetAsync($"/api/countries/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(999999)]
        [InlineData(-2)]
        public async Task GetCountryById_NotValidId(int id)
        {
            var response = await client.GetAsync($"/api/countries/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task AddNewCountry_ValidCountryData()
        {
        var randomNumber = new Random().Next(1, 2000);
        var countryTestData = new StringContent(
            JsonConvert.SerializeObject(new CountryDTO() 
            { CountryCode = $"TestCode{randomNumber}", CountryName = $"TestName{randomNumber}" 
            }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/countries", countryTestData);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        
        public async Task AddNewCountry_InvalidCountryData()
        {
           
            var countryTestData = new StringContent(
                JsonConvert.SerializeObject(new CountryDTO()
                {
                    CountryName = $"TestName"
                }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/countries", countryTestData);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var countryTestData2 = new StringContent(
               JsonConvert.SerializeObject(new CountryDTO()
               {
                   
               }), Encoding.UTF8, "application/json");

            var response2 = await client.PostAsync("/api/countries", countryTestData2);
            response2.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        }

       /* [Fact]
        ///Test data must exist in the database
        public async Task UpdateExistentCountry()
        {
            var countryTestData = new StringContent(
                JsonConvert.SerializeObject(new CountryDTO()
                {   Id= 10,
                    CountryCode = "TestUpdateCode",
                    CountryName = $"TestUpdateName"
                }), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/countries",countryTestData);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }*/

        [Theory]
        [InlineData(0)]
        public async Task UpdateNotExistentCountry(int id )
        {
            var countryTestData = new StringContent(
                JsonConvert.SerializeObject(new CountryDTO()
                {
                    Id = id,
                    CountryCode = "TestUpdateCode",
                    CountryName = $"TestUpdateName"
                }), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/countries", countryTestData);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

       /* [Theory]
        //Inline data id must exist int he database.
        [InlineData(10)]
        public async Task DeleteExistentCountry(int id)
        {
            var response = await client.DeleteAsync($"/api/countries/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }*/


        [Theory]
        //Inline data id must exist int he database.
        [InlineData(0)]
        public async Task DeleteNotExistentCountry(int id)
        {

            var countryTestData = new StringContent(
                JsonConvert.SerializeObject(new CountryDTO()
                {
                    Id = id
                }), Encoding.UTF8, "application/json");

            var response = await client.DeleteAsync($"/api/countries/{id}");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

    }
}
