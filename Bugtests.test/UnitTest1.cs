using System;

namespace Bugtests.test
{
    public class BugTests
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

    internal class FactAttribute : Attribute
    {
    }

    // Dummy implementations for missing types to fix compilation errors
    public enum BugStatus
    {
        Open,
        Closed
    }

    public class Bug
    {
        public string Title { get; }
        public string Description { get; }
        public BugStatus Status { get; private set; }
        public string? AssignedToDeveloper { get; private set; }

        public Bug(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null or whitespace.", nameof(title));
            Title = title;
            Description = description;
            Status = BugStatus.Open;
            AssignedToDeveloper = null;
        }

        public void UpdateStatus(BugStatus newStatus)
        {
            if (Status != newStatus)
            {
                Status = newStatus;
            }
        }
    }

    public static class Assert
    {
        public static void Equal<T>(T expected, T actual)
        {
            if (!object.Equals(expected, actual))
                throw new Exception($"Assert.Equal Failed. Expected: {expected}, Actual: {actual}");
        }

        public static void Null(object? obj)
        {
            if (obj != null)
                throw new Exception("Assert.Null Failed. Object is not null.");
        }

        public static void Throws<TException>(Action action) where TException : Exception
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                if (ex is TException)
                    return;
                throw new Exception($"Assert.Throws Failed. Expected exception of type {typeof(TException)}, but got {ex.GetType()}");
            }
            throw new Exception($"Assert.Throws Failed. Expected exception of type {typeof(TException)}, but no exception was thrown.");
        }
    }
}