using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigationController : MonoBehaviour {

    public static SceneNavigationController instance;

    private float firstLevelLoadDelay = 2.0f;

    // Use this for initialization
    void Start () {

        DontDestroyOnLoad(gameObject);

        StartCoroutine(AutoLoadFirstLevel());

	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private IEnumerator AutoLoadFirstLevel()
    {

        yield return new WaitForSeconds(firstLevelLoadDelay);

        SceneManager.LoadScene(1);

    }


}
