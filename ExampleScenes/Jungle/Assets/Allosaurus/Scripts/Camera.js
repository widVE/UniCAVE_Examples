#pragma strict
var selectTargetObject:Transform;
var selectAnimatedObject:Animation;

 
function Update () {
		this.transform.LookAt (selectTargetObject);
		  this.transform.RotateAround (selectTargetObject.position, Vector3.up, 30 * Time.deltaTime);
 
}

function OnGUI ()
{

 if (GUI.Button(Rect(20,20,70,30),"Idle")) selectAnimatedObject.Play ("Allosaurus_Idle") ;
 if (GUI.Button(Rect(20,60,70,30),"Walk")) selectAnimatedObject.Play ("Allosaurus_Walk") ;
 if (GUI.Button(Rect(20,100,70,30),"Run")) selectAnimatedObject.Play ("Allosaurus_Run") ;
 if (GUI.Button(Rect(20,140,70,30),"Attack01")) selectAnimatedObject.Play ("Allosaurus_Attack01") ;
 if (GUI.Button(Rect(20,180,70,30),"Attack02")) selectAnimatedObject.Play ("Allosaurus_Attack02") ;
 if (GUI.Button(Rect(20,220,70,30),"Hit01")) selectAnimatedObject.Play ("Allosaurus_Hit01") ;
 if (GUI.Button(Rect(20,260,70,30),"Hit02")) selectAnimatedObject.Play ("Allosaurus_Hit02") ;
 if (GUI.Button(Rect(20,300,70,30),"Die")) selectAnimatedObject.Play ("Allosaurus_Die") ;  
 if (GUI.Button(Rect(20,340,120,30),"IdleAggressive")) selectAnimatedObject.Play ("Allosaurus_IdleAggressive");  
 if (GUI.Button(Rect(20,380,120,30),"IdleBellow")) selectAnimatedObject.Play ("Allosaurus_IdleBellow");  
 if (GUI.Button(Rect(20,420,120,30),"Jump")) selectAnimatedObject.Play ("Allosaurus_Jump");   
 if (GUI.Button(Rect(20,460,120,30),"JumpLeft")) selectAnimatedObject.Play ("Allosaurus_JumpLeft");
 if (GUI.Button(Rect(20,500,120,30),"JumpRight")) selectAnimatedObject.Play ("Allosaurus_JumpRight");
 
}