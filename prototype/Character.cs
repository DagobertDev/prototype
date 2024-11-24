using Godot;
using Prototype;

public partial class Character : Node2D
{
	[Export] public float Speed { get; set; }

	public override void _Process(double delta)
	{
		var direction = Input.GetVector(InputActions.MoveLeft,
			InputActions.MoveRight,
			InputActions.MoveUp,
			InputActions.MoveDown);
		
		Position += direction * Speed * (float)delta;
	}
}
