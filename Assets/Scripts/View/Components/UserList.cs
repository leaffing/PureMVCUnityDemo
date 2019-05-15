//[lzh]
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UserList : MonoBehaviour
{
    // ui object
    public Text txt_userCount;
    public UGUI_MyToggleGroup myToggleGroup;
    public Button btn_New;
    public Button btn_Delete;
    public UserList_Item itemPrefab;
    List<UserList_Item> itemList = new List<UserList_Item>();

    // others
    public System.Action NewUser;
    public System.Action DeleteUser;
    public System.Action SelectUser;

    // data
    public UserVO SelectedUserData;
    private IList<UserVO> m_currentUsers;

    // Use this for initialization
    void Start ()
	{
        itemPrefab.gameObject.SetActive(false);

        myToggleGroup.onToggleChange.AddListener(onSelectUserItem);
        btn_New.onClick.AddListener(onClick_btn_New);
        btn_Delete.onClick.AddListener(onClick_btn_Delete);

        UpdateButtons();
    }

    public void LoadUsers(IList<UserVO> list)
    {
        m_currentUsers = list;
        RefreshUI(list);
    }

    void onClick_btn_New()
    {
        if (NewUser != null) NewUser();
    }

    void onClick_btn_Delete()
    {
        if (DeleteUser != null) DeleteUser();
    }

    void onSelectUserItem(Toggle itemToggle)
    {
        if (itemToggle == null)
        {
            return;
        }

        UserList_Item item = itemToggle.GetComponent<UserList_Item>();
        this.SelectedUserData = item.userData;
        UpdateButtons();
        if (SelectUser != null) SelectUser();

    }

    public void Deselect()
    {
        myToggleGroup.toggleGroup.SetAllTogglesOff();
        this.SelectedUserData = null;
        UpdateButtons();
    }


    void RefreshUI(IList<UserVO> datas)
    {
        ClearItems();
        foreach (var data in datas)
        {
            UserList_Item item = CreateItem();
            item.UpdateData(data);
            itemList.Add(item);
        }
        txt_userCount.text = datas.Count.ToString();
    }

    UserList_Item CreateItem()
    {
        UserList_Item item = GameObject.Instantiate<UserList_Item>(itemPrefab);
        item.transform.SetParent(itemPrefab.transform.parent);
        item.gameObject.SetActive(true);
        item.transform.localScale = Vector3.one;
        item.transform.localPosition = Vector3.zero;

        return item;
    }

    void ClearItems()
    {
        foreach(var item in itemList)
        {
            Destroy(item.gameObject);
        }
        itemList.Clear();
    }

    private void UpdateButtons()
    {
        btn_Delete.interactable = (SelectedUserData != null);
    }
}
