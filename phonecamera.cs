using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phonecamera : MonoBehaviour {
	private bool camAvailable;
	private WebCamTexture backcam;
	private Texture defaultBackground;
	public GameObject background;
	//public AspectRatioFitter fit;
	// Use this for initialization
	private void Start () {
		defaultBackground = background.GetComponent<MeshRenderer> ().material.mainTexture;
		WebCamDevice[] device = WebCamTexture.devices;
		if(device.Length==0){
			Debug.Log ("no camera");
			camAvailable = false;
			return;
		}
		for(int i=0;i<device.Length;i++){
			if(!device[i].isFrontFacing){
				backcam = new WebCamTexture (device[i].name,Screen.width,Screen.height);

			}
		}
		if(backcam==null){
			Debug.Log ("unable to find back camera");
			return;
		}
		backcam.Play ();
		background.GetComponent<MeshRenderer>().material.mainTexture = backcam;
		camAvailable = true; 

		
	}
	
	// Update is called once per frame
	private void Update () {
		if (!camAvailable)
			return;
		float ratio = (float)backcam.width / (float)backcam.height;
		//fit.aspectRatio = ratio;
		float scaleY = backcam.videoVerticallyMirrored ? -1f : 1f;
		background.transform.localScale = new Vector3 (1f,scaleY,1f);
		int orient = -backcam.videoRotationAngle;
		background.transform.localEulerAngles = new Vector3 (0,0,orient);
	}
}
