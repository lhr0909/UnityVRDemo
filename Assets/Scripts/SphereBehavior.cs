using UnityEngine;
using System.Collections;

public class SphereBehavior : MonoBehaviour {

	void Update () {
	    if (transform.position.y < -5f)
	    {
            Debug.Log("Removing a sphere that is out of view");
	        DestroyObject(gameObject);
	    }
	}
}
