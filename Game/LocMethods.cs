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
        public static int hely_29(ref LocationData currentLocation)
        {
            Program.SlowPrint("Miután Palkó felérkezett az égigérő paszuly tetejére végre megérkezett végső céljához, a SÁRKÁNYFÉSZEKHEZ.");
            Program.SlowPrint("A sárkányfészekben ült a 3 FEJŰ SÁRKÁNY.");
            Program.SlowPrint("\"Már vártalak téged, Ifjú lovag\" - Dörmögte a 3 fejű sárkány.");
            Program.SlowPrint("A sárkány legyőzéséhez Palkónak mind a 3 fejet le kell győznie!");

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
        public static int hely_30(ref LocationData currentLocation)
        {
            Program.SlowPrint("Elérkeztünk hát mesés történetünk végéhez. Palkó a Kacsalábon forgó kacsalábon forgó palotájában boldogan élt a királylánnyal míg meg nem halt.");
            Program.SlowPrint("VÉGE");
            return 0;
        }
        #endregion

        #region Peti

        #endregion

        public static int hely_1(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_2(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_3(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_4(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_5(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_6(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_7(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_8(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_9(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_10(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_11(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_12(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_13(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_14(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_15(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_16(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_17(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_18(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_19(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_20(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_21(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_22(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_23(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_24(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_25(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_26(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_27(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_28(ref LocationData currentLocation)
        {
            return 0;
        }

    }
}
