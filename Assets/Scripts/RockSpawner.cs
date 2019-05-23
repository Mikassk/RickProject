using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour {

    public GameObject Rock;
    private Transform spawn;
    private bool canSpawn = true;
    private float MaxTime = 5.0f;
    private float MinTime = 5.0f;

	void Start () {
        spawn = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (canSpawn == true) {
            StartCoroutine(Spawn());
            canSpawn = false;
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
        var rock = (GameObject)Instantiate(Rock, spawn);
        if (MinTime > 0.5f)
            MinTime -= 0.5f;
        if (MinTime == 0.5f && MaxTime > 2.0f)
            MaxTime -= 0.5f;
        canSpawn = true;
    }
}
