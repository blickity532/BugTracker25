using BugTracker.Core;

namespace BugTracker.Tests
{
    public class BugTrackerTests
    {
        [Fact]
        public void Constructor_ValidArguments_InitializesProperties()
        {
            // Arrange
            var title = "Sample Bug";
            var description = "Bug description";

            // Act
            var bug = new Bug(title, description);

            // Assert
            Assert.Equal(title, bug.Title);
            Assert.Equal(description, bug.Description);
            Assert.Equal(BugStatus.Open, bug.Status);
            Assert.Null(bug.AssignedToDeveloper);
        }

        [Fact]
        public void Constructor_InvalidTitle_ThrowsArgumentException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Bug(null!, "desc"));
            Assert.Throws<ArgumentException>(() => new Bug("", "desc"));
            Assert.Throws<ArgumentException>(() => new Bug("   ", "desc"));
        }

        [Fact]
        public void UpdateStatus_ChangesStatus()
        {
            // Arrange
            var bug = new Bug("Bug", "desc");

            // Act
            bug.UpdateStatus(BugStatus.Closed);

            // Assert
            Assert.Equal(BugStatus.Closed, bug.Status);
        }

        [Fact]
        public void UpdateStatus_SameStatus_DoesNotChange()
        {
            // Arrange
            var bug = new Bug("Bug", "desc");
            var initialStatus = bug.Status;

            // Act
            bug.UpdateStatus(initialStatus);

            // Assert
            Assert.Equal(initialStatus, bug.Status);
        }
    }
}
