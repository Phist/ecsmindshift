using System;
using System.IO;
using System.Linq;
using DesperateDevs.CodeGeneration;
using DesperateDevs.Utils;
using Entitas.CodeGeneration.Plugins;

namespace Assets.Editor.CustomGenerators
{
    public class SingleValueComponentPropertyGenerator : ICodeGenerator
    {
        public string name => "Component (Entity API) + Single Value Component Property";
        public int priority => 0;
        public bool runInDryMode => true;

        private readonly ComponentEntityApiGenerator _baseGenerator = new ComponentEntityApiGenerator();

        //private const string ValueBaseString = @"public ${ComponentType} ${componentName} { get { return (${ComponentType})GetComponent(${Index}); } }";
        //private const string ValueAndPropertyStringStart = "public ${ComponentType} ${componentName} { get { return (${ComponentType})GetComponent(${Index}); } }\n    public";
        //private const string ValueAndPropertyStringEnd = " { get { return ${componentName}.Value; } }";

        // Entitas 1.8.2: They have this weird 'validComponentName' everywhere. It won't be present in later versions, so if generator stops working one day, just use the section above instead.
        private const string ValueBaseString =
            @"public ${ComponentType} ${validComponentName} { get { return (${ComponentType})GetComponent(${Index}); } }";

        private const string ValueAndPropertyStringStart =
            "public ${ComponentType} ${validComponentName} { get { return (${ComponentType})GetComponent(${Index}); } }\n    public";

        private const string ValueAndPropertyStringEnd = " { get { return ${validComponentName}.Value; } }";

        private const string AddSignature = "public void Add${ComponentName}(${newMethodParameters})";
        private const string AddBuilderSignature = "public ${EntityType} Add${ComponentName}(${newMethodParameters})";
        private const string AddEnding = "AddComponent(index, component);\n    }";
        private const string AddBuilderEnding = "AddComponent(index, component);\n        return this;\n    }";

        private const string ReplaceSignature = "public void Replace${ComponentName}(${newMethodParameters}) {\n";

        private const string ReplaceBuilderSignature =
            "public ${EntityType} Replace${ComponentName}(${newMethodParameters}) {\n";

        private const string ReplaceEnding = "ReplaceComponent(index, component);\n    }";
        private const string ReplaceBuilderEnding = "ReplaceComponent(index, component);\n        return this;\n    }";

        private const string RemoveSignature = "public void Remove${ComponentName}() {\n";
        private const string RemoveBuilderSignature = "public ${EntityType} Remove${ComponentName}() {\n";
        private const string RemoveEnding = "RemoveComponent(${Index});\n    }";
        private const string RemoveBuilderEnding = "RemoveComponent(${Index});\n        return this;\n    }";

        public CodeGenFile[] Generate(CodeGeneratorData[] data)
        {
            CodeGenFile[] codeGenFiles = _baseGenerator.Generate(data);
            ComponentData[] components = data.OfType<ComponentData>().ToArray();

            for (var index = 0; index < components.Length; index++)
            {
                ComponentData component = components[index];
                MemberData[] members = component.GetMemberData();

                CodeGenFile file = FindByComponentNameIn(codeGenFiles, component);

                if (file == null)
                    continue;

                if (IsSingleValueComponent(members))
                    AddPropertyCode(members.First(), file, component);

                if (!ComponentIsFlag(members))
                    MakeBuilderSignatures(file, component);
            }

            return codeGenFiles;
        }

        private static CodeGenFile FindByComponentNameIn(CodeGenFile[] codeGenFiles, ComponentData component)
        {
            CodeGenFile byName = null;
            foreach (var file in codeGenFiles)
            {
                var contextName = file.ContextName();
                var componentContextNames = component.GetContextNames();
                
                string componentNameStripped = component.ComponentName()
                    .Replace("Component", "");
                
                if (componentContextNames.Any(x => x == contextName) && file.fileName.EndsWith($"{contextName}{componentNameStripped}Component.cs") )
                {
                    byName = file;
                    break;
                }
            }

            return byName;
        }

        private static bool ComponentIsFlag(MemberData[] members) => members.Length == 0;

        private static bool IsSingleValueComponent(MemberData[] members) =>
            members.Length == 1 &&
            string.Compare(members[0].name, "Value", StringComparison.InvariantCulture) == 0;

        private static void AddPropertyCode(MemberData member, CodeGenFile codeGenFile, ComponentData component)
        {
            string componentName = component.ComponentName();

            string typeAndName = $" {member.type} {componentName.UppercaseFirst()}";
            string withProperty = $"{ValueAndPropertyStringStart}{typeAndName}{ValueAndPropertyStringEnd}";

            ReplaceWithResolvedNames(codeGenFile, component, ValueBaseString, withProperty);
        }

        private static void MakeBuilderSignatures(CodeGenFile codeGenFile, ComponentData component)
        {
            ReplaceWithResolvedNames(codeGenFile, component, AddSignature, AddBuilderSignature);
            ReplaceWithResolvedNames(codeGenFile, component, AddEnding, AddBuilderEnding);

            ReplaceWithResolvedNames(codeGenFile, component, ReplaceSignature, ReplaceBuilderSignature);
            ReplaceWithResolvedNames(codeGenFile, component, ReplaceEnding, ReplaceBuilderEnding);

            ReplaceWithResolvedNames(codeGenFile, component, RemoveSignature, RemoveBuilderSignature);
            ReplaceWithResolvedNames(codeGenFile, component, RemoveEnding, RemoveBuilderEnding);
        }

        private static void ReplaceWithResolvedNames(CodeGenFile codeGenFile,
            ComponentData component,
            string baseSignature,
            string builderSignature)
        {
            string contextName = codeGenFile.ContextName();

            string baseWithResolvedNames = baseSignature.Replace(component, contextName);
            string builderWithResolvedNames = builderSignature.Replace(component, contextName);

            codeGenFile.fileContent = codeGenFile.fileContent.Replace(baseWithResolvedNames, builderWithResolvedNames);
        }
    }

    public static class GeneratorExtensions
    {
        public static string ContextName(this CodeGenFile codeGenFile)
        {
            return codeGenFile.fileName.Contains(Path.DirectorySeparatorChar)
                ? codeGenFile.fileName.Substring(0, codeGenFile.fileName.IndexOf(Path.DirectorySeparatorChar))
                : "";
        }
    }
}