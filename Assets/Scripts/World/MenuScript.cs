using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
    public Canvas quitMenu;
    public Canvas fader;
    public Button startText;
    public Button exitText;


	void Start () {
        fader = fader.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
        fader.enabled = false;
	}
	
    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel()
    {
        quitMenu.enabled = false;
        this.enabled = false;
        fader.enabled = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
