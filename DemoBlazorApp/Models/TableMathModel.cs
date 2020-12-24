namespace DemoBlazorApp.Models
{
    using DemoBlazorApp.Library;

    /// <summary>
    /// The table math model.
    /// </summary>
    public class TableMathModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the number 1.
        /// </summary>
        [Order]
        [HtmlInput(key: "type", value: "number")]
        [HtmlInput(key: "min", value: "0")]
        [HtmlInput(key: "step", value: "10")]
        [HtmlInput(key: "max", value: "100")]
        public int Number1 { get; set; }

        /// <summary>
        /// Gets or sets the number 2.
        /// </summary>
        [Order]
        [HtmlInput(key: "type", value: "number")]
        public int Number2 { get; set; }

        /// <summary>
        /// Gets or sets the number 3.
        /// </summary>
        [Order]
        [HtmlInput(key: "type", value: "number")]
        public int Number3 { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        [Order]
        [HtmlInput(key: "type", value: "number")]
        public int Total { get; set; }

        /// <summary>
        /// The get total.
        /// </summary>
        public void GetTotal()
        {
            this.Total = this.Number1 + this.Number2 + this.Number3;
        }
    }
}