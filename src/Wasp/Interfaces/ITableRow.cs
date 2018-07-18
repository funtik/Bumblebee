﻿using System.Collections.Generic;

namespace Wasp.Interfaces
{
    public interface ITableRow : IEnumerable<string>
    {
        string this[int index] { get; }
        string this[string column] { get; }
    }
}
