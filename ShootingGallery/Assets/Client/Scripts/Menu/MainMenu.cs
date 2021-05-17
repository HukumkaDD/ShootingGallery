using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Texture2D defaultCursorArrow;

    public void Start()
    {
        Cursor.SetCursor(defaultCursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(Helper.Scenes[Helper.TagName.DefaultShootingGallery]);
    }

    public void Score()
    {
        PlayerProfile.LoadPlayer();
    }

    public void Quit()
    {
        Application.Quit();
    }

}
