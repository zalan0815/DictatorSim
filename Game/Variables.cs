using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    partial class Program
    {
        #region Enemys
        public static Enemy csoves = new Enemy(30, 5, name: "csöves");
        public static Enemy balfej = new Enemy(200, 50, name: "Bal fej");
        public static Enemy kozepsofej = new Enemy(200, 50, name: "Középső fej");
        public static Enemy jobbfej = new Enemy(200, 50, name: "Jobb fej");
        public static Enemy hetszunyuKapanyanyiMonyok = new Enemy(100, 30, name: "Hétszűnyü Kapanyányi Monyók");
        public static Enemy asd = new Enemy(0, 0, name: "asd");
        //public static Enemy asd = new Enemy(0, 0, name: "asd");
        //public static Enemy asd = new Enemy(0, 0, name: "asd");
        //public static Enemy asd = new Enemy(0, 0, name: "asd");
        #endregion

        public static Shop smith = new Shop(
            new Sword("Sima kard",          2,  20, StatType.SliderSpeed),
            new Sword("Hosszú kard",        25, 35, StatType.Damage),
            new Armor("Sima páncél",        20, 25, StatType.Health),
            new Armor("Lovagi páncél",      40, 40, StatType.Health)
            );
        public static Shop trader = new Shop(
            new Sword("Varázskard",         55, 129, StatType.Damage),
            new Sword("Lézerkard",          5,  179, StatType.SliderSpeed),
            new Armor("Varázspáncél",       100,169, StatType.Health),
            new OtherItem("Sima sisak",     40, 200, StatType.Health)
            );

        public static bool fairy = true;
        public static Random rnd = new Random();
        public static int wichHouse = rnd.Next(1, 4);
        public static int where = rnd.Next(1, 3);

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
    }
}
