﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Vtf
{
    [Flags]
    public enum TextureFlags: uint
    {
        // Flags from the *.txt config file
        PointSample = 0x00000001,
        Trilinear = 0x00000002,
        Clamps = 0x00000004,
        Clampt = 0x00000008,
        Anisotropic = 0x00000010,
        HintDxt5 = 0x00000020,
        PwlCorrected = 0x00000040,
        Normal = 0x00000080,
        NoMip = 0x00000100,
        NoLod = 0x00000200,
        AllMips = 0x00000400,
        Procedural = 0x00000800,

        // These are automatically generated by vtex from the texture data.
        OneBitAlpha = 0x00001000,
        EightBitAlpha = 0x00002000,

        // Newer flags from the *.txt config file
        EnvMap = 0x00004000,
        RenderTarget = 0x00008000,
        DepthRenderTarget = 0x00010000,
        NodeBugOverride = 0x00020000,
        Singlecopy = 0x00040000,
        PreSrgb = 0x00080000,

        Unused00100000 = 0x00100000,
        Unused00200000 = 0x00200000,
        Unused00400000 = 0x00400000,

        NoDepthBuffer = 0x00800000,

        Unused01000000 = 0x01000000,

        ClampU = 0x02000000,
        VertexTexture = 0x04000000,
        SsBump = 0x08000000,

        Unused10000000 = 0x10000000,

        Border = 0x20000000,

        Unused40000000 = 0x40000000,
        Unused80000000 = 0x80000000,
    }
}
