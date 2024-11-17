using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace TCGShopNewCardsModPreloader.Handlers
{
    public class CustomMonsterAttribute
    {
        public int MaxValue { get; set; }
        public string Name { get; set; }
    }
}
