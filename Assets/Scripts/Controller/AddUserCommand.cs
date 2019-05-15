using PureMVC.Patterns;
using PureMVC.Interfaces;

public class AddUserCommand : SimpleCommand
{
    /// <summary>
    /// retrieve the user and role proxies and delete the user
    /// and his roles. then send the USER_DELETED notification
    /// </summary>
    /// <param name="notification"></param>
    public override void Execute(INotification notification)
    {
        UserVO user = (UserVO)notification.Body;
        UserProxy userProxy = (UserProxy)Facade.RetrieveProxy(UserProxy.NAME);
        userProxy.AddItem(user);
        SendNotification(EventsEnum.USER_ADDED, user);
    }
}