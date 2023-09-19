using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[RequireComponent(typeof(Dropdown))]
public class SaveDropDown1 : MonoBehaviour
{
    private Dropdown dd;
    const string PrefName = "optionvalueD1";
    void Awake()
    {
        dd = GetComponent<Dropdown>();
        dd.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(PrefName, dd.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        dd.value = PlayerPrefs.GetInt(PrefName, 0);
    }
}
