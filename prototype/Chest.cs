using Godot;
using Prototype;

public partial class Chest : StaticBody2D, IInteractable
{
	private bool _isOpen;
	
	public override void _Ready()
	{
		var area = GetNode<Area2D>("Area");
		area.BodyEntered += OnBodyEntered;
		area.BodyExited += OnBodyExited;
	}
	
	public void Interact()
	{
		if (_isOpen)
		{
			Close();
		}
		else
		{
			Open();
		}
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

	private void Open()
	{
		GetNode<Sprite2D>("SpriteClosed").Hide();
		GetNode<Sprite2D>("SpriteOpened").Show();
		_isOpen = true;
	}

	private void Close()
	{
		GetNode<Sprite2D>("SpriteClosed").Show();
		GetNode<Sprite2D>("SpriteOpened").Hide();
		_isOpen = false;
	}
}
