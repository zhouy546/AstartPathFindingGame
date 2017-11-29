using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node:MonoBehaviour{
    public bool walkable;

    public int gCost;
    public int hCost;
    public int fCost;

    public int x;
    public int y;

    public Node parent;
    private Vector3 _worldPosition;
    public Vector3 worldPosition {
        get { return this._worldPosition; }
        set {
            this._worldPosition = value;
            this.gameObject.transform.position = value;
            this.x = (int)value.x;
            this.y = (int)value.y;
        }
    }

    private string _name;
    public string Name {
        get { return this._name; }
        set {
            this._name = value;
            this.gameObject.name = value;
                }
    }

    private bool _isQuestion;
    public bool isQuestion {
        get { return _isQuestion; }
        set
        {
            _isQuestion = value;
            if (this._isQuestion == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else {
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }


    public Node(bool _walkable, Vector3 _worldPos,string _Name, int _Weight) {
        Name = _Name;
        walkable = _walkable;
        worldPosition = _worldPos;
    }


    public Node(int _x , int _y)
    {
        x = _x;
        y = _y;
    }


    public int fcost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
