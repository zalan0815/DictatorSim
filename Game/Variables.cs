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

        public static string[] viccek =
        {
            "Miért esik le a krumpli a levesből? Mert főként!",
            "Miért siet a tej? Mert mindig lefőz!",
            "Miért nem kap a szellem sosem számot? Mert mindig túl átlátható!",
            "Miért keresi a kuka mindig a szemetet? Mert szereti, ha koszos!",
            "Miért nevet mindig a végzős diák? Mert már nincs otthon felügyelet!",
            "Miért cipel magával szemüveget a matektanár? Mert mindig el akarja szorzni!",
            "Miért esik le a bicikli? Mert kettes szám!",
            "Miért hozza a pulyka mindig magával a napernyőt? Mert szereti a kivirágzást!",
            "Miért beszél folyton a tojás? Mert mindig fel van tojva!",
            "Miért hozza a cápa mindig a tolltartóját az órára? Mert írás közben nagyon csendes!",
            "Miért olvas mindig a porszívó? Mert szereti a poros sztorikat!",
            "Miért utasította vissza a narancslé a munkát? Mert nem volt benne elég pezsgés!",
            "Miért eszik mindig a fűnyíró? Mert fűlékeny!",
            "Miért hoz mindig magával a süni napernyőt? Mert szereti, ha süt a nap!",
            "Miért hord szemüveget a kifli? Mert nagyon kerek a világnézete!",
            "Miért fél a villanykörte? Mert mindig kialszik, ha megdicsérik!",
            "Miért hozza a tűzőgép mindig a zokniját a munkába? Mert szereti, ha a lábán dolgozik!",
            "Miért hord mindig hálóinget a madár? Mert mindig pihen!",
            "Miért nincs szőke szellem? Mert mindig átlátszó!",
            "Miért szereti a kávé mindig a forró vizet? Mert utána mindig jó napja van!",
            "Miért tanul mindig a könyv? Mert szereti a fejét!",
            "Miért viszi mindig a víziló a pénztárcáját a medencébe? Mert szereti a mély vizet!",
            "Miért nem kap parkolócédulát a robot? Mert mindig jól parkol!",
            "Miért nem szereti a szellem a liftet? Mert mindig felmegy az idege!",
            "Miért hozza a kígyó mindig magával a mérőszalagot? Mert mindig pontos!",
            "Miért hozza a pulyka mindig magával a tükörét? Mert szereti, ha kijön a képéből!",
            "Miért jár mindig a cipő a boltba? Mert mindig új pár cipőt vesz!",
            "Miért nevet mindig a nap? Mert mindig ragyog!",
            "Miért nem kap szabadságot a fény? Mert mindig dolgozik!",
            "Miért szeret mindig a fa a tévé előtt ülni? Mert szereti a fa-műsort!",
            "Miért hozza mindig a lufi a ceruzáját az iskolába? Mert mindig felveszi a levegőt!",
            "Miért hozza mindig a pók a hálóját az irodába? Mert mindig kapcsolatokat keres!",
            "Miért viszi mindig a varjú a telefonját? Mert mindig hívja a társaságát!",
            "Miért hozza mindig a körte a fésűjét a fán? Mert szereti, ha a hajába fúj a szél!",
            "Miért olvassa mindig a könyv a könyvjelzőjét? Mert mindig el akarja jegyezni, hol tart!",
            "Miért futkározik mindig a villamos? Mert szereti, ha folyamatosan kapcsolatban van!",
            "Miért nő meg mindig a virág? Mert mindig kap elég napfényt!",
            "Miért hozza a foci mindig a labdáját az irodába? Mert mindig gólt akar elérni!",
            "Miért hozza a szamár mindig a padlást? Mert mindig fent akar lenni!",
            "Miért hozza mindig a szél a hűségét? Mert mindig megfúj!",
            "Miért hozza mindig a hűtő a pólóját a konyhába? Mert mindig jól hűti!",
            "Miért szereti mindig a kalap a zenét? Mert mindig hallja a nótát!",
            "Miért hozza mindig a patak a zenekarját a vízeséshez? Mert mindig jól zúg!",
            "Miért hozza mindig a dinoszaurusz a könyvtárba a könyvjelzőjét? Mert mindig nagyon elmaradt!",
            "Miért hozza mindig a postás a csomagját a bokorba? Mert mindig jó címre érkezik!",
            "Miért hozza mindig a patkány a könyvét a sajátmagához? Mert mindig érdekli a történet!",
            "Miért hozza mindig a kakas a városba a kukoricáját? Mert mindig kukorékol!",
            "Miért eszik mindig a kenyér a szótárt? Mert szereti a szavakat!",
            "Miért hozza mindig a hangyaboly a zenekarját a piknikre? Mert mindig jó zenélnek!",
            "Miért hozza mindig a bokor a hajkeféjét a füredre? Mert mindig fésülik a leveleit!",
            "Miért olvassa mindig a fűnyíró a könyvét? Mert szereti a fűnyírástörténeteket!",
            "Miért hozza mindig a malac a kis labdáját a tanórára? Mert mindig jól pattog!",
            "Miért hozza mindig a hangyaboly a kajaasztalát a piknikre? Mert mindig beözönlnek az ételek!",
            "Miért hozza mindig a malac a napernyőjét a strandra? Mert mindig felégeti a bőrét!",
            "Miért hozza mindig a könyv a vonalzóját az órára? Mert mindig jól megrajzolja a sztorijait!",
            "Miért hozza mindig a számológép a könyvét a munkahelyére? Mert mindig jól számol!",
            "Miért hozza mindig a dió a kétlábút a kertjébe? Mert mindig jól nézegetik a mutatványait!",
            "Miért hozza mindig a hajó a saját kormányát a tengerre? Mert mindig irányt tart!",
            "Miért hozza mindig a kóbor kutya a golyóját a focimeccsre? Mert mindig jó kapust játszik!",
            "Miért hozza mindig a nap a napszemüvegét a tengerpartra? Mert mindig kisüt!",
            "Miért viszi mindig a postás a biciklijét a levélbekerítőhöz? Mert mindig gyorsan áthalad!",
            "Miért hozza mindig a tűzoltó a kulcscsomóját a tűzhöz? Mert mindig meg akarja nyitni a helyet!",
            "Miért hozza mindig a kóbor macska a ceruzáját a jegyzetfüzetéhez? Mert mindig felsejlik benne egy regény!",
            "Miért hozza mindig a madár a telefont a fészkébe? Mert mindig hívják a tojásai!",
            "Miért hozza mindig a cipő a kanapét az órára? Mert mindig ül rajta!",
            "Miért hozza mindig a kígyó a mértani vonalzóját a matekórára? Mert mindig sziszeg!",
            "Miért hozza mindig a pók a szövőkeretét a munkahelyére? Mert mindig szálkás a munkája!",
            "Miért hozza mindig a könyv a pólóját az olvasókörre? Mert mindig jó az ízlése!",
            "Miért hozza mindig a szellem a laptopját a kísértetházba? Mert mindig online!",
            "Miért hozza mindig a kakas a fésűjét a barátnőjéhez? Mert mindig szépen felkunkorodik!",
            "Miért hozza mindig a kacsa a varrótűjét a tavaszi koncertre? Mert mindig szálkás a tolla!",
            "Miért hozza mindig a szendvics a fülhallgatóját a koncertre? Mert mindig szereti a zenét!",
            "Miért hozza mindig a víziló a búvárfelszerelését a medencébe? Mert mindig mélyen merül!",
            "Miért hozza mindig a csiga a szótárat a koncertre? Mert mindig jól kiejti a hangokat!",
            "Miért hozza mindig a kalap a kenyérzsírt a koncertre? Mert mindig jó vastagon fedi a zenét!",
            "Miért hozza mindig a kutya a focilabdáját a koncertre? Mert mindig jó passzokat játszik!",
            "Miért hozza mindig a hangyaboly a picknickkosarát a koncertre? Mert mindig bőven van beözönlő jó hang!",
            "Miért hozza mindig a liba a frizbije a koncertre? Mert mindig jó dobásokat tesz!",
            "Miért hozza mindig a foci a füleseit a koncertre? Mert mindig szereti a zenei ütemeket!",
            "Miért hozza mindig a tévé a távirányítóját a koncertre? Mert mindig kapcsolgat!",
            "Miért hozza mindig a porszívó a tisztítófejét a koncertre? Mert mindig jó szívvel porszívózik!",
            "Miért hozza mindig a jegyzetfüzet a radírját a koncertre? Mert mindig jól törlődik a rossz hangokat!",
            "Miért hozza mindig a pulyka a napernyőjét a koncertre? Mert mindig szereti a szólókat!",
            "Miért hozza mindig a bicikli a sárvédőjét a koncertre? Mert mindig felspriccel!",
            "Miért hozza mindig a víziló a búvármellényét a koncertre? Mert mindig mélyen éli meg a zenét!",
            "Miért hozza mindig a kávé a kávéskanálját a koncertre? Mert mindig jól megkeveri az élményeket!",
            "Miért hozza mindig a dió a héját a koncertre? Mert mindig jól felrepül!",
            "Miért hozza mindig a foci a sípját a koncertre? Mert mindig jól fújja a hangokat!",
            "Miért hozza mindig a malac a kürtjét a koncertre? Mert mindig jó malacul!"
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
