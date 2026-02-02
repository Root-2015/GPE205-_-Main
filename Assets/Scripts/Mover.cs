using UnityEngine;

public abstract class Mover : MonoBehaviour
{
	public abstract void Move(Vector2 moveDirection);
	public abstract void Rotate(Vector2 rotateDirection);
}
