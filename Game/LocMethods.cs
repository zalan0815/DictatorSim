using static Game.SlowPrintSystem;
using Game.Minigames;
using static Game.Program;

namespace Game
{
    partial class Locations
    {
        static bool fairy = true;
        static Random rnd = new Random();
        static int wichHouse = rnd.Next(1, 4);
        static int where = rnd.Next(1, 3);

        static bool helping = false;
        static bool found = false;
        static bool helped = false;

        static bool drake = false;

        #region Zalan
        public static int hely_0(ref LocationData currentLocation) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            SlowPrintLine("Palkó sajnos túl nagy fába vágta fejszéjét és MEGHALT.\n");
            Console.WriteLine("                                      EEEE                                                     \r\n                                     E::E         \r\n                                    E::E\r\n                                   EEEE                                              \r\nVVVVVVVV           VVVVVVVVEEEEEEEEEEEEEEEEEEEEEE       GGGGGGGGGGGGGEEEEEEEEEEEEEEEEEEEEEE\r\nV::::::V           V::::::VE::::::::::::::::::::E    GGG::::::::::::GE::::::::::::::::::::E\r\nV::::::V           V::::::VE::::::::::::::::::::E  GG:::::::::::::::GE::::::::::::::::::::E\r\nV::::::V           V::::::VEE::::::EEEEEEEEE::::E G:::::GGGGGGGG::::GEE::::::EEEEEEEEE::::E\r\n V:::::V           V:::::V   E:::::E       EEEEEEG:::::G       GGGGGG  E:::::E       EEEEEE\r\n  V:::::V         V:::::V    E:::::E            G:::::G                E:::::E             \r\n   V:::::V       V:::::V     E::::::EEEEEEEEEE  G:::::G                E::::::EEEEEEEEEE   \r\n    V:::::V     V:::::V      E:::::::::::::::E  G:::::G    GGGGGGGGGG  E:::::::::::::::E   \r\n     V:::::V   V:::::V       E:::::::::::::::E  G:::::G    G::::::::G  E:::::::::::::::E   \r\n      V:::::V V:::::V        E::::::EEEEEEEEEE  G:::::G    GGGGG::::G  E::::::EEEEEEEEEE   \r\n       V:::::V:::::V         E:::::E            G:::::G        G::::G  E:::::E             \r\n        V:::::::::V          E:::::E       EEEEEEG:::::G       G::::G  E:::::E       EEEEEE\r\n         V:::::::V         EE::::::EEEEEEEE:::::E G:::::GGGGGGGG::::GEE::::::EEEEEEEE:::::E\r\n          V:::::V          E::::::::::::::::::::E  GG:::::::::::::::GE::::::::::::::::::::E\r\n           V:::V           E::::::::::::::::::::E    GGG::::::GGG:::GE::::::::::::::::::::E\r\n            VVV            EEEEEEEEEEEEEEEEEEEEEE       GGGGGG   GGGGEEEEEEEEEEEEEEEEEEEEEE");
            Console.ForegroundColor = ConsoleColor.White;

            return -1; 
        }
        public static int hely_3(ref LocationData currentLocation)
        {
            if (!currentLocation.FirstTime)
            {
                SlowPrintLine("A bánya beomlott! Nem tudsz többet bányászni.");
                return Tovabb(helyek[2]);
            }
            SlowPrintLine("Palkó a bányához érve a következő feliratot látta:");
            SlowPrintLine("\"A bányában 3 mélységben tudsz bányászni, minél mélyebben próbálkozol annál nehezebben, de annál több gyémántot találhatsz!\"");
            int choice;
            do
            {
                choice = Valasztas(ref currentLocation, "Nem mély barlang", "Mély barlang", "Nagyon mély barlang", "Vissza a Faluba");
                switch (choice)
                {
                    case 0:
                        MiningGame mining1 = new();
                        if (mining1.Mining('0', 'O', true))
                        {
                            player.Money += 10;
                            SlowPrintLine("\nA talált gyémántok eladásával Palkó 10 krajcárra tett szert.");
                        }
                        break;
                    case 1:
                        MiningGame mining2 = new();
                        if (mining2.Mining('l', '1', true))
                        {
                            player.Money += 100;
                            SlowPrintLine("\nA talált gyémántok eladásával Palkó 100 krajcárra tett szert.");

                        }
                        break;
                    case 2:
                        MiningGame mining3 = new();
                        if (mining3.Mining('a', 'e', true))
                        {
                            player.Money += 1000;
                            SlowPrintLine("\nA talált gyémántok eladásával Palkó 1000 krajcárra tett szert.");

                        }
                        break;
                    default:
                        return Tovabb(helyek[2]);
                }
                Console.Clear();
            } while (choice != 3);

            SlowPrintLine("");

            return Tovabb(helyek[2]);
        }
        public static int hely_11(ref LocationData currentLocation)
        {
            SlowPrintLine("Az égig érő paszuly. Pontosan olyan, mint amilyennek mondják: az égig ér.");
            foreach (OtherItem item in player.Inventory)
            {
                if (item.Name == "Égig érő kötél")
                {
                    SlowPrintLine("Palkó a kötél segítségével elkezdett felmászni az Égig érő paszulyra.");
                    return Tovabb(helyek[29]);
                }
            }
            SlowPrintLine("Palkó sajnos nem tud felmászni az égig Érő paszulyra. Útját másfelé kell folytatnia.");
            return Tovabb(helyek[6]);
        }
        public static int hely_20(ref LocationData currentLocation)
        {

            if (currentLocation.FirstTime)
            {
                SlowPrintLine("Palkó Tündérország díszes kapjua előtt állt, amikor hozzászólt az egyik Kapuőr tündér.");
                if (fairy)
                {
                    SlowPrintLine("-\"Üdvözöllek Tündérországban halandó! Nemes tettedért cseréb beengedlek!\"");
                }
                else
                {
                    SlowPrintLine("- \"Ide halandó nem jöhet be, csak ha megérdemli azt.\"");
                    return Tovabb(helyek[19]);
                }
                SlowPrintLine("Tündérország egy csodás hely, Palkónak nagyon tetszett. Azonba ide halandó csak jó cselekedet ellenében jöhet be és HALANDÓ CSAK JÓCSELEKEDET ELLENÉBEN MEHET KI.");
                SlowPrintLine("Palkó meglátott az utcán egy sirdogáló Udvari bolond tündért és egy sirdogáló Tündérlányt.");
            }
            if (!helping && !helped)
            {
                int choice = Valasztas(ref currentLocation, "Udvari bolond tündér kisegítése", "Tündérlány kisegítése");
                switch (choice)
                {
                    case 0:
                        return Tovabb(helyek[24]);
                    case 1:
                        SlowPrintLine("- \"Elvesztettem a zsebkendőmet. Meg tudnád keresni nekem?\"");
                        helping = true;
                        return Tovabb(helyek[21], helyek[22], helyek[23]);
                }
            }
            if (helping && !found)
            {
                return Tovabb(helyek[21], helyek[22], helyek[23]);
            }
            if (found)
            {
                SlowPrintLine("- \"Köszönöm szépen, hogy megtaláltad a zsebkendőmet!\"");
                helped = true;
            }
            if (helped || found)
            {
                SlowPrintLine("Palkó a segítségéért cserébe továbbmehetett a Városba!");
                return Tovabb(helyek[25]);
            }

            return 0;
        }
        public static int hely_21(ref LocationData currentLocation)
        {
            SlowPrintLine("Palkó belépett a kék házba.");
            int choice = Valasztas(ref currentLocation, "Szekrény megnézése", "Padlás megnézése", "Vissza");
            while (choice != 2)
            {
                switch (choice)
                {
                    case 0:
                        if (wichHouse == 1 && where == 1)
                        {
                            SlowPrintLine("Palkó megtalálta a zsebkendőt.");
                            found = true;
                            return Tovabb(helyek[20]);
                        }
                        SlowPrintLine("Palkó itt nem találta meg a zsebkendőt.");
                        break;
                    case 1:
                        if (wichHouse == 1 && where == 2)
                        {
                            SlowPrintLine("Palkó megtalálta a zsebkendőt.");
                            found = true;
                            return Tovabb(helyek[20]);
                        }
                        SlowPrintLine("Palkó itt nem találta meg a zsebkendőt.");
                        break;
                }
                choice = Valasztas(ref currentLocation, "Szekrény megnézése", "Padlás megnézése", "Vissza");
            }
            return Tovabb(helyek[20]);
        }
        public static int hely_22(ref LocationData currentLocation)
        {
            SlowPrintLine("Palkó belépett a piros házba.");
            int choice = Valasztas(ref currentLocation, "Pince megnézése", "Kandalló megnézése", "Vissza");
            while (choice != 2)
            {
                switch (choice)
                {
                    case 0:
                        if (wichHouse == 2 && where == 1)
                        {
                            SlowPrintLine("Palkó megtalálta a zsebkendőt.");
                            found = true;
                            return Tovabb(helyek[20]);
                        }
                        SlowPrintLine("Palkó itt nem találta meg a zsebkendőt.");
                        break;
                    case 1:
                        if (wichHouse == 2 && where == 2)
                        {
                            SlowPrintLine("Palkó megtalálta a zsebkendőt.");
                            found = true;
                            return Tovabb(helyek[20]);
                        }
                        SlowPrintLine("Palkó itt nem találta meg a zsebkendőt.");
                        break;
                }
                choice = Valasztas(ref currentLocation, "Pince megnézése", "Kandalló megnézése", "Vissza");
            }
            return Tovabb(helyek[20]);
        }
        public static int hely_23(ref LocationData currentLocation)
        {
            SlowPrintLine("Palkó belépett a zöld házba.");
            int choice = Valasztas(ref currentLocation, "Az ott lakó tündér zsebének mengnézése", "Benézés az ágy alá", "Vissza");
            while (choice != 2)
            {
                switch (choice)
                {
                    case 0:
                        if (wichHouse == 3 && where == 1)
                        {
                            SlowPrintLine("Palkó megtalálta a zsebkendőt.");
                            found = true;
                            return Tovabb(helyek[20]);
                        }
                        SlowPrintLine("Palkó itt nem találta meg a zsebkendőt.");
                        break;
                    case 1:
                        if (wichHouse == 3 && where == 2)
                        {
                            SlowPrintLine("Palkó megtalálta a zsebkendőt.");
                            found = true;
                            return Tovabb(helyek[20]);
                        }
                        SlowPrintLine("Palkó itt nem találta meg a zsebkendőt.");
                        break;
                }
                choice = Valasztas(ref currentLocation, "Az ott lakó tündér zsebének mengnézése", "Benézés az ágy alá", "Vissza");
            }
            return Tovabb(helyek[20]);
        }
        public static int hely_24(ref LocationData currentLocation)
        {
            SlowPrintLine("Az Udvari bolond tündér a Tündérkirály palotájába vezette Palkót.");
            SlowPrintLine("- \"A király szomorú és szeretne hallani egy jó viccet, de én nem tudok jó viccet. Légyszíves mesélj neki egy jó viccet.\"");
            int choice = Valasztas(ref currentLocation, "vicc1", "vicc2");
            switch (choice)
            {
                case 0:
                    if (where == 1)
                    {
                        SlowPrintLine("- \"HAHAHAHAHAHAHAHAHAHAHAHA ez egy jó vicc volt! Köszönöm, hogy felvidítottál Halandó.\"");
                        helped = true;
                        return Tovabb(helyek[20]);
                    }
                    SlowPrintLine("-\"Hát ez egy szörnyen rossz vicc volt. Takarodj innen!\"");
                    return Tovabb(helyek[20]);
                case 1:
                    if (where == 1)
                    {
                        SlowPrintLine("- \"HAHAHAHAHAHAHAHAHAHAHAHA ez egy jó vicc volt! Köszönöm, hogy felvidítottál Halandó.\"");
                        helped = true;
                        return Tovabb(helyek[20]);
                    }
                    SlowPrintLine("-\"Hát ez egy szörnyen rossz vicc volt. Takarodj innen!\"");
                    return Tovabb(helyek[20]);
            }
            return 0;
        }
        public static int hely_25(ref LocationData currentLocation)
        {
            if (currentLocation.FirstTime)
            {
                SlowPrintLine("Palkó amikor megérkezett a Városba. Elcsodálkozott milyen nagy Markotabödögéhez képest, ahol felnőtt.");
                SlowPrintLine("Egy koldus ült az utcán és megszólította Palkót.");
                SlowPrintLine("- \"Jaj, legyen szíves! Nincs egy kis aprója?\"");
                int choice = Valasztas(ref currentLocation, "Koldus kisegítése", "Visszautasítás");
                bool w = false;
                switch (choice)
                {
                    case 0:
                        SlowPrintLine("- \"Köszönöm szépen! Isten segítsen téged kedvességedért cserébe!\"");
                        player.Money -= 50;
                        PrintPlayerStat();
                        return Tovabb(helyek[26], helyek[27], helyek[28]);
                    case 1:
                        SlowPrintLine("- \"Látom, hogy egy csomó pénzed van mégsem adsz? Akkor majd elveszem tőled!\"");
                        FightSystem csovesFight = new FightSystem(player, csoves, out w);
                        break;
                }
                if (w)
                {
                    return Tovabb(helyek[26], helyek[27], helyek[28]);
                }
                return 0;
            }
            SlowPrintLine("A Város még mindig meglepően nagy volt Palkó számára. Most viszont már nem látta a csövest.");
            return Tovabb(helyek[26], helyek[27], helyek[28]);
        }
        public static int hely_26(ref LocationData currentLocation)
        {
            SlowPrintLine("A Kocsma, a szórakozás központja.");
            int choice;
            do
            {
                choice = Valasztas(ref currentLocation, "Black Jack", "Ivás - 100 krajcár", "Vissza a városba");

                switch (choice)
                {
                    case 0:
                        new BlackJack(ref player).Run();
                        currentLocation.ChosenOptions[0] = false;
                        break;
                    case 1:
                        if (player.Money >= 100)
                        {
                            SlowPrintLine("Palkó a pulthoz ment, kért egy korsó sört, majd lehúzta.");
                            player.Money -= 100;
                            player.Health += 10;
                            PrintPlayerStat();
                            currentLocation.ChosenOptions[1] = false;
                            break;
                        }
                        SlowPrintLine("Palkó szegény, mint a templom egere! Nem engedheti meg magának a sört.");
                        break;
                    case 2:
                        break;
                }

            } while (choice != 2);
            return Tovabb(helyek[25]);
        }
        public static int hely_28(ref LocationData currentLocation)
        {
            if (!drake)
            {
                SlowPrintLine("Palkó belépett a király csodaszép kacsalábon forgó palotájába.");
                SlowPrintLine("- \"Üdv Ifjú Vitéz!\" - Köszöntötte a király Palkót.");
                SlowPrintLine("- \"Jöttem, hogy szerencsét próbáljak! Le akarom győzni a 3 fejű sárkányt a lányáért és birodalmáért cserébe!\" - Mondta büszkén Palkó.");
                SlowPrintLine("- \"Tiszteletre méltó a bátorságod, de figyelmeztetnelek kell, hogy már sokan megpróbálták legyőzni a 3 fejű sárkányt de elbuktak!\" - Mondta a király aggódva.");
                SlowPrintLine("- \"Biztos, hogy megpróbálsz megküzdeni a 3 fejű sárkánnyal?\"");

                int choice = Valasztas(ref currentLocation, "Igen", "Nem");
                switch (choice)
                {
                    case 0:
                        SlowPrintLine("- \"Ez esetben menj vissza a Kerekerdőbe és mássz fel az Égigérő paszuly tetejére.\n Ott fogod megtalálni a sárkányfészket, ahol a 3 fejű sárkány lakik.\"");
                        SlowPrintLine("- \"Tessék itt egy Égig érő kötél, ezzel fel fogsz tudni mászni a paszuly tetejére.\"");
                        player.NewItem(new OtherItem("Égig érő kötél", 0, type: StatType.Key));
                        SlowPrintLine("- \"Sok sikert, Ifjú Vitéz!!!\"");
                        return Tovabb(helyek[6]);
                    case 1:
                        SlowPrintLine("Palkó megfutamodott, úgy gondolta szeretne még egy kis időt tölteni a Városban, mielőtt megküzd a sárkánnyal.");
                        return Tovabb(helyek[25]);
                }
            }
            else
            {
                SlowPrintLine("Palkó a Palotába lépve egy éjjenző tömeggel találta szembe magát. A város minden lakosa ott volt.");
                SlowPrintLine("- \"Itt van hát, Városunk megmentője!\" - üdvözölte a Király");
                SlowPrintLine("Palkó nemes tettéért cserébe megkapta feleségül a gyönyörű királylányt és a király odaadta neki a vagyonának nagy részét.");
                player.Money += 1000000;
                PrintPlayerStat();
                return Tovabb(helyek[30]);
            }
            return 0;
        }
        public static int hely_29(ref LocationData currentLocation)
        {
            SlowPrintLine("Miután Palkó felérkezett az Égigérő paszuly tetejére végre megérkezett végső céljához, a SÁRKÁNYFÉSZEKHEZ.");
            SlowPrintLine("A sárkányfészekben ült a 3 FEJŰ SÁRKÁNY.");
            SlowPrintLine("- \"Már vártalak téged, Ifjú lovag\" - Dörmögte a 3 fejű sárkány.");
            SlowPrintLine("A sárkány legyőzéséhez Palkónak mind a 3 fejet le kell győznie!");

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
                        FightSystem balfejFight = new FightSystem(player, balfej, out w0);
                        w3 = true;
                        break;
                    case 1:
                        FightSystem kozepsofejFight = new FightSystem(player, kozepsofej, out w1);
                        w4 = true;
                        break;
                    case 2:
                        FightSystem jobbfejFight = new FightSystem(player, jobbfej, out w2);
                        w5 = true;
                        break;
                }
                if ((w3 && !w0) || (w4 && !w1) || (w5 && !w3))
                {
                    SlowPrintLine("A sárkány torkából hirtelen oly mennyiségű tűz tört elő, hogy Palkó hamuvá égett. Túl nagy falat volt neki a 3 fejű sárkány így elbukott.");
                    return 0;
                }

            }
            while (!(w0 && w1 && w2));
            SlowPrintLine("A sárkány utolsó fejét is levágta Palkó.\nA mostmár 3 nyakú, de 0 fejű sárkány kiterült.\nPalkó győzött! Legyőzte a Sárkányt! Már csak vissza kell mennie a Kacsalábon forgó palotába, hogy megkapja jól kiérdemelt jutalmát.");
            drake = true;
            return Tovabb(helyek[28]);
        }
        public static int hely_30(ref LocationData currentLocation)
        {
            SlowPrintLine("Elérkeztünk hát mesés történetünk végéhez. Palkó a Kacsalábon forgó kacsalábon forgó palotájában boldogan élt a királylánnyal és családjával míg meg nem halt.");SlowPrintLine("VÉGE", 250);
            SlowPrintLine("Szeretnél-e vissza menni a kocsmába még szórakozni?");
            int choice = Valasztas(ref currentLocation, "igen", "nem");
            switch (choice)
            {
                case 0:
                    return 26;
                case 1:
                    return 0;
            }
            return 0;
        }   
        #endregion

        #region Peti
        public static int hely_1(ref LocationData currentLocation)
        {
            if (currentLocation.FirstTime) { 
                SlowPrintLine("A történet Palko házában veszi kezdetét, ahol egy szép napon reggel Palko elhatározta, hogy elmegy világot látni.");
            }

            for (int i = 0; i < 2; i++)
            {
                int choice = Valasztas(ref currentLocation, "Nyissa ki a sarokban kévő ládát", "Búcsúzzon el az anyjától");
                switch (choice)
                {
                    case 0:
                        SlowPrintLine("Palkó kinyitja a ládát.");
                        SlowPrintLine("Megtalálta régi gyakorló kardját fiatal korából.");
                        SlowPrintLine("Ha a pengéje nem is annyira éles még hasznát fogja venni.");
                        Sword sword = new Sword("Fakard", 2, 0, StatType.SliderSpeed);
                        break;
                    case 1:
                        SlowPrintLine("Palkót megpróbálja lebeszélni az édesanyja, de az igazi hőst nem állítja meg semmi.");
                        SlowPrintLine("Megígéri, hogy vigyáz magára és visszatér még.");
                        break;
                    case 2:
                        break;
                }
            }
            return Tovabb(helyek[2]);
        }

        public static int hely_2(ref LocationData currentLocation)
        {
            if (currentLocation.FirstTime)
            {
                SlowPrintLine("Markotabödöge, a falu ahol Palkó az életét élte.");
                SlowPrintLine("Majdnem minden embert ismert, de most nem vesztegethette idejét.");
            }

            int choice = Valasztas(ref currentLocation, "Ki a faluból", "Paphoz");
            switch (choice)
            {
                case 0:
                    SlowPrintLine("Palko szerette volna mi hamarabb elhagyni a falut, ám egy veszett kutya útját állta");
                    SlowPrintLine("Megpróbálta kikerülni de hirtelen rátámadt.");
                    bool w;
                    FightSystem kutya = new FightSystem(player, new Enemy(20, 1, name: "Kutya"), out w);
                    if (w)
                    {
                        SlowPrintLine("Palkó sajnálta, hogy a kutyát meg kellett ölnie.");
                        SlowPrintLine("Nem volt nagy ellenfél, de úgy érezte mindent képes lenne legyőzni.");
                        SlowPrintLine("Nagy magabiztossággal indult tovább.");
                        break;
                    }
                    else
                    {
                        return 0;
                    }
                case 1:
                    SlowPrintLine("Palkó a templom felé vette az irányt.");
                    SlowPrintLine("Odaérkezve üdvözölte a papot.");
                    SlowPrintLine("- \"Dícsértessék atyám!\"");
                    SlowPrintLine("- \"Dícsértessék fiam!\"");
                    SlowPrintLine("- \"Atyám, elhatároztam, hog elmegyek világot látni. Tudom, hogy a világ tele van veszélyekkel, ezért szeretnék áldást kéreni!\"");
                    SlowPrintLine("- \"Fiam, csak Isten tud áldást adni én nem, de ezt az üvegcsét fogadd el. Ha megsebesülsz önts belőle kicsit a sebre majd a maradékot idd meg és jobban leszel.\"");
                    player.HealPotions += 1;
                    SlowPrintLine("- \"Köszönöm atyám!\"");
                    SlowPrintLine("- \"Isten áldjon, fiam\"");

                    break;
            }
            if (currentLocation.FirstTime)
            {
                SlowPrintLine("Palkó, elgondolkodott rajta, hogy lehet mégsem kéne csak úgy nekiindulni megfelelő felszerelés nélkül.");
                SlowPrintLine("Elmehet a bányába értékek után kutatni vagy a helyi gazdához dolgozni némi pénzért dolgozni, hogy a kovácstól vegyvert vásároljon.");
            }


            return Tovabb(helyek[3], helyek[4], helyek[5], helyek[6]);
        }

        public static int hely_6(ref LocationData currentLocation)
        {
            if (currentLocation.FirstTime)
            {
                SlowPrintLine("Palkó rendíthetetlen magabiztoságal lépett be a kerekerdő sötét fái közé.");
                SlowPrintLine("Egyszercsak egy csoport bandita lép elő.");
                SlowPrintLine("- \"Üdvözlet kisfíú! Rossz irányba jöttél! Most pedig átadod a vagyonod nekünk!\" - mondták nagyképűen.");
                int choice = Valasztas(ref currentLocation, "Harcolsz velük", "Adsz pénzt");
                switch (choice)
                { 
                    case 0:
                        SlowPrintLine("- \"Azt majd meglátjuk ki ad át mit!\" - válaszolt Palko megabiztosan.");
                        SlowPrintLine("- \"Azért én vigyáznék ekkora szájjal!\" - mondta a banditák főnöke majd kard-ot rántott Palkóra");
                        SlowPrintLine("Palkó ügyesen kilépett a bandita elől aki a földre esett, majd lassan fölkelt és kezdetét vette a harc.");
                        bool w;
                        FightSystem banditák = new FightSystem(player, new Enemy(50, 5,speed: 1500, name: "Banditák vezetője"), out w);
                        if (w)
                        {
                            SlowPrintLine("Szerencsére csak a szájuk volt nagy. Amint Palkó elintézte a főnököt elmenekült a többi.");
                            SlowPrintLine("Palkó nyugodtan folytathatta útját az erdőben.");
                        }
                        else
                        {
                            return 0;
                        }
                        break;
                    case 1:
                        SlowPrintLine("- \"Jólvan nyugalom adok pénzt.\" - mondta Palkó magabiztosnak tűnve.");
                        SlowPrintLine("Félt, hogy a banditák rátámadnak ha gyengének tűnik.");
                        SlowPrintLine("Adott 10 krajcárt bízva abban, hogy megelégednek vele.");
                        player.Money -= 6;
                        PrintPlayerStat();
                        SlowPrintLine("- \"Jólva fiam, most az egyszer békén hagyunk de legközelebb még az alsógatyádat is ellopjuk!\"");
                        SlowPrintLine("Ezzel a banditák távoztak.");
                        break;
                }
                SlowPrintLine("Kicsivel arrébb egy elágazáshoz érsz.");
            }
            return Tovabb(helyek[7], helyek[8], helyek[11], helyek[12]);
        }

        public static int hely_8(ref LocationData currentLocation)
        {
            if (currentLocation.FirstTime)
            {
                SlowPrintLine("Az út szélén a bokorban mozgóldást hall Palkó.");
                SlowPrintLine("Odanéz és meglát egy kék foltot eltűnni mögötte.");
                SlowPrintLine("Megvizsgálja mi van a bokor mögött és egy hupikék törpikét pillant meg.");
                SlowPrintLine("- \"Ne bánts ifjú, nem akartalak megzavarni.\" - mondta félénken a törp.");
                SlowPrintLine("- \"Ne félj, nem bántalak. Mi járatban vagy erre?\"");
                SlowPrintLine("- \"Öhmm... a kardodból arra következtettünk társaimmal, hogy harcos vagy. A segítségedre lenne szükségünk. Meghálálnánk.\"");
                int choice = Valasztas(ref currentLocation, "Elfogadod", "Nem fogadod el");
                switch (choice)
                {
                    case 0:
                        SlowPrintLine("- \"Miben kéne segíteni?\" - mondta Palkó kíváncsian.");
                        SlowPrintLine("- \"A gonosz Hókuszpók mostanában egyre többször rabol el törpöket, hogy fagyit készítsen a város lakóinak. Arra szeretnénk kérni, hogy menj el a házához és szabadítsd ki a törpöket.\"");
                        SlowPrintLine("- \"Rendben. Mutassátok az utat.\"");
                        return Tovabb(helyek[9]);
                    case 1:
                        SlowPrintLine("- \"Sajnálom, de én egy igazi kalandra vágyok nem holmi öregembert bántani\" - mondta Palkó öntelten, majd folytatta útját.");
                        return Tovabb(helyek[6]);
                }
            }
            else
            {
                SlowPrintLine("Palkó benéz a bokor mögé.");
                SlowPrintLine("Nem lát semmi érdekeset, ezért folytatja útját.");
                return Tovabb(helyek[6]);
            }   
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
        #endregion

        #region Huba
        public static int hely_5(ref LocationData currentLocation)
        {
            SlowPrintLine("Palkó belépett a műhelybe, ahol a kovács, János bácsi, éppen a forró lángok között dolgozott. Az üllőn egy csomó kovácsolt vas darab hevert, mintha valami izgalmas projektbe fogott volna.");
            if (currentLocation.FirstTime)
            {
                currentLocation.ChosenOptions[2] = true;
            }

            int choice;
            do
            {
                choice = Valasztas(ref currentLocation, "Körbenézel a műhelyben", "Vásárlás", "Vissza");
                switch (choice)
                {
                    case 0:
                        SlowPrint("Ahogy Palkó körbejárta a kovács műhelyét, csodálkozva nézte a jobbnál jobb, nagyobbnál nagyobb kardokat, pajzsokat és páncélokat, ahogy azok a falon, a magasban büszkén csillogtak. ");
                        SlowPrintLine($"Az áruk viszont túlságosan is magas volt. Palkó szegény legény, nincs pénze ilyenekre. Hátha van valami olcsóbb is. Meg kéne kérdeznem a kovácsot, mit ajánlana {player.Money} krajcár keretein bellül.");
                        break;
                    case 1:
                        smith.ShopMenu(ref player);
                        currentLocation.ChosenOptions[1] = false;
                        currentLocation.ChosenOptions[2] = false;
                        break;
                    case 2:
                        choice = -1;
                        currentLocation.ChosenOptions[2] = false;
                        break;
                }
            }
            while (choice != -1);


            return Tovabb(helyek[2]);
        }
        #endregion

        
        public static int hely_4(ref LocationData currentLocation)
        {
            return 0;
        }
        public static int hely_7(ref LocationData currentLocation)
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
        
        
        
        
        public static int hely_27(ref LocationData currentLocation)
        {

            return 0;
        }
    }
}
