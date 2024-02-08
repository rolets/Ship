using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship
{
    public class ClassRaschet
    {
        DataTable TableA = new DataTable();//Ледовый класс  Таблица 3.10.3.2.1
        DataTable TableC = new DataTable();//Ледовый класс  Таблица 3.10.3.3.1

        DataTable vmTable = new DataTable();//таблица расчета vm
        DataTable umTable = new DataTable();
        DataTable TableNagruzka = new DataTable();//таблица расчета Интенсивность  нагрузки
        DataTable TableVisota = new DataTable();//таблица расчета Высота
        DataTable TableDlina = new DataTable();//таблица расчета Длина
        string classLedokol = "Arc5"; // класс ледокола
        int accuracy = 8; // точность после запятой
        //int delta=15000; //дельта
        public int delta;
        double kdelta;
        double[] alfa;
        double[] betta;


        public ClassRaschet()
        {
        #region Инициализация таблиц
            //Ледовый класс  Таблица 3.10.3.2.1
            TableA.Clear();
            TableA.Columns.Add("Koef");
            TableA.Columns.Add("Ice1");
            TableA.Columns.Add("Ice2");
            TableA.Columns.Add("Ice3");
            TableA.Columns.Add("Arc4");
            TableA.Columns.Add("Arc5");
            TableA.Columns.Add("Arc6");
            TableA.Columns.Add("Arc7");
            TableA.Columns.Add("Arc8");
            TableA.Columns.Add("Arc9");

            //DataRow _ravi = dt.NewRow();
            //_ravi["Koef"] = "1";
            //_ravi["Ice1"] = "0.36";
            //_ravi["Ice2"] = "0.49";
            //dt.Rows.Add(_ravi);

            TableA.Rows.Add(new object[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            TableA.Rows.Add(new object[] { 1, 0.36, 0.49, 0.61, 0.79, 1.15, 1.89, 2.95, 5.30, 7.90 });
            TableA.Rows.Add(new object[] { 2, null, null, null, 0.80, 1.17, 1.92, 3.06, 5.75, 8.95 });
            TableA.Rows.Add(new object[] { 3, null, 0.22, 0.33, 0.50, 0.78, 1.20, 1.84, 3.7, 5.6 });
            TableA.Rows.Add(new object[] { 4, null, 0.50, 0.63, 0.75, 0.87, 1.00, 0.75, 0.75, 0.75 });

            TableC.Clear();
            TableC.Columns.Add("Koef");
            TableC.Columns.Add("Ice1");
            TableC.Columns.Add("Ice2");
            TableC.Columns.Add("Ice3");
            TableC.Columns.Add("Arc4");
            TableC.Columns.Add("Arc5");
            TableC.Columns.Add("Arc6");
            TableC.Columns.Add("Arc7");
            TableC.Columns.Add("Arc8");
            TableC.Columns.Add("Arc9");



            TableC.Rows.Add(new object[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            TableC.Rows.Add(new object[] { 1, 0.38, 0.42, 0.44, 0.49, 0.6, 0.62, 0.64, 0.64, 0.64 });
            TableC.Rows.Add(new object[] { 2, null, null, null, 0.55, 0.7, 0.73, 0.75, 0.75, 0.75 });
            TableC.Rows.Add(new object[] { 3, null, 0.27, 0.30, 0.34, 0.40, 0.47, 0.50, 0.50, 0.50 });


            //таблица расчета vm
            vmTable.Clear();
            vmTable.TableName = "vmTable";
            vmTable.Columns.Add("X");
            vmTable.Columns.Add("Alfa");
            vmTable.Columns.Add("Betta");
            vmTable.Columns.Add("sqrt4");
            vmTable.Columns.Add("Vm");


            //таблица расчета um
            umTable.Clear();
            umTable.TableName = "umTable";
            umTable.Columns.Add("X");
            umTable.Columns.Add("Alfa");
            umTable.Columns.Add("Betta");
            umTable.Columns.Add("sqrt2");
            umTable.Columns.Add("Um");



            //таблица расчета Нагрузки
            TableNagruzka.Clear();
            TableNagruzka.TableName = "TableNagruzka";
            TableNagruzka.Columns.Add("X");
            TableNagruzka.Columns.Add("1A");
            TableNagruzka.Columns.Add("1A1");
            TableNagruzka.Columns.Add("1B");
            TableNagruzka.Columns.Add("1C");

            TableNagruzka.Columns.Add("2A");
            TableNagruzka.Columns.Add("2A1");
            TableNagruzka.Columns.Add("2B");
            TableNagruzka.Columns.Add("2C");

            TableNagruzka.Columns.Add("3A");
            TableNagruzka.Columns.Add("3A1");
            TableNagruzka.Columns.Add("3B");
            TableNagruzka.Columns.Add("3C");

            TableNagruzka.Columns.Add("4A");
            TableNagruzka.Columns.Add("4A1");


            //таблица расчета Высоты
            TableVisota.Clear();
            TableVisota.TableName = "TableVisota";
            TableVisota.Columns.Add("X");
            TableVisota.Columns.Add("1A");
            TableVisota.Columns.Add("1A1");
            TableVisota.Columns.Add("1B");
            TableVisota.Columns.Add("1C");

            TableVisota.Columns.Add("2A");
            TableVisota.Columns.Add("2A1");
            TableVisota.Columns.Add("2B");
            TableVisota.Columns.Add("2C");

            TableVisota.Columns.Add("3A");
            TableVisota.Columns.Add("3A1");
            TableVisota.Columns.Add("3B");
            TableVisota.Columns.Add("3C");

            TableVisota.Columns.Add("4A");
            TableVisota.Columns.Add("4A1");

            //таблица расчета Длины
            TableDlina.Clear();
            TableDlina.TableName = "TableDlina";
            TableDlina.Columns.Add("X");
            TableDlina.Columns.Add("1A");
            TableDlina.Columns.Add("1A1");
            TableDlina.Columns.Add("1B");
            TableDlina.Columns.Add("1C");

            TableDlina.Columns.Add("2A");
            TableDlina.Columns.Add("2A1");
            TableDlina.Columns.Add("2B");
            TableDlina.Columns.Add("2C");

            TableDlina.Columns.Add("3A");
            TableDlina.Columns.Add("3A1");
            TableDlina.Columns.Add("3B");
            TableDlina.Columns.Add("3C");

            TableDlina.Columns.Add("4A");
            TableDlina.Columns.Add("4A1");
            #endregion           


        }
        public void SetAngle(double[] _alfa, double[] _betta,int _delta, string _classLedokol)
        {
            alfa = _alfa;
            betta = _betta;
            delta = _delta;
            classLedokol = _classLedokol;
            kdelta = Math.Pow(delta / 1000, 0.33333333);
            if (kdelta > 3.5) kdelta = 3.5;
        }
        public DataTable showVm()
        {
            return vmTable;
        }
        public DataTable showUm()
        {
            return umTable;
        }
        public DataTable showTableNagruzka()
        {
            return TableNagruzka;
        }
        public DataTable showTableVisota()
        {
            return TableVisota;
        }
        public DataTable showTableDlina()
        {
            return TableDlina;
        }
        public void start()
        {
            vmTable.Clear();
            umTable.Clear();
            TableNagruzka.Clear();
            TableVisota.Clear();
            TableDlina.Clear();

            double L = 20;
            double x = 0;
             //alfa = new[] { 30.64, 28.45, 25.53, 22.15, 19.22, 15.57, 10.27, 5.87, 2.95, 0, 0 };
             //betta = new[] { 21.94, 26.27, 30.05, 32.59, 29.84, 20.88, 9.70, 2.45, 2.45, 2.45, 2.45 };
            //int index = 0;


            Vm(x, L, alfa, betta);
            //  dataGridView2.DataSource = vmTable; // вывод таблицы расчета vm

            double X = 0;
            double BIVar = 0;
            for (int i = 0; i < 5; i++)
            {
                double vm = Convert.ToDouble(vmTable.Rows[i]["Vm"]);
                var A_1 = Math.Round(PAI(vm, delta), accuracy);
                var A_2 = Math.Round(0.65 * A_1, accuracy);
                var A_3 = Math.Round(0.65 * A_1, accuracy);
                var A_4 = Math.Round(0.45 * A_1, accuracy);
                TableNagruzka.Rows.Add(new object[] { X, A_1, 0, 0, 0, A_2, 0, 0, 0, A_3, 0, 0, 0, A_4, 0 });
                X += 0.025;
                X = Math.Round(X, 4);
            }
            for (int i = 5; i < 11; i++)
            {
                double vm = Convert.ToDouble(vmTable.Rows[i]["Vm"]);
                var A1_1 = Math.Round(PA1I(vm, delta), accuracy);
                var A1_2 = Math.Round(0.65 * A1_1, accuracy);
                var A1_3 = Math.Round(0.65 * A1_1, accuracy);
                var A1_4 = Math.Round(0.45 * A1_1, accuracy);
                TableNagruzka.Rows.Add(new object[] { X, 0, A1_1, 0, 0, 0, A1_2, 0, 0, 0, A1_3, 0, 0, 0, A1_4 });
                X += 0.025;
                X = Math.Round(X, 4);
            }
            for (int i = 11; i < 35; i++)
            {
                var B_1 = Math.Round(BI(delta), accuracy);
                var B_2 = Math.Round(0.50 * B_1, accuracy);
                var B_3 = Math.Round(0.40 * B_1, accuracy);
                TableNagruzka.Rows.Add(new object[] { X, 0, 0, B_1, 0, 0, 0, B_2, 0, 0, 0, B_3, 0, 0, 0 });
                X += 0.025;
                X = Math.Round(X, 4);
                BIVar = B_1;
            }
            for (int i = 35; i < 41; i++)
            {
                
                var C = Math.Round(CI(BIVar), accuracy);
                var C_2 = Math.Round(0.50 * C, accuracy);
                TableNagruzka.Rows.Add(new object[] { X, 0, 0, 0, C, 0, 0, 0, C_2, 0, 0, 0, 0, 0, 0 });
                X += 0.025;
                X = Math.Round(X, 4);
            }

           //Utils.saveTable(@"D:\nagruzka.csv", TableNagruzka); //сохранить таблицу в файл

            Um(x, L, alfa, betta);
            //dataGridView2.DataSource = umTable; // вывод таблицы расчета vm
            var ugol1 = MaxU1();
            var ugol2 = MaxU2();
            X = 0;
            BIVar = 0;
            //var kdelta = Math.Pow(delta / 1000, 0.33333333);
            double koefKDelta = 3.5 * Math.Sqrt(kdelta);
            double koefKDelta2 = 3.0 * Math.Sqrt(kdelta);
            for (int i = 0; i < 5; i++)
            {
                double vm = Convert.ToDouble(umTable.Rows[i]["Um"]);
                var A_1 = Math.Round(BAI(vm, delta), accuracy);
                TableVisota.Rows.Add(new object[] { X, A_1, 0, 0, 0, A_1, 0, 0, 0, A_1, 0, 0, 0, A_1, 0 });

                var A_2 = 11.3 * Math.Sqrt(A_1 * Math.Sin(ugol1));
                if (A_2 < koefKDelta) A_2 = koefKDelta;
                TableDlina.Rows.Add(new object[] { X, A_2, 0, 0, 0, A_2, 0, 0, 0, A_2, 0, 0, 0, A_2, 0 });
                X += 0.025;
                X = Math.Round(X, 4);
            }
            for (int i = 5; i < 11; i++)
            {
                double vm = Convert.ToDouble(umTable.Rows[i]["Um"]);
                var A1_1 = Math.Round(BA1I(vm, delta), accuracy);
                TableVisota.Rows.Add(new object[] { X, 0, A1_1, 0, 0, 0, A1_1, 0, 0, 0, A1_1, 0, 0, 0, A1_1 });

                var A_2 = 11.3 * Math.Sqrt(A1_1 * Math.Sin(ugol2));
                if (A_2 < koefKDelta2) A_2 = koefKDelta;
                TableDlina.Rows.Add(new object[] { X, 0, A_2, 0, 0, 0, A_2, 0, 0, 0, A_2, 0, 0, 0, A_2 });
                X += 0.025;
                X = Math.Round(X, 4);
            }
            for (int i = 11; i < 35; i++)
            {
                var B_1 = Math.Round(BBI(delta), accuracy);
                TableVisota.Rows.Add(new object[] { X, 0, 0, B_1, 0, 0, 0, B_1, 0, 0, 0, B_1, 0, 0, 0 });

                var B_2 = B_1 * 6;
                if (B_2 < koefKDelta2) B_2 = koefKDelta;
                TableDlina.Rows.Add(new object[] { X, 0, 0, B_2, 0, 0, 0, B_2, 0, 0, 0, B_2, 0, 0, 0 });
                X += 0.025;
                X = Math.Round(X, 4);
                BIVar = B_1;
            }
            for (int i = 35; i < 41; i++)
            {
                var C = Math.Round(CCI(BIVar), accuracy);
                TableVisota.Rows.Add(new object[] { X, 0, 0, 0, C, 0, 0, 0, C, 0, 0, 0, 0, 0, 0 });

                var C_2 = C * 6;
                if (C_2 < koefKDelta2) C_2 = koefKDelta;
                TableDlina.Rows.Add(new object[] { X, 0, 0, 0, C_2, 0, 0, 0, C_2, 0, 0, 0, 0, 0, 0 });
                X += 0.025;
                X = Math.Round(X, 4);
            }

            //dataGridView1.DataSource = TableDlina;
        }




    
        private void Vm(double x, double L, double[] alfa, double[] betta) // расчет значений Vm
        {
            for (int i = 0; i < alfa.Count(); i++)
            {
                var temp = Math.Pow(alfa[i], 2) / betta[i];
                var sqrt4 = Math.Pow(temp, 0.25);
                if (sqrt4 < 1.39)
                    sqrt4 = 1.39;
                sqrt4 = Math.Round(sqrt4, accuracy);
                double vm = 0;
                if ((x * L / L) <= 0.25)
                    //vm = (0.278 - 0.18 * (x / L)) * Math.Pow((Math.Pow(alfa, 2) / betta), 0.25);
                    vm = (0.278 - 0.18 * (x * L / L)) * sqrt4;
                if ((x * L / L) > 0.25)
                    vm = (0.343 - 0.08 * (x * L / L)) * sqrt4;
                vm = Math.Round(vm, accuracy);
                vmTable.Rows.Add(new object[] { x, alfa[i], betta[i], sqrt4, vm });
                x += 0.025;
                x = Math.Round(x, 4);
            }
        }

        private double PAI(double vm, double delta)
        {
            double a = Convert.ToDouble(TableA.Rows[1][classLedokol]);
            var temp = 2500 * a * vm * Math.Pow(delta / 1000.0, 0.16666666);
            return temp;
        }

        private double PA1I(double vm, double delta)
        {
            double a = Convert.ToDouble(TableA.Rows[2][classLedokol]);
            var temp = 2500 * a * vm * Math.Pow(delta / 1000.0, 0.16666666);
            return temp;
        }
        private double BI(double delta)
        {
            double a = Convert.ToDouble(TableA.Rows[3][classLedokol]);
            var temp = 1200 * a * Math.Pow(delta / 1000.0, 0.16666666);
            return temp;
        }
        private double CI(double BI)
        {
            if ((classLedokol == "Arc7") | (classLedokol == "Arc8") | (classLedokol == "Arc9"))
            {
                return  0.75;
            }
            double a = Convert.ToDouble(TableA.Rows[4][classLedokol]);
            var temp = a * BI;
            return temp;
        }

        private void Um(double x, double L, double[] alfa, double[] betta) // расчет значений Vm
        {
            for (int i = 0; i < alfa.Count(); i++)
            {
                double kb = 0;
                if (betta[i] >= 7) kb = 1;
                if (betta[i] < 7) kb = 1.15 - (0.15 * (betta[i] / 7));

                if (alfa[i] < 3)
                    alfa[i] = 3;
                var temp = alfa[i] / betta[i];
                var sqrt2 = Math.Sqrt(temp);

                // sqrt2 = Math.Round(sqrt2, accuracy);
                double vm = 0;
                if ((x * L / L) <= 0.25)
                    //vm = (0.278 - 0.18 * (x / L)) * Math.Pow((Math.Pow(alfa, 2) / betta), 0.25);
                    vm = kb * (0.635 - 0.61 * (x * L / L)) * sqrt2;
                if ((x * L / L) > 0.25)
                    vm = (0.862 - 0.30 * (x * L / L)) * sqrt2;
                vm = Math.Round(vm, accuracy);

                umTable.Rows.Add(new object[] { x, alfa[i], betta[i], sqrt2, vm });
                x += 0.025;
                x = Math.Round(x, 4);
            }
        }

        private double BAI(double um, double delta)
        {
            double c = Convert.ToDouble(TableC.Rows[1][classLedokol]);
            var temp = c * um * kdelta;
            return temp;
        }

        private double BA1I(double um, double delta)
        {
            double c = Convert.ToDouble(TableC.Rows[2][classLedokol]);
            var temp = c * um * kdelta;
            return temp;
        }

        private double BBI(double delta)
        {
            double c = Convert.ToDouble(TableC.Rows[3][classLedokol]);
            var temp = c * kdelta;
            return temp;
        }
        private double CCI(double BBI)
        {
            var temp = 0.8 * BBI;
            return temp;
        }
        private double MaxU1()
        {
            double test = 0;
            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                double vm = Convert.ToDouble(umTable.Rows[i]["Um"]);
                if (vm > test)
                {
                    index = i;
                    test = vm;
                }
            }
            double rez = Convert.ToDouble(umTable.Rows[index]["Betta"]);
            rez = rez * (3.14 / 180);
            return rez;
        }

        private double MaxU2()
        {
            double test = 0;
            int index = 0;
            for (int i = 5; i < 11; i++)
            {
                double vm = Convert.ToDouble(umTable.Rows[i]["Um"]);
                if (vm > test)
                {
                    index = i;
                    test = vm;

                }

            }
            double rez = Convert.ToDouble(umTable.Rows[index]["Betta"]);
            rez = rez * (3.14 / 180);
            return rez;
        }


    }
}
