using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Color lineColor;
    private List<Transform> nodes = new List<Transform>();

    void OnDrawGizmos()
    {
        Gizmos.color = lineColor;
        Transform[] pathTransforms = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        for(int i=0;i< pathTransforms.Length; i++){
            if(pathTransforms[i] != transform){
                nodes.Add(pathTransforms[i]);
            } 
        }

        for(int i=0;i<nodes.Count;i++){
            Vector3 currentNode = nodes[i].position;
            Vector3 prevNode = Vector3.zero;
            if(i>0){
                prevNode = nodes[i-1].position;
            }
            else if(i == 0 && nodes.Count > 1){
                continue;
            }
            Gizmos.DrawLine(prevNode,currentNode);
            Gizmos.DrawWireSphere(currentNode,1.0f);
        }
    }
}
