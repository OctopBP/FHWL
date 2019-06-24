using UnityEngine;

public class Character : MonoBehaviour
{
	[SerializeField] bool isPlayer;

	private Rigidbody2D rb;

	private IInput input;
	private IMovement movement;

	// private HealthSystem health;
	private IHealth health;
	public IHealth Health => health;
	private IHealthGUI healthGUI;

	private IAbility ability; // пока что одна
	[SerializeField] private Fireball firaballPrefab; // To SO

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

		// Получаем реализацию передвижения персонажа
		movement = GetComponent<IMovement>();

		// Назначаем инпут
		input = isPlayer ? new PlayerInput() : new AIInput() as IInput;

		health = new HealthSystem(100);
		if (GetComponent<IHealthGUI>() != null) {
			healthGUI = GetComponent<IHealthGUI>();
			healthGUI.Setup(health);
		}



		if (isPlayer) {
			ability = GetComponent<FireballAbility>();
			ability.Init(firaballPrefab);
		}
    }

	private void Update() {
		// Поворачиваем в сторону направления движения
		transform.localScale = new Vector3(Mathf.Sign(input.horizontal), 1, 1);

		// Передаём значения input в movement для перемещения rigidbody
		movement.Tick(rb, input);


		

		if (isPlayer && Input.GetKeyDown(KeyCode.Alpha1)) {
			ability.OnUse();
		}
    }

	public void SetPlayerInput() {
		isPlayer = true;
		input = new PlayerInput();
	}
}