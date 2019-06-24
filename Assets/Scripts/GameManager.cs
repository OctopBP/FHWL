using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameObject spirit;

	private void Start() {
		EventManager.Instance.GoingIn += HideSpirit;
	}

	private void ShowSpirit(GameObject t) {
		spirit.SetActive(true);
	}

	private void HideSpirit(GameObject t) {
		spirit.SetActive(false);
	}
}
