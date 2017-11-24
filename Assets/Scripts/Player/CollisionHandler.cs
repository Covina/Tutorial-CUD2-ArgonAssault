using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [SerializeField] private float levelLoadDelay = 1.0f;

    public GameObject deathExplosion;


    /// <summary>
    /// Handle when Player collides with somethign
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter(Collider collider)
    {
        print("Player triggered with: " + collider.gameObject);

        // Player is dead!
        StartDeathSequence();

    }

    /// <summary>
    /// Player death
    /// </summary>
    private void StartDeathSequence()
    {

        deathExplosion.SetActive(true);

        SendMessage("KillPlayerControls");

        // Reload scene
        StartCoroutine(LoadLevelAfterDeath());
    }


    private IEnumerator LoadLevelAfterDeath()
    {
        yield return new WaitForSeconds(levelLoadDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
