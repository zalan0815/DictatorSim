using static Game.SlowPrintSystem;
using Game.Minigames;
using static Game.Program;

namespace Game
{
    partial class Locations
    {
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
                        if (mining1.Mining('0', 'O', false))
                        {
                            player.Money += 10;
                            SlowPrintLine("\nA talált gyémántok eladásával Palkó 10 krajcárra tett szert.");
                        }
                        break;
                    case 1:
                        MiningGame mining2 = new();
                        if (mining2.Mining('l', '1', false))
                        {
                            player.Money += 15;
                            SlowPrintLine("\nA talált gyémántok eladásával Palkó 100 krajcárra tett szert.");

                        }
                        break;
                    case 2:
                        MiningGame mining3 = new();
                        if (mining3.Mining('a', 'e', false))
                        {
                            player.Money += 25;
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
        public static int hely_18(ref LocationData currentLocation)
        {
            SlowPrintLine("Palkó barangolás közben egy kunyhót vett észre. A Remete kunyhója volt.");
            SlowPrintLine("- \"Szia Palkó már vártalak. Tudtam, hogy jönni fogsz. Mindent tudok.\"");
            SlowPrintLine("- \"Ne is beszélgessünk! Tudom mi kell neked. Képzeld el, tudom merre kell továbbmenned, hogy megtaláld, amit keresel. Menj a Városba, mert a Király el van keseredve, hiszen egy 3 Fejű Sárkány terrorizálja a királyságot. A Király a sárkány legyőzőjének jutalomként a királylányt és vagyonának nagy részét adja.\"");
            SlowPrintLine("- \"A Városba kettő féle képpen tudsz eljutni: a Tündérországon keresztül vagy a Poklon kerseztül. A Poklon keresztül gyorsabb, de nehezebb, viszont Tündérországba nem léphet be akárki.\"");
            SlowPrintLine("Palkó megköszönte az útbaigazítást és tovább indult.");

            return Tovabb(helyek[19], helyek[20]);
        }
        public static int hely_19(ref LocationData currentLocation)
        {
            SlowPrintLine("Palkó alászállt a poklokra. A pokol olyan volt, mint egy vulkán belseje. A padló láva, majdnem minden ég, ami nem az korom feketére égett már.");
            SlowPrintLine("Még Palkó is megégette magát egy kicsit.");
            player.Health -= 5;
            PrintPlayerStat();
            SlowPrintLine("- \"Hogy kerül egy ártatlan lélek eme gonosz helyre?\" - kérdezte egyszer csak Palkót egy mögülle jövő érces hang.");
            SlowPrintLine("Palkó nyomban sarkon fordult és meg látta a kérdés feltevőjét.");
            SlowPrintLine("A Hétszűnyü Kapanyányi Monyókot.");
            SlowPrintLine("- \"Mivel ártatlan vagy tovább engedlek a Város felé - igen tudom, hogy oda akarsz menni - ,de csak egy feltétellel: megválaszolod a találós kérdésem.\"");
            SlowPrintLine("- \"7 szénarakás meg 5 szénarakás az hány szénarakás?\"");
            SlowPrint("Megoldás: ");
            if (Console.ReadLine() == "1")
            {
                SlowPrintLine("- \"Tovább mehetsz!\"");
                return Tovabb(helyek[25]);
            }
            SlowPrintLine("- \"Ez nem talált! A megoldás: 1. Nem engedlek tovább! Csak a tesetemen keresztül mehetsz tovább!\"");
            bool w = false;
            FightSystem pokolFight = new FightSystem(player, hetszunyuKapanyanyiMonyok, out w);
            PrintPlayerStat();
            
            if (w)
            {
                SlowPrintLine("A Hétszűnyű kapanyányi monyók szurokká változott a végzetes vágás után, amit Palkó ejtett rajta és elfolyt a har helyszínéről.");
                return Tovabb(helyek[25]);
            }

            return 0;
        }
        public static int hely_20(ref LocationData currentLocation)
        {

            if (currentLocation.FirstTime)
            {
                SlowPrintLine("Palkó Tündérország díszes kapjua előtt állt, amikor hozzászólt az egyik Kapuőr tündér.");
                if (fairy)
                {
                    SlowPrintLine("-\"Üdvözöllek Tündérországban halandó! Hallottam megmentetted a Tündérkirálylányt. Nemes tettedért cseréb beengedlek!\"");
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
                        PrintPlayerStat();
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
                currentLocation.ChosenOptions[2] = false;
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
                SlowPrintLine("Palkó belépett a Király csodaszép Kacsalábon forgó palotájába.");
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
            SlowPrintLine("A sárkányfészekben ült a 3 FEJŰ SÁRKÁNY.");// itt jártam
            SlowPrintLine("- \"Már vártalak téged, Ifjú lovag\" - Dörmögte a 3 fejű sárkány.");
            SlowPrintLine("A sárkány legyőzéséhez Palkónak mind a 3 fejet le kell győznie!");

            bool w0 = true;
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
                        PrintPlayerStat();
                        break;
                    case 1:
                        FightSystem kozepsofejFight = new FightSystem(player, kozepsofej, out w0);
                        w4 = true;
                        PrintPlayerStat();
                        break;
                    case 2:
                        FightSystem jobbfejFight = new FightSystem(player, jobbfej, out w0);
                        w5 = true;
                        PrintPlayerStat();
                        break;
                }
                if (!w0)
                {
                    SlowPrintLine("a sárkány torkából hirtelen oly mennyiségű tűz tört elő, hogy palkó hamuvá égett.");
                    return 0;
                }

            }
            while (!(w3 && w4 && w5));
            SlowPrintLine("A sárkány utolsó fejét is levágta Palkó.\nA mostmár 3 nyakú, de 0 fejű sárkány kiterült.\nPalkó győzött! Legyőzte a Sárkányt! Már csak vissza kell mennie a Kacsalábon forgó palotába, hogy megkapja jól kiérdemelt jutalmát.");
            drake = true;
            return Tovabb(helyek[28]);
        }
        public static int hely_30(ref LocationData currentLocation)
        {
            SlowPrintLine("Elérkeztünk hát mesés történetünk végéhez. Palkó a Kacsalábon forgó kacsalábon forgó palotájában boldogan élt a királylánnyal és családjával míg meg nem halt.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                      EEEE                                                     \r\n                                     E::E         \r\n                                    E::E\r\n                                   EEEE                                              \r\nVVVVVVVV           VVVVVVVVEEEEEEEEEEEEEEEEEEEEEE       GGGGGGGGGGGGGEEEEEEEEEEEEEEEEEEEEEE\r\nV::::::V           V::::::VE::::::::::::::::::::E    GGG::::::::::::GE::::::::::::::::::::E\r\nV::::::V           V::::::VE::::::::::::::::::::E  GG:::::::::::::::GE::::::::::::::::::::E\r\nV::::::V           V::::::VEE::::::EEEEEEEEE::::E G:::::GGGGGGGG::::GEE::::::EEEEEEEEE::::E\r\n V:::::V           V:::::V   E:::::E       EEEEEEG:::::G       GGGGGG  E:::::E       EEEEEE\r\n  V:::::V         V:::::V    E:::::E            G:::::G                E:::::E             \r\n   V:::::V       V:::::V     E::::::EEEEEEEEEE  G:::::G                E::::::EEEEEEEEEE   \r\n    V:::::V     V:::::V      E:::::::::::::::E  G:::::G    GGGGGGGGGG  E:::::::::::::::E   \r\n     V:::::V   V:::::V       E:::::::::::::::E  G:::::G    G::::::::G  E:::::::::::::::E   \r\n      V:::::V V:::::V        E::::::EEEEEEEEEE  G:::::G    GGGGG::::G  E::::::EEEEEEEEEE   \r\n       V:::::V:::::V         E:::::E            G:::::G        G::::G  E:::::E             \r\n        V:::::::::V          E:::::E       EEEEEEG:::::G       G::::G  E:::::E       EEEEEE\r\n         V:::::::V         EE::::::EEEEEEEE:::::E G:::::GGGGGGGG::::GEE::::::EEEEEEEE:::::E\r\n          V:::::V          E::::::::::::::::::::E  GG:::::::::::::::GE::::::::::::::::::::E\r\n           V:::V           E::::::::::::::::::::E    GGG::::::GGG:::GE::::::::::::::::::::E\r\n            VVV            EEEEEEEEEEEEEEEEEEEEEE       GGGGGG   GGGGEEEEEEEEEEEEEEEEEEEEEE");
            Console.ForegroundColor = ConsoleColor.White;
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
                        SlowPrintLine("Megtalálta régi gyakorló kardját fiatal korából, és egy kis maradék pénzt.");
                        SlowPrintLine("Ha a pengéje nem is annyira éles még hasznát fogja venni.");
                        player.Money += 5;
                        player.Sword = new Sword("Fakard", 10, 0, StatType.Damage);
                        PrintPlayerStat();
                        break;
                    case 1:
                        SlowPrintLine("Palkót megpróbálja lebeszélni az édesanyja, de az igazi hőst nem állítja meg semmi.");
                        SlowPrintLine("Megígéri, hogy vigyáz magára és visszatér még.");
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
                    FightSystem kutyaFight = new FightSystem(player, kutya, out w);
                    PrintPlayerStat();
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
                    SlowPrintLine("- \"Atyám, elhatároztam, hogy elmegyek világot látni. Tudom, hogy a világ tele van veszélyekkel, ezért szeretnék áldást kéreni!\"");
                    SlowPrintLine("- \"Fiam, csak Isten tud áldást adni én nem, de ezt az üvegcsét fogadd el. Ha megsebesülsz önts belőle kicsit a sebre majd a maradékot idd meg és jobban leszel.\"");
                    player.HealPotions += 1;
                    PrintPlayerStat();
                    SlowPrintLine("- \"Köszönöm atyám!\"");
                    SlowPrintLine("- \"Isten áldjon, fiam\"");

                    break;
            }
            if (currentLocation.FirstTime)
            {
                SlowPrintLine("Palkó, elgondolkodott rajta, hogy lehet mégsem kéne csak úgy nekiindulni megfelelő felszerelés nélkül.");
                SlowPrintLine("Elmehet a bányába értékek után kutatni vagy a helyi gazdához dolgozni némi pénzért dolgozni, hogy a kovácstól fegyvert vásároljon.");
            }


            return Tovabb(helyek[3], helyek[4], helyek[5], helyek[6]);
        }
        public static int hely_4(ref LocationData currentLocation)
        {
            if (currentLocation.FirstTime)
            {
                SlowPrintLine("Palkó megérkezett a helyi földműveshez.");
                SlowPrintLine("Bekopogtatott és ajtót is nyitott.");
                SlowPrintLine("- \"Szép jónapot uram!\"");
                SlowPrintLine("- \"Üdvözöllek fiam\"");
                SlowPrintLine("- \"Nincs szüksége véletlen egy segítő kézre?\"");
                SlowPrintLine("- \"Éppenséggel tudnál segíteni, 15 krajcárét megetetheted az állatokat vagy 20 krajcárért felkapálhatod a földeket.\"");
                int choice = Valasztas(ref currentLocation, "Állat etetés", "Kapálás");
                switch (choice)
                {
                    case 0:
                        SlowPrintLine("- \"Elmegyek megetetni az állatokat!\"");
                        SlowPrintLine("- \"Rendben, én addig megyek kapálni, ha végeztél megkapod fizetésed.\"");
                        SlowPrintLine("Palkó becsületesen megetetett minden egyes állatot majd elkérte pénzét és indult is vissza a faluba.");
                        player.Money += 10;
                        PrintPlayerStat();
                        return Tovabb(helyek[2]);
                    case 1:
                        SlowPrintLine("- \"Megkapálom a földeket.\"");
                        SlowPrintLine("- \"Rendben, én addig az állatokat etetem, ha végeztél megkapod fizetésed.\"");
                        SlowPrintLine("A kapálás lefárasztotta Palkót, de cserébe jó testmozgás is, így erősebb lett.");
                        player.Health -= 5;
                        player.Money += 15;
                        PrintPlayerStat();
                        SlowPrintLine("Elkérte pénzét és indult is vissza a faluba.");
                        return Tovabb(helyek[2]);
                }
            }
            SlowPrintLine("Palkó megérkezett a helyi földműveshez.");
            SlowPrintLine("Bekopogtatott, de senki nem nyitott ajtót.");
            SlowPrintLine("Igy hát visszaindult a faluba.");
            return Tovabb(helyek[2]);
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
                        FightSystem banditákFight = new FightSystem(player, bandita, out w);
                        PrintPlayerStat();
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
                        player.Money -= 0;
                        PrintPlayerStat();
                        SlowPrintLine("- \"Jólva fiam, most az egyszer békén hagyunk de legközelebb még az alsógatyádat is ellopjuk!\"");
                        SlowPrintLine("Ezzel a banditák távoztak.");
                        break;
                }
                SlowPrintLine("Kicsivel arrébb egy elágazáshoz ér Palkó.");
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
                        SlowPrintLine("- \"Rendben. Mutassátok az utat!\"");
                        return Tovabb(helyek[9]);
                    case 1:
                        SlowPrintLine("- \"Sajnálom, de én egy igazi kalandra vágyok nem holmi öregembert bántani!\" - mondta Palkó öntelten, majd folytatta útját.");
                        return Tovabb(helyek[6]);
                }
            }
            SlowPrintLine("Palkó benéz a bokor mögé.");
            SlowPrintLine("Nem lát semmi érdekeset, ezért folytatja útját.");
            return Tovabb(helyek[6]);   
        }
        public static int hely_9(ref LocationData currentLocation)
        {
            SlowPrintLine("Amikor a ház közelébe értek, a törpök ezt mondták:");
            SlowPrintLine("- \"Ott lakik abban a házban, innentől magadra leszel utalva. Vigyázz a macskájával, Sziamiauval!\"");
            SlowPrintLine("- \"Megteszem a mi tőlem telik!\" - mondta Palkó, majd elindult a ház felé.");
            SlowPrintLine("A ház körül érdekes érzés fogta el főhősünket, a bizonytalanság érzete.");
            SlowPrintLine("Először benézett az ablakon. Semmi mozgást nem látott.");
            SlowPrintLine("Gondolta belopakodik az ajtón és megnézi hol vannak a törpök.");
            SlowPrintLine("Amint belépett az ajtón a fejére ugrott Sziamiau végig karmolva a hátát.");
            player.Health -= 5;
            PrintPlayerStat();
            SlowPrintLine("Palkó nagyon erős fájdalmat érzett, de nem pocsékolhatta idejét, mert a macska már fel is keltette az alvó Hókuszpókot");
            SlowPrintLine("Az öreg abban a pillanatban már fel is kapta a varázspálcáját, és egy varázslatot indított el Palkó felé.");
            SlowPrintLine("Palkó szerencsére időben kitért előle és felállt harcra készen.");
            SlowPrintLine("Hókuszpók pálcáját átváltoztatta karddá.");
            SlowPrintLine("Palkó kapott is az alkalmon és rá is rontott ellenfelére.");
            bool w;
            FightSystem hókuszpókFight = new FightSystem(player, hokuszpok, out w);
            PrintPlayerStat();
            if (w)
            {
                SlowPrintLine("Palkó egy végső csapással földre küldte Hókuszpókot.");
                SlowPrintLine("Az öregnek ennyi volt az utolsó szava:");
                SlowPrintLine("- \"Legalább dicső módon halok meg...\"");
                SlowPrintLine("Palkó nem gondolkozott sokat ezen, már futott is le a pincébe kiszabadítani a törpöket.");
                SlowPrintLine("Miután mindenki elhagyta a házat visszaindultak a gombafaluba ahol a törpök laktak.");
                return Tovabb(helyek[10]);
            }
            return 0;
        }
        public static int hely_10(ref LocationData currentLocation)
        {
            SlowPrintLine("A faluban Törpapa már várta Palkót:");
            SlowPrintLine("- \"Köszönöm a falu nevében, hogy megmentetted társainkat. Jutalmul fogadd el ezt a bájitalt, és a falu félretett pénzét. Biztos segíteni fog kalandod során\"");
            player.HealPotions += 1;
            player.Money += 50;
            PrintPlayerStat();
            SlowPrintLine("- \"Köszönöm szépen! Semmiség volt...\"");
            SlowPrintLine("- \"Nincs kedved itt maradni megünnepelni a győzelmedet?\"");
            int choice = Valasztas(ref currentLocation, "Elfogadod", "Nem fogadod el");
            switch (choice)
            {
                case 0:
                    SlowPrintLine("- \"Miért is ne, egy kis szórakozás nem árthat.\"");
                    player.Health += 15;
                    PrintPlayerStat();
                    SlowPrintLine("Plakó az egész estét végigmulatta és következő nap indult tovább.");
                    break;
                case 1:
                    SlowPrintLine("\"Köszönöm, igazán nagylelkű de sietek máshova.\"");
                    SlowPrintLine("Palkó ezzel elhagyta a falut és folytatta útját");
                    break;
            }
            return Tovabb(helyek[6]);
        }
        public static int hely_12(ref LocationData currentLocation)
        {
            SlowPrintLine("Palkó a boszorkányházhoz érve azt gondolta be kéne törni hátha van valami hasznos bent, de kicsit tartott a boszorkánytól.");
            int choice = Valasztas(ref currentLocation, "Betörsz", "Nem törsz be");
            switch (choice)
            {
                case 0:
                    SlowPrintLine("Palkó bemászott a hátsó ablakon.");
                    SlowPrintLine("Egyból a bájitalos szekrény mellett volt, szóval végig is nézte mi lehet számára hasznos.");
                    SlowPrintLine("Egyszer csak a semmiből előkerült a boszrka nagy kacajok közepette.");
                    SlowPrintLine("- \"Hahaha... Be mertél törni a házamba? Ezért most meglakolsz!! Hahaha...\" - mondta a boszorkány.");
                    SlowPrintLine("Palkó ilyedtében megragadt egy bájitalt a polcról és a boszorkányhoz vágta.");
                    SlowPrintLine("Szerencsére pont olyat dobott el amely néhány percre elveszi a boszorkány varázserejét.");
                    SlowPrintLine("Palkó a helyzetet kihasználva lesújtott a boszorkányra.");
                    bool w;
                    FightSystem boszorkány = new FightSystem(player, boszi, out w);
                    PrintPlayerStat();
                    if (w)
                    {
                        SlowPrintLine("A boszorkányt igaz nehéz volt megölni, de ereje nélkül igazából nem volt erős.");
                        SlowPrintLine("Palkó meglátott egy karkötőt kifele menet, és egy kis pénzt.");
                        SlowPrintLine("Gondolta elviszi.");
                        player.NewItem(new OtherItem("Ügyesség karkötője", 1, 0, StatType.SliderSpeed));
                        player.Money += 40;
                        PrintPlayerStat();
                        SlowPrintLine("Palkó boldogan indult útjára új szerzeményével.");
                        return Tovabb(helyek[13]);
                    }
                    else
                    {
                        return 0;
                    }
                case 1:
                    SlowPrintLine("Palkó a boszorkányt nem háborgatva továbbindult.");
                    return Tovabb(helyek[13]);
            }
            return Tovabb(helyek[13]);
        }
        public static int hely_13(ref LocationData currentLocation)
        {
            if (currentLocation.FirstTime)
            {
                SlowPrintLine("A hegység magas helyein mászkálva palkó elfáradt.");
                SlowPrintLine("Úgy döntött sátrat ver és alszik egyet.");
                player.Health = player.MaxHealth;
                PrintPlayerStat();
                SlowPrintLine("Egy kiadós alvás után újult erővel indulhatott tovább.");
                SlowPrintLine("Ismét egy elágazáshoz ért Palkó.");
            }
            return Tovabb(helyek[14], helyek[15], helyek[18]);
        }
        public static int hely_14(ref LocationData currentLocation)
        {
            if (currentLocation.FirstTime)
            {
                SlowPrintLine("A barlangba belépve Palkó megpillantott egy nagy kondér fölé kikötözött tündért.");
                SlowPrintLine("- \"Segítség, segítség!\" - kibálta.");
                SlowPrintLine("- \"Egyetse félj, jövök azt kikötözlek!\" - mondta Palkó majd futott volna oda a tündérhez, de megjelent az óriás.");
                SlowPrintLine("- \"Megálj betolakodó, ugye nem akarod te is a levesben végezni?\" - mondta az óriás.");
                SlowPrintLine("Az óriás 14 méteres magasságához képest Palkó csak egy eltaposandó kavics.");
                int choice = Valasztas(ref currentLocation, "Elfutsz", "Segítesz");
                switch (choice)
                {
                    case 0:
                        SlowPrintLine("Palkó helyzetét átgondolva a menekülést választotta.");
                        SlowPrintLine("Sajnálta szegény tündérlányt, de nem tehetett ellene semmit.");
                        return Tovabb(helyek[13]);
                    case 1:
                        SlowPrintLine("Palkó, határozottan kiállt az óriás ellen.");
                        SlowPrintLine("Az óriás elővette bunkóját és lesújtott Palkóra.");
                        SlowPrintLine("Palkó kikerülte, majd elkezdett az óriás felé futni");
                        bool w;
                        FightSystem óriásFight = new FightSystem(player, orias, out w);
                        PrintPlayerStat();
                        if (w)
                        {
                            SlowPrintLine("Palkó nagy nehézségek árán legyőzte az óriást és kiszabadította a tündért.");
                            SlowPrintLine("A tündér a következőt mondta:");
                            SlowPrintLine("- \"Köszönöm, hogy megmentettél, tettedet viszont nem tudom meghálálni.\"");
                            SlowPrintLine("- \"Szívesen tettem!\" - mondta Palkó.");
                            SlowPrintLine("- \"Most nekem haza kell mennem, további jó utat!\" - azzal a tündér errepült a felhők fölé.");
                            SlowPrintLine("A barlangban a föld tele volt szétdobált pénzérmékkel.");
                            player.Money += 60;
                            SlowPrintLine("Palkó összeszedett amennyit tudott majd tovább állt.");
                            return Tovabb(helyek[13]);
                        }
                        return 0;

                }
            }
            else
            {
                SlowPrintLine("Amikor palkó visszasétált a barlanghoz látta, hogy beomlott.");
                SlowPrintLine("- \"Több óriás sem költözik ide!\" - gondolta.");
            }
            return Tovabb(helyek[13]);

        }
        public static int hely_15(ref LocationData currentLocation)
        {
            if (currentLocation.FirstTime)
            {
                SlowPrintLine("Palkó alig, hogy belépett a Kutyafejű tatárok országába szembe találta magát egy csapat tatárral.");
                SlowPrintLine("- \"Betolakodó, elkapni!\" - mondta az egyikük.");
                SlowPrintLine("Palkó megpróbált elfutni de a tatárok lovai gyorsak voltak és elkapták.");
                SlowPrintLine("- \"Na ide figyelj öcsi, ha jót akarsz magadnak velünk jössz a törzsfőnökhöz és nem próbálsz meg elszökni!\"");
                SlowPrintLine("Palkó választás híján el ment velük.");
                return Tovabb(helyek[16]);
            }
            else
            {
                SlowPrintLine("Palkó megbánta, hogy betette ide a lábát, de mint tudjuk, az ember a hibáiból tanul.");
                SlowPrintLine("Ennek tudatában indult vissza a hegységbe.");
                return Tovabb(helyek[13]);
            }
        }
        public static int hely_16(ref LocationData currentLocation)
        {
            if (currentLocation.FirstTime)
            {
                SlowPrintLine("A városba érve Palkót börtönbe zárták.");
                SlowPrintLine("Egy óra múlva megjelent a kutyafejő tatárok törzsfőnöke.");
                SlowPrintLine("- \"Nos fiam, mi cél hozott ide az országomba?\"");
                SlowPrintLine("- \"Én csak átutazóban vagyok, nem akarok semmi rosszat.\"");
                SlowPrintLine("- \"Ha valóban nem akarsz rosszat akkor azt csak egy féle képpen deríthetjük ki. Menj el az erdőbe és vadássz le egy csodaszarvast. A csodaszarvasok csak a tiszta lelkűek előtt tűnnek fel.\"");
                int choice = Valasztas(ref currentLocation, "Vállalod", "Nem vállalod");
                switch (choice)
                {
                    case 0:
                        SlowPrintLine("- \"Megteszek mindent, hogy bebizonyítsam ártatlanságomat.\"");
                        SlowPrintLine("- \"Rendben, kiengedünk de 1 órát kapsz a feladatra. Ha sikerült hozd el a szarvas tetemét, ha nem jössz kutyaorrunk elől nem tudsz elbújni!\"");
                        SlowPrintLine("Azzal palkó elindul megkeresni a szarvast.");
                        return Tovabb(helyek[17]);
                    case 1:
                        SlowPrintLine("- \"Nem gondolom hogy bizonygatnom kéne ártatlanságomat!\"");
                        SlowPrintLine("- \"Velem senki nem beszélhet így! Kihívlak egy párbajra, ha nyersz elmehetsz.\"");
                        SlowPrintLine("A párbajt a börtön udvarán elő is készítették.");
                        SlowPrintLine("Palkónak még nem volt ennyire tapasztalt ellenfele, de nem riadt vissza.");
                        SlowPrintLine("- \"A párbaj kezdetét veszi:\"");
                        SlowPrintLine("- \"3\"");
                        SlowPrintLine("- \"2\"");
                        SlowPrintLine("- \"1\"");
                        SlowPrintLine("- \"START!!\"");
                        bool w;
                        FightSystem törzsfőnökFight = new FightSystem(player, tFonok, out w);
                        if (w)
                        {
                            SlowPrintLine("Palkó nagy nehezen legyőzte a törzsfőnököt.");
                            SlowPrintLine("Ez után annyira meglepődött minden kutyafejű tatár, hogy egyik sem szólt semmit csak hagyták, hogy elsétáljon.");
                            SlowPrintLine("Így palkó nyugodtan elhagyta az országot.");
                            return Tovabb(helyek[13]);
                        }
                        return 0;
                }
            }
            SlowPrintLine("Palkó amikor visszahozta a szarvast a törzsfőnök elismerően szólt hozzá:");
            SlowPrintLine("- \"Nem hittem volna, hogy sikerül. De jólvan, ha már megígértem elmehetsz.\"");
            SlowPrintLine("Palkó egy percet sem várt mielőtt a törzsfőnök meggondolná magát, azonnal el is indult az országból kifele.");
            return Tovabb(helyek[13]);
        }
        public static int hely_17(ref LocationData currentLocation)
        {
            SlowPrintLine("Palkó az erdőbe érve néhány óra séta megpillantott egy barnán csillogó valamit.");
            SlowPrintLine("Amikor közelébe ért elugrott máshova, cak ahangját hallotta.");
            SlowPrintLine("Rögtön tudta, hogy ez a szarvas lesz, ezért elkezdet követni a hangot.");
            SlowPrintLine("Kicsivel később egy tisztásra ért ahol rálátott a szrvasra, ám néha mozgolódott.");
            SlowPrintLine("Nem tudott mást tenni mint, hogy türelmesen vár a megfelelő pillanatra.");

            new DeerGame().Run();
            SlowPrintLine("Miután Palkó sikeresen lelőtte elindult vissza a törzsfőnökhöz.");
            return Tovabb(helyek[16]);
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
                        SlowPrintLine("Az áruk viszont túlságosan is magas volt. Palkó szegény legény, nincs pénze ilyenekre. Hátha van valami olcsóbb is.");
                        SlowPrintLine($"Meg kéne kérdeznem a kovácsot, mit ajánlana {player.Money} krajcár keretein bellül.");
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

        public static int hely_27(ref LocationData currentLocation)
        {
            if (currentLocation.FirstTime)
            {
                currentLocation.ChosenOptions[2] = true;
                SlowPrintLine("Palkó ezennel elérkezett a híres/hírhedt kereskedőhöz. Lajost szinte minden kalandor ismerte az Óperáciás tengeren túl'. Messze nála vannak a legegotikusabb, legjobb kardok és pajzsok a világon. Viszont vigyáznia kell, aki tőle vásárolna, hogy Lajos biztosan jól fog járni az üzlettel, de a vevő lehet nem azt kapja, amire vágyott.");
            }

            int choice;
            do
            {
                choice = Valasztas(ref currentLocation, "Körbejárás a kereskedő boltjában", "Vásárlás", "Vissza");
                switch (choice)
                {
                    case 0:
                        SlowPrint("Palkó nézelődni kezdett a kereskedő boltjában, s a szebbnél szebb, de drágábbnál drágább tárgyak szinte csillogtak tágra nyílt szemeiben. Ez volt maga a mennyország számára. ");
                        SlowPrintLine($"Az áruk viszont még mindig magas volt. Bár Palkó már annyira nem szegény, módosnak sem nevezhető. Biztos kapható valami olyan tárgy is itt, amelyet Palkó is megvehetne szerény {player.Money} krajcárjából.");
                        break;
                    case 1:
                        trader.ShopMenu(ref player);
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

            return Tovabb(helyek[25]);
        }
        
        public static int hely_7(ref LocationData currentLocation)
        {
            if (currentLocation.FirstTime)
            {
                SlowPrintLine("Palkó egy gyönyörű tisztásra érkezett. Ennél tökéletesebb hely nem is lehetne, hogy egy picit lepihenjen és gyönyörködjön az őt körülvevő tájban s elmormoljon egy imát.");
            }

            int choice;
            do
            {
                choice = Valasztas(ref currentLocation, "Imádkozás Istenhez", "Gyönyörködés a tájban", "Vissza");
                switch (choice)
                {
                    case 0:
                        currentLocation.ChosenOptions[0] = false;
                        SlowPrintLine("Palkó elmormolt egy imát, amelyben arra kérte Istent, vezesse a jó irányba.");
                        SlowPrintLine("Miután végzett az imádsággal, azt érezte, valaki szól hozzá.");
                        SlowPrintLine("Ezt hallotta Palkó:");

                        Random r = new Random();

                        string generatedText = "\n\"";
                        int words = r.Next(6,12);
                        for (int i = 0; i < words; i++)
                        {
                            generatedText += randomWords[r.Next(0, randomWords.Length)] + (i < words-1 ? " " : "\"");
                        }
                        SlowPrintLine(generatedText);
                        if (!aldas)
                        {
                            aldas = true;
                            player.Inventory.Add(new OtherItem("Isten áldása", 1, 0, StatType.SliderSpeed));
                            SlowPrintLine("Palkó érezte magán Isten áldásának erejét, úgylátszik meghallgatta kívánságát és segítséget adott neki a kalandjához.");
                            PrintPlayerStat();
                        }
                        break;
                    case 1:
                        SlowPrintLine("A tisztás szépségét a lágy fűszőnyeg, mely finoman simogatja a lábakat, teszi teljessé. A tavaszi virágok színpompája öleli körbe, miközben a madarak dallama életre kel a csendes környezetben. Az ég tiszta kékje felett szelíd szelek ringatják az ágakat, és a nap sugarai játszanak a fák lombjain. Ez a természeti oázis nyugalmat és szépséget áraszt.");
                        SlowPrintLine("A fű illatával vegyülve a friss levegő körülbelül, mintha varázslatos aromát varázsolna az egész területre. A patak partján színes pillangók repkednek, és a környező erdő zöldje mélyíti az összképet. Ezen a csodás tisztáson a természet minden mozzanata összefonódik, teremtve egy békés, idilli környezetet.");
                        break;
                    case 2:
                        choice = -1;
                        currentLocation.ChosenOptions[2] = false;
                        break;
                }
            }
            while (choice != -1);
            return Tovabb(helyek[6]);
        }
        #endregion

    }
}
