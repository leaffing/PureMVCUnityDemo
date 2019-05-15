//[lzh]
using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class StartupCommand : SimpleCommand, ICommand
{
    public override void Execute(INotification notification)
    {
        Debug.Log("StartupCommand.Execute()");
        Facade.RegisterProxy(new UserProxy());

        MainUI mainUI = notification.Body as MainUI;
        Facade.RegisterMediator(new UserListMediator(mainUI.userList));
        Facade.RegisterMediator(new UserFormMediator(mainUI.userForm));
    }


}
