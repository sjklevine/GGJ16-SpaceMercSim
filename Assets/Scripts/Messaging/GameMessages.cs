using UnityEngine;
using Messaging;

public class GameStartMessage : MessageBase { }
public class GameRestartMessage : MessageBase { }

public class PickupItemMessage : MessageBase
{
    public int Hand { get; set; }
    public GameObject ItemPickedUp { get; set; }
}

public class DropItemMessage : MessageBase
{
    public int Hand { get; set; }
}

public class TrySnapItemsMessage : MessageBase { }

public class AcquiredWeaponComboMessage : MessageBase
{
    public GameObject ItemCreated { get; set; }
}

public class AcquiredWeaponMessage : MessageBase { }