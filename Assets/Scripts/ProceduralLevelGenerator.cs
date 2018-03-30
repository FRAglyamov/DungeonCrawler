using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralLevelGenerator : MonoBehaviour {

    public LevelModule[] levelModules;
    public GameObject entranceModule;

	void Start ()
    {
        GenerateLevel();
	}

    [ContextMenu("GenerateLevel")]
    public void GenerateLevel()
    {
        LevelModule initialModule =  CreateModule(levelModules[0], Vector3.zero, Quaternion.identity);

        PlaceNextModule(initialModule.entrances[0]);


    }
    private void PlaceNextModule(Transform previousEntrance)
    {
        LevelModule nextModule = levelModules[UnityEngine.Random.Range(0, levelModules.Length)];

        float angle = Quaternion.Angle(nextModule.entrances[0].rotation, previousEntrance.rotation);
        Quaternion nextRotation = Quaternion.Euler(0f, angle + 180f, 0f);

        Vector3 nextPosition = previousEntrance.position + previousEntrance.rotation * (new Vector3(0f, 0f, 1f) + nextModule.entrances[0].position);
        CreateModule(nextModule, nextPosition, nextRotation);
    }

    private LevelModule CreateModule(LevelModule levelModule, Vector3 position, Quaternion rotation)
    {
        GameObject newGO = Instantiate(levelModule.gameObject, position, rotation);
        List<Transform> entrances = levelModule.entrances;
        for(int i=0;i<entrances.Count;i++)
        {
            GameObject entranceGO = Instantiate(entranceModule);
            entranceGO.transform.rotation = entrances[i].rotation;
            entranceGO.transform.position = entrances[i].position + entrances[i].rotation * new Vector3(0f, 0f, 0.5f);
        }
        return newGO.GetComponent<LevelModule>();
    }
}
