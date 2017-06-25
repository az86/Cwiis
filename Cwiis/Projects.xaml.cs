using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cwiis
{
    /// <summary>
    /// Projects.xaml 的交互逻辑
    /// </summary>
    public partial class Projects : UserControl
    {
        List<Item> Items = new List<Item>();

        public double SumScore { get { return Items.Sum(obj => SumScore); } }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Projects));
        public Projects()
        {
            InitializeComponent();
        }

        public void SetFile(string path)
        {
            var strs = System.IO.File.ReadAllLines(path).ToList();
            for (int i = 0; i < strs.Count() - 1; i++)
            {
                while ((i + 1) < strs.Count() && strs[i + 1][1] != '.')
                {
                    strs[i] += '\n' + strs[i + 1];
                    strs.RemoveAt(i + 1);
                }

            }

            foreach (var str in strs)
            {
                var subStrs = str.Split('\t');
                var i = new Item(subStrs);
                Items.Add(i);
            }


            for (int i = 0; i != Items.Count; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                var gridRow = i+2;

                grid.AddTextblock(Items[i].ProjectNo, gridRow, 0);

                if (!string.IsNullOrEmpty(Items[i].CheckList))
                {
                    var colSpan = 1;
                    while ((i + colSpan) < Items.Count && string.IsNullOrEmpty(Items[i + colSpan].CheckList))
                        colSpan++;
                    grid.AddTextblock(Items[i].CheckList, gridRow, 1, colSpan);
                }
                if (!string.IsNullOrEmpty(Items[i].CheckContent))
                {
                    var colSpan = 1;
                    while ((i + colSpan) < Items.Count && string.IsNullOrEmpty(Items[i + colSpan].CheckContent))
                        colSpan++;
                    grid.AddTextblock(Items[i].CheckContent, gridRow, 2, colSpan);
                }
                grid.AddTextblock(Items[i].JudgmentStandard, gridRow, 3);
                grid.AddTextblock(Items[i].JudgmentCount, gridRow, 4);
                grid.AddTextblock(Items[i].CheckStage1, gridRow, 5);
                grid.AddTextblock(Items[i].CheckStage2, gridRow, 6);
                grid.AddTextblock(Items[i].CheckStage3, gridRow, 7);
                grid.AddTextblock(Items[i].Rule, gridRow, 8);

                grid.AddTextbox(gridRow, 9, Items[i], "BaseScore");
                grid.AddTextbox(gridRow, 10, Items[i], "Weight");
                grid.AddTextbox(gridRow, 11, Items[i], "RealScore");
                grid.AddTextbox(gridRow, 12, Items[i], "Description");

                grid.AddCombobox(Items[i].Grade, gridRow, 13, Items[i], "Grade");

                grid.AddTextblock(gridRow, 14, Items[i], "Score").TargetUpdated += Projects_TargetUpdated;

                grid.AddTextblock(gridRow, 15, Items[i], "FullScore");
            }

            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            var border = new Border();
            border.SetValue(Grid.RowProperty, grid.RowDefinitions.Count - 1);
            border.SetValue(Grid.ColumnSpanProperty, grid.ColumnDefinitions.Count - 2);
            grid.Children.Add(border);

            grid.AddTextblock("600", grid.RowDefinitions.Count - 1, 14);
        }

        private void Projects_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            Console.WriteLine("1234");
        }
    }
}
