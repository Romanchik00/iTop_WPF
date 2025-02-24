using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Calculator_Page.xaml
    /// </summary>
    public partial class Calculator_Page : Page
    {
        public Calculator_Page()
        {
            InitializeComponent();
        }

        private void NumbButton_Click(object sender, RoutedEventArgs e)
        {
            TextFunc.Text += ((TextBlock)((Viewbox)((Button)sender).Content).Child).Text;
        }

        private void ZeroButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextFunc.Text)) { return; }
            if (TextFunc.Text.Last() == '.' || int.TryParse(TextFunc.Text.Last().ToString(), out _))
                TextFunc.Text += '0';
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextFunc.Text)) { return; }
            if (int.TryParse(TextFunc.Text.Last().ToString(), out _))
                TextFunc.Text += '.';
        }

        private void SigilButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextFunc.Text)) { return; }
            if (int.TryParse(TextFunc.Text.Last().ToString(), out _))
                TextFunc.Text += ((TextBlock)((Viewbox)((Button)sender).Content).Child).Text;
        }

        private void GetResultButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), TextFunc.Text);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            TextResult.Text = (double.Parse((string)row["expression"])).ToString();
            TextFunc.Text = "";
        }

        private void ClearEntryButton_Click(object sender, RoutedEventArgs e)
        {
            int lastOperator = TextFunc.Text.LastIndexOfAny(new char[] { '+','-','*','/'});
            if (lastOperator == -1) 
            {
                TextFunc.Text = "";
                return;
            }
            TextFunc.Text = TextFunc.Text.Substring(0, lastOperator + 1);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TextFunc.Text = "";
            TextResult.Text = "";
        }

        private void BeckSpaceButton_Click(object sender, RoutedEventArgs e)
        {
            TextFunc.Text = TextFunc.Text.Substring(0, TextFunc.Text.Length - 1);
        }
    }
}
