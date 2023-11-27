using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    partial class Locations
    {
        #region Zalan
        public static int hely_29()
        {
            Program.SlowPrint("Miután Palkó felérkezett az égigérő paszuly tetejére végre megérkezett végső céljához, a SÁRKÁNYFÉSZEKHEZ.");
            Program.SlowPrint("A sárkányfészekben ült a 3 FEJŰ SÁRKÁNY.");
            Program.SlowPrint("\"Már vártalak téged, Ifjú lovag\" - Dörmögte a 3 fejű sárkány.");
            Program.SlowPrint("A sárkány legyőzéséhez Palkónak mind a 3 fejet le kell győznie.");

            int choice = Valasztas("Bal fej megtámadása", "Középső fej megtámadása", "Jobb fej megtámadása");
            switch (choice)
            {
                case 0:
                    FightSystem balfej = new FightSystem(Program.player, new Enemy(500, 100, name: "Bal fej"), out bool w0);
                    break;
                case 1:
                    FightSystem kozepsofej = new FightSystem(Program.player, new Enemy(500, 100, name: "Középső fej"), out bool w1);
                    break;
                case 2:
                    FightSystem jobbfej = new FightSystem(Program.player, new Enemy(500, 100, name: "Jobb fej"), out bool w2);
                    break;
            }
            return 0;
        }
        public static int hely_30()
        {
            Program.SlowPrint("Elérkeztünk hát mesés történetünk végéhez. Palkó a Kacsalábon forgó kacsalábon forgó palotájában boldogan élt a királylánnyal míg meg nem halt.");
            Program.SlowPrint("VÉGE");
            return 0;
        }
        #endregion

        #region Peti

        #endregion

        public static int hely_1()
        {
            return 0;
        }
        public static int hely_2()
        {
            return 0;
        }
        public static int hely_3()
        {
            return 0;
        }
        public static int hely_4()
        {
            return 0;
        }
        public static int hely_5()
        {
            return 0;
        }
        public static int hely_6()
        {
            return 0;
        }
        public static int hely_7()
        {
            return 0;
        }
        public static int hely_8()
        {
            return 0;
        }
        public static int hely_9()
        {
            return 0;
        }
        public static int hely_10()
        {
            return 0;
        }
        public static int hely_11()
        {
            return 0;
        }
        public static int hely_12()
        {
            return 0;
        }
        public static int hely_13()
        {
            return 0;
        }
        public static int hely_14()
        {
            return 0;
        }
        public static int hely_15()
        {
            return 0;
        }
        public static int hely_16()
        {
            return 0;
        }
        public static int hely_17()
        {
            return 0;
        }
        public static int hely_18()
        {
            return 0;
        }
        public static int hely_19()
        {
            return 0;
        }
        public static int hely_20()
        {
            return 0;
        }
        public static int hely_21()
        {
            return 0;
        }
        public static int hely_22()
        {
            return 0;
        }
        public static int hely_23()
        {
            return 0;
        }
        public static int hely_24()
        {
            return 0;
        }
        public static int hely_25()
        {
            return 0;
        }
        public static int hely_26()
        {
            return 0;
        }
        public static int hely_27()
        {
            return 0;
        }
        public static int hely_28()
        {
            return 0;
        }
        
        

    }
}
