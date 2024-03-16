using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPLab42
{
    public partial class Form1 : Form
    {
        public class Model
        {
            private int valueA=10;
            private int valueB=40;
            private int valueC=70;
            //public System.EventHandler observers;
            public int getValueA()
            {
                return valueA;
            }
            public int getValueB()
            {
                return valueB;
            }
            public int getValueC()
            {
                return valueC;
            }
            public void setValueA(int value)
            {
                if (value > 0 && value < 100)
                {
                    if (value <= valueC)
                    {
                        
                        if (valueB >= value)
                        {
                            valueA = value; 
                        }
                        else
                        {
                            valueA = value;
                            valueB = value;
                        }
                    }
                    else 
                    {
                        valueA = value;
                        valueB = value;
                        valueC = value;
                    }
                }
                else if (value >= 100)
                {

                    valueA = value;
                    valueB = value;
                    valueC = value;
                }
                else if (value <= 0)
                {
                    valueA = 0;
                }
                //observers.Invoke(this, null);
            }
            public void setValueC(int value)
            {
                if (value > 0 && value < 100)
                {
                    if (value >= valueA)
                    {
                        if (valueB <= value)
                        {
                            valueC = value;
                        }
                        else
                        {
                            valueC = value;
                            valueB = value;
                        }
                    }
                    else
                    {
                        valueC = value;
                        valueB = value;
                        valueA = value;
                    }

                }
                else if (value >= 100)
                {
                    valueC = 100;
                }
                else if (value < 0)
                {
                    valueC = 0;
                    valueB = 0;
                    valueA = 0;
                }
                //observers.Invoke(this, null);
            }
            public void setValueB(int value)
            {
                if (value >= valueA && value <= valueC)
                {
                    valueB = value;
                }
                //observers.Invoke(this, null);
            }
        }
        Model model;
        protected override void OnClosing(CancelEventArgs e) //сохранение данных при выключении программы
        {
            Properties.Settings.Default.valueA = model.getValueA();
            Properties.Settings.Default.valueB = model.getValueB();
            Properties.Settings.Default.valueC = model.getValueC();
            Properties.Settings.Default.Save();
        }
        private void LoadSettings() //выгрузка данных из Settings
        {
            model.setValueC(Properties.Settings.Default.valueA);
            model.setValueB(Properties.Settings.Default.valueB);
            model.setValueA(Properties.Settings.Default.valueC);
            textBox1.Text = Properties.Settings.Default.valueA.ToString();
            textBox2.Text = Properties.Settings.Default.valueB.ToString();
            textBox3.Text = Properties.Settings.Default.valueC.ToString();
            numericUpDown1.Value = Properties.Settings.Default.valueA;
            numericUpDown2.Value = Properties.Settings.Default.valueB;
            numericUpDown3.Value = Properties.Settings.Default.valueC;
            trackBar1.Value = Properties.Settings.Default.valueA;
            trackBar2.Value = Properties.Settings.Default.valueB;
            trackBar3.Value = Properties.Settings.Default.valueC;
        }
        public Form1()
        {
            InitializeComponent();
            model = new Model();
            //model.observers += new System.EventHandler(this.UpdateFromModel);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateFromModel();
            LoadSettings();
        }

        private void UpdateFromModel()
        {
            textBox1.Text = model.getValueA().ToString();
            textBox2.Text = model.getValueB().ToString();
            textBox3.Text = model.getValueC().ToString();
            numericUpDown1.Value = model.getValueA();
            numericUpDown2.Value = model.getValueB();
            numericUpDown3.Value = model.getValueC();
            trackBar1.Value = model.getValueA();
            trackBar2.Value = model.getValueB();
            trackBar3.Value = model.getValueC();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            model.setValueA(Convert.ToInt32(textBox1.Text));
            UpdateFromModel();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.setValueA(Decimal.ToInt32(numericUpDown1.Value));
            UpdateFromModel();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            model.setValueA(Decimal.ToInt32(trackBar1.Value));
            UpdateFromModel();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            model.setValueB(Convert.ToInt32(textBox2.Text));
            UpdateFromModel();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.setValueB(Decimal.ToInt32(numericUpDown2.Value));
            UpdateFromModel();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            model.setValueB(Decimal.ToInt32(trackBar2.Value));
            UpdateFromModel();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            model.setValueC(Convert.ToInt32(textBox3.Text));
            UpdateFromModel();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            model.setValueC(Decimal.ToInt32(numericUpDown3.Value));
            UpdateFromModel();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            model.setValueC(Decimal.ToInt32(trackBar3.Value));
            UpdateFromModel();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.valueA = model.getValueA();
            Properties.Settings.Default.valueB = model.getValueC();
            Properties.Settings.Default.valueC = model.getValueC();
            Properties.Settings.Default.Save();
        }
    }
}
