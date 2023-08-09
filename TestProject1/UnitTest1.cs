using Microsoft.AspNetCore.Mvc;
using Moq;
using Tourism.Controllers;
using Tourism.Models;
using Tourism.Repository;

namespace TestProject1
{
    public class UnitTest1
    {
       [ Fact]
        public void Test_Record_Available_102()
        {
            //Arrange
            var user = new Agent
            {
                Id = 102,
                Username = "Gayathri",
                Email = "gayathri@gmail.com",
                Password="",
                FullName="",
                Phone = 0,
                IsApproved = true

            };
            var userRepository = new Mock<AgentInterface>();
          
            userRepository.Setup(x => x.GetAgentById(1)).ReturnsAsync(user); 
            //Act
            var getUserById = new AgentController(userRepository.Object);
            //Assert
            var getAgentById = getUserById.GetAgentId(1);
            Assert.NotNull(getAgentById);  //---> 10,test case failed
                                          

        }
    }
}