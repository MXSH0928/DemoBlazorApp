namespace DemoBlazorApp.Models
{
    /// <summary>
    /// The base mode.
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}
