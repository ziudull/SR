using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

public GameObject GOPage;
float playerShakeY;
public Text shakeValueText;
public Text timerText;
public Text gotimerText;

float previousShake;
float currentShake;
float time;

	// Use this for initialization
	void Start () {
		previousShake = Input.acceleration.y;
		//shakeValueText.text = playerShakeY.ToString();
	}

	void Update(){
		if (transform.position.y < 3.75){
			Timer();
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.y < 3.75){
			Shake();
			shakeValueText.text = currentShake.ToString("F3");
		}
		else{
			gotimerText.text = timerText.text.ToString();
			GOPage.SetActive(true);
		}
	}

	void Shake(){
		currentShake = Input.acceleration.y;
		if (currentShake < 0){
			//do nothing if shake strength is less than 0
		}
		else if(currentShake != previousShake) {
			//move at shake strength
			transform.position += new Vector3(0, Mathf.Abs(currentShake), 0) * 2F * Time.deltaTime;
		}
		previousShake = currentShake;
	}

	void Timer(){
		timerText.text = Time.time.ToString("F2");
	}
}
