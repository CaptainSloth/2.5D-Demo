using UnityEngine;

public class doorController : MonoBehaviour {

    public bool resetable;
    public GameObject door;
    public GameObject gear;
    public bool startOpen;

    bool firstTrigger = false;
    bool open = true;
    Animator doorAnimation;
    Animator gearAnimation;
    AudioSource doorAudio;
    
    // Use this for initialization
    void Start () {
        // setting up components
        doorAnimation = door.GetComponent<Animator>();
        gearAnimation = gear.GetComponent<Animator>();
        doorAudio = door.GetComponent<AudioSource>();

        if (!startOpen)
        {
            open = false;
            // triggers
            doorAnimation.SetTrigger("doorTrigger");
            //plays audio
            doorAudio.Play();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !firstTrigger)
        {
            if (!resetable) firstTrigger = true;
            doorAnimation.SetTrigger("doorTrigger");
            open = !open;
            gearAnimation.SetTrigger("gearRotate");
            doorAudio.Play();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
