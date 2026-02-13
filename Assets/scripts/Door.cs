using UnityEngine;
using TMPro;
using System.Collections;

public class Door : MonoBehaviour
{
    public int keysRequired = 1;
    public TextMeshProUGUI doorMessageText;
    public float messageDuration = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerKeys playerKeys = other.GetComponent<PlayerKeys>();

        if (playerKeys != null && playerKeys.keyCount >= keysRequired)
        {
            OpenDoor();
        }
        else
        {
            int currentKeys = playerKeys != null ? playerKeys.keyCount : 0;
            int keysNeeded = keysRequired - currentKeys;

            StartCoroutine(ShowMessage("Need " + keysNeeded + " more key(s)!"));
        }
    }

    void OpenDoor()
    {
        Debug.Log("Door opened!");
        Destroy(gameObject);
    }

    IEnumerator ShowMessage(string message)
    {
        doorMessageText.gameObject.SetActive(true);
        doorMessageText.text = message;

        yield return new WaitForSeconds(messageDuration);

        doorMessageText.gameObject.SetActive(false);
    }
}
