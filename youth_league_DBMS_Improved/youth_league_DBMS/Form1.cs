using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace youth_league_DBMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            // TODO: Bu kod satırı 'dataSet1.enroll' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.enrollTableAdapter.Fill(this.dataSet1.enroll);
            // TODO: Bu kod satırı 'dataSet1.coach' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.coachTableAdapter.Fill(this.dataSet1.coach);
            // TODO: Bu kod satırı 'dataSet1.parent' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.parentTableAdapter.Fill(this.dataSet1.parent);
            // TODO: Bu kod satırı 'dataSet1.player' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.playerTableAdapter.Fill(this.dataSet1.player);
            // TODO: Bu kod satırı 'dataSet1.Team' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.teamTableAdapter.Fill(this.dataSet1.Team);

        }
        //###########################    TEAM_TABLE    ##################################3
        private void button1_Click(object sender, EventArgs e)
        {
            this.teamTableAdapter.Insert(textBox1.Text,int.Parse(textBox2.Text));
            this.teamTableAdapter.Fill(this.dataSet1.Team);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int team_ID;
            int.TryParse(comboBox1.SelectedValue.ToString(), out team_ID);
            this.teamTableAdapter.DeleteQuery(team_ID);
            this.teamTableAdapter.Fill(this.dataSet1.Team);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int team_ID;
            int team_color;
            string team_name;
            int.TryParse(comboBox1.SelectedValue.ToString(), out team_ID);
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                team_name = this.teamTableAdapter.GetTeamNameByID(team_ID).Single().team_name; 
            }
            else { team_name = textBox1.Text; }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                team_color = this.teamTableAdapter.GetTeamColorByID(team_ID).Single().team_color;
            }
            else {team_color = int.Parse(textBox2.Text); }
    
            this.teamTableAdapter.UpdateQuery(team_name, team_color,team_ID);
            this.teamTableAdapter.Fill(this.dataSet1.Team);
        }

        //###########################    PLAYER_TABLE    ##################################
        private void button6_Click(object sender, EventArgs e)
        {
            int team_ID;
            int.TryParse(comboBox8.SelectedValue.ToString(), out team_ID);
            this.playerTableAdapter.Insert(textBox3.Text, textBox4.Text, int.Parse(textBox5.Text), team_ID);
            this.playerTableAdapter.Fill(this.dataSet1.player);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int player_ID;
            int.TryParse(comboBox2.SelectedValue.ToString(), out player_ID);
            this.playerTableAdapter.DeleteQuery(player_ID);
            this.playerTableAdapter.Fill(this.dataSet1.player);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string first_name,last_name;
            int age;
            int player_ID;
            int.TryParse(comboBox2.SelectedValue.ToString(), out player_ID);
            

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                first_name = this.playerTableAdapter.GetPlayerFirstNameByID(player_ID).Single().player_first_name;
            }
            else { first_name = (textBox3.Text); }

            if (string.IsNullOrEmpty(textBox4.Text))
            {
                last_name = this.playerTableAdapter.GetPlayerLastNameByID(player_ID).Single().player_last_name;
            }
            else { last_name = textBox4.Text; }

            if (string.IsNullOrEmpty(textBox5.Text))
            {
                age = this.playerTableAdapter.GetPlayerAgeByID(player_ID).Single().player_age;
            }
            else { age = int.Parse(textBox5.Text); }



            
            int team_ID;
            int.TryParse(comboBox8.SelectedValue.ToString(), out team_ID);
            this.playerTableAdapter.UpdateQuery(first_name, last_name, age, team_ID,player_ID);

            this.playerTableAdapter.Fill(this.dataSet1.player);
        }

        //###########################    PARENT_TABLE    ##################################
        private void button9_Click(object sender, EventArgs e)
        {
            this.parentTableAdapter.Insert(textBox7.Text, textBox8.Text, long.Parse(textBox9.Text), textBox10.Text);
            this.parentTableAdapter.Fill(this.dataSet1.parent);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int parent_ID;
            int.TryParse(comboBox3.SelectedValue.ToString(), out parent_ID);
            this.parentTableAdapter.DeleteQuery(parent_ID);
            this.parentTableAdapter.Fill(this.dataSet1.parent);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string first_name,last_name,address;
            int parent_ID;
            long phone_number;
            int.TryParse(comboBox3.SelectedValue.ToString(), out parent_ID);

            if (string.IsNullOrEmpty(textBox7.Text))
            {
                first_name = this.parentTableAdapter.GetParentFirstNameByID(parent_ID).Single().parent_first_name;
            }
            else { first_name = (textBox7.Text); }

            if (string.IsNullOrEmpty(textBox8.Text))
            {
                last_name = this.parentTableAdapter.GetParentLastNameByID(parent_ID).Single().parent_last_name;
            }
            else { last_name = textBox8.Text; }

            if (string.IsNullOrEmpty(textBox9.Text))
            {
                phone_number = this.parentTableAdapter.GetParentPhoneNumberByID(parent_ID).Single().parent_phone_number;
            }
            else { phone_number = long.Parse(textBox9.Text); }

            if (string.IsNullOrEmpty(textBox10.Text))
            {
                address = this.parentTableAdapter.GetParentAddressByID(parent_ID).Single().parent_address;
            }
            else { address = textBox10.Text; }





            
            this.parentTableAdapter.UpdateQuery(first_name, last_name, phone_number, address,parent_ID);
            this.parentTableAdapter.Fill(this.dataSet1.parent);
        }

        //###########################    COACH_TABLE    ##################################
        private void button12_Click(object sender, EventArgs e)
        {
            int team_ID;
            int.TryParse(comboBox9.SelectedValue.ToString(), out team_ID);
            this.coachTableAdapter.Insert(textBox11.Text, textBox12.Text, int.Parse(textBox13.Text), team_ID);
            this.coachTableAdapter.Fill(this.dataSet1.coach);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int coach_ID;
            int.TryParse(comboBox4.SelectedValue.ToString(), out coach_ID);
            this.coachTableAdapter.DeleteQuery(coach_ID);
            this.coachTableAdapter.Fill(this.dataSet1.coach);

        }

        private void button10_Click(object sender, EventArgs e)
        {   string first_name,last_name;
            int coach_ID;
            long phone_number;
            int.TryParse(comboBox4.SelectedValue.ToString(), out coach_ID);

            if (string.IsNullOrEmpty(textBox11.Text))
            {
                first_name = this.coachTableAdapter.GetCoachFirstNameByID(coach_ID).Single().coach_first_name;
            }
            else { first_name = (textBox11.Text); }

            if (string.IsNullOrEmpty(textBox12.Text))
            {
                last_name = this.coachTableAdapter.GetCoachLastNameByID(coach_ID).Single().coach_last_name;
            }
            else { last_name = textBox12.Text; }

            if (string.IsNullOrEmpty(textBox13.Text))
            {
                phone_number = this.coachTableAdapter.GetCoachPhoneNumberByID(coach_ID).Single().coach_phone_number;
            }
            else { phone_number = int.Parse(textBox13.Text); }


            
            int team_ID;
            int.TryParse(comboBox9.SelectedValue.ToString(), out team_ID);
            this.coachTableAdapter.UpdateQuery(first_name, last_name, phone_number, team_ID,coach_ID);

            this.coachTableAdapter.Fill(this.dataSet1.coach);
        }

        //###########################    ENROLL_TABLE    ##################################
        private void button15_Click(object sender, EventArgs e)
        {
            int parent_ID, player_ID;
            int.TryParse(comboBox6.SelectedValue.ToString(), out parent_ID);
            int.TryParse(comboBox7.SelectedValue.ToString(), out player_ID);
            int enroll_ID = 1000 * parent_ID + player_ID;
            this.enrollTableAdapter.Insert(enroll_ID, player_ID, parent_ID);
            this.enrollTableAdapter.Fill(this.dataSet1.enroll);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int enroll_ID;
            int.TryParse(comboBox5.SelectedValue.ToString(), out enroll_ID);
            this.enrollTableAdapter.DeleteQuery(enroll_ID);
            this.enrollTableAdapter.Fill(this.dataSet1.enroll);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int enroll_ID,parent_ID, player_ID;
            int.TryParse(comboBox5.SelectedValue.ToString(), out enroll_ID);
            int.TryParse(comboBox6.SelectedValue.ToString(), out parent_ID);
            int.TryParse(comboBox7.SelectedValue.ToString(), out player_ID);
            int enroll_ID_new = 1000 * parent_ID + player_ID;
            this.enrollTableAdapter.Insert(enroll_ID_new, player_ID, parent_ID);
            this.enrollTableAdapter.Fill(this.dataSet1.enroll);
        }
    }
}
