using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void Load3DToUI()
    {
        SceneManager.LoadScene("3DInUI");
    }

    public void LoadDoubleScroll()
    {
        SceneManager.LoadScene("DoubleScroll");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
