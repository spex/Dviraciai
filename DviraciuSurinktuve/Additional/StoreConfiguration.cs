using FluentNHibernate.Automapping;
using System;
using FluentNHibernate;
public class StoreConfiguration : DefaultAutomappingConfiguration
{
    public override bool ShouldMap(Type type)
    {
        return type.Namespace == "DviraciuSurinktuve.Entities";
    }
    public override bool IsId(Member member)
    {
        return member.Name == member.DeclaringType.Name + "_ID";
    }

}