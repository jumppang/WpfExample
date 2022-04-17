using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using WpfExample.Model;

namespace WpfExample
{
    /// <summary>
    /// RadGridViewExample1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RadGridViewExample1 : Window
    {
        private List<SampleModel> _lstSampleModel;
        private int _count = 0;

        public RadGridViewExample1()
        {
            InitializeComponent();
        }

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            this._lstSampleModel = new List<SampleModel>();

            for (int i = 0; i < 50; i++)
            {
                _lstSampleModel.Add(new SampleModel { aa = "aa" + i, bb = "bb" + i, cc = "cc" + i, dd = "dd" + i });
            }

            this.grdSample.ItemsSource = this._lstSampleModel;
        }

        private void grdSample_RowLoaded(object sender, Telerik.Windows.Controls.GridView.RowLoadedEventArgs e)
        {
            if (e.Row is GridViewNewRow) return;

            var item = e.Row.Item as SampleModel;

            if (item == null) return;

            if ((e.Row.Item as SampleModel).aa == "aa15")
            {
                e.Row.Style = this.Resources["rowStyle"] as Style;

            }

            Debug.WriteLine("RowLoaded " + this._count.ToString());

            this.grdSample.SelectedItem = _lstSampleModel[1];
            this._count++;
        }


        private void GridStyleInit()
        {
            foreach (var row in grdSample.ChildrenOfType<GridViewRow>())
            {
                if (row is GridViewNewRow) continue;

                string aa = (row.Item as SampleModel).aa;

                if (aa == "aa5")
                {
                    row.Style = this.Resources["rowStyle"] as Style;
                }
            }
        }


        L1
        L2
        L3
        //void radGridView1_ValueChanged(object sender, EventArgs e)
        //{

        //    RadCheckBoxEditor editor = sender as RadCheckBoxEditor;

        //    if (editor != null && (bool)editor.Value == true)

        //    {

        //        this.radGridView1.GridElement.BeginUpdate();

        //        foreach (GridViewDataRowInfo row in this.radGridView1.Rows)

        //        {

        //            if (row != this.radGridView1.CurrentRow)

        //            {

        //                row.Cells["Bool"].Value = false;

        //            }

        //        }

        //        this.radGridView1.GridElement.EndUpdate();

        //    }
        //}

        private void grdSample_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            this.grdSample.SelectedItem = _lstSampleModel[1];
        }
        //private IEnumerable<SampleModel> GetDataGridRows(RadGridView radGridView)
        //{
        //    SampleModel row = null;
        //    var itemSource = radGridView.ItemsSource as IEnumerable;
        //    if (itemSource == null) yield return null;

        //    foreach (var item in itemSource)
        //    {
        //        row = radGridView.ItemContainerGenerator.ContainerFromItem(item) as SampleModel;
        //        if (row != null) yield return row;
        //    }
        //}
    }
}
