namespace DemoBlazorApp.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DemoBlazorApp.Models;

    using Microsoft.AspNetCore.Components;

    public partial class Table
    {
        /// <summary>
        /// The tables.
        /// </summary>
        private readonly List<TableType> tables = new List<TableType>();

        /// <summary>
        /// The selected table.
        /// </summary>
        public TableType SelectedTable { get; set; } = new TableType();

        /// <summary>
        /// The on initialized async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            this.tables.Add(new TableType() { Id = 1, Name = nameof(TableOneModel), Description = "Table One" });
            this.tables.Add(new TableType() { Id = 2, Name = nameof(TableTwoModel), Description = "Table Two" });
        }

        /// <summary>
        /// The on table selection.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        private void OnTableSelection(ChangeEventArgs obj)
        {
            var id = obj.Value is null ? 0 : Convert.ToInt32(obj.Value);
            this.SelectedTable = this.tables.FirstOrDefault(t => t.Id == id);

            // ToDo: Throw exception
            if (this.SelectedTable != null && this.SelectedTable.Id == 0)
            {
                Console.WriteLine($"Unable to set {nameof(this.SelectedTable)} value.");
            }
        }
    }
}
