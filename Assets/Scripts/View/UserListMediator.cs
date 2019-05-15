//[lzh]
using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using System.Collections.Generic;

public class UserListMediator : Mediator, IMediator
{
    private UserProxy userProxy;

    public new const string NAME = "UserListMediator";

    private UserList View
    {
        get { return (UserList)ViewComponent; }
    }

    public UserListMediator(UserList userList)
            : base(NAME, userList)
    {
        Debug.Log("UserListMediator()");
        userList.NewUser += userList_NewUser;
        userList.DeleteUser += userList_DeleteUser;
        userList.SelectUser += userList_SelectUser;
    }

    public override void OnRegister()
    {
        Debug.Log("UserListMediator.OnRegister()");
        base.OnRegister();
        userProxy = Facade.RetrieveProxy(UserProxy.NAME) as UserProxy;
        View.LoadUsers(userProxy.Users);
    }

    void userList_NewUser()
    {
        UserVO user = new UserVO();
        SendNotification(EventsEnum.NEW_USER, user);
    }

    void userList_DeleteUser()
    {
        SendNotification(EventsEnum.DELETE_USER, View.SelectedUserData);
    }

    void userList_SelectUser()
    {
        SendNotification(EventsEnum.USER_SELECTED, View.SelectedUserData);
    }

    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
        list.Add(EventsEnum.USER_DELETED);
        list.Add(EventsEnum.CANCEL_SELECTED);
        list.Add(EventsEnum.USER_ADDED);
        list.Add(EventsEnum.USER_UPDATED);
        return list;
    }

    public override void HandleNotification(INotification notification)
    {
        switch(notification.Name)
        {
            case EventsEnum.USER_DELETED:
                View.Deselect();
                View.LoadUsers(userProxy.Users);
                break;
            case EventsEnum.CANCEL_SELECTED:
                View.Deselect();
                break;
            case EventsEnum.USER_ADDED:
                View.Deselect();
                View.LoadUsers(userProxy.Users);
                break;
            case EventsEnum.USER_UPDATED:
                View.Deselect();
                View.LoadUsers(userProxy.Users);
                break;
        }
    }
}
