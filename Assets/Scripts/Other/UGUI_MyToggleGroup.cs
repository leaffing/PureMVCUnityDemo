//[lzh]
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ToggleEvent : UnityEvent<Toggle> { }

[RequireComponent(typeof(ToggleGroup))]
public class UGUI_MyToggleGroup : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public ToggleEvent onToggleChange = new ToggleEvent();

    void Start()
    {
        if (toggleGroup == null) toggleGroup = this.GetComponent<ToggleGroup>();
    }

    public void ChangeToggle(Toggle toggle)
    {
        onToggleChange.Invoke(toggle);
    }
	
}
