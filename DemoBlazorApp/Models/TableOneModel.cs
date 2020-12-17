namespace DemoBlazorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DemoBlazorApp.Library;

    /// <summary>
    /// The table one.
    /// </summary>
    public class TableOneModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the column one.
        /// </summary>
        [Order(3)]
        public string Email { get; set; }
    }
}
