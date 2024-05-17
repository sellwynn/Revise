using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENROLLMENT_SYSTEM
{
    public partial class EnrollmentEntry : Form
    {
        
        //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = \\Server2\second semester 2023-2024\LAB802\79286_CC_APPSDEV22_1030_1230_PM_MW\79286-23222490\Desktop\FINAL FINALLY\finalsappdevsheesh-main\PAMAYBAY.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\harle\Desktop\finalsappdevsheesh-main\PAMAYBAY.accdb";
        int totalunits = 0;
        public EnrollmentEntry()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void IDNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();
                string sql = "SELECT * FROM STUDENTFILE";
                thisCommand.CommandText = sql;

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();

                bool found = false;
                string name = "";
                string course = "";
                int year = 0;

                while (thisDataReader.Read())
                {
                    if (thisDataReader["STFSTUDID"].ToString().Trim().ToUpper() == IDNumberTextBox.Text.Trim().ToUpper())
                    {
                        found = true;
                        name = thisDataReader["STFSTUDLNAME"].ToString().ToUpper() + ", " + thisDataReader["STFSTUDFNAME"].ToString().ToUpper() + " " + thisDataReader["STFSTUDMNAME"].ToString().ToUpper().Substring(0, 1);
                        course = thisDataReader["STFSTUDCOURSE"].ToString().ToUpper();
                        year = Convert.ToInt16(thisDataReader["STFSTUDYEAR"]);
                        break;
                    }

                }
                if (found == false)
                    MessageBox.Show("Student ID Not Found");
                else
                {
                    NameLabel.Text = name;
                    CourseLabel.Text = course;
                    YearLabel.Text = year.ToString();
                }
            }
        }

        private void EDPCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string days = string.Empty;
                string start = string.Empty;
                string end = string.Empty;
                bool conflict = false;
                bool closed = false;
                int i = 0;

                using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
                {
                    thisConnection.Open();
                    OleDbCommand thisCommand = thisConnection.CreateCommand();

                    thisCommand.CommandText = "SELECT * FROM SUBJECTSCHEDULEFILE";
                    using (OleDbDataReader thisDataReader = thisCommand.ExecuteReader())
                    {
                        while (thisDataReader.Read())
                        {
                            if (thisDataReader["SSFEDPCODE"].ToString().Trim().ToUpper() == EDPCodeTextBox.Text.Trim().ToUpper())
                            {
                                days = thisDataReader["SSFDAYS"].ToString().ToUpper();
                                start = thisDataReader["SSFSTARTTIME"].ToString();
                                end = thisDataReader["SSFENDTIME"].ToString();
                            }
                        }
                    }

                    if (SummaryDataGridView.Rows[0].Cells[0].Value != null)
                        i = -1;

                    while (i < SummaryDataGridView.Rows.Count - 1)
                    {
                        string daysInDataGrid = SummaryDataGridView.Rows[i + 1].Cells[4].Value.ToString().ToUpper();

                        if (IsConflict(days, daysInDataGrid))
                        {
                            conflict = true;
                            break;
                        }

                        i++;
                    }

                    if (conflict)
                    {
                        i = SummaryDataGridView.Rows[0].Cells[0].Value != null ? -1 : 0;

                        while (i < SummaryDataGridView.Rows.Count - 1)
                        {
                            TimeSpan startTime1 = DateTime.Parse(start).TimeOfDay;
                            TimeSpan startTime2 = DateTime.Parse(SummaryDataGridView.Rows[i + 1].Cells[2].Value.ToString()).TimeOfDay;
                            TimeSpan endTime1 = DateTime.Parse(end).TimeOfDay;
                            TimeSpan endTime2 = DateTime.Parse(SummaryDataGridView.Rows[i + 1].Cells[3].Value.ToString()).TimeOfDay;

                            if ((startTime1 < endTime2 && endTime1 > startTime2) || (startTime1 == startTime2 && endTime1 == endTime2))
                            {
                                conflict = true;
                                break;
                            }

                            i++;
                        }
                    }

                    thisCommand.CommandText = "SELECT * FROM SUBJECTSCHEDULEFILE";
                    using (OleDbDataReader thisDataReader = thisCommand.ExecuteReader())
                    {
                        while (thisDataReader.Read())
                        {
                            if (thisDataReader["SSFEDPCODE"].ToString().Trim().ToUpper() == EDPCodeTextBox.Text.Trim().ToUpper() &&
                                thisDataReader["SSFSTATUS"].ToString().Trim().ToUpper() == "IN")
                            {
                                closed = true;
                                break;
                            }
                        }
                    }
                }

                if (!conflict && !closed)
                {
                    if (SummaryDataGridView.Rows[0].Cells[0].Value != null)
                        SummaryDataGridView.Rows.Insert(0, new object[] { });

                    using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
                    {
                        thisConnection.Open();
                        OleDbCommand thisCommand = thisConnection.CreateCommand();

                        thisCommand.CommandText = "SELECT * FROM SUBJECTSCHEDULEFILE";
                        using (OleDbDataReader thisDataReader = thisCommand.ExecuteReader())
                        {
                            while (thisDataReader.Read())
                            {
                                if (thisDataReader["SSFEDPCODE"].ToString().Trim().ToUpper() == EDPCodeTextBox.Text.Trim().ToUpper())
                                {
                                    DateTime startTime = DateTime.Parse(thisDataReader["SSFSTARTTIME"].ToString());
                                    DateTime endTime = DateTime.Parse(thisDataReader["SSFENDTIME"].ToString());

                                    SummaryDataGridView.Rows[0].Cells[0].Value = EDPCodeTextBox.Text.Trim().ToUpper();
                                    SummaryDataGridView.Rows[0].Cells[1].Value = thisDataReader["SSFSUBJCODE"].ToString();
                                    SummaryDataGridView.Rows[0].Cells[2].Value = startTime.ToShortTimeString();
                                    SummaryDataGridView.Rows[0].Cells[3].Value = endTime.ToShortTimeString();
                                    SummaryDataGridView.Rows[0].Cells[4].Value = thisDataReader["SSFDAYS"].ToString();
                                    SummaryDataGridView.Rows[0].Cells[5].Value = thisDataReader["SSFROOM"].ToString();
                                    break;
                                }
                            }
                        }

                        thisCommand.CommandText = "SELECT * FROM SUBJECTFILE";
                        using (OleDbDataReader thisDataReader = thisCommand.ExecuteReader())
                        {
                            while (thisDataReader.Read())
                            {
                                if (thisDataReader["SFSSUBJCODE"].ToString().Trim().ToUpper() == SummaryDataGridView.Rows[0].Cells[1].Value.ToString().Trim().ToUpper())
                                {
                                    SummaryDataGridView.Rows[0].Cells[6].Value = thisDataReader["SFSSUBJUNITS"].ToString();
                                    break;
                                }
                            }
                        }
                    }

                    UpdateTotalUnits();
                }
                else
                {
                    MessageBox.Show(conflict ? "Schedule is Conflict" : "Schedule is Closed");
                }
            }
        }

        private void UpdateTotalUnits()
        {
            int totalUnits = 0;
            int units = 0;
            foreach (DataGridViewRow row in SummaryDataGridView.Rows)
            {
               
                if (int.TryParse(row.Cells[6].Value?.ToString(), out units))
                {
                    totalUnits += units;
                }
            }
            UnitsLabel.Text = totalUnits.ToString();
        }

        private bool IsConflict(string days, string daysInDataGrid)
        {
            return days == daysInDataGrid ||
                   (days == "MW" && (daysInDataGrid == "MON" || daysInDataGrid == "WED")) ||
                   (daysInDataGrid == "MW" && (days == "MON" || days == "WED")) ||
                   (days == "MWF" && (daysInDataGrid == "MON" || daysInDataGrid == "WED" || daysInDataGrid == "FRI")) ||
                   (daysInDataGrid == "MWF" && (days == "MON" || days == "WED" || days == "FRI")) ||
                   (days == "TTH" && (daysInDataGrid == "TUE" || daysInDataGrid == "THU")) ||
                   (daysInDataGrid == "TTH" && (days == "TUE" || days == "THU")) ||
                   (days == "TTHS" && (daysInDataGrid == "TUE" || daysInDataGrid == "THU" || daysInDataGrid == "SAT")) ||
                   (daysInDataGrid == "TTHS" && (days == "TUE" || days == "THU" || days == "SAT")) ||
                   (days == "FS" && (daysInDataGrid == "FRI" || daysInDataGrid == "SAT")) ||
                   (daysInDataGrid == "FS" && (days == "FRI" || days == "SAT"));
        }


        public void ActiveInactive()
        {
           
        
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(IDNumberTextBox.Text != string.Empty)
            {
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                string Ole = "Select * From ENROLLMENTHEADERFILE";
                OleDbDataAdapter thisAdapter = new OleDbDataAdapter(Ole, thisConnection);
                OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);
                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "EnrollmentHeaderFile");

                DataRow thisRow = thisDataSet.Tables["EnrollmentHeaderFile"].NewRow();

                thisRow["ENRHFSTUDID"] = IDNumberTextBox.Text;
                thisRow["ENRHFSTUDDATEENROLL"] = DateTime.Now.ToShortDateString().ToString().Trim();
                thisRow["ENRHFSTUDSCHLYR"] = YearLabel.Text;
                thisRow["ENRHFSTUDENCODER"] = NameLabel.Text;
                thisRow["ENRHFSTUDTOTALUNITS"] = UnitsLabel.Text.Substring((UnitsLabel.Text.IndexOf(':') + 1));
                thisRow["ENRHFSTUDSTATUS"] = "EN";

                thisDataSet.Tables["EnrollmentHeaderFile"].Rows.Add(thisRow);
                thisAdapter.Update(thisDataSet, "EnrollmentHeaderFile");

                for(int i = 0; i < SummaryDataGridView.Rows.Count - 1; i++)
                {
                    thisConnection = new OleDbConnection(connectionString);
                    Ole = "Select * From ENROLLMENTDETAILFILE";
                    thisAdapter = new OleDbDataAdapter(Ole, thisConnection);
                    thisBuilder = new OleDbCommandBuilder(thisAdapter);
                    thisDataSet = new DataSet();
                    thisAdapter.Fill(thisDataSet, "EnrollmentDetailFile");

                    thisRow = thisDataSet.Tables["EnrollmentDetailFile"].NewRow();

                    thisRow["ENRDFSTUDID"] = IDNumberTextBox.Text;
                    thisRow["ENRDFSTUDSUBJCDE"] = SummaryDataGridView.Rows[i].Cells[1].Value;
                    thisRow["ENRDFSTUDEDPCODE"] = SummaryDataGridView.Rows[i].Cells[0].Value;

                    thisDataSet.Tables["EnrollmentDetailFile"].Rows.Add(thisRow);
                    thisAdapter.Update(thisDataSet, "EnrollmentDetailFile");
                }

                MessageBox.Show("Enrolled.");
            }
            else
            {
                MessageBox.Show("ID Number is empty.");
            }
        }

        

        private void BackButton_Click(object sender, EventArgs e)
        {
            Menu mainMenu = new Menu();
            mainMenu.Show();
            this.Hide();
        }

       
    }
}
