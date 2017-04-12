﻿using SharpVk.Emit;
using SharpVk.Generator.Generation;
using SharpVk.Generator.Pipeline;
using System.Collections.Generic;
using static SharpVk.Emit.AccessModifier;

namespace SharpVk.Generator.Emission
{
    public class UnionEmitter
        : IOutputWorker
    {
        private readonly IEnumerable<UnionDefinition> unions;

        public UnionEmitter(IEnumerable<UnionDefinition> unions)
        {
            this.unions = unions;
        }

        public void Execute()
        {
            foreach (var @struct in this.unions)
            {
                using (var fileBuilder = new FileBuilder("..\\SharpVk", $"{@struct.Name}.cs"))
                {
                    fileBuilder.EmitUsing("System");

                    fileBuilder.EmitNamespace("SharpVk", namespaceBuilder =>
                    {
                        namespaceBuilder.EmitType(TypeKind.Struct, @struct.Name, typeBuilder =>
                        {
                        }, Public);
                    });
                }
            }
        }
    }
}