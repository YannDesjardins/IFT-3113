using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public static bool GamePaused = false;
	public GameObject pauseMenuUI;
	public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (GamePaused){
				Resume();
			}
			else{
				Pause();
			}
		}
    }
	public void Resume(){
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		mainCamera.GetComponent<FlyCamera>().enabled = true;
		Cursor.visible = false;
		GamePaused = false;
	}
	void Pause(){
		pauseMenuUI.SetActive(true);
		mainCamera.GetComponent<FlyCamera>().enabled = false;
		Cursor.visible = true;
		Time.timeScale = 0f;
		GamePaused = true;

	}
	public void Quit(){
		Application.Quit();

	}
}
