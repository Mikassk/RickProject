using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public Transform Spawn;
    public Transform Destroyer;
    public float scrollSpeed;

	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, Destroyer.position, scrollSpeed);
	}

}
