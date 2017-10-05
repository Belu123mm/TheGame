using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GridPlacementExample : MonoBehaviour
{

    public float xGridScale = 1;
    public float yGridScale = 1;
    public float zGridScale = 1;
    public int gridScale;

    void Start()
    {
    }
    void Update()
    {
        Transform[] childrens = GetComponentsInChildren<Transform>();
        print(childrens.Length);
        if (Application.isEditor)
        {
            for (int i = childrens.Length - 1; i >= 0; i--)
            {
                Vector3 currentPosition = childrens[i].position;
                float xDifference = currentPosition.x % xGridScale;
                float yDifference = currentPosition.y % yGridScale;
                float zDifference = currentPosition.z % zGridScale;
                childrens[i].transform.position = new Vector3(
                    currentPosition.x - xDifference,
                    currentPosition.y - yDifference,
                    currentPosition.z - zDifference);
            }

        }
        //Grid
        float xCalc = xGridScale / 2;
        float yCalc = yGridScale / 2;
        float zCalc = zGridScale / 2;
        for (int i = 0; i < gridScale; i++)
        {
            if (gridScale % 2 == 0)
                gridScale++;


        }
    }
    // void OnDrawGizmos() {

}

