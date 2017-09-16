using UnityEngine;

public class DestroyMe : MonoBehaviour {

    public float aliveTime;

	// Use this for initialization
	void Awake () {
        Destroy (gameObject, aliveTime);	
	}

}
