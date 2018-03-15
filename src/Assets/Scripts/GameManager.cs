using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private float points = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddPoints(float points)
    {
        this.points += points;
        Debug.Log("Gesamte Punkte: " + this.points);
    }
}
