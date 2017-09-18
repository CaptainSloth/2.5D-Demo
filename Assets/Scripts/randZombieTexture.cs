
using UnityEngine;

public class randZombieTexture : MonoBehaviour {

    public Material[] zombieTexture;

	// Use this for initialization
	void Start () {
        SkinnedMeshRenderer renderer = GetComponent<SkinnedMeshRenderer>();
        renderer.material = zombieTexture[Random.Range(0, zombieTexture.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
