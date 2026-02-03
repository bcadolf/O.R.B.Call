using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CreatePCUI : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Dropdown itemDropdown;
    public Button confirmButton;
    public StartingORBDropdown orbDropdownSource;

    private System.Action<string, string> onComplete;

    public void Initialize(System.Action<string, string> callback)
    {
        onComplete = callback;

        confirmButton.onClick.AddListener(() =>
        {
            string name = nameInput.text;
            int index = itemDropdown.value;
            int orbId = orbDropdownSource.startingOrbs[index].id;
            onComplete?.Invoke(name, orbId.ToString());
        });

    }
}