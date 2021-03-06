﻿/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2009-01-01
 * Time: 18:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ParkingSystem.BLL;
using ParkingSystem.Model;

namespace ParkingSystem
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>	
   
	public partial class FreedomCarEnter : Form
	{
        public static FreedomCarEnter freeenter;
        public static BLL_Records records;

		public FreedomCarEnter()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
            freeenter = this;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}


        private void Button_enter_ban_Click(object sender, EventArgs e)
        {
            MessageBox.Show("停车场已满！拒绝进入");
            this.Close();
        }

        private void Button_enter_allow_Click(object sender, EventArgs e)
        {
            DateTime timenow=DateTime.Now;
            //新建一个model，数据通过这个model进行传递
            Model_FreedomCars newcar = new Model_FreedomCars(
                Convert.ToInt32(this.textBox_placeid.Text),
                this.textBox_carnumbers.Text,
                this.textBox_mastername.Text,
                this.textBox_tel.Text,
                timenow
                );
            BLL_FreedomCars.EnterNewFreeCar(newcar);



            Model_Records newrecord = new Model_Records(
                this.textBox_mastername.Text,
                this.textBox_carnumbers.Text,
                this.textBox_tel.Text,
                Convert.ToInt32(this.textBox_placeid.Text),
                timenow
                );
            BLL_Records.AddNewRecord(newrecord);

            this.Close();

            //  records = new BLL_Records(
            //  this.textBox_mastername.Text,
            //  this.textBox_tel.Text,
            //  Convert.ToInt32(this.textBox_placeid.Text),
            //  this.textBox_carnumbers.Text
            //  );
            //records.SaveRecords();
        }
	}
}
