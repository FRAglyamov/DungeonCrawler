using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using System.IO;
using UnityEngine.AI;

public class GameController : MonoBehaviour {

    private string path;
    public bool isLoad;

    public NavMeshSurface surface;
    public bool isNavMeshBuild = false;
    public bool isSpawnObjects = false;

    public int corridor;
    public int hall;
    public int endDungeon;
    public int enemy;
    public GameObject portal;
    public GameObject meleeEnemy;
    public static int roomSize = 4;
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
            }
            return _instance;
        }
    }

    public List<SaveableObjects> objects = new List<SaveableObjects>();

    private void Awake()
    {
        path = Application.dataPath + "testsave.xml";
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //if (Input.GetButton("Jump")) Save();
        //if (Input.GetKeyDown(KeyCode.Backspace)) Load();
        if (!isNavMeshBuild && hall == 0 && corridor == 0 && endDungeon == 0 && enemy == 0)
        {
            surface.BuildNavMesh();
            //Save();
            isNavMeshBuild = true;
        }
        SpawnObjects(isSpawnObjects);
    }

    public void Save()
    {
        XElement root = new XElement("root");


        foreach(SaveableObjects obj in objects)
        {
            root.Add(obj.GetElement());
        }

        Debug.Log(root);

        XDocument saveDoc = new XDocument(root);
        File.WriteAllText(path, saveDoc.ToString());
        Debug.Log(path);
    }


    public void Load()
    {
        isLoad = true;
        XElement root = null;
        if (File.Exists(path))
        {
            root = XDocument.Parse(File.ReadAllText(path)).Element("root");
        }
        if(root==null)
        {
            Debug.Log("Loading failed");
            return;
        }

        GenerateScene(root);
        surface.BuildNavMesh();
    }

    private void GenerateScene(XElement root)
    {

        foreach (SaveableObjects obj in objects)
        {
            obj.DestroySelf();
        }
        foreach (XElement instance in root.Elements("instance"))
        {
            Vector3 position = Vector3.zero;

            position.x = float.Parse(instance.Attribute("x").Value);
            position.y = float.Parse(instance.Attribute("y").Value);
            position.z = float.Parse(instance.Attribute("z").Value);
            float rotation = float.Parse(instance.Attribute("rotation").Value);

            Instantiate(Resources.Load<GameObject>(instance.Value), position, Quaternion.Euler(0f, rotation, 0f));

        }
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //if(player!=null)
        //{

        //}
    }

    void SpawnObjects(bool isSpawnObjects)
    {
        if (Time.time > 2f && !isSpawnObjects)
        {
            List<SaveableObjects> spawnList = objects;
            foreach (var item in spawnList)
            {
                if (item.objectName != "EndRoom" || item.objectName != "Corridor" || item.objectName != "Hall")
                {
                    spawnList.Remove(item);
                }
            }

            for (int i = 0; i < endDungeon; i++)
            {
                int rnd = Random.Range(0, spawnList.Capacity - i);
                Instantiate(portal, spawnList[i].transform.position, Quaternion.identity);
                spawnList.Remove(spawnList[rnd]);
            }
            for (int i = 0; i < enemy; i++)
            {
                int rnd = Random.Range(0, spawnList.Capacity);
                Instantiate(meleeEnemy, spawnList[i].transform.position, Quaternion.identity);
                spawnList.Remove(spawnList[rnd]);
            }

            isSpawnObjects = true;
        }
    }
}
