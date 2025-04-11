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
public class LoadMetadata
{
    [Editor("Bonsai.Design.OpenFileNameEditor, Bonsai.Design", DesignTypes.UITypeEditor)]
    public string Path { get; set;}

    public IObservable<ExperimentMetadata> Process()
    {
        return Observable.Defer(() =>
        {
            ExperimentMetadata settings;
            using (var reader = new StreamReader(Path))
            {
                var parser = new MergingParser(new Parser(reader));

                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();
                settings =  deserializer.Deserialize<ExperimentMetadata>(parser);
            }
            return Observable.Return(settings);
        });
    }
}
