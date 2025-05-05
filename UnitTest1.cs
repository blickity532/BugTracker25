namespace TestProject1
{
    public class UnitTest1 // Defines a test class for unit tests.
    {
        [Fact] // Marks this method as a test case using the xUnit framework.
        public void Bug_Constructor_ShouldInitializeProperties() // Test method to verify the Bug constructor initializes properties correctly.
        {
            // Arrange
            int expectedId = 1; // Expected ID for the Bug object.
            string expectedTitle = "Sample Bug"; // Expected Title for the Bug object.
            string expectedDescription = "This is a sample bug."; // Expected Description for the Bug object.

            // Act
            var bug = new Bug // Creates a new Bug object and initializes its properties.
            {
                Id = expectedId, // Assigns the expected ID to the Bug object.
                Title = expectedTitle, // Assigns the expected Title to the Bug object.
                Description = expectedDescription // Assigns the expected Description to the Bug object.
            };

            // Assert
            Assert.Equal(expectedId, bug.Id); // Verifies that the Bug object's ID matches the expected value.
            Assert.Equal(expectedTitle, bug.Title); // Verifies that the Bug object's Title matches the expected value.
            Assert.Equal(expectedDescription, bug.Description); // Verifies that the Bug object's Description matches the expected value.
            Assert.Null(bug.Status); // Ensures that the Status property is null by default.
        }

        [Fact] // Marks this method as a test case using the xUnit framework.
        public void UpdateBugStatus_ShouldUpdateStatus() // Test method to verify the UpdateBugStatus method updates the Status property.
        {
            // Arrange
            var initialBug = new Bug // Creates an initial Bug object with specific properties.
            {
                Id = 1, // Sets the ID of the initial Bug object.
                Title = "Initial Bug", // Sets the Title of the initial Bug object.
                Description = "Initial description." // Sets the Description of the initial Bug object.
            };

            var newStatus = new Bug // Creates a new Bug object to represent the updated status.
            {
                Id = 2, // Sets the ID of the new status Bug object.
                Title = "Resolved", // Sets the Title of the new status Bug object.
                Description = "Bug has been resolved." // Sets the Description of the new status Bug object.
            };

            // Act
            initialBug.UpdateBugStatus(newStatus); // Updates the status of the initial Bug object.

            // Assert
            Assert.Equal(newStatus, initialBug.Status); // Verifies that the Status property of the initial Bug object is updated correctly.
        }

        [Fact] // Marks this method as a test case using the xUnit framework.
        public void UpdateBugStatus_ShouldThrowArgumentNullException_WhenNewStatusIsNull() // Test method to verify UpdateBugStatus throws an exception when null is passed.
        {
            // Arrange
            var bug = new Bug // Creates a Bug object with specific properties.
            {
                Id = 1, // Sets the ID of the Bug object.
                Title = "Sample Bug", // Sets the Title of the Bug object.
                Description = "Sample description." // Sets the Description of the Bug object.
            };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => bug.UpdateBugStatus(null)); // Ensures that an ArgumentNullException is thrown when a null status is passed.
        }
    }
}
