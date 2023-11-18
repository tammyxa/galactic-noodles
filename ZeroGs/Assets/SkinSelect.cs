using UnityEngine;
using UnityEngine.SceneManagement;
public class SkinSelector : MonoBehaviour
{
    public GameObject[] skins; 
    public int selectedCharacter = 0;

    public void NextCharacter(){
        skins[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter +1 ) % skins.Length;
        skins[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter(){
        skins[selectedCharacter].SetActive(false);
        selectedCharacter --;
        if(selectedCharacter < 0 ){
            selectedCharacter += skins.Length;
        }
        skins[selectedCharacter].SetActive(true);
    }

public void StartGame(){
    PlayerPrefs.SetInt("selectedCharacter",selectedCharacter);
    SceneManager.LoadScene(1);
}

}
