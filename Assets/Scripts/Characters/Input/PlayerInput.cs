using UnityEngine;

public class PlayerInput : IInput {
	public float horizontal => Input.GetAxis("Horizontal");
	public float vertical => Input.GetAxis("Vertical");
	public bool jump => Input.GetKeyDown(KeyCode.W);
}