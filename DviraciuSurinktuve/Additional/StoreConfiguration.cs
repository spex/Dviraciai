using FluentNHibernate.Automapping;
using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;
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
public class CustomForeignKeyConvention : ForeignKeyConvention
{
    protected override string GetKeyName(Member property, Type type)
    {
        if (property == null)
            return type.Name + "_FK";

        return property.Name + "_FK";
    }
}