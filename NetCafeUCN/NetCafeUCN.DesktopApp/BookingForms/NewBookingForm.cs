using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCafeUCN.DesktopApp.BookingForms
{
    public partial class NewBookingForm : Form
    {
        public NewBookingForm()
        {
            InitializeComponent();
            InitializeTimes();
        }

        private void InitializeTimes()
        {
            cmbStartTime.DataSource = DateTimeUI.GetStartTimes();
            cmbEndTime.DataSource = DateTimeUI.GetEndTimes();
        }

        private void cmbStartTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEndTime.SelectedIndex <= cmbStartTime.SelectedIndex)
            {
                cmbEndTime.SelectedIndex = cmbStartTime.SelectedIndex + 1;
            }
        }

        private void cmbEndTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEndTime.SelectedIndex <= cmbStartTime.SelectedIndex)
            {
                cmbEndTime.SelectedIndex = cmbStartTime.SelectedIndex + 1;
            }
        }
    }
}
