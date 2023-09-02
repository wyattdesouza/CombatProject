using System;
using StarterAssets;
using UnityEngine;

public class Player : Hittable, IHittable
{
    public static Player Instance;
    public FirstPersonController FirstPersonController;

    public bool Moving => FirstPersonController.Moving;

    protected override void DoAwake()
    {
        Instance = this;
    }

    private Player player;
}