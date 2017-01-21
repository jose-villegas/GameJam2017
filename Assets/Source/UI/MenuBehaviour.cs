using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour {

	public Canvas quitMenu;
	public Button starText;
	public Button exitText;	

	// Use this for initialization
	void Start () {

		quitMenu.GetComponent<Canvas>();
		starText.GetComponent<Button>();
		exitText.GetComponent<Button>();
		quitMenu.enabled = false;

	}

	public void ExitPress(){

		quitMenu.enabled = true;
		starText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPress(){

		quitMenu.enabled = false;
		starText.enabled = true;
		exitText.enabled = true;
	}


	public void StartLevel(){
		//SceneManager.LoadScene(); cuando exista la primera escena colocar aqui
	}

	public void ExitGame(){
		Application.Quit();
	}
}
