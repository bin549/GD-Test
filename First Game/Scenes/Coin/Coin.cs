using Godot;

public partial class Coin : Area2D {
    private GameManager gameManager;
    private AnimationPlayer animationPlayer;

    public override void _Ready() {
        gameManager = GetNode<GameManager>("%GameManager");
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node body) {
        gameManager.AddPoint();
        animationPlayer.Play("pickup");
    }
}