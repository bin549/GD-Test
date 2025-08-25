using Godot;

public partial class Player : CharacterBody2D {
    private const float Speed = 130.0f;
    private const float JumpVelocity = -300.0f;

    private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    private AnimatedSprite2D animatedSprite;

    public override void _Ready() {
        animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta) {
        Vector2 velocity = Velocity;
        if (!IsOnFloor()) {
            velocity.Y += gravity * (float)delta;
        }
        if (Input.IsActionJustPressed("jump") && IsOnFloor()) {
            velocity.Y = JumpVelocity;
        }
        float direction = Input.GetAxis("move_left", "move_right");
        if (direction > 0) {
            animatedSprite.FlipH = false;
        } else if (direction < 0) {
            animatedSprite.FlipH = true;
        }
        if (IsOnFloor()) {
            if (direction == 0) {
                animatedSprite.Play("idle");
            } else {
                animatedSprite.Play("run");
            }
        } else {
            animatedSprite.Play("jump");
        }
        if (direction != 0) {
            velocity.X = direction * Speed;
        } else {
            velocity.X = Mathf.MoveToward(velocity.X, 0, Speed);
        }
        Velocity = velocity;
        MoveAndSlide();
    }
}