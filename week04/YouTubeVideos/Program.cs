using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();
        Video video1 = new Video(
            "Jungles: Survival of the Fittest (Full Episode) | Hostile Planet",
            "National Geographic",
            742
        );
        video1.AddComment(new Comment("DiamondRubyJewel",   "THE JAGUAR KILL WAS THE BEST KILL I'VE EVERRRRR WITNESSED IN MY LIFE!!!!THANK YOU NATGEO!!!!!!"));
        video1.AddComment(new Comment("RS33381",     "The jaguar catching the aligator was honestly the most impressive and horrifying thing ive ever seen"));
        video1.AddComment(new Comment("georgecarberry9222",     "The videography in this documentary is fantastic.  National Geographic has outdone itself with this film."));
        video1.AddComment(new Comment("D.P.R.",  " A truly beautiful piece of art ,calms me beyond. Thank you NatGeo"));

        videos.Add(video1);
        Video video2 = new Video(
            "Drivers React After The Race | 2026 Canadian Grand Prix",
            "Formula 1",
            1834
        );
        video2.AddComment(new Comment("LRaahul2306",   "Stroll finishes ahead of George in his home GP"));
        video2.AddComment(new Comment("Goldenslayer",  "Max seeing the light for the first time this year"));
        video2.AddComment(new Comment("trackandfieldarchive",   "Franco is cooking!! Great drive again."));

        videos.Add(video2);
        Video video3 = new Video(
            "The Crystal That Could Destroy All Medicine",
            "Veritasium",
            2291
        );
        video3.AddComment(new Comment("jameshoffmann",   "I've really got to start double-checking I've locked the studio up properly..."));
        video3.AddComment(new Comment("HesterClapp",    "Finally, a chemical disaster video that wasn't caused by the manufacturer lying to the public and burying evidence to preserve their profits!"));
        video3.AddComment(new Comment("newbie4789",  "I love the subtle nod to the fact that cooking is very high level material science"));
        video3.AddComment(new Comment("MonkeySasquatch",  "Teacher, I did my homework, but it changed into a different polymorph"));

        videos.Add(video3);
        Video video4 = new Video(
            "The new Ferrari Luce: My HONEST take...",
            "carwow",
            3107
        );
        video4.AddComment(new Comment("TomPrice-x2c",   "It looks about £30k worth"));
        video4.AddComment(new Comment("jetstreamsam2657",   "I always wanted a bigger Honda jazz for 600k..."));
        video4.AddComment(new Comment("mollypila",   "To be honest, this is a terrific car; all they need to do is change the name to BYD and reduce the price by more than 90%"));

        videos.Add(video4);
        foreach (Video video in videos)
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Title:    {video.Title}");
            Console.WriteLine($"Author:   {video.Author}");
            Console.WriteLine($"Length:   {video.LengthInSeconds} seconds");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("----------------------------------------");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"  {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}