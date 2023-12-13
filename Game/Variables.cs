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
        public static Enemy kutya = new Enemy(20, 1, name: "Kutya");
        public static Enemy bandita = new Enemy(50, 5, speed: 1500, name: "Banditák vezetője");
        public static Enemy hokuszpok = new Enemy(70, 10, speed: 2500, name: "Hókuszpók");
        public static Enemy boszi = new Enemy(150, 10, speed: 3500, name: "Boszorkány");
        public static Enemy orias = new Enemy(200, 25, speed: 4000, name: "Óriás");
        public static Enemy tFonok = new Enemy(100, 15, speed: 1000, name: "Törzsfőnök");
        public static Enemy hetszunyuKapanyanyiMonyok = new Enemy(100, 20, speed: 1500, name: "Hétszűnyü Kapanyányi Monyók");
        public static Enemy csoves = new Enemy(50, 10, speed: 2000, name: "csöves");
        public static Enemy balfej = new Enemy(200, 50, speed: 3000, name: "Bal fej");
        public static Enemy kozepsofej = new Enemy(200, 50, speed: 3000, name: "Középső fej");
        public static Enemy jobbfej = new Enemy(200, 50, speed: 3000, name: "Jobb fej");
        #endregion

        public static Shop smith = new Shop(
            new Sword("Sima kard",          15, 30, StatType.Damage),
            new Sword("Hosszú kard",        18, 45, StatType.Damage),
            new Armor("Sima páncél",        20, 35, StatType.Health),
            new Armor("Lovagi páncél",      40, 50, StatType.Health)
            );
        public static Shop trader = new Shop(
            new Sword("Varázskard",         25, 129, StatType.Damage),
            new Sword("Lézerkard",          35, 179, StatType.Damage),
            new Armor("Varázspáncél",       60, 169, StatType.Health),
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
