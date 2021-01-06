using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string filename;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)| *.txt | All files(*.*) | *.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        //открытие файла
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            return;
            filename = openFileDialog1.FileName;
            string fileText = File.ReadAllText(filename);
            richTextBox1.Text = fileText;
        }

        //сохранение файла
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(filename))
            {
                //сохранить
                File.WriteAllText(filename, richTextBox1.Text);
            }

            else
            {
                //сохранить как
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                filename = saveFileDialog1.FileName;// получаем выбранный файл
                File.WriteAllText(filename, richTextBox1.Text);// сохраняем текст в файл
            }
        }

        //сохранить как
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            File.WriteAllText(filename, richTextBox1.Text);
        }

        //шрифт
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog FontDialog1 = new FontDialog();
            FontDialog1.Font = richTextBox1.Font;//для запоминания  шрифта
            if (DialogResult.OK == FontDialog1.ShowDialog())
            {
                richTextBox1.Font = FontDialog1.Font;//установление шрифта
            }
        }

        //цвет фона
        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog backgroundColorDialog = new ColorDialog();
            backgroundColorDialog.Color = richTextBox1.BackColor;
            if (backgroundColorDialog.ShowDialog() == DialogResult.OK)
                richTextBox1.BackColor = backgroundColorDialog.Color;
        }

        //о программе 
        private void aboutTheProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developer - Shalaeva Alina YGTU 2020");
        }

        //выход
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                 "Не сохраненные данные будут потеряны ",
                 "Сообщение",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Information,
                 MessageBoxDefaultButton.Button1,
                 MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog MyD = new ColorDialog();
            MyD.Color = richTextBox1.ForeColor;

            if (MyD.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = MyD.Color;
            }
        }
    }
}
