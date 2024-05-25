using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer animationPlayerNode;
    [Export] public Sprite3D spriteNode;
    public Vector2 direction = Vector2.Zero;
    [Export] public StateMachine stateMachineNode;
    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector3(direction.X, 0, direction.Y) * 5;


        MoveAndSlide();
        flip();
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT, GameConstants.INPUT_MOVE_FORWARD, GameConstants.INPUT_MOVE_DOWN);
    }

    private void flip()

    {
        bool isNotMovingHorizontally = Velocity.X == 0;
        if (isNotMovingHorizontally) { return; } // No need to flip if we're not moving horizontally;
        bool flip = Velocity.X < 0;
        spriteNode.FlipH = flip;
    }
}