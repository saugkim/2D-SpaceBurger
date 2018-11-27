using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyByPath : MonoBehaviour {

	// Use this for initialization
	
	public GameObject StartPoint;
	public GameObject StopPoint;
	public GameObject EndPoint;
	public Transform targetPoint ;
	public int stopTimer ;
	public float speed;
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		targetPoint = transform;
		
		stopTimer = -1;
	}
	public void StartFlyBy () {
		transform.position = StartPoint.transform.position;
		targetPoint = StopPoint.transform;
		speed = 0.3f;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Vector2.Distance(transform.position, targetPoint.position)>=speed){
			transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed );
		}
		if(Vector2.Distance(transform.position, StopPoint.transform.position)<= 0.01f&&stopTimer == -1){
			stopTimer = 0;
			GameObject.FindGameObjectWithTag("AsiakasCTRL").GetComponent<AsiakasScript>().Progress();
		}
		if(stopTimer > 0){
			stopTimer--;
		}else if(stopTimer == 0){
			targetPoint = EndPoint.transform;
			stopTimer = -1;
		}
	}
}
