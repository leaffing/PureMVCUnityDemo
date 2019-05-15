//[lzh]
using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour
{
    public UserList userList;
    public UserForm userForm;

    void Awake()
    {
        ApplicationFacade facade = ApplicationFacade.Instance as ApplicationFacade;
        facade.Startup(this);
    }
}
