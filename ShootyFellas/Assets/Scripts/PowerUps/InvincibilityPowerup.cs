using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPowerup : Base_Upgrade
{
    // Start is called before the first frame update
    Character player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnTouchPlayer();
        }
    }

    public override void OnTouchPlayer()
    {
        player.DamageMultiplier = 0;
        StartCoroutine(ResetInvincibility());
    }

    IEnumerator ResetInvincibility()
    {
        yield return new WaitForSeconds(10);
        player.DamageMultiplier = 1f;
    }
}
