using UnityEngine;

public interface IMovement {
    void Tick(Rigidbody2D rb, IInput input);
}