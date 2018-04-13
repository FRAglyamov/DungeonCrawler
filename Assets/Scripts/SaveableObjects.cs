using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class SaveableObjects : MonoBehaviour {

    [SerializeField]
    private string objectName;

    private GameController gc;

    private void Awake()
    {
        gc = gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Start()
    {
        gc.objects.Add(this);
    }

    private void OnDestroy()
    {
        gc.objects.Remove(this);
    }

    public XElement GetElement()
    {
        XAttribute x = new XAttribute("x", transform.position.x);
        XAttribute y = new XAttribute("y", transform.position.y);
        XAttribute z = new XAttribute("z", transform.position.z);
        XAttribute rotation = new XAttribute("rotation", transform.rotation.eulerAngles.y);

        XElement element = new XElement("instance", objectName, x, y, z, rotation);

        return element;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
