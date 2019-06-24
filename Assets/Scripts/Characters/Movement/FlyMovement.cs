using UnityEngine;

public class FlyMovement : MonoBehaviour, IMovement {
	[SerializeField] private float speed = 5;

	public void Tick(Rigidbody2D rb, IInput input) {
		rb.velocity = new Vector2(input.horizontal, input.vertical) * speed;
	}
}