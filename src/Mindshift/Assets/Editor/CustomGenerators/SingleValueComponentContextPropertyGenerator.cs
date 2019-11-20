using System;
using System.Linq;
using DesperateDevs.CodeGeneration;
using DesperateDevs.Utils;
using Entitas.CodeGeneration.Plugins;

namespace Assets.Editor.CustomGenerators
{
  public class SingleValueComponentContextPropertyGenerator : AbstractGenerator
  {
    public override string name => "Component (Context API) + Single Value Component Property";

    private readonly ComponentContextApiGenerator _baseGenerator = new ComponentContextApiGenerator();

    //private const string ValueBaseString = @"public ${ComponentType} ${componentName} { get { return (${ComponentType})GetComponent(${Index}); } }";
    //private const string ValueAndPropertyStringStart = "public ${ComponentType} ${componentName} { get { return (${ComponentType})GetComponent(${Index}); } }\n    public";
    //private const string ValueAndPropertyStringEnd = " { get { return ${componentName}.Value; } }";

    // Entitas 1.8.2: They have this weird 'validComponentName' everywhere. It won't be present in later versions, so if generator stops working one day, just use the section above instead.
    private const string ValueBaseString = @"public ${ComponentType} ${validComponentName} { get { return ${validComponentName}Entity.${validComponentName}; } }";
    private const string ValueAndPropertyStringStart = "public ${ComponentType} ${validComponentName} { get { return ${validComponentName}Entity.${validComponentName}; } }\n    public";
    private const string ValueAndPropertyStringEnd = " { get { return ${validComponentName}.Value; } }";

    public override CodeGenFile[] Generate(CodeGeneratorData[] data)
    {
      CodeGenFile[] codeGenFiles = _baseGenerator.Generate(data);
      ComponentData[] components = data.OfType<ComponentData>().ToArray();

      foreach (ComponentData component in components)
      {
        MemberData[] members = component.GetMemberData();

        if (component.IsUniqueAndSingleValueComponent(members))
          AddPropertyCode(members.First(), component.CorrespondingFile(codeGenFiles), component);
      }
      
      return codeGenFiles;
    }

    private static void AddPropertyCode(MemberData member, CodeGenFile codeGenFile, ComponentData component)
    {
      string typeAndName = $" {member.type} {component.ComponentName().UppercaseFirst()}";
      string withProperty = $"{ValueAndPropertyStringStart}{typeAndName}{ValueAndPropertyStringEnd}";

      ReplaceWithResolvedNames(codeGenFile, component, ValueBaseString, withProperty);
    }

    private static void ReplaceWithResolvedNames(CodeGenFile codeGenFile, ComponentData component, string baseSignature, string builderSignature)
    {
      string baseWithResolvedNames = baseSignature.Replace(component, "Game");
      string builderWithResolvedNames = builderSignature.Replace(component, "Game");

      codeGenFile.fileContent = codeGenFile.fileContent.Replace(baseWithResolvedNames, builderWithResolvedNames);
    }
  }

  public static partial class CleanCodeExtensions
  {
    public static bool IsUniqueAndSingleValueComponent(this ComponentData component, MemberData[] members) =>
      component.IsUnique() && members.Length == 1 && string.Compare(members[0].name, "Value", StringComparison.InvariantCultureIgnoreCase) == 0;

    public static CodeGenFile CorrespondingFile(this ComponentData component, CodeGenFile[] codeGenFiles) => 
      codeGenFiles.FirstOrDefault(f => f.fileName.EndsWith($"{component.GetContextNames().First()}{component.ComponentName()}Component.cs"));
  }
}