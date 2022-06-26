using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStep {
    private Part attackingPart;
    private List<AttackStep> nextAttacks;

    public AttackStep(Part part, List<AttackStep> nextAttacks = null) {
        attackingPart = part;
        if (nextAttacks == null) {
            nextAttacks = new List<AttackStep>();
        }
    }

    public Part GetPart() {
        return attackingPart;
    }

    public void SetNextParts(List<AttackStep> nextAttacks) {
        this.nextAttacks = nextAttacks;
    }
}

public class Attack
{
    private readonly AttackStep attackStep;

    public Attack(AttackStep attackStep) {
        this.attackStep = attackStep;
    }

    public Attack(Part firstPart) : this(new AttackStep(firstPart)) { }

    public AttackStep GetAttackStep() {
        return attackStep;
    }

    public float GetPrecision()
    {
        throw new NotImplementedException();
    }

    public float GetStrength()
    {
        throw new NotImplementedException();
    }
}
