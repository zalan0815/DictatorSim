using System.Xml.Serialization;
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
        public static int hely_1(ref LocationData currentLocation)
        {
            SlowPrint("A történet Palko házában veszi kezdetét, ahol egy szép napon reggel Palko elhatározta, hogy elmegy világot látni.");
            
            for (int i = 0; i < 2; i++)
            {
                int choice = Valasztas(ref currentLocation, "Nyissa ki a sarokban kévő ládát", "Búcsúzzon el az anyjától");
                switch (choice)
                {
                    case 0:
                        SlowPrint("Palkó kinyitja a ládát.");
                        SlowPrint("Megtalálta régi gyakorló kardját fiatal korából.");
                        SlowPrint("Ha a pengéje nem is annyira éles még hasznát fogja venni.");
                        Sword sword = new Sword("Fakard", 2, 0, StatType.SliderSpeed);
                        break;
                    case 1:
                        SlowPrint("Palkót megpróbálja lebeszélni az édesanyja, de az igazi hőst nem állítja meg semmi.");
                        SlowPrint("Megígéri, hogy vigyáz magára és visszatér még.");
                        break;
                    case -1:
                        break;
                }
            }
            return Tovabb(helyek[2]);
        }

        public static int hely_2(ref LocationData currentLocation)
        {
            if (currentLocation.FirstTime)
            {
                SlowPrint("Markotabödöge, a falu ahol Palkó az életét élte.");
                SlowPrint("Majdnem minden embert ismert, de most nem vesztegethette idejét.");
            }
            
            int choice = Valasztas(ref currentLocation, "Ki a faluból", "Paphoz");
            switch (choice)
            {
                case 0:
                    SlowPrint("Palko szerette volna mi hamarabb elhagyni a falut, ám meglátta a szomszéd kutyáját.");
                    SlowPrint("Megpróbálta megsimogatni de hirtelen rátámadt.");
                    bool w;
                    FightSystem kutya = new FightSystem(Program.player, new Enemy(20, 1, name: "Kutya"), out w);
                    Console.WriteLine(w);
                    if (w)
                    {
                        SlowPrint("Palkó sajnálta, hogy a kutyát meg kellett ölnie.");
                        SlowPrint("Nem volt nagy ellenfél, de úgy érezte mindent képes lenne legyőzni.");
                        SlowPrint("Nagy magabiztossággal indult tovább.");
                        break;
                    }
                    else
                    {
                        return 0;
                    }
                case 1:
                    SlowPrint("Palkó a templom felé vette az irányt.");
                    SlowPrint("Odaérkezve üdvözölte a papot.");
                    SlowPrint("- \"Dícsértessék atyám!\"");
                    SlowPrint("- \"Dícsértessék fiam!\"");
                    SlowPrint("- \"Atyám, elhatároztam, hog elmegyek világot látni. Tudom, hogy a világ tele van veszélyekkel, ezért szeretnék áldást kéreni!\"");
                    SlowPrint("- \"Fiam, csak Isten tud áldást adni én nem, de ezt az üvegcsét fogadd el. Ha megsebesülsz önts belőle kicsit a sebre majd a maradékot idd meg és jobban leszel.\"");
                    SlowPrint("- \"Köszönöm atyám!\"");
                    SlowPrint("- \"Isten áldjon, fiam\"");
                    break;
            }
            if (currentLocation.FirstTime)
            {
                SlowPrint("Palkó, elgondolkodott rajta, hogy lehet mégsem kéne csak úgy nekiindulni megfelelő felszerelés nélkül.");
                SlowPrint("Elmehet a bányába értékek után kutatni vagy a helyi gazdához dolgozni némi pénzért dolgozni, hogy a kovácstól vegyvert vásároljon.");
            }
            

            return Tovabb(helyek[3], helyek[4], helyek[5], helyek[6]);
        }
        #endregion



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
