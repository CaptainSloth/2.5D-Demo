using UnityEngine;

public class elevatorController : MonoBehaviour {

    public float resetTime;

    Animator elevatorAnimator;
    AudioSource elevatorAudio;

    float downTime;
    bool elevatorIsUp = false;

	// Use this for initialization
	void Start () {
        //Setting things up, calling components from Unity
        elevatorAnimator = GetComponent<Animator>();
        elevatorAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (downTime <= Time.time && elevatorIsUp)
        {
            elevatorAnimator.SetTrigger("elevatorTrigger");
            elevatorIsUp = false;
            elevatorAudio.Play();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            elevatorAnimator.SetTrigger("elevatorTrigger");
            downTime = Time.time + resetTime;
            elevatorIsUp = true;
            elevatorAudio.Play();
        }
    }
}
