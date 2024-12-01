using Godot;
using Prototype;

public partial class Chest : StaticBody2D, IInteractable
{
	public override void _Ready()
	{
		var area = GetNode<Area2D>("Area");
		area.BodyEntered += OnBodyEntered;
		area.BodyExited += OnBodyExited;
	}
	
	public void Interact()
	{
		GD.Print("Opening chest");
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is Character character)
		{
			character.AddInteractableObject(this);
		}
	}
	
	private void OnBodyExited(Node2D body)
	{
		if (body is Character character)
		{
			character.RemoveInteractableObject(this);
		}
	}
}
