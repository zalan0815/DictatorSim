using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Game
{
    partial class Program
    {
        #region Enemys
        public static Enemy kutya = new Enemy(20, 1, speed: 30000, name: "Kutya");
        public static Enemy bandita = new Enemy(50, 5, speed: 1500, name: "Banditák vezetője");
        public static Enemy hokuszpok = new Enemy(70, 10, speed: 2500, name: "Hókuszpók");
        public static Enemy boszi = new Enemy(150, 10, speed: 3500, name: "Boszorkány");
        public static Enemy orias = new Enemy(200, 25, speed: 4000, name: "Óriás");
        public static Enemy tFonok = new Enemy(100, 15, speed: 1000, name: "Törzsfőnök");
        public static Enemy hetszunyuKapanyanyiMonyok = new Enemy(100, 20, speed: 1500, name: "Hétszűnyü Kapanyányi Monyók");
        public static Enemy csoves = new Enemy(10, 10, speed: 2000, name: "csöves");
        public static Enemy balfej = new Enemy(200, 40, speed: 3000, name: "Bal fej");
        public static Enemy kozepsofej = new Enemy(200, 40, speed: 3000, name: "Középső fej");
        public static Enemy jobbfej = new Enemy(200, 40, speed: 3000, name: "Jobb fej");
        #endregion

        public static Shop smith = new Shop(
            new Sword("Sima kard",          15, 25, StatType.Damage),
            new Sword("Hosszú kard",        18, 40, StatType.Damage),
            new Armor("Sima páncél",        20, 30, StatType.Health),
            new Armor("Lovagi páncél",      40, 45, StatType.Health)
            );
        public static Shop trader = new Shop(
            new Sword("Varázskard",         25, 70, StatType.Damage),
            new Sword("Lézerkard",          35, 90, StatType.Damage),
            new Armor("Varázspáncél",       60, 85, StatType.Health),
            new OtherItem("Sima sisak",     40, 60, StatType.Health)
            );

        public static bool fairy = false;
        public static Random rnd = new Random();
        public static int wichHouse = rnd.Next(1, 4);
        public static int where = rnd.Next(1, 3);

        public static bool aldas = false;

        public static bool won = false;

        public static bool helping = false;
        public static bool found = false;
        public static bool helped = false;

        public static bool drake = false;


        public static string[] randomWords = new string[120]
        {
            "lovag", "kard", "vár", "kút", "mező", "erdő", "pajzs", "sisak", "íj", "nyíl",
            "kő", "fal", "portya", "udvar", "király", "királynő", "kocsi", "szolgáló", "szolga", "ékszer",
            "kávé", "tea", "bor", "pohár", "serleg", "papír", "könyv", "toll", "tinta", "doboz",
            "szépség", "szerelem", "dal", "zene", "gyöngy", "gyertya", "pékség", "borbély", "kocsmáros", "kendő",
            "csizma", "ruha", "cipő", "kalap", "kabát", "szoknya", "ing", "nadrág", "kesztyű", "köpeny",
            "tükör", "óra", "gyűrű", "ékszer", "szűr", "ló", "szekér", "patkó", "bogár", "madár",
            "kemence", "kenyér", "tészta", "hús", "hal", "tojás", "só", "fűszer", "kandalló", "kéreg",
            "szobor", "festmény", "templom", "kolostor", "kápolna", "oltár", "szószék", "fa", "kő", "szék",
            "ágy", "asztal", "szekrény", "szőnyeg", "lámpa", "ablak", "ajtó", "kulcs", "kőrisfa", "gyertyatartó",
            "korona", "trón", "címertábla", "láthatatlan toll", "szent grál", "lovagi turné", "gyóntatószék", "bíró", "királyi pecsét", "kódex",
            "írástudó", "prédikátor", "apát", "térkép", "iránytű", "bot", "szekérkép", "kátrány", "tej", "sajt",
            "baromfi", "gyümölcs", "zöldség", "borjú", "juh", "birka", "kecske", "macska", "kutya", "madár"
        };

        public static string[] sorok =
        {
            "A JÁTÉKOT KITALÁLTA:",
            "Bende Huba",
            "Kovács Péter",
            "Tófalvi Zalán",
            "",
            "A JÁTÉKOT KÉSZÍTETTE:",
            "Bende Huba",
            "Kovács Péter",
            "Tófalvi Zalán",
            "",
            "A JÁTÉKOT TESZTELTE:",
            "Bende Huba",
            "Kovács Péter",
            "Tófalvi Zalán",
            "Süke Benedek",
            "",
            "A KÉSZÍTÉST TERRORIZÁLTA:",
            "Csöngető Csongor",
            "Roncz Olivér",
            "Süke Benedek",
            "Pintér Bálint",
            "Reinhardt Benjámin",
            "",
            "KÜLÖN KÖSZÖNET:",
            "Bognár Pál tanárúrnak a felkészítésért",
            "Sándor László tanárúrnak, hogy dolgozhattunk az óráján",
            "Süke Bendeknek a középre igazításért",
            "Az internetnek a segítségért",
            "",
            "",
            "Köszönjük szépen, hogy játszottál a játékunkkal!"
        };

        public static string[] palko =
        {
           "PPPPPPPPPPPPPPPPP                   lllllll kkkkkkkk                   oooo   ",
           "P::::::::::::::::P                  l:::::l k::::::k                  o::o    ",
           "P::::::PPPPPP:::::P                 l:::::l k::::::k                 o::o     ",
           "PP:::::P     P:::::P                l:::::l k::::::k                oooo      ",
           "  P::::P     P:::::Paaaaaaaaaaaaa    l::::l  k:::::k    kkkkkkk ooooooooooo   ",
           "  P::::P     P:::::Pa::::::::::::a   l::::l  k:::::k   k:::::koo:::::::::::oo ",
           "  P::::PPPPPP:::::P aaaaaaaaa:::::a  l::::l  k:::::k  k:::::ko:::::::::::::::o",
           "  P:::::::::::::PP           a::::a  l::::l  k:::::k k:::::k o:::::ooooo:::::o",
           "  P::::PPPPPPPPP      aaaaaaa:::::a  l::::l  k::::::k:::::k  o::::o     o::::o",
           "  P::::P            aa::::::::::::a  l::::l  k:::::::::::k   o::::o     o::::o",
           "  P::::P           a::::aaaa::::::a  l::::l  k:::::::::::k   o::::o     o::::o",
           "  P::::P          a::::a    a:::::a  l::::l  k::::::k:::::k  o::::o     o::::o",
           "PP::::::PP        a::::a    a:::::a l::::::lk::::::k k:::::k o:::::ooooo:::::o",
           "P::::::::P        a:::::aaaa::::::a l::::::lk::::::k  k:::::ko:::::::::::::::o",
           "P::::::::P         a::::::::::aa:::al::::::lk::::::k   k:::::koo:::::::::::oo ",
           "PPPPPPPPPP          aaaaaaaaaa  aaaallllllllkkkkkkkk    kkkkkkk ooooooooooo   ",
        };
        public static string[] vege =
        {
            "                                     EEEE                                                  ",
            "                                    E::E                                                   ",
            "                                   EEEE                                                    ",
            "VVVVVVVV           VVVVVVVVEEEEEEEEEEEEEEEEEEEEEE       GGGGGGGGGGGGGEEEEEEEEEEEEEEEEEEEEEE",
            "V::::::V           V::::::VE::::::::::::::::::::E    GGG::::::::::::GE::::::::::::::::::::E",
            "V::::::V           V::::::VE::::::::::::::::::::E  GG:::::::::::::::GE::::::::::::::::::::E",
            "V::::::V           V::::::VEE::::::EEEEEEEEE::::E G:::::GGGGGGGG::::GEE::::::EEEEEEEEE::::E",
            " V:::::V           V:::::V   E:::::E       EEEEEEG:::::G       GGGGGG  E:::::E       EEEEEE",
            "  V:::::V         V:::::V    E:::::E            G:::::G                E:::::E             ",
            "   V:::::V       V:::::V     E::::::EEEEEEEEEE  G:::::G                E::::::EEEEEEEEEE   ",
            "    V:::::V     V:::::V      E:::::::::::::::E  G:::::G    GGGGGGGGGG  E:::::::::::::::E   ",
            "     V:::::V   V:::::V       E:::::::::::::::E  G:::::G    G::::::::G  E:::::::::::::::E   ",
            "      V:::::V V:::::V        E::::::EEEEEEEEEE  G:::::G    GGGGG::::G  E::::::EEEEEEEEEE   ",
            "       V:::::V:::::V         E:::::E            G:::::G        G::::G  E:::::E             ",
            "        V:::::::::V          E:::::E       EEEEEEG:::::G       G::::G  E:::::E       EEEEEE",
            "         V:::::::V         EE::::::EEEEEEEE:::::E G:::::GGGGGGGG::::GEE::::::EEEEEEEE:::::E",
            "          V:::::V          E::::::::::::::::::::E  GG:::::::::::::::GE::::::::::::::::::::E",
            "           V:::V           E::::::::::::::::::::E    GGG::::::GGG:::GE::::::::::::::::::::E",
            "            VVV            EEEEEEEEEEEEEEEEEEEEEE       GGGGGG   GGGGEEEEEEEEEEEEEEEEEEEEEE"
        };
    }
}
