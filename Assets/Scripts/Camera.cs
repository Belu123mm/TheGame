using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject gObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 objPos = gObj.transform.position;
        this.transform.position = new Vector3(objPos.x, objPos.y, -3);

    }
}
