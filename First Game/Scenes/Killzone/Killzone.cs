using Godot;

public partial class Killzone : Area2D {
    private Timer timer;

    public override void _Ready() {
        timer = GetNode<Timer>("Timer");
        BodyEntered += OnBodyEntered;
        timer.Timeout += OnTimerTimeout;
    }

    private void OnBodyEntered(Node body) {
        GD.Print("You died!");
        Engine.TimeScale = 0.5f;
        var collisionShape = body.GetNodeOrNull<CollisionShape2D>("CollisionShape2D");
        if (collisionShape != null) {
            collisionShape.QueueFree();
        }
        timer.Start();
    }

    private void OnTimerTimeout() {
        Engine.TimeScale = 1.0f;
        GetTree().ReloadCurrentScene();
    }
}