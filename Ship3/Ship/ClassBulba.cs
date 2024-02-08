using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship
{
    class ClassBulba
    {
        DataTable Table1 = new DataTable();//Таблица  из правил 3.10.3.8.1-1
        DataTable Table2 = new DataTable();//Таблица  из правил 3.10.3.8.1-2
        DataTable Table3 = new DataTable();//Таблица  из правил 3.10.3.8.1-3
        DataTable vm2Table = new DataTable();//таблица расчета vm
        DataTable ulTable = new DataTable();//таблица расчета um
        DataTable VTable = new DataTable();//Высота распределения ледовой нагрузки
        string classLedokol = "Arc5"; // класс ледокола
      //  string classLedokol = "Ice1"; // класс ледокола
                                      // int accuracy = 8; // точность после запятой
                                      //int delta=15000; //дельта
        public int delta;
        double kdelta;
        double[] alfa;
        double[] betta;

        public ClassBulba()
        {
            Table1.Clear();
            Table1.Columns.Add("Name");
            Table1.Columns.Add("Ice1");
            Table1.Columns.Add("Ice2");
            Table1.Columns.Add("Ice3");
            Table1.Columns.Add("Arc4");
            Table1.Columns.Add("Arc5");
            Table1.Columns.Add("Arc6");
            Table1.Columns.Add("Arc7");
            //Table1.Rows.Add(new object[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            Table1.Rows.Add(new object[] {"Piref", 1120, 1460, 1810, 3620, 5910, 10360, 16020 });
            Table1.Rows.Add(new object[] { "Bh", null, null, null, 1.5, 2.0, 3.7, 4.8 });
            Table1.Rows.Add(new object[] { "Biref", 0.65, 0.80, 1.00, null, null, null, null });
            Table1.Rows.Add(new object[] { "Liref", 12.05, 14.22, 13.94, 4.55, 4.52, 4.39, 4.23});

            Table2.Clear();
            Table2.Columns.Add("Name");
            Table2.Columns.Add("Ice1");
            Table2.Columns.Add("Ice2");
            Table2.Columns.Add("Ice3");
            Table2.Columns.Add("Arc4");
            Table2.Columns.Add("Arc5");
            Table2.Columns.Add("Arc6");
            Table2.Columns.Add("Arc7");
           // Table2.Rows.Add(new object[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            Table2.Rows.Add(new object[] { "b0v", 1.015, 1.020, 1.008, 0.728, 0.754, 0.790, 0.820 });
            Table2.Rows.Add(new object[] { "b1v", -5.829, -5.975, -5.679, -3.758, -4.790, -6.170, -7.269 });
            Table2.Rows.Add(new object[] { "b2v", 0.035, 0.036, 0.037, 0.021, 0.021, 0.020, 0.018 });
            Table2.Rows.Add(new object[] { "b11v", 14.57, 15.06, 13.46, 20.50, 24.90, 32.21, 37.65 });
            Table2.Rows.Add(new object[] { "b22v", -0.0003, -0.0003, -0.0003, -0.0003, -0.0002, -0.0002, -0.0002 });
            Table2.Rows.Add(new object[] { "b12v", -0.0393, -0.0404, -0.0481, 0.0688, 0.0917, 0.1188, 0.1414 });

            Table3.Clear();
            Table3.Columns.Add("Name");
            Table3.Columns.Add("Ice1");
            Table3.Columns.Add("Ice2");
            Table3.Columns.Add("Ice3");
            Table3.Columns.Add("Arc4");
            Table3.Columns.Add("Arc5");
            Table3.Columns.Add("Arc6");
            Table3.Columns.Add("Arc7");
            // Table3.Rows.Add(new object[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            Table3.Rows.Add(new object[] { "b0u", 0.167, 0.155, 0.139, 0.307, 0.302, 0.324, 0.320 });
            Table3.Rows.Add(new object[] { "b1u", -3.297, -3.318, -2.607, 0.205, 0.325, 0.294, 0.313 });
            Table3.Rows.Add(new object[] { "b2u", 0.0231, 0.0216, 0.0222, 0.0370, 0.0375, 0.0363, 0.037 });
            Table3.Rows.Add(new object[] { "b11u", 17.4, 17.9, 15.02, 2.37, 1.78,1.17, 1.27 });
            Table3.Rows.Add(new object[] { "b22u", -0.0003, -0.0003, -0.0003, -0.0002, -0.0003, -0.0002, -0.0003 });
            Table3.Rows.Add(new object[] { "b12u", 0.153, 0.165, 0.152, 0.031, 0.030, 0.030, 0.028 });

            //таблица расчета vm
            vm2Table.Clear();
            vm2Table.TableName = "vm2Table";
            vm2Table.Columns.Add("X");
            vm2Table.Columns.Add("Vm");
            vm2Table.Columns.Add("Alfa");
            vm2Table.Columns.Add("Pmai");

            //таблица расчета um
            ulTable.Clear();
            ulTable.TableName = "vm2Table";
            ulTable.Columns.Add("X");
            ulTable.Columns.Add("Ul");
            ulTable.Columns.Add("Alfa");
            ulTable.Columns.Add("la");

            //таблица расчета um
            VTable.Clear();
            VTable.TableName = "VTable";
            VTable.Columns.Add("X");
            VTable.Columns.Add("BA");
            VTable.Columns.Add("Alfa");
            //VTable.Columns.Add("la");

        }
        public void SetAngle(double[] _alfa, double[] _betta, int _delta, string _classLedokol)
        {
            alfa = _alfa;
            betta = _betta;
            delta = _delta;
            classLedokol = _classLedokol;
            kdelta = Math.Pow(delta / 1000, 0.33333333);
            if (kdelta > 3.5) kdelta = 3.5;
        }
        public void start()
        {
            if ((classLedokol == "Arc8") | (classLedokol == "Arc9"))
            { }
            else
            {
                vm2Table.Clear();
                Vm(0, alfa);

                ulTable.Clear();
                Ul(0, alfa);

                VTable.Clear();
                BA(0, alfa);
            }
            //double L = 20;
            //  double x = 0;
        }
        public DataTable showVm2()
        {
            return vm2Table;
        }
        public DataTable showUl()
        {
            return ulTable;
        }
        public DataTable showBA()
        {
            return VTable;
        }
        private void Vm(double x, double[] alfa) // расчет значений Vm
        {
            x = 0;
            double vm = 0;
            double Pmai = 0;
            double stepen = 0;
            double koef = 0;
            if (classLedokol.IndexOf("Arc")>=0 )
            {
                stepen = 0.0614;
                koef = 0.790;
            }
            if (classLedokol.IndexOf("Ice") >= 0)
            {
                stepen = 0.0052;
                koef = 0.976;
            }

            for (int i = 0; i < alfa.Count(); i++)
            {
                double b0 = Convert.ToDouble(Table2.Rows[0][classLedokol]);
                double b1 = Convert.ToDouble(Table2.Rows[1][classLedokol]);
                double b2 = Convert.ToDouble(Table2.Rows[2][classLedokol]);
                double b11 = Convert.ToDouble(Table2.Rows[3][classLedokol]);
                double b22 = Convert.ToDouble(Table2.Rows[4][classLedokol]);
                double b12 = Convert.ToDouble(Table2.Rows[5][classLedokol]);
                var prefi= Convert.ToDouble(Table1.Rows[0][classLedokol]);

                vm =b0 + (b1 * x) + (b2 * alfa[i]) + (b11 * Math.Pow(x, 2)) + (b22 * Math.Pow(alfa[i], 2)) + (b12 * x * alfa[i]);
                Pmai = koef * prefi * vm * (Math.Pow((delta / 1000.0), stepen));
                vm2Table.Rows.Add(new object[] { x, vm, alfa[i], Pmai });/////
                x += 0.025;
                x = Math.Round(x, 4);
            }
        }

        //Высота распределения  нагрузки
        private void BA(double x, double[] alfa)
        {
            x = 0;
            if (classLedokol.IndexOf("Arc") >= 0)
            {
                var bh = Convert.ToDouble(Table1.Rows[1][classLedokol]);
                for (int i = 0; i < alfa.Count(); i++)
                {
                    VTable.Rows.Add(new object[] { x, bh, alfa[i] });
                    x += 0.025;
                    x = Math.Round(x, 4);

                }
            }
            if (classLedokol.IndexOf("Ice") >= 0)
            {
 
                for (int i = 0; i < alfa.Count(); i++)
                {
                    var b0 = Convert.ToDouble(Table3.Rows[0][classLedokol]);
                    var b1 = Convert.ToDouble(Table3.Rows[1][classLedokol]);
                    var b11 = Convert.ToDouble(Table3.Rows[3][classLedokol]);
                    var brefi = Convert.ToDouble(Table1.Rows[2][classLedokol]);
                    var ub = b0 + (b1 * x) + (b11 * Math.Pow(x, 2));
                    var ba = ub * brefi;
                    VTable.Rows.Add(new object[] { x, ba, alfa[i]});
                    x += 0.025;
                    x = Math.Round(x, 4);
                }
            }

            





        }

        //Длина распределения ледовой нагрузки
        private void Ul(double x, double[] alfa) // расчет значений Vm
        {
            x = 0;
            double um = 0;
            double La = 0;
            double stepen = 0;
            double koef = 0;
            if (classLedokol.IndexOf("Arc") >= 0)
            {
                stepen = 0.2906;
                koef = 0.337;
            }
            if (classLedokol.IndexOf("Ice") >= 0)
            {
                stepen = 0.3311;
                koef = 0.218;
            }

            for (int i = 0; i < alfa.Count(); i++)
            {
                var b0 = Convert.ToDouble(Table3.Rows[0][classLedokol]);
                var b1 = Convert.ToDouble(Table3.Rows[1][classLedokol]);
                var b2 = Convert.ToDouble(Table3.Rows[2][classLedokol]);
                var b11 = Convert.ToDouble(Table3.Rows[3][classLedokol]);
                var b22 = Convert.ToDouble(Table3.Rows[4][classLedokol]);
                var b12 = Convert.ToDouble(Table3.Rows[5][classLedokol]);
                var lrefi = Convert.ToDouble(Table1.Rows[3][classLedokol]);

                um = b0 + (b1 * x) + (b2 * alfa[i]) + (b11 * Math.Pow(x, 2)) + (b22 * Math.Pow(alfa[i], 2)) + (b12 * x * alfa[i]);
                double temp = (Math.Pow((delta / 1000.0), stepen));
                La = koef * lrefi * um * temp;
                ulTable.Rows.Add(new object[] { x, um, alfa[i], La });
                x += 0.025;
                x = Math.Round(x, 4);
            }
        }
    }
}
