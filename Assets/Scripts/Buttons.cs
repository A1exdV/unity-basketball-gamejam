using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
   [SerializeField] private List<AudioSource> sounds;
   [SerializeField] private TextMeshProUGUI soundText;

   public void RestartButton()
   {
      Time.timeScale = 1;
      SceneManager.LoadScene(0);
   }

   public void SoundState()
   {
      if (sounds[0].mute)
      {
         foreach (var sound in sounds)
         {
            sound.mute = false;
            soundText.text = "Sound: OFF";
         }
      }
      else
      {
         foreach (var sound in sounds)
         {
            sound.mute = true;
            soundText.text = "Sound: ON";
         }
      }
   }
}
