namespace DemoBlazorApp
{
    using System;

    /// <summary>
    /// The state container.
    /// </summary>
    public class StateContainer
    {
        /// <summary>
        /// The on change.
        /// </summary>
        public event Action OnChange;

        /// <summary>
        /// Gets or sets the property.
        /// </summary>
        public string Property { get; set; } = "Initial value from StateContainer";

        /// <summary>
        /// The set property.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void SetProperty(string value)
        {
            this.Property = value;
            this.NotifyStateChanged();
        }

        /// <summary>
        /// The notify state changed.
        /// </summary>
        private void NotifyStateChanged()
        {
            this.OnChange?.Invoke();
        }
    }
}