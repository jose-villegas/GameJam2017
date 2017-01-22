using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BeginGame : MonoBehaviour {
	
	public void StartLevel(){
		SceneManager.LoadScene(0); 
	}
}
