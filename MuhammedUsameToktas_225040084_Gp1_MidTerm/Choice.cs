public class Choice
{
    public string Text { get; set; } // Text displayed for the choice
    public Func<Player, bool> Condition { get; set; } // Condition to succeed (e.g., attribute check)
    public StoryNode SuccessNode { get; set; } // Node to navigate to on success
    public StoryNode FailNode { get; set; } // Node to navigate to on failure

    public Choice(string text, StoryNode successNode, Func<Player, bool> condition = null, StoryNode failNode = null)
    {
        Text = text;
        SuccessNode = successNode;
        Condition = condition;
        FailNode = failNode;
    }

    public StoryNode GetNextNode(Player player)
    {
        if (Condition == null || Condition(player)) // If no condition or condition met
        {
            return SuccessNode; // Proceed to the success node
        }
        return FailNode; // Proceed to the fail node
    }
}
