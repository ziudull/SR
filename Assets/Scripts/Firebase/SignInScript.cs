using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignInScript : MonoBehaviour {

public Firebase.Auth.FirebaseAuth auth;
public Text setDisplayName;

	// Use this for initialization
	void Start () {
		auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
	}

	public void SetDisplayName(){
		Debug.Log(setDisplayName);

		Firebase.Auth.FirebaseUser user = auth.CurrentUser;
		if (user != null) {
			Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile {
				DisplayName = setDisplayName.ToString()
				//,
				//PhotoUrl = new System.Uri("https://example.com/jane-q-user/profile.jpg"),
			};
		user.UpdateUserProfileAsync(profile).ContinueWith(task => {
			if (task.IsCanceled) {
			Debug.LogError("UpdateUserProfileAsync was canceled.");
			return;
			}
			if (task.IsFaulted) {
			Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
			return;
			}

			Debug.Log("User profile updated successfully.");
		});
}
	}

	// Use this to for users to sign in anonymously
	public void SignInAnon(){
		auth.SignInAnonymouslyAsync().ContinueWith(task => {
		if (task.IsCanceled) {
			Debug.LogError("SignInAnonymouslyAsync was canceled.");
			return;
		}
		if (task.IsFaulted) {
			Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
			return;
		}

		Firebase.Auth.FirebaseUser newUser = task.Result;
		SetDisplayName();
		Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
		});
	}

	public void SignInFB(){

	}
}
