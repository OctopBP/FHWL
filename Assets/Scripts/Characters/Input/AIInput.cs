using UnityEngine;

public class AIInput : IInput {
	// Горизонтальное передвижение (должно возвращать значение в границах [-1; 1])
	public float horizontal {
		get {
			// Тут вся логика

			// Сдесь возвращаеться значение
			return ((Time.time % 6) > 3) ? 1 : -1; // Просто заглушка (движение туда-обратно каждые 3 секунды)
		}
	}
	
	// Вертикальное передвижение (для ИИ = 0)
	public float vertical => 0;
	
	// Прыжок
	public bool jump => false;
}
