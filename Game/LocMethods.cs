using static Game.SlowPrintSystem;

namespace Game
{
    partial class Locations
    {
        #region Zalan
        public static int hely_27(ref LocationData currentLocation)
        {
            Program.trader.ShopMenu(ref Program.player);
            return 0;
        }
        public static int hely_28(ref LocationData currentLocation)
        {
            SlowPrint("Palkó belépett a király csodaszép kacsalábon forgó palotájába.");
            SlowPrint("\"Üdv Ifjú Vitéz!\" - Köszöntötte a király Palkót.");
            SlowPrint("\"Jöttem, hogy szerencsét próbáljak! Le akarom győzni a 3 fejű sárkányt a lányáért és birodalmáért cserébe!\" - Mondta büszkén Palkó.");
            SlowPrint("\"Tiszteletre méltó a bátorságod, de figyelmeztetnelek kell, hogy már sokan megpróbálták legyőzni a 3 fejű sárkányt de elbuktak!\" - Mondta a király aggódva.");
            SlowPrint("\"Biztos, hogy megpróbálsz megküzdeni a 3 fejű sárkánnyal?\"");

            int choice = Valasztas(ref currentLocation, "Igen", "Nem");
            switch (choice)
            {
                case 0:
                    SlowPrint("\"Ez esetben menj vissza a Kerekerdőbe és mássz fel az Égigérő paszuly tetejére.\n Ott fogo megtalálni a sárkányfészket, ahol a 3 fejű sárkány lakik.\"");
                    SlowPrint("\"Tessék itt egy Égig érő kötél, ezzel fel fogsz tudni mászni a paszuly tetejére.\"");
                    Program.player.NewItem(new OtherItem("Égig érő kötél", 0, type:StatType.Key));
                    SlowPrint("\"Sok sikert, Ifjú Vitéz!!!\"");
                    return Tovabb(helyek[6]);
                case 1:
                    SlowPrint("Palkó megfutamodott, úgy gondolta szeretne még egy kis időt tölteni a Városban, mielőtt megküzd a sárkánnyal.");
                    return Tovabb(helyek[25]);
            }
            return 0;
        }
        public static int hely_29(ref LocationData currentLocation)
        {
            SlowPrint("Miután Palkó felérkezett az égigérő paszuly tetejére végre megérkezett végső céljához, a SÁRKÁNYFÉSZEKHEZ.");
            SlowPrint("A sárkányfészekben ült a 3 FEJŰ SÁRKÁNY.");
            SlowPrint("\"Már vártalak téged, Ifjú lovag\" - Dörmögte a 3 fejű sárkány.");
            SlowPrint("A sárkány legyőzéséhez Palkónak mind a 3 fejet le kell győznie!");

            bool w0 = false;
            bool w1 = false;
            bool w2 = false;
            bool w3 = false;
            bool w4 = false;
            bool w5 = false;

            do
            {
                int choice = Valasztas(ref currentLocation, "Bal fej megtámadása", "Középső fej megtámadása", "Jobb fej megtámadása");
                switch (choice)
                {
                    case 0:
                        FightSystem balfej = new FightSystem(Program.player, new Enemy(5, 1, name: "Bal fej"), out w0);
                        w3 = true;
                        break;
                    case 1:
                        FightSystem kozepsofej = new FightSystem(Program.player, new Enemy(5, 1, name: "Középső fej"), out w1);
                        w4 = true;
                        break;
                    case 2:
                        FightSystem jobbfej = new FightSystem(Program.player, new Enemy(5, 1, name: "Jobb fej"), out w2);
                        w5 = true;
                        break;
                }
                if ((w3 && !w0) || (w4 && !w1) || (w5 && !w3))
                {
                    SlowPrint("A sárkány torkából hirtelen oly mennyiségű tűz tört elő, hogy Palkó hamuvá égett. Túl nagy falat volt neki a 3 fejű sárkány így elbukott.");
                    return 0;
                }

            }
            while (!(w0 && w1 && w2));
            SlowPrint("A sárkány utolsó fejét is levágta Palkó.\nA mostmár 3 nyakú, de 0 fejű sárkány kiterült.\nPalkó győzött! Legyőzte a Sárkányt! Már csak vissza kell mennie a Kacsalábon forgó palotába, hogy megkapja jól kiérdemelt jutalmát.");
            return Tovabb(helyek[28]);
        }
        public static int hely_30(ref LocationData currentLocation)
        {
            SlowPrintSystem.SlowPrint("Elérkeztünk hát mesés történetünk végéhez. Palkó a Kacsalábon forgó kacsalábon forgó palotájában boldogan élt a királylánnyal és családjával míg meg nem halt.");
            SlowPrintSystem.SlowPrint("VÉGE", 250);
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
       
        

    }
}
