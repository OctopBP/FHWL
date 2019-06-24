using UnityEngine;

public class EventManager : MonoBehaviour {

    private static EventManager instance;
    public static EventManager Instance { get{ return instance; } }

	public delegate void GoingInDelegate(GameObject target);
	public event GoingInDelegate GoingIn;
	public void OnGoingIn(GameObject target) {
		if(GoingIn != null) GoingIn(target);
	}

    private void Awake() {
        if (instance == null)
        	instance = this;
    }
}