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
    public class StatesControllerTest
    {
        private HttpClient client;
        public StatesControllerTest()
        {
            client = new TestClassProvider().Client;
        }

        [Fact]
        public async Task GetAllStates()
        {

            var response = await client.GetAsync("/api/states");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Theory]
        //Inline data must exist in the database
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(19)]
        public async Task GetStateById_ValidId(int id)
        {
            var response = await client.GetAsync($"/api/states/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(999999)]
        [InlineData(-2)]
        public async Task GetStateById_NotValidId(int id)
        {
            var response = await client.GetAsync($"/api/states/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData(1)]
        //state Data with id must exist in the database
        public async Task AddNewstate_ValidStateData(int countryId)
        {
            var randomNumber = new Random().Next(1, 2000);
            var stateTestData = new StringContent(
                JsonConvert.SerializeObject(new StateDTO()
                {
                    CountryId = countryId,
                    Name = $"TestName{randomNumber}",
                    StateCode= $"TestCode{randomNumber}"
                }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/states", stateTestData);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]

        public async Task AddNewstate_InvalidStateData()
        {
            //Non required field-CountryId
            var stateTestData = new StringContent(
                JsonConvert.SerializeObject(new StateDTO()
                {
                    
                    Name = "TestName",
                    StateCode = "TestCode"
                }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/states", stateTestData);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            //Empty body
            var stateTestData2 = new StringContent(
               JsonConvert.SerializeObject(new StateDTO()
               {
               
               }), Encoding.UTF8, "application/json");

            var response2 = await client.PostAsync("/api/states", stateTestData2);
            response2.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        }

         [Theory]
         [InlineData(21,1)]
         ///Test data must exist in the database
         public async Task UpdateExistentState(int stateId,int countryId)
         {
             var stateTestData = new StringContent(
                 JsonConvert.SerializeObject(new StateDTO()
                 {   Id= stateId,
                     CountryId= countryId,
                     StateCode = "TestUpdateCode",
                     Name = $"TestUpdateName"
                 }), Encoding.UTF8, "application/json");
             var response = await client.PutAsync($"/api/states",stateTestData);
             response.StatusCode.Should().Be(HttpStatusCode.OK);
         }

        [Theory]
        [InlineData(0, 1)]
        public async Task UpdateNotExistentState(int stateId, int countryId)
        {
            var stateTestData = new StringContent(
                JsonConvert.SerializeObject(new StateDTO()
                {
                    Id = stateId,
                    CountryId =countryId,
                    StateCode = "TestUpdateCode",
                    Name = "TestUpdateName"
                }), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/states", stateTestData);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

       /*  [Theory]
         //Inline data id must exist int the database.
         [InlineData(22)]
         public async Task DeleteExistentState(int id)
         {
             var response = await client.DeleteAsync($"/api/states/{id}");
             response.StatusCode.Should().Be(HttpStatusCode.OK);
         }*/


        [Theory]
        //Inline data id must exist int he database.
        [InlineData(0)]
        public async Task DeleteNotExistentstate(int id)
        {

            var stateTestData = new StringContent(
                JsonConvert.SerializeObject(new StateDTO()
                {
                    Id = id
                }), Encoding.UTF8, "application/json");

            var response = await client.DeleteAsync($"/api/states/{id}");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


    }
}
