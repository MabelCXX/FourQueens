
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;

    private void Start()
    {
        HideDeathScreen();
    }

    public void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
    }

    public void HideDeathScreen()
    {
        deathScreen.SetActive(false);
    }
}