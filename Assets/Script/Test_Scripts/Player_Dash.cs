using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dash : MonoBehaviour
{
    public void PlayerDash()
    {
        this.ghost.makeGhost = true;
        this.dashTime += Time.deltaTime;
        this.isDash = true;

        if (this.tmpDir == Vector2.zero) this.tmpDir = Vector2.right;
        this.rBody2d.velocity = this.tmpDir.normalized * (this.playerMoveSpeed * 5) * Time.deltaTime;
        if (this.dashTime >= this.maxaDashTime)
        {
            this.dashTime = 0;
            this.isDash = false;
            this.ghost.makeGhost = false;
        }
    }
}

