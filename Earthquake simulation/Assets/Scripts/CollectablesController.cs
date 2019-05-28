using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesController : MonoBehaviour {


    private AudioSource audioPlayer;
    public AudioClip point;
    public AudioClip error;
    public ParticleSystem stars;

    // Use this for initialization
    void Start () {
        audioPlayer = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Destruye un collectable al entrar al botiquin añade los puntos y muestra las estrellas, sonido de error de lo contrario
    public void OnTriggerEnter(Collider other)
    {
        GameObject game = GameObject.FindGameObjectWithTag("Game");
        GameController script = game.GetComponent<GameController>();
        int level = script.level;
        if(level==4){
            if (other.gameObject.tag == "Collectable")
            {
                //other.gameObject.SetActive(false);
                Destroy(other.gameObject);
                game.SendMessage("IncreasePoints");
                audioPlayer.clip = point;
                audioPlayer.Play();
                stars.Play();
            }
            else
            {
                audioPlayer.clip = error;
                audioPlayer.Play();
            }
        }
        else if (level == 2)
        {
                if (other.gameObject.tag == "Collectable")
                {
                    //other.gameObject.transform.position = new Vector3(-0.195f, 2.65f, 5.76f);
                    game.SendMessage("IncreasePoints2");
                    audioPlayer.clip = point;
                    audioPlayer.Play();
                    stars.Play();
                }
                else
                {
                    game.SendMessage("IncreasePoints3");
                    audioPlayer.clip = error;
                    audioPlayer.Play();
                }
            }
           
        }
}

