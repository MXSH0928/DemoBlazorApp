namespace DemoBlazorApp.Models
{
    using DemoBlazorApp.Library;

    /// <summary>
    /// The base mode.
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Order(1)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Order(2)]
        public string Name { get; set; }
    }
}
