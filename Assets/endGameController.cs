using UnityEngine;
using UnityEngine.UI;

public class endGameController : MonoBehaviour {

    AudioSource endOfGameAudio;

    //HUD
    public Text endGameDedText;
    public restartGame MCP;

    // Use this for initialization
    void Start () {
        endOfGameAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            //Collider trigger
            endOfGameAudio.Play();
            endGameDedText.text = "YOUWIN!";
            Animator endGameAnimation = endGameDedText.GetComponent<Animator>();
            endGameAnimation.SetTrigger("endGame");
            MCP.restartTheGame();
        }
    }

}
