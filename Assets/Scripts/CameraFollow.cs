using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	#region Rabih Code
	private Vector2 velocidade;
	public float xSuave , ySuave;
	public bool limite;
	public Vector3 minCam , maxCam;
	public GameObject player;

	void FixedUpdate () {

        float xzin = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocidade.x, xSuave);
		float yzin = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocidade.y, ySuave);

        transform.position = new Vector3 (xzin, yzin, transform.position.z);

        if (limite)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCam.x, maxCam.x),
            Mathf.Clamp(transform.position.y, minCam.y, maxCam.y), Mathf.Clamp(transform.position.z, minCam.z, maxCam.z));
        }
    }	
	#endregion



	//First code of camera follow;
	/* 
	[SerializeField] private Transform target;
	[SerializeField] private float speed = 0.15f;
	public Vector3 offset;
	public bool maxMin;
	public float xMin;
	public float yMin;
	public float xMax;
	public float yMax;

	void FixedUpdate () {
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
		transform.position = smoothedPosition;

		//transform.LookAt(target);
	 */
}
