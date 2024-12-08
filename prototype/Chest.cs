using Godot;
using Prototype;

public partial class Chest : StaticBody2D, IInteractable
{
	private bool _isOpen;
	private ShaderMaterial _outlineMaterial;
	private Sprite2D _spriteClosed;
	private Sprite2D _spriteOpened;
	
	public override void _Ready()
	{
		var area = GetNode<Area2D>("Area");
		area.BodyEntered += OnBodyEntered;
		area.BodyExited += OnBodyExited;
		_outlineMaterial = GD.Load<ShaderMaterial>("res://selection_outline.tres");
		_spriteClosed = GetNode<Sprite2D>("SpriteClosed");
		_spriteOpened = GetNode<Sprite2D>("SpriteOpened");
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
		if (_isOpen)
		{
			Close();
		}
		else
		{
			Open();
		}
	}

	private void EnableInteraction(Character character)
	{
		character.AddInteractableObject(this);
		_spriteClosed.Material = _outlineMaterial;
		_spriteOpened.Material = _outlineMaterial;
	}

	private void DisableInteraction(Character character)
	{
		character.RemoveInteractableObject(this);
		_spriteClosed.Material = null;
		_spriteOpened.Material = null;
	}

	private void Open()
	{
		_spriteClosed.Hide();
		_spriteOpened.Show();
		_isOpen = true;
	}

	private void Close()
	{
		_spriteClosed.Show();
		_spriteOpened.Hide();
		_isOpen = false;
	}
}
