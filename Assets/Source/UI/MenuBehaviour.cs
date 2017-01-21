using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour {

	public Canvas QuitMenu;
	public Button starText;
	public Button exitText;

	// Use this for initialization
	void Start () {

		QuitMenu.GetComponent<Canvas>();
		starText.GetComponent<Button>();
		exitText.GetComponent<Button>();
		QuitMenu.enabled = false;
	}

	public void exitPress(){

		QuitMenu.enabled = true;
		starText.enabled = false;
		exitText.enabled = false;
	}

	public void noPress(){

		QuitMenu.enabled = false;
		starText.enabled = true;
		exitText.enabled = true;
	}


	public void startLevel(){
		//SceneManager.LoadScene(); cuando exista la primera escena colocar aqui
	}

	public void exitGame(){
		Application.Quit();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
