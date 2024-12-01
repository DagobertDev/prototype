using System.Collections.Generic;
using Godot;
using Prototype;

public partial class Character : CharacterBody2D
{
	[Export] public float Speed { get; set; }

	private readonly List<IInteractable> _interactableObjects = new();

	public override void _Process(double delta)
	{
		var direction = Input.GetVector(InputActions.MoveLeft,
			InputActions.MoveRight,
			InputActions.MoveUp,
			InputActions.MoveDown);
		
		Velocity = direction * Speed;

		MoveAndSlide();
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed(InputActions.Interact))
		{
			foreach (var interactableObject in _interactableObjects)
			{
				interactableObject.Interact();
			}
		}
	}
	
	public void AddInteractableObject(IInteractable interactable)
	{
		_interactableObjects.Add(interactable);
	}

	public void RemoveInteractableObject(IInteractable interactable)
	{
		_interactableObjects.Remove(interactable);
	}
}
