using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Cwiis
{
    static class GridExtentions
    {
        public static TextBlock AddTextblock(this Grid grid, string text, int row, int col, int rowSpan = 1)
        {
            var tb = new Border();
            tb.Child = new TextBlock { Text = text };
            tb.SetValue(Grid.RowProperty, row);
            tb.SetValue(Grid.ColumnProperty, col);
            if (rowSpan > 1)
                tb.SetValue(Grid.RowSpanProperty, rowSpan);
            grid.Children.Add(tb);
            return tb.Child as TextBlock;
        }

        public static TextBlock AddTextblock(this Grid grid, int row, int col, object bindingSource, string bindingPath, int rowSpan = 1)
        {
            var ch = new TextBlock();
            var binding = new Binding(bindingPath);
            binding.Source = bindingSource;
            binding.Mode = BindingMode.TwoWay;
            ch.SetBinding(TextBlock.TextProperty, binding);
            var tb = new Border();
            tb.Child = ch;
            tb.SetValue(Grid.RowProperty, row);
            tb.SetValue(Grid.ColumnProperty, col);
            if (rowSpan > 1)
                tb.SetValue(Grid.RowSpanProperty, rowSpan);
            grid.Children.Add(tb);
            return ch;
        }

        public static void AddTextbox(this Grid grid, int row, int col, object source, string path)
        {
            var tb = new Border();
            var ch = new TextBox();
            var binding = new Binding(path);
            binding.Source = source;
            binding.Mode = BindingMode.TwoWay;
            ch.SetBinding(TextBox.TextProperty, binding);
            tb.Child =ch;
            tb.SetValue(Grid.RowProperty, row);
            tb.SetValue(Grid.ColumnProperty, col);
            grid.Children.Add(tb);
        }


        public static void AddCombobox(this Grid grid, string selected, int row, int col, object source, string path)
        {

            var comboBox = new ComboBox();
            comboBox.Items.Add("A");
            comboBox.Items.Add("B");
            comboBox.Items.Add("C");
            comboBox.Items.Add("D");
            comboBox.Items.Add("NA");
            comboBox.Items.Add("缺失");
            comboBox.SetValue(Grid.RowProperty, row);
            comboBox.SetValue(Grid.ColumnProperty, col);
            var binding = new Binding(path);
            binding.Source = source;
            binding.Mode = BindingMode.TwoWay;
            comboBox.SetBinding(ComboBox.SelectedItemProperty, binding);
            grid.Children.Add(comboBox);
        }
    }
}
