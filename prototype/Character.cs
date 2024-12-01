using Godot;
using Prototype;

public partial class Character : CharacterBody2D
{
	[Export] public float Speed { get; set; }

	public override void _Process(double delta)
	{
		var direction = Input.GetVector(InputActions.MoveLeft,
			InputActions.MoveRight,
			InputActions.MoveUp,
			InputActions.MoveDown);
		
		Velocity = direction * Speed;

		MoveAndSlide();
	}
}
