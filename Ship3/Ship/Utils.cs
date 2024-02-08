using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ship
{
    public static class Utils
    {


        public static void saveTable(string st, DataTable tabl)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            // сохраняем таблицу в файл cvs
            var builder = new StringBuilder();

            if (tabl.TableName != "vmTable")
                if (tabl.TableName != "umTable")
                    if (tabl.TableName != "vm2Table")
                        if (tabl.TableName != "ulTable")
                        {
                            builder.Append("X;I;;;;II; ; ; ;III; ; ; ;IV;;");
                            builder.Append("\r\n");
                        }



            // запись заголовка
            foreach (DataColumn r in tabl.Columns)
            {
                builder.Append(r.Caption.ToString());
                builder.Append(";");
                builder.Append("\t");
            }
            builder.Append("\r\n");

            //builder.Append("X;A;A1;B;C;A;A1;B;C;A;A1;B;C;A;A1;");
            //builder.Append("\r\n");
            // запись тела файла
            foreach (DataRow r in tabl.Rows)
            {
                foreach (var o in r.ItemArray)
                {
                    builder.Append(o.ToString());
                    builder.Append(";");
                    builder.Append("\t");
                }
                builder.Append("\r\n");
            }
            File.WriteAllText(st, builder.ToString(), Encoding.GetEncoding(1251));

        }

        public static class InputData1_1
        {
            public static string name = "Пароход";
            public static string flag = "Бразилия";
            public static string HomePort = "Бразилия";
            public static string regNum = "12345";
            public static string signal = "SOS";
            public static string IMO = "56";
            public static string type = "Arc5";
            public static string placeOfConstruction = "Бразилия";
            public static string dateOfConstruction = "10.06.2021";
            public static string VesselClass = "5";
            public static string HomePort2 = "Бразилия";
            public static string Owner = "Бразилия";
            public static string GrossCapacity = "20";
            public static string Type_of_main_mechanisms = "Дизельный";
            public static string sumMex = "5";
        }
            public static class InputData1_2
        {
            // private static double Lwl_;

            public static bool rez = true;
            public static double deltaV = 1500;//Водоизмещение полное в грузу
            public static double V = 20000;//Водоизмещение полное объемное
            public static double Loa = 20;//Длина наибольшая
            public static double Lwl = 5;//Длина по КВЛ
            //{
            //    get { return Lwl_; }

            //    set
            //    {
            //        if (value >= 1)
            //        {
            //            MessageBox.Show("Длина по КВЛ не должна превышать длину наибольшую", "Ошибка", MessageBoxButtons.OK);
            //            rez = false;
            //        }
            //        else
            //        {
            //            Lwl_ = value;
            //        }
            //    }


            //}
            public static double Lbr = 5; //Длина между перпендикулярами
            public static double L = 100; //Длина по Правилам 
            public static double Lll = 18; //Длина в соответствии с Международной конвенцией о грузовой марке
            public static double B = 50; //Ширина
            public static double D = 10; //Высота борта
            public static double d = 5; //Осадка судна
            public static double ds = 5; //Расчетная осадка
            public static double Cb = 0.1; //Коэффициент  Общей полноты
            public static double Cw = 0.1; //Коэффициент  Полноты ватерлинии
            public static double Cm = 0.1; //Коэффициент  Полноты мидель-шпангоута
            public static int zP = 4; //Число валов/гребных винтов
            public static int zR = 4; //Число рулей
        }

        public static class InputData1_3
        {
            public static double PCRG=0; //Груз перевозимый
            public static double vS = 0; //Расчетная скорость хода на прямом курсе
            public static double tSA = 0; //Продолжительность автономного рейса
            public static double RS = 0; //Максимальная дальность плавания (перехода морем)
            public static double h3 = 0; //Высота волны 3%-ой обеспеченности
            public static double q = 120; //Расчетный скоростной напор ветра в шквале
        }

        public static class InputData1_4
        {
            public static DataTable Table1_4 = new DataTable();//1.4.	Нагрузка масс судна.

        }

        public static class InputData1_56
        {
            public static double p = 1; //Плотность морской воды
            public static double g = 9.81; //Ускорение свободного падения
            public static double h3 = 0; //Высота волны 3%-ой обеспеченности
            public static double q = 120; //Расчетный скоростной напор ветра в шквале
        }

        public static class InputData1_7
        {
            public static DataTable Table1_7 = new DataTable();//1.7.	Прочие данные.

        }
    }
}
