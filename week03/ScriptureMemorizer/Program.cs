using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        // Create a library of scriptures for varietys
        List<Scripture> scriptures = GetScriptureLibrary();

        // Continue allowing users to memorize scriptures
        bool keepGoing = true;
        while (keepGoing)
        {
            // Select a random scripture from the library
            Random random = new Random();
            int randomIndex = random.Next(scriptures.Count);
            Scripture scripture = scriptures[randomIndex];

            // Run the memorization session
            RunMemorizationSession(scripture);

            // Ask if user wants to try another scripture
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Would you like to memorize another scripture? (yes/no)");
            string response = Console.ReadLine().ToLower();
            if (response != "yes" && response != "y")
            {
                keepGoing = false;
            }
        }

        Console.WriteLine("\nThank you for using Scripture Memorizer!");
        Console.WriteLine("Keep practicing and the scriptures will be in your heart.");
    }
    static void RunMemorizationSession(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine(new string('=', 60));
        Console.WriteLine("SCRIPTURE MEMORIZER");
        Console.WriteLine(new string('=', 60));

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(scripture.GetReference());
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine(new string('=', 60));
            int hidden = scripture.GetHiddenWordCount();
            int total = scripture.GetWordCount();
            Console.WriteLine($"Progress: {hidden}/{total} words hidden");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("Press ENTER to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                Console.WriteLine("\nSession ended. Great effort!");
                return;
            }
            scripture.HideRandomWord();
        }
        Console.Clear();
        Console.WriteLine(new string('=', 60));
        Console.WriteLine(scripture.GetReference());
        Console.WriteLine(new string('=', 60));
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine(new string('=', 60));
        Console.WriteLine("Congratulations! You have hidden all the words!");
        Console.WriteLine("You have completed memorizing this scripture.");
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
    }
    static List<Scripture> GetScriptureLibrary()
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding: In all thy ways acknowledge him, and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("Philippians", 4, 8),
                "Finally, brethren, whatsoever things are true, whatsoever things are honest, whatsoever things are just, whatsoever things are pure, whatsoever things are lovely, whatsoever things are of good report; if there be any virtue, and if there be any praise, think on these things."
            ),
            new Scripture(
                new Reference("Psalm", 23, 1, 6),
                "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: he leadeth me beside the still waters. He restoreth my soul: he leadeth me in the paths of righteousness for his name's sake. Yea, though I walk through the valley of the shadow of death, I will fear no evil: for thou art with me; thy rod and thy staff they comfort me. Thou preparest a table before me in the presence of mine enemies: thou anointest my head with oil; my cup runneth over. Surely goodness and mercy shall follow me all the days of my life: and I will dwell in the house of the Lord for ever."
            ),
            new Scripture(
                new Reference("Matthew", 5, 3, 10),
                "Blessed are the poor in spirit: for theirs is the kingdom of heaven. Blessed are they that mourn: for they shall be comforted. Blessed are the meek: for they shall inherit the earth. Blessed are they which do hunger and thirst after righteousness: for they shall be filled. Blessed are the merciful: for they shall obtain mercy. Blessed are the pure in heart: for they shall see God. Blessed are the peacemakers: for they shall be called the children of God. Blessed are they which are persecuted for righteousness' sake: for theirs is the kingdom of heaven."
            ),
            new Scripture(
                new Reference("1 John", 3, 16),
                "Hereby perceive we the love of God, because he laid down his life for us: and we ought to lay down our lives for the brethren."
            ),
            new Scripture(
                new Reference("Joshua", 1, 8),
                "This book of the law shall not depart out of thy mouth; but thou shalt meditate therein day and night, that thou mayest observe to do according to all that is written therein: for then thou shalt make thy way prosperous, and then thou shalt have good success."
            )
        };
        return scriptures;
    }
}