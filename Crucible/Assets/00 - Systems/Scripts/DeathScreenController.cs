using System.Collections;
using UnityEngine;

public class DeathScreenController : MonoBehaviour
{
    public GameObject DeathScreen;
    private Animation animation;

    void Start()
    {
        Player.Instance.OnDeath += OnPlayerDeath;
        animation = DeathScreen.GetComponent<Animation>();
        if (animation == null)
        {
            Debug.LogError("No animation found on the death screen");
        }
        DeathScreen.SetActive(false);
    }

    private void OnPlayerDeath()
    {
        DeathScreen.SetActive(true);
        animation.Play();
    }
}
