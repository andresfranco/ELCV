using ELCV.UI.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ELCV.Integration.Test
{
    public class CitiesControllerTest
    {
        private HttpClient client;
        public CitiesControllerTest()
        {
            client = new TestClassProvider().Client;
        }
        [Fact]
        public async Task GetAllCities()
        {
            var response = await client.GetAsync("/api/cities");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        //Inline data must exist in the database
        [InlineData(1)]
       
        public async Task GetCityById_ValidId(int id)
        {
            var response = await client.GetAsync($"/api/cities/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(999999)]
        [InlineData(-2)]
        public async Task GetCityById_NotValidId(int id)
        {
            var response = await client.GetAsync($"/api/cities/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData(1,10)]
        //state Data with id must exist in the database
        public async Task AddNewCity_ValidData(int countryId,int stateId)
        {
            var randomNumber = new Random().Next(1, 2000);
            var cityTestData = new StringContent(
                JsonConvert.SerializeObject(new CityDTO()
                {
                    CountryId = countryId,
                    StateId = stateId,
                    Name = $"TestName{randomNumber}",
                    CityCode = $"TestCode{randomNumber}"
                }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/cities", cityTestData);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(1)]

        public async Task AddNewCity_InvalidData( int stateId)
        {
            //Non required field-CountryId
            var cityTestData = new StringContent(
                JsonConvert.SerializeObject(new CityDTO()
                {
                    StateId = stateId,
                    Name = "TestName",
                    CityCode = "TestCode"
                }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/cities", cityTestData);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            //Empty body
            var cityTestData2 = new StringContent(
               JsonConvert.SerializeObject(new StateDTO()
               {

               }), Encoding.UTF8, "application/json");

            var response2 = await client.PostAsync("/api/states", cityTestData2);
            response2.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        }
       /*
        [Theory]
        [InlineData(1,10,1)]
        ///Test data must exist in the database
        public async Task UpdateExistentCity( int countryId, int stateId,int cityId)
        {
            var cityTestData = new StringContent(
                JsonConvert.SerializeObject(new CityDTO()
                {
                    Id =cityId, 
                    StateId=stateId,
                    CountryId = countryId,
                    CityCode = "TestUpdateCode",
                    Name = $"TestUpdateName"
                }), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/cities", cityTestData);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }*/

        [Theory]
        //Existent Country and State but not City
        [InlineData(1, 10,0)]
        public async Task UpdateNotExistentCity(int countryId, int stateId, int cityId)
        {
            var cityTestData = new StringContent(
                JsonConvert.SerializeObject(new CityDTO()
                {
                    Id = cityId,
                    StateId = stateId,
                    CountryId = countryId,
                    CityCode = "TestUpdateCode",
                    Name = "TestUpdateName"
                }), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/cities", cityTestData);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        /* [Theory]
          //Inline data id must exist int the database.
          [InlineData(6)]
          public async Task DeleteExistentCity(int id)
          {
              var response = await client.DeleteAsync($"/api/cities/{id}");
              response.StatusCode.Should().Be(HttpStatusCode.OK);
          }
          */

        [Theory]
        //Inline data id must exist int he database.
        [InlineData(0)]
        public async Task DeleteNotExistentCity(int id)
        {

            var response = await client.DeleteAsync($"/api/cities/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
