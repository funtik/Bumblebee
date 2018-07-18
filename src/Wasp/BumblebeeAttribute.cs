using System;

namespace Wasp
{
    /// <summary>
    /// An attribute that tells Wasp to ignore this type/class when determining the file name to use when capturing the screen.
    /// </summary>
    /// <remarks>
    /// On screen capture, Wasp will use the name of the class and method outside of Wasp internal classes to name the image.  
    /// Apply this attribute to any type that you do not want Wasp to use for the naming.  
    /// For example, any third party element projects such as Wasp.KendoUI.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class WaspAttribute : Attribute
    {
    }
}
