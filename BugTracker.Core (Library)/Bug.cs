namespace BugTracker.Core
{

    public class Bug
    {
        public int Id
        {
            get;
        } // TODO: Rename to BugId for clarity
          // The `Id` property is defined as read-only. A TODO comment suggests renaming it to `BugId` for better clarity.

        public string Title
        {
            get;
        }
        // The `Title` property is defined as read-only. It stores the title of the bug.

        public string Description
        {
            get; set;
        }
        // The `Description` property is defined with both getter and setter accessors, allowing it to be modified.

        public BugStatus Status
        {
            get; private set;
        }
        public string? AssignedToDeveloper
        {
            get; set;
        }
        // The `Status` property is of type `BugStatus` and has a private setter, ensuring it can only be updated internally.

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
            Status = BugStatus.Open ?? throw new InvalidOperationException("BugStatus.Open must not be null.");
            // Initializes the `Status` property to `BugStatus.Open`. Throws an exception if `BugStatus.Open` is null.
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

        // TODO: Add a new property: AssignedToDeveloper with get and set accessors
        // A TODO comment suggests adding a new property `AssignedToDeveloper` to track the developer assigned to the bug.
    }
}