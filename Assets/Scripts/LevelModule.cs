using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModule : MonoBehaviour {

    public List<Transform> entrances;

    [ContextMenu("AddEntrance")]
    public void AddEntrance()
    {
        GameObject newGO = new GameObject("_EntrancePoint");
        newGO.transform.parent = transform;
        newGO.transform.localPosition = Vector3.zero;
        newGO.transform.localRotation = Quaternion.identity;
        entrances.Add(newGO.transform);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < entrances.Count; i++)
        {
            if (entrances[i] == null)
            {
                entrances.RemoveAt(i);
                break;
            }
            Gizmos.DrawSphere(entrances[i].position, 0.2f);
        }
    }
}
