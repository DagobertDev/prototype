using Godot;
using Prototype;

public partial class LevelExit : Area2D, IInteractable
{
	private ShaderMaterial _outlineMaterial;
	private Sprite2D _sprite;
	
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
		BodyExited += OnBodyExited;
		_outlineMaterial = GD.Load<ShaderMaterial>("res://selection_outline.tres");
		_sprite = GetNode<Sprite2D>("Sprite");
	}
	
	private void OnBodyEntered(Node2D body)
	{
		if (body is Character character)
		{
			EnableInteraction(character);
		}
	}
	
	private void OnBodyExited(Node2D body)
	{
		if (body is Character character)
		{
			DisableInteraction(character);
		}
	}
	
	public void Interact()
	{
		GetParent<Game>().ExitLevel();
	}

	private void EnableInteraction(Character character)
	{
		character.AddInteractableObject(this);
		_sprite.Material = _outlineMaterial;
	}

	private void DisableInteraction(Character character)
	{
		character.RemoveInteractableObject(this);
		_sprite.Material = null;
	}
}
