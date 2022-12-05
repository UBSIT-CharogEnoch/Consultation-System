using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultation_System
{
    public partial class adminReportAccounts : Form
    {
        public adminReportAccounts()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""O:\School\Consultation System\Consultation System\consys.mdf"";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELCECT * FROM Accounts", con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            da.Fill(dt);

            ReportDataSource rds = new ReportDataSource("AccountsDataSet", dt);
            reportViewer1.LocalReport.ReportPath = @"O:\\School\\Consultation System\\Consultation System\\AccountsReport.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void adminReportAccounts_Load(object sender, EventArgs e)
        {

        }
    }
}
