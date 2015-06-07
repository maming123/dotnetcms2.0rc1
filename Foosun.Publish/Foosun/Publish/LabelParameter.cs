namespace Foosun.Publish
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct LabelParameter
    {
        public string LPName;
        public string LPValue;
    }
}

