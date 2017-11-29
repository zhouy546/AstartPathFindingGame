using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theGrid : MonoBehaviour {
    [SerializeField]
    GameObject NodePrefab;
    [SerializeField]
   public static Node[,] NodeaPool;

  //  public static List<Node> NodeaPool;
    public Vector2 gridWorldSize;
    public float nodeRadius;

    public int questionNumber = 0;
    public float QuestionRate;

    public character mycharacter;
    void CreateGride(Vector2 _gridWorldSize) {
        NodeaPool = new Node[(int)gridWorldSize.x, (int)gridWorldSize.y];

        for (int i = 0; i < _gridWorldSize.x; i++)
        {
            for (int j = 0; j < _gridWorldSize.y; j++)
            {
                //Debug.Log(NodeaPool[i, j].x+"_"+NodeaPool[i, j].y);
                GameObject GameObjectNode = Instantiate(NodePrefab);
                GameObjectNode.transform.SetParent(this.transform);
                Node node = GameObjectNode.GetComponent<Node>();
                //where json to setup node

                node.Name = i.ToString() + "_" + j.ToString();//setup name
                node.worldPosition = new Vector3(i, j, 0);
                //json weight
                node.gCost = 0;
                node.hCost = 0;
                node.walkable = true;

                if (i != mycharacter.x&&j != mycharacter.y){
                GenerateQuestion(node);
                }
              


                NodeaPool[i, j] = node;
               // NodeaPool.Add(node);
            }
        }
    }

    void Start() {
        CreateGride(gridWorldSize);
    }

    public List<Node> GetNeightbours(Node _node)
    {
        List<Node> neighbours = new List<Node>();
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;
                if (x == -1 && y == 1)
                    continue;
                if (x == 1 && y == 1)
                    continue;
                if (x == -1 && y == -1)
                    continue;
                if (x == 1 && y == -1)
                    continue;
                int checkX =(int) _node.worldPosition.x + x;
                int checkY =(int) _node.worldPosition.y + y;

                if (checkX >= 0 && checkX < gridWorldSize.x && checkY >= 0 && checkY < gridWorldSize.y)
                {
                    // Debug.Log(_node.x + "," + _node.y);
                    neighbours.Add(NodeaPool[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }


    public Node NodeFromWorldPoint(int _x, int _y)
    {
        int x = _x;
        int y = _y;
       // Debug.Log(NodeaPool[3, 3].walkable);
        return NodeaPool[x, y];
    }

    public void GenerateQuestion(Node _node)
    {
            _node.isQuestion = StaticFunction.randomTrueAndFalse(QuestionRate);
          //  Debug.Log(_node.isQuestion);
            if (_node.isQuestion)
            {
            questionNumber++;
            }   
    }
}
