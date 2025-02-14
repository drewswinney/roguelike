using Godot;

public partial class Player : CharacterBody2D
{
	public float Speed = 320.0f;

	public override void _Ready()
	{
		base._Ready();

		this.Position = new Vector2(440, 160);
		var idle = this.GetNode<AnimatedSprite2D>("IdleAnimation");
		idle.SpeedScale = 0.5f;
		idle.Play();
	}

	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsKeyPressed(Key.Right))
		{
			this.Velocity = new Vector2(this.Speed * (float)delta, 0);
		}
		else if (Input.IsKeyPressed(Key.Left))
		{
			this.Velocity = new Vector2(-1 * this.Speed * (float)delta, 0);
		}
		else if (Input.IsKeyPressed(Key.Up))
		{
			this.Velocity = new Vector2(0, -1 * this.Speed * (float)delta);
		}
		else if (Input.IsKeyPressed(Key.Down))
		{
			this.Velocity = new Vector2(0, this.Speed * (float)delta);
		}
		else
		{
			this.Velocity = new Vector2(0, 0);
		}

		this.MoveAndCollide(this.Velocity);
	}
}
