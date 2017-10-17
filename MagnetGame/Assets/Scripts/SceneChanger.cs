using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	void ChangeToScene(string SceneToChange){
		SceneManager.LoadScene (SceneToChange);
	}
}
