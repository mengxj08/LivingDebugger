/*
 * Created by SharpDevelop.
 * User: Xiaojun
 * Date: 2/25/2013
 * Time: 3:25 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace Test
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private int currentStep = 0;
		private const int MINSTEP = 0;
		private const int MAXSTEP = 57;
		private int [] LineToStep;
		private ArrayList LineListCode = new ArrayList();
		private ArrayList LineListState = new ArrayList();
		private TextBox [] textBoxes;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			readCodes();
			AddCodes();
			AddStates();
			setLineToStep();
			combineTextBoxes();
			this.dataGridView1.Rows[35].Selected = true;
			this.dataGridView1.CurrentCell = this.dataGridView1.Rows[35].Cells[1];
					
			this.dataGridView1.CurrentCellChanged += new EventHandler(this.DataGridView1_CurrentCellChanged);
			this.dataGridView1.SelectionChanged += new EventHandler(this.DataGridView1_SelectionChanged);
			
			//this.textBox1.Text = "CurrentStep:"+currentStep.ToString();
			
			//this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
			this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
			this.trackBar3.ValueChanged += new System.EventHandler(this.trackBar3_ValueChanged);
			this.trackBar4.ValueChanged += new System.EventHandler(this.trackBar4_ValueChanged);
			this.trackBar5.ValueChanged += new System.EventHandler(this.trackBar5_ValueChanged);
			this.trackBar6.ValueChanged += new System.EventHandler(this.trackBar6_ValueChanged);
			this.trackBar7.ValueChanged += new System.EventHandler(this.trackBar7_ValueChanged);
			
			
			this.button1.MouseClick += new MouseEventHandler(this.button1_MouseClick);
			this.button2.MouseClick += new MouseEventHandler(this.button2_MouseClick);
			this.button7.MouseClick += new MouseEventHandler(this.button7_MouseClick);
			this.button8.MouseClick += new MouseEventHandler(this.button8_MouseClick);
			
			/*
			 * Test for the trackbar
			 * */
			//this.trackBar1.BackColor = Color.FromArgb(255,100,0,0);
		}
		/*
		 * Simple function
		 * */
		private void setCurrentStep(int num)
		{
			this.currentStep = num;
		}
		private void combineTextBoxes()
		{
			this.textBoxes = new TextBox[24];
			this.textBoxes.SetValue(this.textBox11,0);
			this.textBoxes.SetValue(this.textBox12,1);
			this.textBoxes.SetValue(this.textBox13,2);
			this.textBoxes.SetValue(this.textBox14,3);
			this.textBoxes.SetValue(this.textBox15,4);
			this.textBoxes.SetValue(this.textBox16,5);
			this.textBoxes.SetValue(this.textBox17,6);
			this.textBoxes.SetValue(this.textBox18,7);
			this.textBoxes.SetValue(this.textBox19,8);
			this.textBoxes.SetValue(this.textBox20,9);
			this.textBoxes.SetValue(this.textBox21,10);
			this.textBoxes.SetValue(this.textBox22,11);
			
		    this.textBoxes.SetValue(this.textBox36,12);
			this.textBoxes.SetValue(this.textBox37,13);
			this.textBoxes.SetValue(this.textBox38,14);
			this.textBoxes.SetValue(this.textBox39,15);
			this.textBoxes.SetValue(this.textBox40,16);
			this.textBoxes.SetValue(this.textBox41,17);
			this.textBoxes.SetValue(this.textBox42,18);
			this.textBoxes.SetValue(this.textBox43,19);
			this.textBoxes.SetValue(this.textBox44,20);
			this.textBoxes.SetValue(this.textBox45,21);
			this.textBoxes.SetValue(this.textBox46,22);
			this.textBoxes.SetValue(this.textBox47,23);
		}
		/*
		 * setLineToStep is to create table from Line to Step
		 * */
		private void setLineToStep()
		{
			int length = LineListCode.Count;
			this.LineToStep = new int[length];
			for(int i = 0 ;i < length ;i++)
				LineToStep[i] = -1;
			for(int i = 0;i < LineListState.Count; i++)
			{
				String line = LineListState[i].ToString();
				String [] temp = line.Split('$');
				LineToStep[int.Parse(temp[1])] = int.Parse(temp[0]);
			}
			/*
			this.textBox11.Text = "LineToStep[12]="+LineToStep[12].ToString();
			this.textBox12.Text = "LineToStep[18]="+LineToStep[18].ToString();
			this.textBox13.Text = "LineToStep[41]="+LineToStep[41].ToString();
			this.textBox14.Text = "LineToStep[0]="+LineToStep[0].ToString();
			this.textBox15.Text = "LineToStep[42]="+LineToStep[42].ToString();
			*/
		}
	    /*
	     * ReadCodes is to read bubblesort code from the document
	     * AddStates is to read bubblesort state from the document
	     * AddCodes is to add codes into the datagridview
	     * 
	     * */
		void readCodes()
		{
			StreamReader objReader = new StreamReader("../../BubbleSort.java");
			String Line = "";
			while(Line != null)
			{
				Line = objReader.ReadLine();
				if(Line != null)
				{
					LineListCode.Add(Line);	
					//LineListCode.
				}
			}
			objReader.Close();
		}
		void AddStates()
		{
			StreamReader objReader = new StreamReader("../../bubble_value");
			String Line = "";
			while(Line != null)
			{
				Line = objReader.ReadLine();
				if(Line != null)
				{
					LineListState.Add(Line);
					//LineListState
				}
			}
			objReader.Close();
			
		}
		void AddCodes()
		{
			//DataGridViewRow row
			for(int i=0; i<LineListCode.Count;i++)
			{
				int index = this.dataGridView1.Rows.Add();
				this.dataGridView1.Rows[index].Cells[0].Value = i.ToString();
				this.dataGridView1.Rows[index].Cells[1].Value = LineListCode[i].ToString();;
			}

		}
		/*
		 * This part contains all the event function
		 * 
		 * */
		void VScrollBar1Scroll(object sender, ScrollEventArgs e)
		{
			
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}
		
		void TableLayoutPanel1Paint(object sender, PaintEventArgs e)
		{
			
		}
		
		void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		
		}
		/*
		void trackBar1_Scroll(Object sender, EventArgs e)
		{
			//this.textBox4.Text = trackBar1.Value.ToString();
		}
		*/
		void trackBar1_ValueChanged(Object sender, EventArgs e)//currentStep changes...
		{
			int trackBar1_value = trackBar1.Value;
			int tempCurrentStep = 0;
			switch (trackBar1_value)
			{
				case 3:
					tempCurrentStep = 3;
					if(this.currentStep >= 3 && this.currentStep <= 7)return;
					break;
				case 4:
					tempCurrentStep = 8;
					if(this.currentStep >= 8 && this.currentStep <= 43)return;
					break;
				case 5:
					tempCurrentStep = 44;
					if(this.currentStep >= 44 && this.currentStep <= 56)return;
					break;
				case 6:
					tempCurrentStep = 57;
					break;
				default:
					tempCurrentStep = trackBar1_value;
					break;
			}
			if(this.currentStep == tempCurrentStep)return;
			setCurrentStep(tempCurrentStep);
			setTimeline();
		}
		void trackBar2_ValueChanged(Object sender, EventArgs e)
		{
			if(this.currentStep == this.trackBar2.Value + 4)return;
			this.setCurrentStep(this.trackBar2.Value + 4);
			setTimeline();
		}
		void trackBar3_ValueChanged(Object sender, EventArgs e)
		{
			int trackBar3_value = this.trackBar3.Value;
			int tempStep = 0;
			if(trackBar3_value >= 0 && trackBar3_value <= 3)
			{
				tempStep = trackBar3_value + 9;
				if(this.currentStep >= 13 && this.currentStep <= 17)return;
			}
			else if(trackBar3_value >= 4 && trackBar3_value <= 5)
			{
				tempStep = trackBar3_value + 14;
				if(this.currentStep >= 20 && this.currentStep <= 24)return;
			}
			else if(trackBar3_value >= 6 && trackBar3_value <= 11)
			{
				tempStep = trackBar3_value + 19;
				if(this.currentStep >= 31 && this.currentStep <= 35)return;
			}
			else if(trackBar3_value >= 12 && trackBar3_value <= 19)
			{
				tempStep = trackBar3_value + 24;
			}
			
			if(tempStep == this.currentStep)return;
			
			this.setCurrentStep(tempStep);
			setTimeline();
		}
		void trackBar4_ValueChanged(Object sender, EventArgs e)
		{
			if(this.currentStep == this.trackBar4.Value + 45)return;
			this.setCurrentStep(this.trackBar4.Value + 45);
			setTimeline();
		}
		void trackBar5_ValueChanged(Object sender, EventArgs e)
		{
			if(this.currentStep == this.trackBar5.Value + 13)return;
			this.setCurrentStep(this.trackBar5.Value + 13);
			setTimeline();
		}
		void trackBar6_ValueChanged(Object sender, EventArgs e)
		{
			if(this.currentStep == this.trackBar6.Value + 20)return;
			this.setCurrentStep(this.trackBar6.Value + 20);
			setTimeline();
		}
		void trackBar7_ValueChanged(Object sender, EventArgs e)
		{
			if(this.currentStep == this.trackBar7.Value + 31)return;
			this.setCurrentStep(this.trackBar7.Value + 31);
			setTimeline();
		}
	    /*
	     * event function for buttons
	     * 
	     * */
		void button1_MouseClick(Object sender, EventArgs e)
		{
			if(this.currentStep > MINSTEP)this.currentStep --;
			setTimeline();
		}
		void button2_MouseClick(Object sender, EventArgs e)
		{
			if(this.currentStep < MAXSTEP)this.currentStep ++;
			setTimeline();
		}
		void button7_MouseClick(Object sender, EventArgs e)
		{
			this.currentStep = MINSTEP;
			setTimeline();
		}
		void button8_MouseClick(Object sender, EventArgs e)
		{
			this.currentStep = MAXSTEP;
			setTimeline();
		}
		void DataGridView1_CurrentCellChanged(object sender, EventArgs e)//currentStep changes...
		{
			if(LineToStep[dataGridView1.SelectedRows[0].Index] == -1)return;
			String line = this.LineListState[this.currentStep].ToString();
			String []temp = line.Split('$');
			if(temp[1] == dataGridView1.SelectedRows[0].Index.ToString())return;
			
			if(this.currentStep != LineToStep[dataGridView1.SelectedRows[0].Index])
			{
				this.setCurrentStep(LineToStep[dataGridView1.SelectedRows[0].Index]);
				setTimeline();
			}
		}
		void DataGridView1_SelectionChanged(Object sender, EventArgs e)
		{
		}
		/*
		 * set the variables
 		 */
		void setStates()
		{
			for(int i = 0; i < this.textBoxes.Length; i++)
				this.textBoxes[i].Clear();
			
			String line = LineListState[this.currentStep].ToString();
			String []temp = line.Split('$');
			int valueNum = temp.Length - 3;
			int index = 0;
			for(int i = 2; i < temp.Length - 1;i++)
			{
				if(temp[i] == "NONE")continue;
				String [] tempWord = temp[i].ToString().Split('=');
				this.textBoxes[index].Text = tempWord[0];
				this.textBoxes[index + 12].Text = tempWord[1];
				index++;
			}
			
			this.textBox1.Clear();
			this.textBox2.Clear();
			if(temp[temp.Length - 1] != "NONE")
			{
				String []tempOut = temp[temp.Length - 1].ToString().Split(':');
				this.textBox1.Text = tempOut[0]+":";
				if(tempOut.Length > 1)
					this.textBox2.Text = tempOut[1];
			}
		}
		/*
		 * set the various timelines
		 * */
		void setTimeline()
		{
			this.textBox5.Text = this.currentStep.ToString();
			if(this.currentStep <= 3)
			{
				this.setComponentVisible();
				this.trackBar1.Value = this.currentStep;
			}
			else if(this.currentStep >= 4 && this.currentStep <= 7)
			{
				this.setComponentVisible();
				this.trackBar2.Visible = true;
				this.label2.Visible = true;
				this.trackBar2.Value = this.currentStep - 4;
				this.trackBar1.Value = 3;
			}
			else if(this.currentStep == 8)
			{
				this.setComponentVisible();
				this.trackBar1.Value = 4;
			}
			else if(this.currentStep >= 9 && this.currentStep <= 43)
			{
				this.setComponentVisible();
				this.trackBar1.Value = 4;
				this.trackBar3.Visible = true;
				this.label3.Visible = true;
				if(this.currentStep >= 9 && this.currentStep <= 12)
				{
					this.trackBar3.Value = this.currentStep - 9;
					this.trackBar3.BackColor = Color.FromArgb(255,128,255,128);
				}
				else if(this.currentStep >= 13 && this.currentStep <= 17)
				{
					this.trackBar3.Value = 3;
					this.trackBar3.BackColor = Color.FromArgb(255,128,128,255);
					this.trackBar5.Visible = true;
					this.label5.Visible = true;
					this.trackBar5.Value = this.currentStep - 13;
				}
				else if(this.currentStep >= 18 && this.currentStep <= 19)
				{
					this.trackBar3.Value = this.currentStep - 14;
					this.trackBar3.BackColor = Color.FromArgb(255,128,255,128);
				}
				else if(this.currentStep >= 20 && this.currentStep <= 24)
				{
					this.trackBar3.Value = 5;
					this.trackBar3.BackColor = Color.FromArgb(255,128,128,255);
					this.trackBar6.Visible = true;
					this.label6.Visible = true;
					this.trackBar6.Value = this.currentStep - 20;
				}
				else if(this.currentStep >= 25 && this.currentStep <= 30)
				{
					this.trackBar3.Value = this.currentStep - 19;
					this.trackBar3.BackColor = Color.FromArgb(255,128,255,128);
				}
				else if(this.currentStep >= 31 && this.currentStep <= 35)
				{
					this.trackBar3.Value = 11;
					this.trackBar3.BackColor = Color.FromArgb(255,128,128,255);
					this.trackBar7.Visible = true;
					this.label7.Visible = true;
					this.trackBar7.Value = this.currentStep - 31;
				}
				else if(this.currentStep >= 36 && this.currentStep <= 43)
				{
					this.trackBar3.Value = this.currentStep - 24;
					this.trackBar3.BackColor = Color.FromArgb(255,128,255,128);
				}
				else
				{
					this.trackBar3.BackColor = Color.FromArgb(255,128,255,128);
				}
			}
			else if(this.currentStep == 44)
			{
				this.setComponentVisible();
				this.trackBar1.Value = 5;
			}
			else if(this.currentStep >= 45 && this.currentStep <= 56)
			{
				this.setComponentVisible();
				this.trackBar1.Value = 5;
				this.trackBar4.Visible = true;
				this.label4.Visible = true;
				this.trackBar4.Value = this.currentStep - 45;
				
			}
			else if(this.currentStep == 57)
			{
				this.setComponentVisible();
				this.trackBar1.Value = 6;
			}
			else
			{
				this.setComponentVisible();
			}
			this.dataGridView1.ClearSelection();
			String line = LineListState[this.currentStep].ToString();
			String []temp = line.Split('$');
			this.dataGridView1.Rows[int .Parse(temp[1])].Selected = true;
			this.dataGridView1.CurrentCell = this.dataGridView1.Rows[int.Parse(temp[1])].Cells[1];
			
			setStates();
		}
		void setComponentVisible()
		{
			this.trackBar2.Visible = false;
			this.label2.Visible = false;
			this.trackBar3.Visible = false;
			this.label3.Visible = false;
			this.trackBar4.Visible = false;
			this.label4.Visible = false;
			this.trackBar5.Visible = false;
			this.label5.Visible = false;
			this.trackBar6.Visible = false;
			this.label6.Visible = false;
			this.trackBar7.Visible = false;
			this.label7.Visible = false;
		}
	}
}
