using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip playerScoredSound, playerFlap, mainMusic, loseSound;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerScoredSound = Resources.Load<AudioClip>("coin");
        playerFlap = Resources.Load<AudioClip>("flap");
        mainMusic = Resources.Load<AudioClip>("main_music");
        loseSound = Resources.Load<AudioClip>("lose");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip) 
    {
        switch (clip)
        {
            case "scored":
                audioSource.PlayOneShot(playerScoredSound);
                break;
            case "flap":
                audioSource.PlayOneShot(playerFlap);
                break;
            case "lose":
                audioSource.PlayOneShot(loseSound);
                break;
        }
    }

}
