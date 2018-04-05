using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCS2.Models;

namespace CCS2.Tests.Models
{
    [TestClass]
    public class ProgressReportTestss
    {
        [TestMethod]
        public void CreateNewProgressReport()
        {
            // Arrange
            ProgressReport progRep = new ProgressReport();

            // Act
            progRep.Name = "First Update";
            progRep.Notes = "Testing the progress report object";
            progRep.RequestId = 1;

            // Assert
        }
    }
}
