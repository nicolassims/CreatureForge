using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//these resources are, as of right now, only things the body part absolutely and immediately requires to function
//if a body part lost all of this resource, it would entirely cease to function
public enum BodyResources
{
    Air,
    Blood,
    Ooze,
    Ectoplasm,
    Fire,
    Venom,
    Poison,
}

public enum PerceptionType
{
    LightVisible,
    LightInfrared,
    LightUltraviolet,
    SoundAudible,
    SoundHiFreq,
    SoundLowFreq,
    VibrationAir,
    VibrationGround,
    Touch,
    Magnetism,
    Temperature,
    Chemicals
}