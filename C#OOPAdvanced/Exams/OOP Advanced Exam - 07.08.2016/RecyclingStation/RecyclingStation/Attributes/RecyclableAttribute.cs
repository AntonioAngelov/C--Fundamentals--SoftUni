namespace RecyclingStation.Attributes
{
    using System;
    using WasteDisposal.Attributes;

    [AttributeUsage(AttributeTargets.Class)]
    public class RecyclableAttribute
        : DisposableAttribute
    {
    }
}
