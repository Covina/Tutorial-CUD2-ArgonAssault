using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {


        // Pseudo singleton
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if(numMusicPlayers > 1)
        {
            Destroy(gameObject);

        } else
        {
            DontDestroyOnLoad(gameObject);
        }

        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
