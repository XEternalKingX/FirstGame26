using UnityEngine;
using TMPro;

public class PlayerKeys : MonoBehaviour
{
    public int keyCount = 0;
    public TextMeshProUGUI keyText;

    private void Start()
    {
        UpdateKeyUI();
    }

    public void CollectKey()
    {
        keyCount++;
        UpdateKeyUI();
    }

    void UpdateKeyUI()
    {
        if (keyText != null)
        {
            keyText.text = "Keys: " + keyCount;
        }
    }
}
