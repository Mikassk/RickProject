using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

    public Transform Spawn;
    public GameObject Coin;
    public bool canSpawn = true;
    private float MinTime = 2.0f;
    private float MaxTime = 5.0f;

	void Start () {
        Spawn = GetComponent<Transform>();
	}

    void Update()
    {
        if (canSpawn == true)
        {
            StartCoroutine(Spawner());
            canSpawn = false;
        }
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
        var rock = (GameObject)Instantiate(Coin, Spawn);
        canSpawn = true;
    }
}
