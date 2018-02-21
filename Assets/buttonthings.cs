using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonthings : MonoBehaviour {

    public RectTransform button;
    private UnityEngine.UI.Text text;
    [Header("Button Expansion Variables")]
    public float xButtonExpansionSpeed;
    public float yButtonExpansionSpeed;

    // Use this for initialization
    void Start () {
		text = button.GetComponentInChildren<UnityEngine.UI.Text>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void ClickExpansion()
    {
        button.localScale = new Vector3(button.localScale.x + xButtonExpansionSpeed, button.localScale.y + yButtonExpansionSpeed, button.localScale.z);
        text.fontSize += 1;
    }
}
