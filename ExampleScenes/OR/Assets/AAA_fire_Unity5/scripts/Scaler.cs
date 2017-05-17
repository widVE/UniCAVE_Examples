using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class Scaler : MonoBehaviour {
	#if UNITY_EDITOR
	private float[] PS_parameters = new float[10];

	SerializedObject so; 
	ParticleSystem[] allChildren;
	private Vector3 Base_scale;
	private int counter = 0;
	private float scale=1f;
	private float scale_old=1f;
	private bool have_data = false;
	// Use this for initialization
	void Start () {

		GetChildren();
	}

	void GetPSparameters(ParticleSystem _PS){


	
		PS_parameters[0] = _PS.startSize/scale_old;
		PS_parameters[1] = _PS.startSpeed/scale_old;
		PS_parameters[2] = so.FindProperty("ForceModule.y.scalar").floatValue/scale_old ;
		PS_parameters[3] = so.FindProperty("ForceModule.x.scalar").floatValue/scale_old ;
		PS_parameters[4] = so.FindProperty("ForceModule.z.scalar").floatValue/scale_old ;
		Base_scale = this.transform.localScale/scale_old; 
	}

	void GetChildren(){
		allChildren = GetComponentsInChildren<ParticleSystem>();

		if (!have_data){
		
			foreach (ParticleSystem child in allChildren) {
				so = new SerializedObject(child);
					GetPSparameters(child);
					
				
				Scaling(child);
			}
			//have_data = true;
		//}else{
		//	foreach (ParticleSystem child in allChildren) {
		//		so = new SerializedObject(child);
		//		Scaling(child);
			//}
		}

	}
	
	void Scaling(ParticleSystem _PS){

		so.FindProperty("ForceModule.y.scalar").floatValue = PS_parameters[2]*scale;
		so.FindProperty("ForceModule.x.scalar").floatValue = PS_parameters[3]*scale;
		so.FindProperty("ForceModule.z.scalar").floatValue = PS_parameters[4]*scale;
		so.ApplyModifiedProperties();
		_PS.startSize = PS_parameters[0]*scale;
		_PS.startSpeed = PS_parameters[1]*scale;
		this.transform.localScale = new Vector3(scale,scale,scale); 
	
}

	// Update is called once per frame
	void OnGUI () {
		GUI.Label (new Rect (Screen.width / 2f, 70f, 200, 20), "Effect scale coefficient:" + (Mathf.Round (scale * 10f)/10f).ToString ());
		scale = GUI.HorizontalSlider(new Rect(Screen.width/2f,90f,200,20),scale,0.2f,5f);
	}

	void Update(){

		if (scale !=scale_old){

			GetChildren();
			scale_old = scale;
		}

	}
#endif
}
