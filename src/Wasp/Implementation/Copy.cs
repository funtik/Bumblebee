﻿using System;

using OpenQA.Selenium;

using Wasp.Interfaces;

namespace Wasp.Implementation
{
    [Obsolete("Make a string property instead that directly returns the text. Do verifications through a lambda on the parent block.")]
    public class Copy<TResult> : Element, ICopy<TResult> where TResult : IBlock
    {
        public Copy(IBlock parent, By by) : base(parent, by)
        {
        }

        public Copy(IBlock parent, IWebElement element) : base(parent, element)
        {
        }
    }
}
