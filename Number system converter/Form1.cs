using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number_system_converter
{
    public partial class Form1 : Form
    {
        public About_Form about_Form;
        protected NumberSystem selectedNumberSystem;
        protected bool inputAlreadyHasPoint = false;
        protected bool copyPasteActive = false;

        public NumberSystem SelectedNumberSystem { get => selectedNumberSystem; }

        public Form1()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 2;
            textBox1.KeyPress += KeyPressedEvent;
            textBox1.KeyDown += CopyPasteTest;
            //System.Diagnostics.Process.Start(@"cmd.exe");//, @"/k c:\path\my.exe");
            //Console.WriteLine("EFEF");
            //ProcessStartInfo psi = new ProcessStartInfo(cmdexePath, cmdArguments);
            //consoleProcess = new Process();
            //consoleProcess.StartInfo = psi;
            //consoleProcess.Start();

            //this.MainMenuStrip.BackColor = Color.FromArgb(4, 13, 21);
        }


        public void UpdateConvertedOutputs()
        {
            //string input = textBox1.Text;

            //if (input.Length != 0)
            //{
            //    switch (selectedNumberSystem)
            //    {
            //        case NumberSystem.Binary:
            //            binaryOutput.Text = NumberConverter.Convert(textBox1.Text, selectedNumberSystem, NumberSystem.Binary);
            //            //NumberConverter.ConvertToDecimal(input, selectedNumberSystem);
            //            break;
            //        case NumberSystem.Octal:
            //            octalOutput.Text = NumberConverter.Convert(textBox1.Text, selectedNumberSystem, NumberSystem.Octal);
            //            //NumberConverter.ConvertToDecimal(input, selectedNumberSystem);
            //            break;
            //        case NumberSystem.Decimal:
            //            decimalOutput.Text = NumberConverter.Convert(textBox1.Text, selectedNumberSystem, NumberSystem.Decimal);
            //            break;
            //        case NumberSystem.Hexadecimal:
            //            hexadecimalOutput.Text = NumberConverter.Convert(textBox1.Text, selectedNumberSystem, NumberSystem.Hexadecimal);
            //            break;
            //        default:
            //            break;
            //    }
            //}

            Debug.WriteLine("Текущее значение ввода: " + textBox1.Text);
            binaryOutput.Text = NumberConverter.Convert(textBox1.Text, selectedNumberSystem, NumberSystem.Binary);
            octalOutput.Text = NumberConverter.Convert(textBox1.Text, selectedNumberSystem, NumberSystem.Octal);
            decimalOutput.Text = NumberConverter.Convert(textBox1.Text, selectedNumberSystem, NumberSystem.Decimal);
            hexadecimalOutput.Text = NumberConverter.Convert(textBox1.Text, selectedNumberSystem, NumberSystem.Hexadecimal);
        }

        private void KeyPressedEvent(object sender, KeyPressEventArgs e)
        {
            bool desidedHandle = false;
            if (textBox1.Text.Contains(",") || textBox1.Text.Contains("."))
                inputAlreadyHasPoint = true;
            else inputAlreadyHasPoint = false;

            if (NumberConverter.DoesSystemHasLetter(e.KeyChar, selectedNumberSystem) == false)
                desidedHandle = true;
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (inputAlreadyHasPoint == false)
                    inputAlreadyHasPoint = true;
                else desidedHandle = true;
            }
            else if (e.KeyChar == '\b')
                desidedHandle = false;
            if (copyPasteActive)
                desidedHandle = false;
            e.Handled = desidedHandle;
        }

        private void CopyPasteTest(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Control && e.KeyCode == Keys.X) || (e.Control && e.KeyCode == Keys.V))
                copyPasteActive = true;
            else copyPasteActive = false;
        }

        public void ClearAll()
        {
            textBox1.Text = "";
            inputAlreadyHasPoint = false;
            UpdateConvertedOutputs();
        }


        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ОПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            about_Form = new About_Form();
            about_Form.Show();
        }

        private void MainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateConvertedOutputs();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    selectedNumberSystem = NumberSystem.Binary;
                    break;
                case 1:
                    selectedNumberSystem = NumberSystem.Octal;
                    break;
                case 2:
                    selectedNumberSystem = NumberSystem.Decimal;
                    break;
                case 3:
                    selectedNumberSystem = NumberSystem.Hexadecimal;
                    break;

                default:
                    break;
            }
            Debug.WriteLine("Текущий индекс системы исчисления: " + comboBox1.SelectedIndex);

            ClearAll();
        }
        
    }
}
