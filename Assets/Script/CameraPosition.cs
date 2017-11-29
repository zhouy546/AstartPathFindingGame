using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {
    public theGrid myGrid;
	
	void Start () {
        Vector3 pos = new Vector3(myGrid.gridWorldSize.x/2, myGrid.gridWorldSize.y/2, this.transform.position.z);
        this.transform.position = pos;
    }
}
