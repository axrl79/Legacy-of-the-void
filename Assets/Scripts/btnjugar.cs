using UnityEngine;
using UnityEngine.SceneManagement;

public class btnjugar : MonoBehaviour
{
    public AudioSource musicaMenu; 

    public void CambiarASampleScene()
    {
        if (musicaMenu != null)
        {
            musicaMenu.Stop(); 
        }

        SceneManager.LoadScene("SampleScene");
    }
}
