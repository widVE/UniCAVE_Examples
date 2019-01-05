using UnityEngine;
using System.Collections;

public class Firesource : MonoBehaviour {


	public float fuel = 1000;
	public float temp = 200;

	public float maxTemp = 500;

	public bool IsBurning { get { return fuel > 0 && maxTemp > 0; } }

	// Update is called once per frame
	void Update () {

		temp -= Time.deltaTime;
		if (temp < 0) {
			temp = 0;
		}

		if (fuel > 0) {

			// burn 
			fuel -= (Time.deltaTime * (1 + temp/maxTemp));

			// increase temp
			temp += Time.deltaTime * 20;

			if (temp > maxTemp)
				temp = maxTemp;


			// adjust color
            Renderer r = GetComponent<Renderer>();
            if(r != null)
            {
			    r.material.color = Color.Lerp(Color.blue, Color.red, temp/maxTemp);
            }

		}

		if (fuel <= 0 && temp < maxTemp / 2)
			StopBurning ();

	}

	void StopBurning() { 
		ParticleSystem[] ps = GetComponentsInChildren<ParticleSystem> ();
		foreach (ParticleSystem p in ps) {
			p.Stop ();
		}

	}

	void OnTriggerStay(Collider other) { 

		if (other.name == "Foam") {
			temp -= 50 * Time.deltaTime;

            Debug.Log("Foam Hit");
			
            if (temp <= 0)
				StopBurning ();

		}

	}


}
