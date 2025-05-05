namespace BugTracker.Tests
{
    public class BugTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_ThrowsArgumentException_WhenTitleIsInvalid(string? invalidTitle)
        {
            Assert.Throws<ArgumentException>(() => new Bug(invalidTitle!, "Some description"));
        }

        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            var bug = new Bug("Login fails", "Steps to reproduce the issue");

            Assert.Equal("Login fails", bug.Title);
            Assert.Equal("Steps to reproduce the issue", bug.Description);
            Assert.Equal(BugStatus.Open, bug.Status);
        }

        [Fact]
        public void UpdateStatus_ChangesStatusCorrectly()
        {
            var bug = new Bug("Issue", "Details");

            bug.UpdateStatus(BugStatus.InProgress);

            Assert.Equal(BugStatus.InProgress, bug.Status);
        }

        [Fact]
        public void UpdateStatus_DoesNotChangeToSameStatus()
        {
            var bug = new Bug("Issue", "Details");

            bug.UpdateStatus(BugStatus.Open);

            Assert.Equal(BugStatus.Open, bug.Status);
        }

        [Fact]
        public void AssignedToDeveloper_DefaultsToNull()
        {
            var bug = new Bug("Issue", "Details");

            Assert.Null(bug.AssignedToDeveloper);
        }

        [Fact]
        public void AssignedToDeveloper_CanBeAssignedAndRetrieved()
        {
            var bug = new Bug("Issue", "Details");
            var developer = "John Doe";

            bug.AssignedToDeveloper = developer;

            Assert.Equal(developer, bug.AssignedToDeveloper);
        }
    }

    public enum BugStatus
    {
        Open,
        InProgress,
        Resolved,
        Closed
    }

    public class Bug
    {
        public string Title { get; }
        public string Description { get; }
        public BugStatus Status { get; private set; }
        public string? AssignedToDeveloper { get; set; }

        public Bug(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null or whitespace.", nameof(title));

            Title = title;
            Description = description;
            Status = BugStatus.Open; // Default status
        }

        public void UpdateStatus(BugStatus newStatus)
        {
            if (Status != newStatus)
            {
                Status = newStatus;
            }
        }
    }
    public class UnitTest1
    {
        [Fact]
        public void Bug_Constructor_ShouldInitializeProperties()
        {
            var bug = new Bug("Sample Bug", "This is a sample bug.");

            Assert.Equal("Sample Bug", bug.Title);
            Assert.Equal("This is a sample bug.", bug.Description);
            Assert.Equal(BugStatus.Open, bug.Status);
        }

        [Fact]
        public void UpdateBugStatus_ShouldUpdateStatus()
        {
            var bug = new Bug("Initial Bug", "Initial description.");

            bug.UpdateStatus(BugStatus.Resolved);

            Assert.Equal(BugStatus.Resolved, bug.Status);
        }
    }
}
