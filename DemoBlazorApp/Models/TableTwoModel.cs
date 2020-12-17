namespace DemoBlazorApp.Models
{
    using DemoBlazorApp.Library;

    /// <summary>
    /// The table two model.
    /// </summary>
    public class TableTwoModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the column two.
        /// </summary>
        [Order]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        [Order]
        public string Note { get; set; }
    }
}
