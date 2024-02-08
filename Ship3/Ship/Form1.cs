using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace Ship
{
    public partial class Form1 : Form
    {
       ClassRaschet ship= new();
        ClassBulba ship2 = new();
        // Utils.InputData InputData = new();
        PointF[] points2D = new PointF[50];
        //Graphics g;
        public int diam = 8;//диаметр элипсов на звеньях
        Pen p = new Pen(Color.Red, 3);
        Pen koord = new Pen(Color.Green, 3);
        

        double scale = 1;
        int mouseX;
        int mouseXmove;
        int mouseY;
        int mouseYmove;
        bool flag = false;
        
        public Form1()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Utils.InputData1_4.Table1_4.Columns.Add("Шпангоуты");
            Utils.InputData1_4.Table1_4.Columns.Add("Нагрузка");
            Utils.InputData1_4.Table1_4.Rows.Add(new object[] { "0-1", null });
            Utils.InputData1_4.Table1_4.Rows.Add(new object[] { "1-2", null });
            Utils.InputData1_4.Table1_4.Rows.Add(new object[] { "2-3", null });
            Utils.InputData1_4.Table1_4.Rows.Add(new object[] { "3-4", null });
            Utils.InputData1_4.Table1_4.Rows.Add(new object[] { "4-5", null });
            Utils.InputData1_4.Table1_4.Rows.Add(new object[] { "5-6", null });
            Utils.InputData1_4.Table1_4.Rows.Add(new object[] { "6-7", null });
            Utils.InputData1_4.Table1_4.Rows.Add(new object[] { "7-8", null });
            Utils.InputData1_4.Table1_4.Rows.Add(new object[] { "8-9", null });
            Utils.InputData1_4.Table1_4.Rows.Add(new object[] { "9-10", null });
            Utils.InputData1_4.Table1_4.Rows.Add(new object[] { "11-12", null });
            Utils.InputData1_4.Table1_4.Rows.Add(new object[] { "13-14", null });
            Utils.InputData1_4.Table1_4.Rows.Add(new object[] { "15-16", null });
            Utils.InputData1_4.Table1_4.Rows.Add(new object[] { "17-18", null });
            Utils.InputData1_4.Table1_4.Rows.Add(new object[] { "19-20", null });

            Utils.InputData1_7.Table1_7.Columns.Add("X");
            Utils.InputData1_7.Table1_7.Columns.Add("Y");

            Utils.InputData1_7.Table1_7.Rows.Add(new object[] { "0", "0" });
            Utils.InputData1_7.Table1_7.Rows.Add(new object[] { "-50", "50" });
            Utils.InputData1_7.Table1_7.Rows.Add(new object[] { "200", "50" });
            Utils.InputData1_7.Table1_7.Rows.Add(new object[] { "200", "100" });
            Utils.InputData1_7.Table1_7.Rows.Add(new object[] { "300", "100" });
            Utils.InputData1_7.Table1_7.Rows.Add(new object[] { "300", "50" });
            Utils.InputData1_7.Table1_7.Rows.Add(new object[] { "600", "50" });
            Utils.InputData1_7.Table1_7.Rows.Add(new object[] { "550", "0" });
            Utils.InputData1_7.Table1_7.Rows.Add(new object[] { "500", "-50" });
            Utils.InputData1_7.Table1_7.Rows.Add(new object[] { "50", "-50" });


            // points2D= Convert.ToDouble(Utils.InputData1_7.Table1_7.Rows[3][2]);
            
            //g = pictureBox1.CreateGraphics();
            //g.TranslateTransform(100, pictureBox1.Height / 2);
            //g.ScaleTransform(1, -1);

        }
              

        private void button2_Click(object sender, EventArgs e)
        {
            Utils.saveTable(@"Vm.csv", ship.showVm()); //сохранить таблицу в файл
            Utils.saveTable(@"Um.csv", ship.showUm()); //сохранить таблицу в файл
            Utils.saveTable(@"TableNagruzka.csv", ship.showTableNagruzka()); //сохранить таблицу в файл
            Utils.saveTable(@"TableVisota.csv", ship.showTableVisota()); //сохранить таблицу в файл
            Utils.saveTable(@"TableDlina.csv", ship.showTableDlina()); //сохранить таблицу в файл

            Utils.saveTable(@"Vm2.csv", ship2.showVm2()); //сохранить таблицу в файл
            Utils.saveTable(@"Ul.csv", ship2.showUl()); //сохранить таблицу в файл
        }

        private void button_Raschet_Click(object sender, EventArgs e)
        {
            string phrase = textBox_Alfa.Text;
            string[] words = phrase.Split(';');
            double[] alfa = words.Select(x => double.Parse(x, CultureInfo.GetCultureInfo("en-US"))).ToArray();
      
            phrase = textBox_Betta.Text;
            words = phrase.Split(';');
            double[] betta = words.Select(x => double.Parse(x, CultureInfo.GetCultureInfo("en-US"))).ToArray();
                        
            ship.SetAngle(alfa, betta,Convert.ToInt32(textBox_Delta.Text),Utils.InputData1_1.type);
            ship.start();

            ship2.SetAngle(alfa, betta, Convert.ToInt32(textBox_Delta.Text), Utils.InputData1_1.type);
            ship2.start();
        }
        #region вывод таблиц на экран
             
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {        

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    dataGridView1.DataSource = ship.showVm();
                    break;
                case 1:
                    dataGridView1.DataSource = ship.showUm();
                    break;
                case 2:
                    dataGridView1.DataSource = ship.showTableNagruzka();
                    break;
                case 3:
                    dataGridView1.DataSource = ship.showTableVisota();
                    break;
                case 4:
                    dataGridView1.DataSource = ship.showTableDlina();
                    break;
                case 5:
                    dataGridView1.DataSource = ship2.showVm2();
                    break;
                case 6:
                    dataGridView1.DataSource = ship2.showBA();
                    break;
                case 7:
                    dataGridView1.DataSource = ship2.showUl();
                    break;
                default:

                    break;
            }

        }
        #endregion

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           // MessageBox.Show("Message", "Title", MessageBoxButtons.OKCancel);
        }

        private void button1_InputData_Click(object sender, EventArgs e)
        {
          //  Utils.InputData.deltaV = 11;
                
            //Form2_InputData SF = new Form2_InputData(InputData);

            ////Показываем форму. В данном конкретном случае все равно как показывать: с помощью метода Show() либо ShowDialog()
            //SF.ShowDialog();
          

            Form2_InputData frm = new Form2_InputData();
            //frm.Owner = this; //Передаём вновь созданной форме её владельца.
            frm.ShowDialog();
            
        }

        

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void vvodDannih_Click(object sender, EventArgs e)
        {

            Form2_InputData frm = new Form2_InputData();
            //frm.Owner = this; //Передаём вновь созданной форме её владельца.
            frm.ShowDialog();
           
        }

        private void button_picture_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Utils.InputData1_7.Table1_7.Rows.Count; i++)
            {
                points2D[i] = new PointF((float)Convert.ToDouble(Utils.InputData1_7.Table1_7.Rows[i][0]), (float)Convert.ToDouble(Utils.InputData1_7.Table1_7.Rows[i][1]));
            }
            pictureBox1.Invalidate(); 
            //Draw();
            label7.Visible = true;
            trackBar1.Visible = true;
        }

   

   

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            scale = trackBar1.Value / 100.0;
            label7.Text = String.Format("Масштаб {0} %", trackBar1.Value);
            pictureBox1.Invalidate(); 
            //Draw();
        }

        private void Draw()
        {
            //g.Clear(Color.White);
            //g.DrawPolygon(p, points2D);
            //for (int i = 0; i < Utils.InputData1_7.Table1_7.Rows.Count; i++)
            //{
            //    g.DrawEllipse(Pens.Gray, -diam / 2 + points2D[i].X, -diam / 2 + points2D[i].Y, (float)diam, (float)diam);// рисуем кружочки
            //    g.FillEllipse(new SolidBrush(Color.Gray), -diam / 2 + points2D[i].X, -diam / 2 + points2D[i].Y, (float)diam, (float)diam); //закрашиваем
            //}
            //for (int i = -200; i < 1000; i += 100)
            //{
            //    g.DrawLine(Pens.Gray, i, -150, i, 150);
            //    g.DrawLine(Pens.Gray, -150, i, 150, i);
                
            //}

        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            mouseX = x;
            mouseY = y;
            flag = true;
           //  MessageBox.Show(String.Format("X={0:f2}, Y={1:f2}", (x-100)/scale, (pictureBox1.Height-y- pictureBox1.Height / 2) / scale));
           //label8.Text = String.Format("Координаты X={0:f2}, Y={1:f2}", (x - 100) / scale, (pictureBox1.Height - y - pictureBox1.Height / 2) / scale);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                mouseXmove = e.X;
                mouseYmove = e.Y;
                pictureBox1.Invalidate();
                //Invalidate();
                //Draw();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            g.Clear(Color.White);
           // g.ResetTransform();
            //g = pictureBox1.CreateGraphics();
            g.TranslateTransform(100, pictureBox1.Height / 2);
            g.ScaleTransform(1, -1);
            g.ScaleTransform((float)scale, (float)scale);
            if (flag)
            {
                g.ResetTransform();
                g.TranslateTransform(100, pictureBox1.Height / 2);
                g.ScaleTransform(1, -1);
                Debug.WriteLine(mouseXmove - mouseX);
                g.TranslateTransform(mouseXmove - mouseX, mouseY - mouseYmove);
                g.ScaleTransform((float)scale, (float)scale);

            }
            
            g.DrawPolygon(p, points2D);
            for (int i = 0; i < Utils.InputData1_7.Table1_7.Rows.Count; i++)
            {
                g.DrawEllipse(Pens.Gray, -diam / 2 + points2D[i].X, -diam / 2 + points2D[i].Y, (float)diam, (float)diam);// рисуем кружочки
                g.FillEllipse(new SolidBrush(Color.Gray), -diam / 2 + points2D[i].X, -diam / 2 + points2D[i].Y, (float)diam, (float)diam); //закрашиваем
            }
            for (int i = -200; i < 1000; i += 100)
            {
                g.DrawLine(Pens.Gray, i, -1500, i, 1500);
                g.DrawLine(Pens.Gray, -1500, i, 1500, i);

            }
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
            koord.CustomEndCap = bigArrow;
           
            g.DrawLine(koord, 0, 0, 0, 100);
            g.DrawLine(koord, 0, 0, 100, 0);
            var GreenkC = new SolidBrush(Color.Green);// кисть
            g.DrawString("X", new Font("Arial", 12), GreenkC, 100, 0);
            g.RotateTransform(180);
            g.DrawString("Y", new Font("Arial", 12), GreenkC, 0+10, -100);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Point p = pictureBox1.PointToClient(Cursor.Position);
            label8.Text = String.Format("Координаты X={0:f2}, Y={1:f2}", (p.X - 100) / scale, (pictureBox1.Height - p.Y - pictureBox1.Height / 2) / scale);
            
        }
    }
}
