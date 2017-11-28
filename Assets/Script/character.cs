using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class character : MonoBehaviour {
    public int x, y;
    public int Targetx, Targety;

    [SerializeField]
    AstartPathFinding astartpathfind;
   // [SerializeField]
    //IsometricManger isometricmanger;
    int index = 0;
    [SerializeField]
    bool inAnimation;
	// Use this for initialization
	void Start () {
	
	}
    public List<Node> path;
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //suppose i have two objects here named obj1 and obj2.. how do i select obj1 to be transformed 
                if (hit.collider != null)
                {
                    if (hit.collider.GetComponent<Node>().walkable&&!inAnimation) {
                        string[] Row_Column = hit.collider.name.Split('_');
                        Targetx = int.Parse(Row_Column[0]);
                        Targety = int.Parse(Row_Column[1]);
                        Debug.Log(Targetx + "_" + Targety);
                        astartpathfind.FindPath(x, y, Targetx, Targety);
                        Movement();
                    }
                }
            }
        }
    }

    void Movement() {
        for (int i = 0; i < path.Count; i++)
        {
            //Debug.Log(path[i].x + "_" + path[i].y);
        }

        if (path != null) {
            if (index < path.Count)
            {
                Debug.Log(index);
                Transform target = path[index].gameObject.transform;
                inAnimation = true;
                LeanTween.move(gameObject, target, .2f).setOnComplete(delegate ()
                {           
                    x = path[index].x;
                    y = path[index].y;
                    index++;
                    Movement();
                    
                });
            }
            else {
                inAnimation = false;
                LeanTween.cancelAll();
                index = 0;
            }

        }
    }

}
