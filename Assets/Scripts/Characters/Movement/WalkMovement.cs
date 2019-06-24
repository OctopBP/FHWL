using UnityEngine;

public class WalkMovement : MonoBehaviour, IMovement {
	
	// TODO: убрать в ScriptableObject
	[SerializeField] private float speed;
	[SerializeField] private float jumpForce;

	[SerializeField] private CircleCollider2D groundCollider;
	[SerializeField] private LayerMask groundMask;

	public void Tick(Rigidbody2D rb, IInput input) {
		rb.velocity = new Vector2(input.horizontal * speed, rb.velocity.y);

		if (groundCollider.IsTouchingLayers(groundMask) && input.jump) {
			rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
		}
	}
}