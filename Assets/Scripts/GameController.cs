using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using System.IO;
using UnityEngine.AI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private string path;
    public bool isLoad;

    public NavMeshSurface surface;
    public bool isNavMeshBuild = false;
    public bool isSpawnObjects = false;

    public int corridor;
    public int hall;
    public int endDungeon;
    public int mEnemy;
    public int rEnemy;
    public int oranges;
    public int orbs;
    public int spikes;
    public GameObject portal;
    public GameObject plateWithOranges;
    public GameObject orb;
    public GameObject spike;
    public GameObject meleeEnemy;
    public GameObject rangeEnemy;
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
        
    }

    private void Start()
    {

    }

    private void Update()
    {
        SpawnObjects();
        if(Time.time>1.5f && Time.time<2f)
        {
            corridor = 0;
            hall = 0;
        }
    }

    public void Save(string folder)
    {
        string directory = Application.dataPath + "/.." + "/Saves/" + folder;
        Directory.CreateDirectory(directory);


        XElement root = new XElement("root");
        foreach (SaveableObjects obj in objects)
        {
            root.Add(obj.GetElement());
        }

        Debug.Log(root);

        XDocument saveDoc = new XDocument(root);
        File.WriteAllText(directory + "/save.xml", saveDoc.ToString());
        Debug.Log(directory + "/save.xml");
    }
    public void Load(string folder)
    {
        string directory = Application.dataPath + "/.." + "/Saves/" + folder;

        isLoad = true;
        XElement root = null;
        if (File.Exists(directory + "/save.xml"))
        {
            root = XDocument.Parse(File.ReadAllText(directory + "/save.xml")).Element("root");
        }
        if (root == null)
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
            if (obj.objectName != "Player")
                obj.DestroySelf();
        }
        foreach (XElement instance in root.Elements("instance"))
        {
            Vector3 position = Vector3.zero;

            position.x = float.Parse(instance.Attribute("x").Value);
            position.y = float.Parse(instance.Attribute("y").Value);
            position.z = float.Parse(instance.Attribute("z").Value);
            float rotation = float.Parse(instance.Attribute("rotation").Value);

            if(instance.Value.ToString() == "Player")
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = position;
            }
            else
            {
                Instantiate(Resources.Load<GameObject>(instance.Value), position, Quaternion.Euler(0f, rotation, 0f));
            }
        }
    }

    void SpawnObjects()
    {
        if (Time.time > 2f && !isSpawnObjects && hall == 0 && corridor == 0)
        {
            isSpawnObjects = true;


            List<GameObject> spawnList = GameObject.FindGameObjectsWithTag("Level").ToList();
            for (int i = 0; i < endDungeon; i++)
            {
                int rnd = Random.Range(0, spawnList.Count);
                Instantiate(portal, spawnList[rnd].transform.position, Quaternion.identity);
                spawnList.Remove(spawnList[rnd]);
            }
            for (int i = 0; i < oranges; i++)
            {
                int rnd = Random.Range(0, spawnList.Count);
                Instantiate(plateWithOranges, spawnList[rnd].transform.position, Quaternion.identity);
                spawnList.Remove(spawnList[rnd]);
            }
            for (int i = 0; i < orbs; i++)
            {
                int rnd = Random.Range(0, spawnList.Count);
                Instantiate(orb, spawnList[rnd].transform.position, Quaternion.identity);
                spawnList.Remove(spawnList[rnd]);
            }
            for (int i = 0; i < spikes; i++)
            {
                int rnd = Random.Range(0, spawnList.Count);
                Instantiate(spike, spawnList[rnd].transform.position, Quaternion.identity);
                spawnList.Remove(spawnList[rnd]);
            }
            //surface.BuildNavMesh();
            for (int i = 0; i < mEnemy; i++)
            {
                int rnd = Random.Range(0, spawnList.Count);
                Instantiate(meleeEnemy, spawnList[rnd].transform.position, Quaternion.identity);
                spawnList.Remove(spawnList[rnd]);
            }
            for (int i = 0; i < rEnemy; i++)
            {
                int rnd = Random.Range(0, spawnList.Count);
                Instantiate(rangeEnemy, spawnList[rnd].transform.position, Quaternion.identity);
                spawnList.Remove(spawnList[rnd]);
            }
            surface.RemoveData();
            surface.BuildNavMesh();
            
            isNavMeshBuild = true;
        }
    }


}
