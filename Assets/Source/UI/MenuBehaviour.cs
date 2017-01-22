using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour {

	//canvas
	public Canvas howToPlayMenu;
	public Canvas creditsMenu;
	public Canvas quitMenu;

	// Buttons
	public Button starText;
	public Button creditsText;
	public Button howToPlayText;
	public Button exitText;


	// Use this for initialization
	void Start () {

		howToPlayMenu.GetComponent<Canvas>();
		creditsMenu.GetComponent<Canvas>();
		quitMenu.GetComponent<Canvas>();
		
		starText.GetComponent<Button>();
		creditsText.GetComponent<Button>();
		howToPlayText.GetComponent<Button>();
		exitText.GetComponent<Button>();
		
		creditsMenu.enabled = false;
		howToPlayMenu.enabled = false;	
		quitMenu.enabled = false;

	}


	// Credits Press Event
	public void CreditsPress(){


		creditsMenu.enabled = true;

		starText.enabled = false;
		creditsText.enabled = false;
		howToPlayText.enabled = false;
		exitText.enabled = false;
	}

	// How To Play Press Event
	public void HowToPlayPress(){

		howToPlayMenu.enabled = true;

		starText.enabled = false;
		creditsText.enabled = false;
		howToPlayText.enabled = false;
		exitText.enabled = false;
	}

	// Quit Press Event
	public void ExitPress(){

		//enable quit promp
		quitMenu.enabled = true;

		//Dissable main menu buttons
		starText.enabled = false;
		creditsText.enabled = false;
		howToPlayText.enabled = false;
		exitText.enabled = false;
	}

	// pressing No and return buttons event
	public void NoPress(){

		//inabilitating canvases
		creditsMenu.enabled = false;
		howToPlayMenu.enabled = false;
		quitMenu.enabled = false;

		//enabling buttons
		starText.enabled = true;
		creditsText.enabled = true;
		howToPlayText.enabled = true;
		exitText.enabled = true;
	}


	public void StartLevel(){
		//SceneManager.LoadScene(); cuando exista la primera escena colocar aqui
	}

	public void ExitGame(){
		Application.Quit();
	}
}
