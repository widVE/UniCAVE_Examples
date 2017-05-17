using UnityEngine;
using System.Collections;

public class ScenarioSelection : MonoBehaviour {


	public enum Stage {
		All_Good = -1,
		Equipment_Smoking,
		Equipment_Burning,
		Fire_Near_Patient,
		General_Mayhem
	};

	public Stage stage = Stage.All_Good;


	public int StageCount { get { return System.Enum.GetNames (typeof(Stage)).Length; } }


	public GameObject[] fires = new GameObject[5];


	// Use this for initialization
	void Start () {

		Debug.Assert (fires.Length == StageCount - 1);

		for (int i = 0; i < fires.Length; ++i) {
			Debug.Assert (fires [i] != null);

			ParticleSystem[] ps = fires[i].GetComponentsInChildren<ParticleSystem> ();
			foreach (ParticleSystem p in ps)
				p.Stop ();
			
		}

		StopAllFires ();

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.BackQuote))
			this.StopAllFires ();
		if (Input.GetKeyDown (KeyCode.Alpha1))
			this.SetStage (Stage.Equipment_Smoking);
		if (Input.GetKeyDown (KeyCode.Alpha2))
			this.SetStage (Stage.Equipment_Burning);
		if (Input.GetKeyDown(KeyCode.Alpha3))
			this.SetStage(Stage.Fire_Near_Patient);
		if (Input.GetKeyDown (KeyCode.Alpha4))
			this.SetStage (Stage.General_Mayhem);

	}

	public void StartRandomFire() {

		// get random stage
		System.Array values = System.Enum.GetValues(typeof(Stage));
		// skip over the first item == all good
		Stage s = (Stage)values.GetValue (Random.Range (1, values.Length));
		SetStage (s);
	}

	void SetStage(Stage s) {

		Debug.Log ("Setting new stage to " + s.ToString ());

		stage = s;

		// disable all previous fires
		StopAllFires();

		GameObject go = fires [(int)s];
		go.SetActive (true);


		try {
			go.GetComponent<ParticleSystem> ().Play();
		
			Firesource fs = go.GetComponent<Firesource>();
			fs.enabled = true;
		} catch (MissingComponentException e) {
		}



		// start the particle systems
		ParticleSystem[] ps = go.GetComponentsInChildren<ParticleSystem> ();
		foreach (ParticleSystem p in ps)
			p.Play();
		
	}

	void StopAllFires() {
		for (int i = 0; i < fires.Length; ++i) {
			Debug.Assert (fires [i] != null);

            ParticleSystem p2 = fires [i].GetComponent<ParticleSystem> ();
            if(p2 != null)
            {
                p2.Stop();
            }

			ParticleSystem[] ps = fires [i].GetComponentsInChildren<ParticleSystem> ();
			foreach (ParticleSystem p in ps)
				p.Stop ();
		
			fires [i].SetActive (false);
		}

	}


}
