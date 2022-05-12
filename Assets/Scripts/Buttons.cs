using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
   [SerializeField] private AudioListener sound;
   [SerializeField] private TextMeshProUGUI soundText;

   public void RestartButton()
   {
      Time.timeScale = 1;
      SceneManager.LoadScene(0);
   }

   public void SoundState()
   {
      if (sound.enabled)
      {
         sound.enabled = false;
         soundText.text = "Sound: OFF";
      }
      else
      {
         sound.enabled = true;
         soundText.text = "Sound: ON";
      }
   }
}
