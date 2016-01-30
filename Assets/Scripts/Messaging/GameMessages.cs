using UnityEngine;
using Messaging;

public class GameStartMessage : MessageBase { }
public class GameRestartMessage : MessageBase { }
public class PickupItemMessage : MessageBase
{
    public GameObject ItemPickedUp { get; set; }
}
/*
public class PlayerHitWallMessage : MessageBase { }
public class PlayerHitEnemyMessage : MessageBase { }
public class PlayerDigMessage : MessageBase
{
    public Vector3 PlayerPosition { get; set; }
}
public class PlayerHitScrollPointMessage : MessageBase { }
*/
