using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CreatePCUI : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Dropdown itemDropdown;
    public Button confirmButton;

    private System.Action<string, string> onComplete;

    public void Initialize(System.Action<string, string> callback)
    {
        onComplete = callback;

        confirmButton.onClick.AddListener(() =>
        {
            string name = nameInput.text;
            string item = itemDropdown.options[itemDropdown.value].text;
            onComplete?.Invoke(name, item);
        });

    }
}