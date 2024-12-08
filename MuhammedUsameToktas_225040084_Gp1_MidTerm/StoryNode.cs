public class StoryNode
{
    public string ID { get; set; }
    public string Text { get; set; }
    public bool IsEnding { get; set; } = false;
    public Action<Player> OnEnter { get; set; }
    public List<Choice> Choices { get; set; } = new List<Choice>();

    public StoryNode(string id, string text, bool isEnding = false, Action<Player> onEnter = null)
    {
        ID = id;
        Text = text;
        IsEnding = isEnding;
        OnEnter = onEnter;
    }

    public void EnterNode(Player player)
    {
        OnEnter?.Invoke(player);
        Console.WriteLine(Text);
    }

    public void DisplayChoices()
    {
        for (int i = 0; i < Choices.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Choices[i].Text}");
        }
    }

    public StoryNode GetNextNode(Player player, int choiceIndex)
    {
        var choice = Choices[choiceIndex];
        return choice.GetNextNode(player);
    }
}
