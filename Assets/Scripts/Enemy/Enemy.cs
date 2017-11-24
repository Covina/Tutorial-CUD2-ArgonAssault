using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    [SerializeField] private GameObject enemyExplosionPFX;
    [SerializeField] Transform spawnParent;

    private Scoreboard scoreboard;

	// Use this for initialization
	void Start ()
    {
        AddNonTriggerBoxCollider();

        scoreboard = GameObject.FindObjectOfType<Scoreboard>();

    }

    /// <summary>
    /// Adding box collider if it's missing one
    /// </summary>
    private void AddNonTriggerBoxCollider()
    {
        // Check if it has a box collider
        if (gameObject.GetComponent<BoxCollider>() == null)
        {
            // generate the box collider
            Collider newBoxCollider = gameObject.AddComponent<BoxCollider>();

            // force disable Is trigger
            newBoxCollider.isTrigger = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}


    private void OnParticleCollision(GameObject other)
    {
        // print("Particles collided with enemy: " + gameObject.name);

        scoreboard.ScoreHit();

        //
        EnemyDeathSequence();
    }

    /// <summary>
    /// Enemy Death
    /// </summary>
    private void EnemyDeathSequence()
    {

        // Play Particle Effect
        // TODO - add particle effect enemy explosion
        GameObject pfxExplosion = Instantiate(enemyExplosionPFX, transform.position, Quaternion.identity);
        pfxExplosion.transform.parent = spawnParent;


        // Destroy Enemy
        Destroy(gameObject);
    }



}
