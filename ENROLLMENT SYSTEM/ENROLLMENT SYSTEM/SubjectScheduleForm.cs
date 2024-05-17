using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENROLLMENT_SYSTEM
{
    public partial class SubjectScheduleForm : Form
    {
        //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\arjay\Documents\Github\finalsappdevsheesh\PAMAYBAY.accdb";
       string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\harle\Desktop\finalsappdevsheesh-main\PAMAYBAY.accdb";
        //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\Server2\second semester 2023-2024\LAB802\79286_CC_APPSDEV22_1030_1230_PM_MW\79286-23222490\Desktop\FINAL\PAMAYBAY.accdb";
        public SubjectScheduleForm()
        {
            InitializeComponent();
            CenterToScreen();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string Ole = "Select * From SUBJECTSCHEDULEFILE";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(Ole, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);
            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "SubjectScheduleFile");

            DataRow thisRow = thisDataSet.Tables["SubjectScheduleFile"].NewRow();
            thisRow["SSFEDPCODE"] = EDPCodeTextBox.Text;
            thisRow["SSFSUBJCODE"] = SubjectCodeTextBox.Text;
            thisRow["SSFSTARTTIME"] = StartTimeDateTimePicker.Text;
            thisRow["SSFENDTIME"] = ExitTimeDateTimePicker.Text;
            thisRow["SSFDAYS"] = DaysTextBox.Text;
            thisRow["SSFROOM"] = RoomTextBox.Text;
            thisRow["SSFXM"] = AMPMComboBox.Text;
            thisRow["SSFSCHOOLYEAR"] = SchoolYearTextBox.Text;
            thisRow["SSFSECTION"] = SectionTextBox.Text;
            thisRow["SSFMAXSIZE"] = 5;
            thisRow["SSFCLASSSIZE"] = 0;

            thisDataSet.Tables["SubjectScheduleFile"].Rows.Add(thisRow);
            thisAdapter.Update(thisDataSet, "SubjectScheduleFile");

            MessageBox.Show("Recorded");
        }

        private void SubjectCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();
                string sql = "SELECT * FROM SUBJECTFILE";
                thisCommand.CommandText = sql;

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();

                bool found = false;

                while (thisDataReader.Read())
                {
                    //MessageBox.Show(thisDataReader["SFSSUBJCODE"].ToString());
                    if (thisDataReader["SFSSUBJCODE"].ToString().Trim().ToUpper() == SubjectCodeTextBox.Text.Trim().ToUpper())
                    {
                        found = true;
                        DescriptionLabel.Text = thisDataReader["SFSSUBJDESC"].ToString();
                        break;
                    }

                }
                if (found == false)
                    MessageBox.Show("Subject Code Not Found");

            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            EDPCodeTextBox.Text = "";
            SubjectCodeTextBox.Text = "";
            DescriptionLabel.Text = "";
            StartTimeDateTimePicker.Enabled = false;
            ExitTimeDateTimePicker.Enabled = false;
            AMPMComboBox.Enabled = false;
            DaysTextBox.Text = "";
            SectionTextBox.Text = "";
            RoomTextBox.Text = "";
            SchoolYearTextBox.Text = "";
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Menu mainMenu = new Menu();
            mainMenu.Show();
            this.Hide();
        }

        
    }
}
