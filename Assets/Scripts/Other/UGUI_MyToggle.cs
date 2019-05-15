//[lzh]
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Toggle))]
public class UGUI_MyToggle : MonoBehaviour
{    
    [SerializeField]Toggle toggle;
    [SerializeField]UGUI_MyToggleGroup myToggleGroup;

    void Start()
    {
        if (toggle == null) toggle = this.GetComponent<Toggle>();
        if (myToggleGroup == null) myToggleGroup = toggle.group.GetComponent<UGUI_MyToggleGroup>();

        toggle.onValueChanged.AddListener(onToggle);
    }

    void onToggle(bool value)
    {
        if(value)
        {
            myToggleGroup.ChangeToggle(toggle);
        }
    }
}
