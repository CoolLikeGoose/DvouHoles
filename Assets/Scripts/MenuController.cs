using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void LoadScene(int id) //id ссцены, которую загружать
    {
        SceneManager.LoadScene(id);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
