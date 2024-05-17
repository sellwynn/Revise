using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENROLLMENT_SYSTEM
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void SubjectEntryButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void SubjectScheduleEntryButton_Click(object sender, EventArgs e)
        {
            SubjectScheduleForm subjectScheduleForm = new SubjectScheduleForm();
            subjectScheduleForm.Show();
            this.Hide();
        }

        private void EnrollmentEntryButton_Click(object sender, EventArgs e)
        {
            EnrollmentEntry enrollment = new EnrollmentEntry();
            enrollment.Show();
            this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        

    }
}
