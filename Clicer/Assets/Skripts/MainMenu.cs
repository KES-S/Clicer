using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame() {
        Application.Quit();
    }
    
    public Text recordTextUI;
    public void ReadValueOfRecord()
    {
        recordTextUI.text = "";
        int valueNat = PlayerPrefs.GetInt("SaveVal", 0);
        int count = 0;
        for (int i = valueNat; i >= valueNat - 3;i--) {

            count++;
            string namePosNaw = "ValueOfRecord" + i.ToString();
            int nowPosInt = PlayerPrefs.GetInt(namePosNaw, 0);
            if (PlayerPrefs.HasKey(namePosNaw)) 
                recordTextUI.text += count.ToString() + ". " + nowPosInt.ToString() + "\n";
            

        }
        //PlayerPrefs.DeleteAll();
    }
    public void ReadBBBBBBBBB()
    {
        PlayerPrefs.DeleteAll();
    }
}
