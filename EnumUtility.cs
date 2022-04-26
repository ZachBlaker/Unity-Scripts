using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumUtility 
{
    public static object GetBackingValue(this Enum enumValue)
    {
        return Convert.ChangeType(enumValue, enumValue.GetTypeCode());
    }

    public static Enum[] ToEnumArray(this Type type)
    {
        if (!type.IsEnum) throw new Exception($"Cannot convert type {type} that is not Enum to EnumArray");

        string[] enumNames = Enum.GetNames(type);
        Enum[] enums = new Enum[enumNames.Length];

        for(int i = 0; i < enumNames.Length; i++)
            enums[i] =  Enum.Parse(type, enumNames[i]) as Enum;

        return enums;
    }

    public static Enum[] GetEnumsDeclaredByType(Type typeToCheck)
    {
        List<Enum> enums = new List<Enum>();

        foreach (Type enumType in
            typeToCheck.GetNestedTypes()
            .Where(t => t.IsEnum))
        {
            foreach (string name in Enum.GetNames(enumType))
            {
                Enum nameAsEnum = Enum.Parse(enumType, name) as Enum;
                enums.Add(nameAsEnum);
            }
        }
        return enums.ToArray();
    }
}
