using System;
using System.Collections.Generic;
using System.Text;

namespace FalopaBot.Lib.Models
{
    public class FalopaSound
    {
        public static FalopaSound Hello = new FalopaSound("sounds\\hello.mp3");
        public static FalopaSound Broken = new FalopaSound("sounds\\broken.mp3");
        public static FalopaSound GodNo = new FalopaSound("sounds\\godno.mp3");
        public static FalopaSound Attitude = new FalopaSound("sounds\\dontneedatt.mp3");
        public static FalopaSound AskQuestion = new FalopaSound("sounds\\askques.mp3");
        public static FalopaSound Assasinate = new FalopaSound("sounds\\assas.mp3");
        public static FalopaSound Assasinate2 = new FalopaSound("sounds\\assas-2.mp3");
        public static FalopaSound Boots = new FalopaSound("sounds\\boots.mp3");
        public static FalopaSound BrannigansLaw = new FalopaSound("sounds\\branlaw.mp3");
        public static FalopaSound Broad = new FalopaSound("sounds\\broad.mp3");
        public static FalopaSound CantAllow = new FalopaSound("sounds\\cantallow.mp3");
        public static FalopaSound Conaroused = new FalopaSound("sounds\\conaroused.mp3");
        public static FalopaSound DealFemale = new FalopaSound("sounds\\dealfem-2.mp3");
        public static FalopaSound DisgustMeMore = new FalopaSound("sounds\\disgustmemore.mp3");
        public static FalopaSound Dogfight = new FalopaSound("sounds\\dogfight-2.mp3");
        public static FalopaSound HaveSex = new FalopaSound("sounds\\havesex.mp3");
        public static FalopaSound ImPathetic = new FalopaSound("sounds\\impath.mp3");
        public static FalopaSound Lonely = new FalopaSound("sounds\\lonely.mp3");
        public static FalopaSound MadeABra = new FalopaSound("sounds\\madebra.mp3");
        public static FalopaSound MadeItWithAWoman = new FalopaSound("sounds\\madewithwoman-2.mp3");
        public static FalopaSound MakeTimeTogether = new FalopaSound("sounds\\maketimetog.mp3");
        public static FalopaSound ManDream = new FalopaSound("sounds\\mandream.mp3");
        public static FalopaSound Menu = new FalopaSound("sounds\\menu.mp3");
        public static FalopaSound MornLover = new FalopaSound("sounds\\mornlover.mp3");
        public static FalopaSound MyWoman = new FalopaSound("sounds\\mywoman.mp3");
        public static FalopaSound Noodle = new FalopaSound("sounds\\noodle.mp3");
        public static FalopaSound NotGuilty = new FalopaSound("sounds\\notguilty.mp3");
        public static FalopaSound Order = new FalopaSound("sounds\\order.mp3");
        public static FalopaSound Rav = new FalopaSound("sounds\\rav.mp3");
        public static FalopaSound SchoolGirls = new FalopaSound("sounds\\schoolgirls.mp3");
        public static FalopaSound Seduction = new FalopaSound("sounds\\seduction.mp3");
        public static FalopaSound Tail = new FalopaSound("sounds\\tail.mp3");
        public static FalopaSound Underarrest = new FalopaSound("sounds\\underarrest.mp3");
        public static FalopaSound Work = new FalopaSound("sounds\\work.mp3");
        public static FalopaSound Work2 = new FalopaSound("sounds\\work-2.mp3");


        public static List<FalopaSound> Sounds = new List<FalopaSound>
        {
            //Hello, // Exclusive for join
            Broken,
            GodNo,
            Attitude,
            AskQuestion,
            Assasinate,
            Assasinate2,
            Boots,
            BrannigansLaw,
            Broad,
            CantAllow,
            Conaroused,
            DealFemale,
            DisgustMeMore,
            Dogfight,
            HaveSex,
            ImPathetic,
            Lonely,
            MadeABra,
            MadeItWithAWoman,
            MakeTimeTogether,
            ManDream,
            Menu,
            MornLover,
            MyWoman,
            Noodle,
            NotGuilty,
            Order,
            Rav,
            SchoolGirls,
            Seduction,
            Tail,
            Underarrest,
            Work,
            Work2
        };

        public static FalopaSound RandomSound() => Sounds.Random();



        public string Filename { get; set; }

        public FalopaSound(string filename)
        {
            Filename = filename;
        }
    }
}
