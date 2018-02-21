using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {

    public List<GameObject> allGOs = new List<GameObject>();
    bool enteringHole;
    public float moveSpeed = 1;
    float destroyDelay = 0.2f;
    int index;

    // Use this for initialization
    void Start () {
        WorldDotDistort();

    }
	
	// Update is called once per frame
	void Update () {
		if (enteringHole)
        {
            for (index = 0; index < allGOs.Count; index++)
            {
                if (!allGOs[index].gameObject.GetComponent<Camera>())
                allGOs[index].transform.position = Vector3.MoveTowards(allGOs[index].transform.position, transform.position, moveSpeed);
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            TurnOn();
            print("I don't care");
        }
	}

    public void WorldDotDistort()
    {
        GameObject[] objects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objects)
        {
            obj.AddComponent<Rigidbody>();
            allGOs.Add(obj);
        }
    }

    public void TurnOn()
    {
        enteringHole = true;
        InvokeRepeating("DestroyGO", destroyDelay, destroyDelay);
    }

    public void DestroyGO()
    {
        GameObject GO = allGOs[Random.Range(0,allGOs.Count)];
        allGOs.Remove(GO);
        Destroy(GO);
    }
}
