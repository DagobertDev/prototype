using Godot;

public partial class Game : Node
{
    public void ExitLevel()
    {
        GetTree().Paused = true;
        GetNode<CanvasLayer>("MissionEndScreen").Show();
    }
}
