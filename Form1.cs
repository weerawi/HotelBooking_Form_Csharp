using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q2_CS19020
{
    public partial class Form1 : Form
    {


        //number of rooms variable
        private int singleRooms = 10;
        private int doubleRooms = 7;
        private int familyRooms = 4;
        private int suiteRooms = 2; 
        private decimal total = 0;




        public Form1()
        {
            InitializeComponent();
            comboBoxRmType.Items.Add("Single");
            comboBoxRmType.Items.Add("Double");
            comboBoxRmType.Items.Add("Suite");
            comboBoxRmType.Items.Add("Family");
            Controls.Add(comboBoxRmType);

            comboBoxBook.Items.Add("Yes");
            comboBoxBook.Items.Add("No");
            Controls.Add(comboBoxBook);



            comboBoxRmType.Text = "--Select--";
            comboBoxBook.Text = "--Y/N--";
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
 

            string name = textBoxName.Text;
            string address = textBoxAddress.Text;
            string booking = this.comboBoxBook.GetItemText(this.comboBoxBook.SelectedItem);


             
             
                int rooms;
                if (!int.TryParse(textBoxRooms.Text, out rooms))
                {
                    MessageBox.Show("Please enter a valid number of rooms.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int days;
                if (!int.TryParse(textBoxDays.Text, out days))
                {
                    MessageBox.Show("Please enter a valid number of days.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string Rtype = this.comboBoxRmType.GetItemText(this.comboBoxRmType.SelectedItem);



                decimal price = 0;


                switch (Rtype)
                {

                    case "Single":
                        price = 5000.00m;

                        if ((singleRooms) == 0)
                        {
                            MessageBox.Show(Rtype + " rooms are not available at the moment", "Out of Rooms", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if ((singleRooms - rooms) < 0)
                        {
                            MessageBox.Show("Only " + (singleRooms) + " " + Rtype + " rooms are available at the moment", "Out of Rooms", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        singleRooms -= rooms;
                        break;

                    case "Double":
                        price = 7500.00m;
                        if ((doubleRooms) == 0)
                        {
                            MessageBox.Show(Rtype + " rooms are not available at the moment", "Out of Rooms", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if ((doubleRooms - rooms) < 0)
                        {
                            MessageBox.Show("Only " + (doubleRooms) + " " + Rtype + " rooms are available at the moment", "Out of Rooms", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        doubleRooms -= rooms;
                        break;

                    case "Family":
                        price = 8000.00m;
                        if ((familyRooms) == 0)
                        {
                            MessageBox.Show(Rtype + " rooms are not available at the moment", "Out of Rooms", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if ((familyRooms - rooms) < 0)
                        {
                            MessageBox.Show("Only " + (familyRooms) + " " + Rtype + " rooms are available at the moment", "Out of Rooms", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        familyRooms -= rooms;
                        break;

                    case "Suite":
                        price = 12500.00m;
                        if ((suiteRooms) == 0)
                        {
                            MessageBox.Show(Rtype + " rooms are not available at the moment", "Out of Rooms", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if ((suiteRooms - rooms) < 0)
                        {
                            MessageBox.Show("Only " + (suiteRooms) + " " + Rtype + " rooms are available at the moment", "Out of Rooms", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        suiteRooms -= rooms;
                        break;
                }

                decimal disRatePrice = 1;


                // Calculate the discount, if any
                if (days > 5 && (Rtype == "Suite" || Rtype == "Double"))
                {

                    if (Rtype == "Suite")
                    {
                        disRatePrice = 0.88m;
                    }
                    if (Rtype == "Double")
                    {
                        disRatePrice = 0.95m;
                    }


                }

            if (booking == "Yes")
            {
                total += (decimal)rooms * (decimal)days * price * disRatePrice;


                // Clear the booking inputs
                textBoxDays.Text = "";
                textBoxRooms.Text = "";
                comboBoxRmType.Text = "--Select--";
                comboBoxBook.Text = "--Y/N--";
                textBoxTot.Text = total.ToString();
            }else
            {
                total += (decimal)rooms * (decimal)days * price * disRatePrice;
                textBoxTot.Text = total.ToString();
                 
                MessageBox.Show("Total is " + (total) + "! \n" +  "Booking is Succesfull.", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }

                
             

             

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            textBoxAddress.Text = "";
            textBoxDays.Text = "";
            textBoxRooms.Text = "";
            comboBoxRmType.Text = "--Select--";
            comboBoxBook.Text = "--Y/N--";
            textBoxTot.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         
    }
}
