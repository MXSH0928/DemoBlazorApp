namespace DemoBlazorApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using DemoBlazorApp.Library;

    /// <summary>
    /// The base mode.
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        [Order(1)]
        [HtmlInput(key: "disabled", value: "disabled")]
        [HtmlInput(key: "type", value: "number")]
        public int Id { get; set; } = 0;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Order(2)]
        public string Name { get; set; } = "Not available";

        public virtual void UpdateModel(Action action)
        {
            if (action != null)
            {
                action.Invoke();
            }
            
        }
    }
}
