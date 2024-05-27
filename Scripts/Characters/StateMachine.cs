using Godot;
using System;

public partial class StateMachine : Node
{
    [Export] private Node currentState;
    [Export] private Node[] states;

    public override void _Ready()
    {
        currentState.Notification(GameConstants.Notification_Enter_State);

    }

    public void SwitchState<T>()
    {
        Node newState = null;
        foreach (Node state in states)
        {
            if (state is T)
            {
                newState = state;
                break;
            }
        }
        if (newState == null)
        {
            GD.PrintErr("State not found");
            return;
        }
        currentState.Notification(GameConstants.Notification_Exit_State);
        currentState = newState;
        currentState.Notification(GameConstants.Notification_Enter_State);
    }
}
