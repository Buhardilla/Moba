using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    Ability1 hab1;

    public void Start()
    {

    }

    public class Ability1 : Ability
    {
        public override void CastAbility()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Ability2 : Ability
    {
        public override void CastAbility()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Ability3 : Ability
    {
        public override void CastAbility()
        {
            throw new System.NotImplementedException();
        }
    }
}
