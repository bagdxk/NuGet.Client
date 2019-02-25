// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NuGet.SolutionRestoreManager.Test
{

    internal abstract class ItemList<T> : Collection<T>
    {
        public ItemList() : base() { }

        public ItemList(IEnumerable<T> collection) : base()
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public T Item(Object index)
        {
            if (index is int)
            {
                return this[(int)index];
            }
            else
            {
                return default(T);
            }
        }
    }

    internal class VsReferenceItems : ItemList<IVsReferenceItem>, IVsReferenceItems
    {
        public VsReferenceItems() : base() { }

        public VsReferenceItems(IEnumerable<IVsReferenceItem> collection) : base(collection) { }
    }
}
