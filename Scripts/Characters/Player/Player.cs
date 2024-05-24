using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer animationPlayerNode;
    [Export] private Sprite3D spriteNode;
    private Vector2 direction = Vector2.Zero;

    public override void _Ready()
    {
        animationPlayerNode.Play(GameConstants.ANIM_IDLE);
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector3(direction.X, 0, direction.Y) * 5;


        MoveAndSlide();
        flip();
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT, GameConstants.INPUT_MOVE_FORWARD, GameConstants.INPUT_MOVE_DOWN);
        animationPlayerNode.Play(direction != Vector2.Zero ? GameConstants.ANIM_MOVE : GameConstants.ANIM_IDLE);
    }

    private void flip()

    {
        bool isNotMovingHorizontally = Velocity.X == 0;
        if (isNotMovingHorizontally) { return; } // No need to flip if we're not moving horizontally;
        bool flip = Velocity.X < 0;
        spriteNode.FlipH = flip;
    }
}
