using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class procGen : MonoBehaviour {

	public int sweatDropNumber;
	public int maxZ;
	public int scaleMult;
	public int xRange;
	public int yRange;
	public int zRange;

	void Start () {
		gen ();		
	}
	

	/* KEY INPUTS */

	void Update () {

		if (Input.GetKeyDown("m")) {
			newGen();
		}

		if (Input.GetKeyDown("r")) {
			res();
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}		
		
	}

	/* GENERATOR */

	void gen() {
		
		for (int i = 0; i < sweatDropNumber; i++) {
			GameObject drop = Instantiate (Resources.Load ("o") as GameObject);
			Vector3 pos = new Vector3 (Random.Range (-xRange, xRange), Random.Range (-yRange, yRange), Random.Range (-zRange, zRange));
			Vector3 scale = new Vector3 (1, 1, Random.Range (1, maxZ)) * Random.Range(1, scaleMult);
			drop.transform.localScale = scale;
			drop.transform.position = pos;
			drop.transform.parent = this.transform;
			drop.name = "drop";
		}

	}

	public void newGen() {
		gen ();
	}

	public void res() {

		Camera.main.GetComponent<cameraScript> ().res ();
		foreach (Transform drop in this.GetComponent<Transform>()) {
			Destroy (drop.gameObject);
		}
		newGen ();
	}
}
