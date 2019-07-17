using UnityEngine;

public class restartGame : MonoBehaviour {

    public float restartTime;
    bool resetNow = false;
    float resetTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(resetNow && resetTime <= Time.time)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
	}

    public void restartTheGame()
    {
        resetNow = true;
        resetTime = restartTime + Time.time;
    }
}
