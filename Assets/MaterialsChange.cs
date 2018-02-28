using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsChange : MonoBehaviour {

    bool hasChanged = false;
    public Color firstColor;
    public Color secondColor;
    [Range(0,0.2f)]
    public float step;
    bool isChanging = false;

    // Use this for initialization
    void Start () {
        GetComponent<MeshRenderer>().material.color = firstColor;
	}
	
	// Update is called once per frame
	void Update () {
        if (isChanging)
        {
            if (GetComponent<MeshRenderer>().material.color != secondColor)
            GetComponent<MeshRenderer>().material.color = Color.Lerp(GetComponent<MeshRenderer>().material.color, secondColor, step);
        }
        /*
        if (Input.anyKey)
        {
            ChangeMat();
        } 
        */
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Don'tBlackHole")
        {
            ChangeMat();
        }
    }

    public void ChangeMat()
    {
        isChanging = true;
    }
}
