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
        //string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = \\Server2\second semester 2023-2024\LAB802\79286_CC_APPSDEV22_1030_1230_PM_MW\79286-23222490\Desktop\Revise-main\PAMAYBAY.accdb";
        string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Home\OneDrive\Desktop\Revise-main\PAMAYBAY.accdb";
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
                        string startInDataGrid = SummaryDataGridView.Rows[i + 1].Cells[2].Value.ToString();
                        string endInDataGrid = SummaryDataGridView.Rows[i + 1].Cells[3].Value.ToString();

                        if (IsConflict(days.ToUpper(), daysInDataGrid) &&
                            IsTimeConflict(DateTime.Parse(start), DateTime.Parse(end), DateTime.Parse(startInDataGrid), DateTime.Parse(endInDataGrid)))
                        {
                            conflict = true;
                            break;
                        }

                        i++;
                    }

                    if (conflict)
                    {
                        MessageBox.Show("Schedule is Conflict");
                        return;
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

                    if (closed)
                    {
                        MessageBox.Show("Schedule is Closed");
                        return;
                    }

                    using (OleDbConnection newConnection = new OleDbConnection(connectionString))
                    {
                        bool edp = false;
                        newConnection.Open();
                        OleDbCommand newCommand = newConnection.CreateCommand();

                        newCommand.CommandText = "SELECT * FROM SUBJECTSCHEDULEFILE";
                        using (OleDbDataReader newDataReader = newCommand.ExecuteReader())
                        {
                            while (newDataReader.Read())
                            {
                                if (newDataReader["SSFEDPCODE"].ToString().Trim().ToUpper() == EDPCodeTextBox.Text.Trim().ToUpper())
                                {
                                    edp = true;
                                    if (SummaryDataGridView.Rows[0].Cells[0].Value != null)
                                        SummaryDataGridView.Rows.Insert(0, new object[] { });
                                    DateTime startTime = DateTime.Parse(newDataReader["SSFSTARTTIME"].ToString());
                                    DateTime endTime = DateTime.Parse(newDataReader["SSFENDTIME"].ToString());

                                    SummaryDataGridView.Rows[0].Cells[0].Value = EDPCodeTextBox.Text.Trim().ToUpper();
                                    SummaryDataGridView.Rows[0].Cells[1].Value = newDataReader["SSFSUBJCODE"].ToString();
                                    SummaryDataGridView.Rows[0].Cells[2].Value = startTime.ToShortTimeString();
                                    SummaryDataGridView.Rows[0].Cells[3].Value = endTime.ToShortTimeString();
                                    SummaryDataGridView.Rows[0].Cells[4].Value = newDataReader["SSFDAYS"].ToString();
                                    SummaryDataGridView.Rows[0].Cells[5].Value = newDataReader["SSFROOM"].ToString();
                                    break;
                                }
                            }
                        }

                        if (!edp)
                        {
                            MessageBox.Show("EDP Code Not Found!");
                            return;
                        }

                        newCommand.CommandText = "SELECT * FROM SUBJECTFILE";
                        using (OleDbDataReader newDataReader = newCommand.ExecuteReader())
                        {
                            while (newDataReader.Read())
                            {
                                if (newDataReader["SFSSUBJCODE"].ToString().Trim().ToUpper() == SummaryDataGridView.Rows[0].Cells[1].Value.ToString().Trim().ToUpper())
                                {
                                    SummaryDataGridView.Rows[0].Cells[6].Value = newDataReader["SFSSUBJUNITS"].ToString();
                                    break;
                                }
                            }
                        }
                    }

                    UpdateTotalUnits();
                }
            }
        }


        private bool IsTimeConflict(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            return start1 < end2 && end1 > start2;
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

                for(int i = 0; i < SummaryDataGridView.Rows.Count; i++)
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
