using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var asciiArt = new AsciiArt();


        Console.WriteLine(@"
        
        
                    ____
                  .'* *.'
               __/_*_*(_
              / _______ \
             _\_)/___\(_/_
            / _((\- -/))_ \
            \ \())(-)(()/ /
             ' \(((()))/ '
            / ' \)).))/ ' \
           / _ \ - | - /_  \
          (   ( .;''';. .'  )
          _\ __ /    )\ __ /_
            \/  \   ' /  \/
             .'  '...' ' )
              / /  |  \ \
             / .   .   . \
            /   .     .   \
           /   /   |   \   \
         .'   /    b    '.  '.
     _.-'    /     Bb     '-. '-._
 _.-'       |      BBb       '-.  '-.
(___________(____.dBBBb.________)____)


        
        ");
        // Create player
        Console.WriteLine("A low hum fills the air as the faint outline of a figure materializes before you.\n"+ 


        "The swirling lights solidify into the shape of a wizard—his robes shimmering like the night sky, his eyes glowing faintly with wisdom.\n"+

        "He strokes his long, silver beard and gazes at you with curiosity. 'Ah, there you are,' he says, his voice both warm and commanding.\n"+ 
        "What's your name?");
        string playerName = Console.ReadLine();
        Console.WriteLine($"'Well met, {playerName},' he continues.\n"+
        "'You are here because destiny has chosen you. But before we begin your journey, we must prepare you for the trials ahead.\n"+

        "He waves his staff, and two glowing orbs appear in the air. \n"+

        "Distribute your points,' he commands. 'You have 10 points to allocate between Strength and Intelligence. \n"+
        "Choose wisely, for this will shape the path you take.");
        
        Console.WriteLine(@"
        
        
          69696969                         69696969
       6969    696969                   696969    6969
     969    69  6969696               6969  6969     696
    969        696969696             696969696969     696
   969        69696969696           6969696969696      696
   696      9696969696969           969696969696       969
    696     696969696969             969696969        969
     696     696  96969               9696969  69    696
       9696    969696                   696969    6969
          96969696                         69696969
             96                               69
             69                               96
            6969                             9696


        
        ");


    

        int strength = GetAttribute("Strength");
        int intelligence = 20 - strength;

        Player player = new Player(playerName, strength, intelligence);

        Console.WriteLine($"As the energy settles, the wizard steps closer. 'You are the chosen one,' he says solemnly.\n"+
        "An ancient evil stirs, threatening to unravel all that is good. You alone hold the power to stop it.\n"+
        " Your journey will be fraught with peril and wonder, and the choices you make will shape the very fabric of reality.");
        Console.WriteLine("Your journey begins!");

        Console.WriteLine(@"
        
                    ~         ~~          __
               _T      .,,.    ~--~ ^^
         ^^   // \                    ~
              ][O]    ^^      ,-~ ~
           /''-I_I         _II____
        __/_  /   \ ______/ ''   /'\_,__
          | II--'''' \,--:--..,_/,.-{ },
        ; '/__\,.--';|   |[] .-.| O{ _ }
        :' |  | []  -|   ''--:.;[,.'\,/
        '  |[]|,.--'' '',   ''-,.    |
          ..    ..-''    ;       ''. '
            
        
        ");

        // Create story nodes
        StoryNode start = new StoryNode("start", "You arrive at the edge of a bustling town. Above it looms a mysterious tower. As you approach the town gates, a hooded figure blocks your path.\n"+
        "'You've come,' the figure says cryptically. 'If you seek to enter, you must first prove your worth.", onEnter: p => asciiArt.DisplayArt("guard"));
        StoryNode elder = new StoryNode("elder",
            "You seek out the town elder. She looks at you with piercing eyes.\n" +
            "\"To face the trials ahead, you will need both strength and intelligence,\" she says. \"Seek the sword and shield hidden in the cavern.\"", onEnter: p => asciiArt.DisplayArt("Elder"));
        StoryNode tower = new StoryNode("tower",
            "You approach the towering structure. Its doors are sealed shut, with an inscription: \"Only the key can unlock the truth.\"", onEnter: p => asciiArt.DisplayArt("towerDoor"));
        StoryNode cavernEntry = new StoryNode("cavernEntry",
            "You enter the cavern, its damp air chilling your bones. A strange, Gollum-like creature appears, hissing: \"My treasures! You cannot have them!\"", onEnter: p => asciiArt.DisplayArt("Gollum"));
        StoryNode fightCreature = new StoryNode("fightCreature",
            "You draw your weapon and attack the creature. After a fierce battle, it collapses, leaving behind a chest containing a shining sword and shield.", onEnter: p => asciiArt.DisplayArt("treasure"));
        StoryNode failFight = new StoryNode("failFight",
            "The creature is too fast for you. It strikes you down and forces you to retreat.");
        StoryNode negotiateCreature = new StoryNode("negotiateCreature",
            "You speak to the creature, empathizing with its plight. Reluctantly, it agrees to let you take the sword and shield.", onEnter: p => asciiArt.DisplayArt("swordshield"));
        StoryNode failNegotiate = new StoryNode("failNegotiate",
            "Your words fall on deaf ears. The creature attacks, driving you away.");
        StoryNode dottopusBattle = new StoryNode("dottopusBattle",
            "You face Dottopus, the massive one-eyed octopus guardian. Its tentacles thrash as you fight for the golden key.", onEnter: p => asciiArt.DisplayArt("dottopus"));
        StoryNode failDottopusBattle = new StoryNode("failDottopusBattle",
            "Dottopus overwhelms you, forcing you to flee back to the cavern entrance.");
        StoryNode dottopusRiddle = new StoryNode("dottopusRiddle",
            "Dottopus poses a riddle:\n" +
            "\"I speak without a mouth and hear without ears. I have no body, but I come alive with wind. What am I?\"\n" +
            "You answer correctly: \"An echo.\" The guardian grants you the key.", onEnter: p => asciiArt.DisplayArt("key"));
        StoryNode failDottopusRiddle = new StoryNode("failDottopusRiddle",
            "Your answer is incorrect. \"Wrong!\" roars Dottopus, thrashing in anger. You barely escape with your life.");
        StoryNode knightBattle = new StoryNode("knightBattle",
            "The knight and his dragon loom before you. You fight valiantly, defeating them after an intense battle.", onEnter: p => asciiArt.DisplayArt("dragonknight"));
        StoryNode failKnightBattle = new StoryNode("failKnightBattle",
            "The knight and dragon overpower you. Flames engulf you, forcing you to retreat.", onEnter: p => asciiArt.DisplayArt("dragonknight"));
        StoryNode knightConvince = new StoryNode("knightConvince",
            "You remind the knight of his noble past. Touched, he lowers his weapon and allows you to pass.", onEnter: p => asciiArt.DisplayArt("dragonknight"));
        StoryNode failKnightConvince = new StoryNode("failKnightConvince",
            "The knight scoffs at your words. \"Foolish mortal!\" He orders his dragon to attack, and you retreat.", onEnter: p => asciiArt.DisplayArt("dragonknight"));
        StoryNode guardiansFight = new StoryNode("guardiansFight",
            "You face the two axe-wielding guardians. After a fierce battle, you emerge victorious.", onEnter: p => asciiArt.DisplayArt("axeguard"));
        StoryNode failGuardiansFight = new StoryNode("failGuardiansFight",
            "The guardians are too powerful. Their combined strength forces you to retreat.", onEnter: p => asciiArt.DisplayArt("dragonknight"));
        StoryNode guardiansConvince = new StoryNode("guardiansConvince",
            "You recount your journey with wisdom and courage. Impressed, the guardians step aside.", onEnter: p => asciiArt.DisplayArt("dragonknight"));
        StoryNode failGuardiansConvince = new StoryNode("failGuardiansConvince",
            "The guardians remain unconvinced. \"You are unworthy,\" they say, forcing you back.", onEnter: p => asciiArt.DisplayArt("dragonknight"));
        StoryNode dragonSlay = new StoryNode("dragonSlay",
            "With one final strike, you slay the corrupted dragon, freeing the realms.", true);
        StoryNode dragonPurify = new StoryNode("dragonPurify",
            "Using the orb, you channel its light to purify the dragon. Its corruption fades, and it soars into the sky, free at last.", true);

        // Add choices
        start.Choices.Add(new Choice("Seek the town elder for guidance", elder));
        start.Choices.Add(new Choice("Head straight to the tower", tower));

        elder.Choices.Add(new Choice("Enter the cavern to search for the sword and shield", cavernEntry));
        tower.Choices.Add(new Choice("Enter the cavern to search for the key", cavernEntry));

        cavernEntry.Choices.Add(new Choice("Fight the creature", fightCreature, p => p.Strength >= 6, failFight));
        cavernEntry.Choices.Add(new Choice("Negotiate with the creature", negotiateCreature, p => p.Intelligence >= 6, failNegotiate));

        fightCreature.Choices.Add(new Choice("Face Dottopus in battle", dottopusBattle, p => p.Strength >= 7, failDottopusBattle));
        negotiateCreature.Choices.Add(new Choice("Solve Dottopus's riddle", dottopusRiddle, p => p.Intelligence >= 7, failDottopusRiddle));

        dottopusBattle.Choices.Add(new Choice("Confront the knight and dragon", knightBattle, p => p.Strength >= 8, failKnightBattle));
        dottopusRiddle.Choices.Add(new Choice("Reason with the knight and dragon", knightConvince, p => p.Intelligence >= 8, failKnightConvince));

        knightBattle.Choices.Add(new Choice("Defeat the axe-wielding guardians", guardiansFight, p => p.Strength >= 9, failGuardiansFight));
        knightConvince.Choices.Add(new Choice("Prove your worth to the guardians", guardiansConvince, p => p.Intelligence >= 9, failGuardiansConvince));

        guardiansFight.Choices.Add(new Choice("Slay the dragon", dragonSlay, p => p.Strength == 10));
        guardiansConvince.Choices.Add(new Choice("Purify the dragon", dragonPurify, p => p.Intelligence == 10));

        // Start the game loop
        StoryNode currentNode = start;
        while (!currentNode.IsEnding)
        {
            currentNode.EnterNode(player);
            currentNode.DisplayChoices();

            Console.WriteLine("Choose an option:");
            if (int.TryParse(Console.ReadLine(), out int choiceIndex) && choiceIndex > 0 && choiceIndex <= currentNode.Choices.Count)
            {
                currentNode = currentNode.GetNextNode(player, choiceIndex - 1);
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }

        Console.WriteLine(currentNode.Text);
        Console.WriteLine("THE END.");
    }

    private static int GetAttribute(string attributeName)
    {
        int points;
        do
        {
            Console.WriteLine($"Enter points for {attributeName} (0-20):");
        } while (!int.TryParse(Console.ReadLine(), out points) || points < 0 || points > 20);
        return points;
    }
}
