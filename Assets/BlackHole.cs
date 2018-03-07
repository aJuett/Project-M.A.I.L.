using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {

    public List<GameObject> allGOs = new List<GameObject>();
    bool enteringHole;
    public float moveSpeed = 1;
    float destroyDelay = 0.2f;
    int index;

    void Start () {
        WorldDotDistort();
    }

	void Update () {
		if (enteringHole)
        {
            for (index = 0; index < allGOs.Count; index++)
            {
                if (allGOs[index] == null)
                {
                    if (allGOs.Count == 0)
                    {
                        enteringHole = false;
                    }
                    allGOs.RemoveAt(index);
                }
                if (!allGOs[index].gameObject.GetComponent<Camera>())
                allGOs[index].transform.position = Vector3.MoveTowards(allGOs[index].transform.position, transform.position, moveSpeed);
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            //TODO make this happen when you want it to
            TurnOn();
            print("I don't care");
        }
	}

    public void WorldDotDistort()
    {
        GameObject[] objects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj == Camera.main.gameObject || obj.CompareTag("Don'tBlackHole"))
            {
                continue;
            }
            obj.AddComponent<Rigidbody>();
            obj.GetComponent<Rigidbody>().isKinematic = true;
            allGOs.Add(obj);
        }
    }

    public void TurnOn()
    {
        enteringHole = true;
        for (int index = 0; index < allGOs.Count; index++)
        {
            allGOs[index].GetComponent<Rigidbody>().isKinematic = false;
        }
        InvokeRepeating("DestroyGO", destroyDelay, destroyDelay);
    }

    public void DestroyGO()
    {
        if (allGOs.Count == 0)
        {
            //make black canvas appear
            //
            CancelInvoke("DestroyGO");
        }
        GameObject GO = allGOs[Random.Range(0,allGOs.Count)];
        allGOs.Remove(GO);
        Destroy(GO);
    }
}
