using System;
public static class ActionHandler
{
    public static Action<string> ShowValue;

    public static Action<bool> EnableOthers;
    public static Action SelfDisable;

    public static Action <string> PlayerTurn;
}
