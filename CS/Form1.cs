using Syncfusion.WinForms.Core.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusyIndicatorHelperSample
{
    public partial class Form1 : Form
    {
        BusyIndicator busyIndicator = new BusyIndicator();
        ObservableCollection<int> sampleData = new ObservableCollection<int>();
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += DoWork;
            backgroundWorker.RunWorkerCompleted += RunWorkerCompleted;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            this.sfButton1.Invoke(new Action(() => this.sfButton1.Text = string.Empty));
            busyIndicator.Show(this.sfButton1);
            for (int i = 0; i <= 10000000; i++)
            {
                sampleData.Add(i);
            }
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.sfButton1.Text = "Get items";
            if (!backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();
            busyIndicator.Hide();
            sampleData.Clear();
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        } 
    }   
}
