using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ship
{
    public partial class Form2_InputData : Form
    {
        public Form2_InputData()
        {
            InitializeComponent();
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //Utils.InputData.deltaV = 11;


        }
        private void Form2_InputData_Load(object sender, EventArgs e)
        {
            textBox1_1_1.Text = Utils.InputData1_1.name;
            textBox1_1_2.Text = Utils.InputData1_1.flag;
            textBox1_1_3.Text = Utils.InputData1_1.HomePort;
            textBox1_1_4.Text = Utils.InputData1_1.regNum;
            textBox1_1_5.Text = Utils.InputData1_1.signal;
            textBox1_1_6.Text = Utils.InputData1_1.IMO;
            textBox1_1_7.Text = Utils.InputData1_1.type;
            textBox1_1_8.Text = Utils.InputData1_1.placeOfConstruction;
            textBox1_1_9.Text = Utils.InputData1_1.dateOfConstruction;
            textBox1_1_10.Text = Utils.InputData1_1.VesselClass;
            textBox1_1_11.Text = Utils.InputData1_1.HomePort2;
            textBox1_1_12.Text = Utils.InputData1_1.Owner;
            textBox1_1_13.Text = Utils.InputData1_1.GrossCapacity;
            textBox1_1_17.Text = Utils.InputData1_1.Type_of_main_mechanisms;
            textBox1_1_18.Text = Utils.InputData1_1.sumMex;


            textBox1_2_1.Text = Utils.InputData1_2.deltaV.ToString();
            textBox1_2_2.Text = Utils.InputData1_2.V.ToString();
            textBox1_2_3.Text = Utils.InputData1_2.Loa.ToString();
            textBox1_2_4.Text = Utils.InputData1_2.Lwl.ToString();
            textBox1_2_5.Text = Utils.InputData1_2.Lbr.ToString();
            textBox1_2_6.Text = Utils.InputData1_2.L.ToString();
            textBox1_2_7.Text = Utils.InputData1_2.Lll.ToString();
            textBox1_2_8.Text = Utils.InputData1_2.B.ToString();
            textBox1_2_9.Text = Utils.InputData1_2.D.ToString();
            textBox1_2_10.Text = Utils.InputData1_2.d.ToString();
            textBox1_2_11.Text = Utils.InputData1_2.ds.ToString();
            textBox1_2_12.Text = Utils.InputData1_2.Cb.ToString();
            textBox1_2_13.Text = Utils.InputData1_2.Cw.ToString();
            textBox1_2_14.Text = Utils.InputData1_2.Cm.ToString();
            textBox1_2_15.Text = Utils.InputData1_2.zP.ToString();
            textBox1_2_16.Text = Utils.InputData1_2.zR.ToString();

            textBox1_3_1.Text = Utils.InputData1_3.PCRG.ToString();
            textBox1_3_2.Text = Utils.InputData1_3.vS.ToString();
            textBox1_3_3.Text = Utils.InputData1_3.tSA.ToString();
            textBox1_3_4.Text = Utils.InputData1_3.RS.ToString();
            textBox1_3_5.Text = Utils.InputData1_3.h3.ToString();
            textBox1_3_6.Text = Utils.InputData1_3.q.ToString();



            dataGridView1.DataSource = Utils.InputData1_4.Table1_4;

            textBox1_5_1.Text = Utils.InputData1_56.p.ToString();
            textBox1_5_2.Text = Utils.InputData1_56.g.ToString();
            textBox1_6_1.Text = Utils.InputData1_56.h3.ToString();
            textBox1_6_2.Text = Utils.InputData1_56.q.ToString();

            dataGridView2.DataSource = Utils.InputData1_7.Table1_7;

        }
        private bool chek1_2(bool rez)
        {
            
            if (Convert.ToDouble(textBox1_2_4.Text) > Convert.ToDouble(textBox1_2_3.Text))
            {
                MessageBox.Show("Длина по КВЛ не должна превышать длину наибольшую", "Ошибка", MessageBoxButtons.OK);
                textBox1_2_4.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }
            else
            {
                textBox1_2_4.ForeColor = System.Drawing.SystemColors.WindowText;
            }

            if (Convert.ToDouble(textBox1_2_5.Text) > Convert.ToDouble(textBox1_2_3.Text))
            {
                MessageBox.Show("Длина между перпендикулярами не должна превышать длину наибольшую", "Ошибка", MessageBoxButtons.OK);
                textBox1_2_5.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }
            else
            {
                textBox1_2_5.ForeColor = System.Drawing.SystemColors.WindowText;
            }

            if ((Convert.ToDouble(textBox1_2_6.Text) >= 12) & (Convert.ToDouble(textBox1_2_6.Text) <= 350))
            {
                textBox1_2_6.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Длина по Правилам должна быть в диапазоне значений 12-350", "Ошибка", MessageBoxButtons.OK);
                textBox1_2_6.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }

            if (Convert.ToDouble(textBox1_2_7.Text) > Convert.ToDouble(textBox1_2_3.Text))
            {
                MessageBox.Show("Длина в соответствии с Международной конвенцией не должна превышать длину наибольшую", "Ошибка", MessageBoxButtons.OK);
                textBox1_2_7.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }
            else
            {
                textBox1_2_7.ForeColor = System.Drawing.SystemColors.WindowText;
            }

            if ((Convert.ToDouble(textBox1_2_8.Text) >= 1.58) & (Convert.ToDouble(textBox1_2_8.Text) <= 60.87))
            {
                textBox1_2_8.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Ширина должна быть в диапазоне значений 1.58-60.87", "Ошибка", MessageBoxButtons.OK);
                textBox1_2_8.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }

            if ((Convert.ToDouble(textBox1_2_9.Text) >= 0.52) & (Convert.ToDouble(textBox1_2_9.Text) <= 19.44))
            {
                textBox1_2_9.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Высота борта должна быть в диапазоне значений 0.52-19.44", "Ошибка", MessageBoxButtons.OK);
                textBox1_2_9.ForeColor = System.Drawing.Color.Red;
                rez = false;

            }
            if (Convert.ToDouble(textBox1_2_12.Text) <= 1)
            {
                textBox1_2_12.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Коеффициент должен быть меньше 1", "Ошибка", MessageBoxButtons.OK);
                textBox1_2_12.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }
            if (Convert.ToDouble(textBox1_2_13.Text) <= 1)
            {
                textBox1_2_13.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Коеффициент должен быть меньше 1", "Ошибка", MessageBoxButtons.OK);
                textBox1_2_13.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }
            if (Convert.ToDouble(textBox1_2_14.Text) <= 1)
            {
                textBox1_2_14.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Коеффициент должен быть меньше 1", "Ошибка", MessageBoxButtons.OK);
                textBox1_2_14.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }
            if ((Convert.ToDouble(textBox1_2_15.Text) >= 0) & (Convert.ToDouble(textBox1_2_15.Text) <= 4))
            {
                textBox1_2_15.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Число валов/гребных винтов должно быть в диапазоне значений 0-4", "Ошибка", MessageBoxButtons.OK);
                textBox1_2_15.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }
            if ((Convert.ToDouble(textBox1_2_16.Text) >= 0) & (Convert.ToDouble(textBox1_2_16.Text) <= 4))
            {
                textBox1_2_16.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Число рулей должно быть в диапазоне значений 0-4", "Ошибка", MessageBoxButtons.OK);
                textBox1_2_16.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }

            return rez;
        }

        private bool chek1_3(bool rez)
        {
            //bool rez = rez;
            if ((Convert.ToDouble(textBox1_3_1.Text) >= 0) )
            {
                textBox1_3_1.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Груз перевозимый должен быть больше 0", "Ошибка", MessageBoxButtons.OK);
                textBox1_3_1.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }
            if ((Convert.ToDouble(textBox1_3_2.Text) <=35))
            {
                textBox1_3_2.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Расчетная скорость хода на прямом курсе должна быть меньше 35", "Ошибка", MessageBoxButtons.OK);
                textBox1_3_2.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }
            if ((Convert.ToDouble(textBox1_3_3.Text) >= 0))
            {
                textBox1_3_3.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Продолжительность автономного рейса должен быть больше 0", "Ошибка", MessageBoxButtons.OK);
                textBox1_3_3.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }
            if ((Convert.ToDouble(textBox1_3_4.Text) >= 0))
            {
                textBox1_3_4.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Максимальная дальность плавания  должна быть больше 0", "Ошибка", MessageBoxButtons.OK);
                textBox1_3_4.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }
            if ((Convert.ToDouble(textBox1_3_5.Text) >= 0) & (Convert.ToDouble(textBox1_3_5.Text) <= 8.5))
            {
                textBox1_3_5.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Высота волны 3%-ой обеспеченности должна быть в диапазоне значений 0-8.5", "Ошибка", MessageBoxButtons.OK);
                textBox1_3_5.ForeColor = System.Drawing.Color.Red;
                rez = false;

            }
            if ((Convert.ToDouble(textBox1_3_6.Text) >= 119) & (Convert.ToDouble(textBox1_3_6.Text) <= 504))
            {
                textBox1_3_6.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Расчетный скоростной напор ветра в шквале должна быть в диапазоне значений 119-504", "Ошибка", MessageBoxButtons.OK);
                textBox1_3_6.ForeColor = System.Drawing.Color.Red;
                rez = false;

            }
            return rez;


        }

        private bool chek1_56(bool rez)
        {
            if ((Convert.ToDouble(textBox1_5_1.Text) >= 1) & (Convert.ToDouble(textBox1_5_1.Text) <= 1.025))
            {
                textBox1_5_1.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Плотность морской воды должна быть в диапазоне значений 1-1.025", "Ошибка", MessageBoxButtons.OK);
                textBox1_5_1.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }
            if (Convert.ToDouble(textBox1_5_2.Text) == 9.81) 
            {
                textBox1_5_2.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Ускорение свободного падения должна быть 9.81", "Ошибка", MessageBoxButtons.OK);
                textBox1_5_2.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }

            if ((Convert.ToDouble(textBox1_6_1.Text) >= 0) & (Convert.ToDouble(textBox1_6_1.Text) <= 8.5))
            {
                textBox1_6_1.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Высота волны 3%-ой обеспеченности должна быть в диапазоне значений 0-8.5", "Ошибка", MessageBoxButtons.OK);
                textBox1_6_1.ForeColor = System.Drawing.Color.Red;
                rez = false;
            }
            if ((Convert.ToDouble(textBox1_6_2.Text) >= 119) & (Convert.ToDouble(textBox1_6_2.Text) <= 504))
            {
                textBox1_6_2.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else
            {
                MessageBox.Show("Расчетный скоростной напор ветра в шквале должна быть в диапазоне значений 119-504", "Ошибка", MessageBoxButtons.OK);
                textBox1_6_2.ForeColor = System.Drawing.Color.Red;
                rez = false;

            }

            return rez;
        }
       
        private void button1_2_Save_Click(object sender, EventArgs e)
        {
            bool rez = true;
            rez = chek1_2(rez);
            rez = chek1_3(rez);
            rez = chek1_56(rez);
            if (rez)
            {
                Utils.InputData1_1.name = textBox1_1_1.Text;
                Utils.InputData1_1.flag = textBox1_1_2.Text;
                Utils.InputData1_1.HomePort = textBox1_1_3.Text;
                Utils.InputData1_1.regNum = textBox1_1_4.Text;
                Utils.InputData1_1.signal = textBox1_1_5.Text;
                Utils.InputData1_1.IMO = textBox1_1_6.Text;
                Utils.InputData1_1.type = textBox1_1_7.Text;
                Utils.InputData1_1.placeOfConstruction = textBox1_1_8.Text;
                Utils.InputData1_1.dateOfConstruction = textBox1_1_9.Text;
                Utils.InputData1_1.VesselClass = textBox1_1_10.Text;
                Utils.InputData1_1.HomePort2 = textBox1_1_11.Text;
                Utils.InputData1_1.Owner = textBox1_1_12.Text;
                Utils.InputData1_1.GrossCapacity = textBox1_1_13.Text;
                Utils.InputData1_1.Type_of_main_mechanisms = textBox1_1_17.Text;
                Utils.InputData1_1.sumMex = textBox1_1_18.Text;


                Utils.InputData1_2.deltaV = Convert.ToDouble(textBox1_2_1.Text);
                Utils.InputData1_2.V = Convert.ToDouble(textBox1_2_2.Text);
                Utils.InputData1_2.Loa = Convert.ToDouble(textBox1_2_3.Text);
                Utils.InputData1_2.Lwl = Convert.ToDouble(textBox1_2_4.Text);
                Utils.InputData1_2.Lbr = Convert.ToDouble(textBox1_2_5.Text);
                Utils.InputData1_2.L = Convert.ToDouble(textBox1_2_6.Text);
                Utils.InputData1_2.Lll = Convert.ToDouble(textBox1_2_7.Text);
                Utils.InputData1_2.B = Convert.ToDouble(textBox1_2_8.Text);
                Utils.InputData1_2.D = Convert.ToDouble(textBox1_2_9.Text);
                Utils.InputData1_2.d = Convert.ToDouble(textBox1_2_10.Text);
                Utils.InputData1_2.ds = Convert.ToDouble(textBox1_2_11.Text);
                Utils.InputData1_2.Cb = Convert.ToDouble(textBox1_2_12.Text);
                Utils.InputData1_2.Cw = Convert.ToDouble(textBox1_2_13.Text);
                Utils.InputData1_2.Cm = Convert.ToDouble(textBox1_2_14.Text);
                Utils.InputData1_2.zP = Convert.ToInt32(textBox1_2_15.Text);
                Utils.InputData1_2.zR = Convert.ToInt32(textBox1_2_16.Text);

                Utils.InputData1_3.PCRG = Convert.ToDouble(textBox1_3_1.Text);
                Utils.InputData1_3.vS = Convert.ToDouble(textBox1_3_2.Text);
                Utils.InputData1_3.tSA = Convert.ToDouble(textBox1_3_3.Text);
                Utils.InputData1_3.RS = Convert.ToDouble(textBox1_3_4.Text);
                Utils.InputData1_3.h3 = Convert.ToDouble(textBox1_3_5.Text);
                Utils.InputData1_3.q = Convert.ToDouble(textBox1_3_6.Text);

                Utils.InputData1_56.p = Convert.ToDouble(textBox1_5_1.Text);
                Utils.InputData1_56.g = Convert.ToDouble(textBox1_5_2.Text);
                Utils.InputData1_56.h3 = Convert.ToDouble(textBox1_6_1.Text);
                Utils.InputData1_56.q = Convert.ToDouble(textBox1_6_2.Text);
                Close();
            }
           // if (Utils.InputData.rez)
             //   

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_5_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 

            if (e.KeyChar == ',') e.KeyChar = '.';
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 46 && number != 45) // цифры, клавиша BackSpace и точка, запятая, минус
            {
                e.Handled = true;
            }
           
        }

        private void textBox1_5_2_TextChanged(object sender, EventArgs e) //удаление второй точки
        {
            //var ttt = (TextBox)sender;
            //string tmp = ttt.Text.Trim();
            //string outS = string.Empty;
            //bool zapyataya = true;

            //foreach (char ch in tmp)
            //    if (Char.IsDigit(ch) || (ch == '.' && zapyataya))
            //    {
            //        outS += ch;
            //        if (ch == '.')
            //            zapyataya = false;
            //    }

            //ttt.Text = outS;
            //ttt.SelectionStart = outS.Length;
        }

        private void button_insert_Click(object sender, EventArgs e)
        {
            DataRow row = Utils.InputData1_7.Table1_7.NewRow();
            row["X"] = "null";
            row["Y"] = "null";
            Utils.InputData1_7.Table1_7.Rows.InsertAt(row, Convert.ToInt32(textBox1.Text));
        }
    }
}
