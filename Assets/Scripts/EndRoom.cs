using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoom : MonoBehaviour {

    public GameObject portal;
    public GameObject enemy;

	void Start ()
    {

        //if (GameController.Instance.hall == 0 && GameController.Instance.corridor == 0 && GameController.Instance.endDungeon > 0)
        //{
        //    Instantiate(portal, transform.position, transform.rotation);
        //    GameController.Instance.endDungeon -= 1;
        //}
        //int rnd = Random.Range(0, 100);
        //if (rnd > 5 && GameController.Instance.enemy > 0)
        //{
        //    Instantiate(enemy, transform.position, transform.rotation);
        //    GameController.Instance.enemy -= 1;
        //}
    }

}
