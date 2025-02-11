using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimationPlayerNode { get; private set; }
    [Export] public Sprite3D SpriteNode { get; private set; }
    [Export] public StateMachine StateMachineNode { get; private set; }

    public Vector2 direction = Vector2.Zero;
    public override void _PhysicsProcess(double delta)
    {

    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT, GameConstants.INPUT_MOVE_FORWARD, GameConstants.INPUT_MOVE_DOWN);
    }

    public void flip()

    {
        bool isNotMovingHorizontally = Velocity.X == 0;
        if (isNotMovingHorizontally) { return; } // No need to flip if we're not moving horizontally;
        bool flip = Velocity.X < 0;
        SpriteNode.FlipH = flip;
    }
}