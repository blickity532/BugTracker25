namespace BugTracker.Core
{

    public class Bug
    {
        public int Id { get; } // TODO: Rename to BugId for clarity

        public string Title { get; }
        // The `Title` property is defined as read-only. It stores the title of the bug.

        public string Description { get; set; }
        // The `Description` property is defined with both getter and setter accessors, allowing it to be modified.

        public BugStatus Status { get; private set; }
        // The `Status` property is of type `BugStatus` and has a private setter, ensuring it can only be updated internally.

        public string? AssignedToDeveloper { get; set; }

        public Bug(string title, string description)
        {
            // Validate that title is not null, empty, or whitespace
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null, empty, or whitespace.", nameof(title));
            }
            // Added validation to ensure the `title` parameter is not null, empty, or whitespace.

            Title = title;
            Description = description;
            Status = BugStatus.Open;
            // Initializes the `Status` property to `BugStatus.Open`.
        }

        public void UpdateStatus(BugStatus newStatus)
        {
            // Only update if newStatus is different from current Status
            if (Status != newStatus)
            {
                Status = newStatus;
            }
            // Added logic to update the `Status` property only if the new status is different from the current status.
        }
    }
}
