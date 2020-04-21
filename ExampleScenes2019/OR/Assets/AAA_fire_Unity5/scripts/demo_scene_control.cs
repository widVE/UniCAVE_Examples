using UnityEngine;
using System.Collections;

public class demo_scene_control : MonoBehaviour {
	public Transform c_point;
	public Transform c_point1;
	public Transform f_point;

	public Transform[] style1 = new Transform[8];
	public Transform[] style2 = new Transform[8];
	public Transform[] style3 = new Transform[8];
	public Transform[] style4 = new Transform[8];
	private GameObject current;
	private int style =0;
	private int cur_effect =0;
	private int max_n =11;

	void Start(){
		Restart();
		Application.targetFrameRate = 60;
	}

	void Update(){
		this.transform.RotateAround(c_point1.transform.position,Vector3.up,0.5f);
	}

	void OnGUI(){
		string name_ = current.name;
		name_ = name_.Substring(0, name_.Length - 7);
		GUI.Label(new Rect(15,10,200,20),name_);
		if (GUI.Button(new Rect(290, 30, 90, 30), "Style1"))
		{
			style=0;
			Restart();
		}
		if (GUI.Button(new Rect(390, 30, 90, 30), "Style 2"))
		{
			style=1;
			Restart();
		}
		if (GUI.Button(new Rect(490, 30, 90, 30), "Style 3"))
		{
			style=2;
			Restart();
		}
		if (GUI.Button(new Rect(590, 30, 90, 30), "Style 4"))
		{
			style=3;
			Restart();
		}
		if (GUI.Button(new Rect(10, 30, 40, 30), "<-"))
		{
			if (cur_effect<=0)
				cur_effect=max_n;
			else
				cur_effect -=1;
			Restart();
		}
		if (GUI.Button(new Rect(60, 30, 40, 30), "->"))
		{
			if (cur_effect>=max_n)
				cur_effect=0;
			else
				cur_effect +=1;
			Restart();
		}


	}

	void Restart(){
		Transform rot_p = c_point;

		Destroy(current);
		if (cur_effect==4 || cur_effect == 5){
			rot_p.transform.eulerAngles = new Vector3(0f,-90f,0f);
			rot_p.transform.position = c_point1.transform.position+ new Vector3(1f,1f,0f); 
		}
		else if (cur_effect==6 || cur_effect ==7){
			rot_p.transform.eulerAngles = c_point1.transform.eulerAngles;
			rot_p.transform.position = c_point1.transform.position+ new Vector3(0f,1f,0f); 
		}
		else if (cur_effect==10 || cur_effect ==11){
			rot_p.transform.eulerAngles =  new Vector3(0f,0f,0f);
			rot_p.transform.position = c_point1.transform.position+ new Vector3(0f,1f,0f); 
		}
		else{
			rot_p.transform.eulerAngles = c_point1.transform.eulerAngles;
			rot_p.transform.position = c_point1.transform.position; 
		}


		//if (cur_effect==0 || cur_effect ==1)
		//{
			//if
			//rot_p = new Vector3(270f,0f,0f);
		//}

		if (style==0)
			current = (Instantiate(style1[cur_effect],rot_p.transform.position,rot_p.transform.rotation) as Transform).gameObject;
		if (style==1)
			current = (Instantiate(style2[cur_effect],rot_p.transform.position,rot_p.transform.rotation) as Transform).gameObject;
		if (style==2)
			current = (Instantiate(style3[cur_effect],rot_p.transform.position,rot_p.transform.rotation) as Transform).gameObject;
		if (style==3)
			current = (Instantiate(style4[cur_effect],rot_p.transform.position,rot_p.transform.rotation) as Transform).gameObject;

	}
}
