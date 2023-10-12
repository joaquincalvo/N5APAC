namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;

[TestClass]
public class StudentControllerTest
{
    private StudentController _controller;
    private Mock<IStudentLogic> mock;

    [TestInitialize]
    public void setup()
    {
        mock = new Mock<IStudentLogic>();
        _controller = new StudentController(mock.Object);
    }

    [TestMethod]
    public void PostStudentOkTest()
    {
        var student = new Student();
        student.Id = 1;
        student.Name = "Test";

        var result = _controller.RegisterStudentOK(student);

        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }
}
