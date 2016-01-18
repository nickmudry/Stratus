using UnityEngine;
using System.Collections;

public class Location : MonoBehaviour {

    public TextMesh locationNameTextMesh;

	// Use this for initialization
	void Start () {
        locationNameTextMesh.text = gameObject.name;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
