namespace ERPSysZoo.Models;

public static class EntityFactory
{
    private static int _idCounter = 0;
    public static int GetNextId() => ++_idCounter;
}