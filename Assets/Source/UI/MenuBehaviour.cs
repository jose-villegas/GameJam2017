using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour {

	//canvas
	private Canvas startMenu;
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

		startMenu.gameObject.GetComponent<Canvas>();		
		howToPlayMenu.GetComponent<Canvas>();
		creditsMenu.GetComponent<Canvas>();
		quitMenu.GetComponent<Canvas>();
		
		starText.GetComponent<Button>();
		creditsText.GetComponent<Button>();
		howToPlayText.GetComponent<Button>();
		exitText.GetComponent<Button>();
		
		startMenu.gameObject.SetActive(true);
		creditsMenu.gameObject.SetActive(false);
		howToPlayMenu.gameObject.SetActive(false);
		
		startMenu.enabled = true;
		creditsMenu.enabled = false;
		howToPlayMenu.enabled = false;	
		quitMenu.enabled = false;

	}


	// Credits Press Event
	public void CreditsPress(){

		/*creditsMenu.enabled = true;
		startMenu.enabled = false;*/

		creditsMenu.gameObject.SetActive(true);
		startMenu.gameObject.SetActive(false);

		/*starText.enabled = false;
		creditsText.enabled = false;
		howToPlayText.enabled = false;
		exitText.enabled = false;*/
	}

	// How To Play Press Event
	public void HowToPlayPress(){

		/*howToPlayMenu.enabled = true;
		startMenu.enabled = false;*/

		howToPlayMenu.gameObject.SetActive(true);
		startMenu.gameObject.SetActive(false);
		

		/*starText.enabled = false;
		creditsText.enabled = false;
		howToPlayText.enabled = false;
		exitText.enabled = false;*/
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
		/*startMenu.enabled = true;
		creditsMenu.enabled = false;
		howToPlayMenu.enabled = false;
		quitMenu.enabled = false;	*/

		startMenu.gameObject.SetActive(true);
		creditsMenu.gameObject.SetActive(false);
		howToPlayMenu.gameObject.SetActive(false);
		
		
		//enabling buttons
		/*starText.enabled = true;
		creditsText.enabled = true;
		howToPlayText.enabled = true;
		exitText.enabled = true;*/
	}


	public void StartLevel(){
		//SceneManager.LoadScene(); cuando exista la primera escena colocar aqui
	}

	public void ExitGame(){
		Application.Quit();
	}
}
