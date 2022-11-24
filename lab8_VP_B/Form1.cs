using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8_VP_B
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Studentinfo> std = new List<Studentinfo>();
        
        private void button1_Click(object sender, EventArgs e)                  //add student button
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please fill all require fields");
            }
            else
            {
                Studentinfo s = new Studentinfo();
                s.StudentID = int.Parse(textBox1.Text);
                s.StudentName = textBox2.Text;
                s.Age = int.Parse(textBox3.Text);
                s.marks = int.Parse(textBox4.Text);
                s.gender = textBox5.Text;

                std.Add(s);
                MessageBox.Show("Student added successfully");
                clearControls();


            }

            dataGridView1.Rows.Clear();
            var myString = from st in std
                           select st;
            foreach (Studentinfo si in myString)
            {
                dataGridView1.Rows.Add(si.StudentID, si.StudentName, si.Age, si.marks, si.gender);
            }

        }

        private void clearControls()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void button2_Click(object sender, EventArgs e)                          //search record by specific name
        {
            
            dataGridView1.Rows.Clear();
            if (textBox6.Text == "")
            {
                MessageBox.Show("Please enter name to search");
            }
            else
            {
                var myString = from st in std
                               where st.StudentName == textBox6.Text
                               select st;
                foreach (Studentinfo s in myString)
                {
                    dataGridView1.Rows.Add(s.StudentID, s.StudentName, s.Age, s.marks, s.gender);
                }
                textBox6.Clear();
            }
           
            
        }

        private void button3_Click(object sender, EventArgs e)          //search record by marks
        {
            
            dataGridView1.Rows.Clear();
            if (textBox7.Text == "")
            {
                MessageBox.Show("Please enter name to search");
            }
            else
            {
                var myString = from mark in std
                               where mark.marks > int.Parse(textBox7.Text)
                               orderby mark.marks descending
                               select mark;
                foreach (Studentinfo s in myString)
                {
                    dataGridView1.Rows.Add(s.StudentID, s.StudentName, s.Age, s.marks, s.gender);
                   
                }
                textBox7.Clear();
            }
           
        }

        private void button4_Click(object sender, EventArgs e)                  //sort by marks
        {
            dataGridView1.Rows.Clear();
            var myString = from mark in std
                           orderby mark.marks descending
                            select mark;
            foreach (Studentinfo s in myString)
            {
                dataGridView1.Rows.Add(s.StudentID, s.StudentName, s.Age, s.marks, s.gender);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)                  //sort by gender,marks and age
        {
            dataGridView1.Rows.Clear();
            var myString = from s in std
                           orderby s.gender ascending,s.marks descending, s.Age ascending
                           select s;
            foreach (Studentinfo s in myString)
            {
                dataGridView1.Rows.Add(s.StudentID, s.StudentName, s.Age, s.marks, s.gender);
            }
        }

        private void button6_Click(object sender, EventArgs e)              //show all record
        {
            dataGridView1.Rows.Clear();
            var myString = from s in std
                           select s;
            foreach (Studentinfo s in myString)
            {
                dataGridView1.Rows.Add(s.StudentID, s.StudentName, s.Age, s.marks, s.gender);
            }
        }

       
    }
}
