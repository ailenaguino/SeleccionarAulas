using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownFilter : MonoBehaviour
{
    [SerializeField]
    private InputField inputField;

    [SerializeField]
    private Dropdown dropdown;

    [SerializeField]
    private List<GameObject> targetObjects = new List<GameObject>();

    private List<Dropdown.OptionData> dropdownOptions;

    private void Start()
    {
        dropdownOptions = dropdown.options;
    }
    public void FilterDropdown(string input)
    {
        dropdown.options = dropdownOptions.FindAll(option => option.text.IndexOf(input) >= 0);
    }

    public void SetCurrentNavigationTarget(int selectedValue)
    {
        string selectedText = dropdown.options[selectedValue].text;
        GameObject currentObject = targetObjects.Find(x => x.name.Equals(selectedText));
        if (currentObject != null)
        {
            Debug.Log(currentObject.name+", "+ currentObject.GetComponent<Renderer>().enabled);
            currentObject.GetComponent<Renderer>().enabled = !currentObject.GetComponent<Renderer>().enabled;
        }
    }
}
