using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab01_OOP
{
    public partial class Form1 : Form
    {
        private List<double> memory;

        public Form1()
        {
            InitializeComponent();
            
            memory = new List<double>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double value;
                value = Convert.ToDouble(textBox1.Text);

                switch (comboBox1.Text)
                {
                    case "sin":
                        textBox2.Text = Convert.ToString(Math.Sin(value));
                        break;
                    case "cos":
                        textBox2.Text = Convert.ToString(Math.Cos(value));
                        break;
                    case "tang":
                        textBox2.Text = Convert.ToString(Math.Tan(value));
                        break;
                    case "корень квадратный":
                        if (value > 0)
                        {
                            textBox2.Text = Convert.ToString(Math.Pow(value, 1.0 / 2.0));
                        }
                        else 
                        {
                            throw new Exception("Нельзя найти корень от отрицательного числа");
                        }
                        break;
                    case "корень кубический":
                        if (value > 0)
                        {
                            textBox2.Text = Convert.ToString(Math.Pow(value, 1.0 / 3.0));
                        }
                        else
                        {
                            throw new Exception("Нельзя найти корень от отрицательного числа");
                        }
                        break;
                    case "ряд возведений в степень":
                        textBox2.Clear();
                        int numberOfTerms = 9;
                        for (int i = 1; i <= numberOfTerms; i++)
                        {
                            textBox2.Text += Convert.ToString(Math.Pow(value, i));
                            if (i < numberOfTerms)
                            {
                                textBox2.Text += ", ";
                            }
                        }
                        break;
                    default:
                        this.comboBox1.BackColor = ColorTranslator.FromHtml("#f57a7a");
                        throw new Exception("Не выбранна операция");
                }
            }
            catch (FormatException)
            {
                this.textBox1.BackColor = ColorTranslator.FromHtml("#f57a7a");
                MessageBox.Show("Неверный формат данных");
            }
            catch(Exception mes)
            {
                this.textBox1.BackColor = ColorTranslator.FromHtml("#f57a7a");
                MessageBox.Show("Ошибка: "+ mes.Message);
            }
            finally
            {
                this.comboBox1.BackColor = Color.White;
                this.textBox1.BackColor = Color.White;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    double value = double.Parse(textBox2.Text);
                    memory.Add(value);
                    comboBox2.Items.Add(value);
                    MessageBox.Show("Сохранено");

                }
                else
                    throw new Exception("Нет данных для сохранения");
            }
            catch (Exception mes)
            {
                this.textBox2.BackColor = ColorTranslator.FromHtml("#f57a7a");
                MessageBox.Show("Ошиба: " + mes.Message);
            }
            finally
            {
                this.textBox2.BackColor = Color.White;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                double selectedValue = (double)comboBox2.SelectedItem;
                textBox1.Text = selectedValue.ToString();
            }
        }

    }
}
