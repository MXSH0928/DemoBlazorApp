namespace DemoBlazorApp.Components.tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    using System.Data;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    using DemoBlazorApp.Models;

    using Microsoft.AspNetCore.Components;

    /// <summary>
    ///     The table.
    /// </summary>
    public partial class TableComponent
    {
        /// <summary>
        /// The my table.
        /// </summary>
        private DynamicTable table = null;

        /// <summary>
        ///     The selected table.
        /// </summary>
        private TableType selectedTableType;

        /// <summary>
        ///     Gets or sets the selected table.
        /// </summary>
        [Parameter]
        public TableType SelectedTableType
        {
            get => this.selectedTableType;

            set
            {
                this.selectedTableType = value;
                this.DisplayTable();
            }
        }

        /// <summary>
        /// The get prop value.
        /// </summary>
        /// <param name="src">
        /// The source.
        /// </param>
        /// <param name="propName">
        /// The prop name.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName)?.GetValue(src, null);
        }

        /// <summary>
        /// The display table.
        /// </summary>
        private void DisplayTable()
        {
            if (this.selectedTableType is null)
            {
                return;
            }

            Console.WriteLine("Display Table: " + this.selectedTableType);

            switch (this.selectedTableType.Name)
            {
                case nameof(TableOneModel):

                    var modelOneList = new List<TableOneModel>
                                           {
                                               new TableOneModel { Id = 1, Name = "John", Email = "test1@email.com" },
                                               new TableOneModel { Id = 2, Name = "Doe", Email = "test2@email.com" }
                                           };

                    this.table = this.GetDynamicTable(modelOneList);

                    break;
                case nameof(TableTwoModel):

                    var modelTwoList = new List<TableTwoModel>
                                           {
                                               new TableTwoModel
                                                   {
                                                       Id = 1, Name = "Mohammed", Phone = "2140000000", Note = "Nothing"
                                                   },
                                               new TableTwoModel
                                                   {
                                                       Id = 1,
                                                       Name = "Test User",
                                                       Phone = "9720000000",
                                                       Note = "Some note"
                                                   }
                                           };

                    this.table = this.GetDynamicTable(modelTwoList);

                    break;
            }
        }

        /// <summary>
        /// The get my table.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <typeparam name="T">
        /// The list item type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="DynamicTable"/>.
        /// </returns>
        private DynamicTable GetDynamicTable<T>(List<T> items)
        {
            var myTable = new DynamicTable();

            var props = typeof(T).GetProperties().ToList();

            for (var i = 0; i < props.Count; i++)
            {
                myTable.Columns.Add(new TableColumn { Index = i, Name = props[i].Name });
            }

            for (var i = 0; i < items.Count; i++)
            {
                var item = items[i];
                var row = new TableRow { Index = i };

                for (var j = 0; j < props.Count; j++)
                {
                    var prop = props[j];
                    var cell = new TableCell
                    {
                        Index = j,
                        ColumnName = prop.Name,
                        Value = GetPropValue(item, prop.Name).ToString(),
                        ValueType = prop.PropertyType
                    };

                    row.Cells.Add(cell);
                }

                myTable.Rows.Add(row);
            }

            return myTable;
        }

        /// <summary>
        /// The on row change.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        private void OnRowChange(TableRow row)
        {
            
            var obj = this.table.Rows.FirstOrDefault(r => r.Index == row.Index);

            if (obj != null && this.selectedTableType != null)
            {
                if (this.selectedTableType.Name == nameof(TableOneModel))
                {
                    var updatedObject = this.ConvertTableRowToType<TableOneModel>(row);
                    var index = this.table.Rows.IndexOf(row);

                    if (index != -1)
                    {
                        this.table.Rows[index] = updatedObject.ToTableRow(); // ToDo: Create this ext method.
                    }
                }
            }
        }

        private T ConvertTableRowToType<T>(TableRow row)
        {
            var type = typeof(T);
            var obj = Activator.CreateInstance(type);
            var properties = type.GetProperties();

            foreach (var propertyInfo in properties)
            {
                var cell = row.Cells.FirstOrDefault(c => c.ColumnName == propertyInfo.Name);
                
                if(cell != null)
                {
                    var newValue = Convert.ChangeType(cell.Value, propertyInfo.PropertyType);
                    propertyInfo.SetValue(obj, newValue, null);
                }
            }

            return (T)obj;
        }

        /// <summary>
        /// The my table.
        /// </summary>
        private class DynamicTable
        {
            /// <summary>
            /// Gets or sets the columns.
            /// </summary>
            public List<TableColumn> Columns { get; set; } = new List<TableColumn>();

            /// <summary>
            /// Gets or sets the rows.
            /// </summary>
            public List<TableRow> Rows { get; set; } = new List<TableRow>();
        }

        /// <summary>
        ///     The table cell.
        /// </summary>
        private class TableCell
        {
            /// <summary>
            /// The value type.
            /// </summary>
            private Type valueType;

            /// <summary>
            /// Gets or sets the header.
            /// </summary>
            public string ColumnName { get; set; }

            /// <summary>
            /// Gets or sets the index.
            /// </summary>
            public int Index { get; set; }

            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            public string Value { get; set; }

            /// <summary>
            /// Gets or sets the value type.
            /// </summary>
            public Type ValueType
            {
                get => this.valueType;
                set
                {
                    if (value != null)
                    {
                        this.valueType = value;
                        this.HtmlInputType = this.GetHtmlInputType(value);
                    }
                }
            }

            /// <summary>
            /// Gets or sets the html input type.
            /// </summary>
            public string HtmlInputType { get; set; } = "text";

            /// <summary>
            /// The get html input type.
            /// </summary>
            /// <param name="type">
            /// The type.
            /// </param>
            /// <returns>
            /// The <see cref="string"/>.
            /// </returns>
            public string GetHtmlInputType(Type type)
            {
                string result;

                switch (type.Name.ToLower())
                {
                    case "string":
                        result = "text";
                        break;
                    case "int32":
                    case "int64":
                    case "decimal":
                    case "double":
                        result = "number";
                        break;
                    default:
                        result = "text";
                        break;
                }

                return result;
            }
        }

        /// <summary>
        ///     The table column.
        /// </summary>
        private class TableColumn
        {
            /// <summary>
            ///     Gets or sets the index.
            /// </summary>
            public int Index { get; set; }

            /// <summary>
            ///     Gets or sets the name.
            /// </summary>
            public string Name { get; set; }
        }

        /// <summary>
        /// The table row.
        /// </summary>
        private class TableRow
        {
            /// <summary>
            /// Gets or sets the cells.
            /// </summary>
            public List<TableCell> Cells { get; set; } = new List<TableCell>();

            /// <summary>
            /// Gets or sets the index.
            /// </summary>
            public int Index { get; set; }
        }
    }
}