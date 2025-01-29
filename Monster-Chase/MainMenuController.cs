using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main : MonoBehaviour
{
    public void PlayGame()
    {
        int SelectedCharacter =
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        GameManager.Instance.CharIndex = SelectedCharacter;
        SceneManager.LoadScene("Gameplay1");
    }

}
