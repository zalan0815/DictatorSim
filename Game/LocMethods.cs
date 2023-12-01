using static Game.SlowPrintSystem;

namespace Game
{
    partial class Locations
    {
        #region Zalan
        public static int hely_29(ref LocationData currentLocation)
        {
            SlowPrint("Miután Palkó felérkezett az égigérő paszuly tetejére végre megérkezett végső céljához, a SÁRKÁNYFÉSZEKHEZ.");
            SlowPrint("A sárkányfészekben ült a 3 FEJŰ SÁRKÁNY.");
            SlowPrint("\"Már vártalak téged, Ifjú lovag\" - Dörmögte a 3 fejű sárkány.");
            SlowPrint("A sárkány legyőzéséhez Palkónak mind a 3 fejet le kell győznie!");

            bool w0 = true;
            bool w1 = true;
            bool w2 = true;

            do
            {
                int choice = Valasztas(ref currentLocation, "Bal fej megtámadása", "Középső fej megtámadása", "Jobb fej megtámadása");
                switch (choice)
                {
                    case 0:
                        FightSystem balfej = new FightSystem(Program.player, new Enemy(5, 1, name: "Bal fej"), out w0);
                        break;
                    case 1:
                        FightSystem kozepsofej = new FightSystem(Program.player, new Enemy(5, 1, name: "Középső fej"), out w1);
                        break;
                    case 2:
                        FightSystem jobbfej = new FightSystem(Program.player, new Enemy(5, 1, name: "Jobb fej"), out w2);
                        break;
                }
            }
            while (w0 && w1 && w2);
            
            if (w0 && w1 && w2)
            {
                return 30;
            }
            else
            {
                return 0;
            }
        }
        public static int hely_30(ref LocationData currentLocation)
        {
            SlowPrintSystem.SlowPrint("Elérkeztünk hát mesés történetünk végéhez. Palkó a Kacsalábon forgó kacsalábon forgó palotájában boldogan élt a királylánnyal míg meg nem halt.");
            SlowPrintSystem.SlowPrint("VÉGE");
            return 0;
        }
        #endregion

        #region Peti

        #endregion

        public static int hely_1(ref LocationData currentLocation)
        {
            Program.SlowPrint("A történet Palko házában veszi kezdetét, ahol egy szép napon reggel Palko elhatározta, hogy elmegy világot látni.");
            Program.SlowPrint("Mit csináljon palko?");
            int choice = Valasztas("Sarokban lévő láda kinyitása", "Elbúcsúzás Palko édesanyjától");
            return Tovabb(helyek[2]);
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
