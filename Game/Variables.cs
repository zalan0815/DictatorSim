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

    }
}
