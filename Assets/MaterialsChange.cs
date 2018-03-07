using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsChange : MonoBehaviour {


    bool hasChanged = false;
    public Color firstColor;
    public Color secondColor;
    [Range(0, 0.2f)]
    public float step;
    bool isChanging = false;
    bool touching = false;

    // Use this for initialization
    void Start() {
        GetComponent<MeshRenderer>().material.color = firstColor;
    }

    // Update is called once per frame
    void Update() {
        if (isChanging)
        {
            if (GetComponent<MeshRenderer>().material.color != secondColor)
                GetComponent<MeshRenderer>().material.color = Color.Lerp(GetComponent<MeshRenderer>().material.color, secondColor, step);
        }

        if (touching == true)
        {
            CurrentTouch();
        }
    }
 
    public void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Don'tBlackHole")
        {
            touching = true;
        }
    }

    public void ChangeMat()
    {
        isChanging = true;
    }

    public void CurrentTouch()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {          
            ChangeMat();
            touching = false;
        }
    }
}
