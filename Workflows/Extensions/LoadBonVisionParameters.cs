using Bonsai;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.IO;
using Metadata;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

[Combinator]
[Description("")]
[WorkflowElementCategory(ElementCategory.Source)]
public class LoadBonVisionParameters
{
    [Editor("Bonsai.Design.OpenFileNameEditor, Bonsai.Design", DesignTypes.UITypeEditor)]
    public string Path { get; set;}

    public IObservable<BonVisionParameters.BonVisionParameters> Process()
    {
        return Observable.Defer(() =>
        {
            BonVisionParameters.BonVisionParameters settings;
            using (var reader = new StreamReader(Path))
            {
                var parser = new MergingParser(new Parser(reader));

                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();
                settings =  deserializer.Deserialize<BonVisionParameters.BonVisionParameters>(parser);
            }
            return Observable.Return(settings);
        });
    }
}
