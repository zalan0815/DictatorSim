using System.Media;

namespace Game
{
    partial class Program
    {
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
        //public static SoundPlayer baseSounds = new SoundPlayer("Audio/smash.wav");
        public static SoundPlayer swordSounds = new SoundPlayer("Audio/sword.wav");
    }
}
