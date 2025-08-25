using Godot;

public partial class GameManager : Node {
    private int score = 0;
    private Label scoreLabel;

    public override void _Ready() {
        scoreLabel = GetNode<Label>("ScoreLabel");
        UpdateLabel();
    }

    public void AddPoint() {
        score += 1;
        UpdateLabel();
    }

    private void UpdateLabel() {
        scoreLabel.Text = $"You collected {score} coins.";
    }
}