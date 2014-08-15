﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;

namespace builder
{
    public sealed class Library
    {
        public readonly string Name;

        public readonly Optional<string> Directory;

        public readonly IEnumerable<Package> PackageList;

        public Library(
            string name,
            Optional.Class<string> directory = new Optional.Class<string>(),
            Optional.Class<IEnumerable<Package>> packageList = new Optional.Class<IEnumerable<Package>>())
        {
            Name = name;
            Directory = directory.Cast();
            PackageList = packageList.OneIfAbsent();
        }

        public IEnumerable<string> Create()
        {
            return PackageList.SelectMany(p => p.Create(Directory).ToEnum());
        }

    }
}
