using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public class ReflectionUtility
{
    public static MethodInfo[] GetAllMethodsDeclaredBy(Type type)
    {
        if (type == null)
            throw new Exception("GetAllMethodsDeclaredBy called with null Type");

        MethodInfo[] methods = type.GetMethods();
        List<MethodInfo> methodsDeclaredByType = new List<MethodInfo>();

        foreach (MethodInfo meth in methods)
        {
            if (meth.DeclaringType == type)
                methodsDeclaredByType.Add(meth);
        }
        return methodsDeclaredByType.ToArray();
    }

    public static MethodInfo[] GetAllMethodsDeclaredByTypeWithAttribute(Type type, Type attributeType)
    {
        if (type == null)
            throw new Exception("GetAllMethodsDeclaredBy called with null Type");

        if (attributeType == null)
            throw new Exception("GetAllMethodsDeclaredBy called with null attribute Type");

        MethodInfo[] methods =
            type.GetMethods()
            .Where(method => method.GetCustomAttribute(attributeType) != null)
            .ToArray();

        List<MethodInfo> methodsDeclaredByType = new List<MethodInfo>();

        foreach (MethodInfo method in methods)
            if (method.DeclaringType == type)
                methodsDeclaredByType.Add(method);

        return methodsDeclaredByType.ToArray();
    }

    public static Enum[] GetEnumsDeclaredByType(Type type)
    {
        List<Enum> enums = new List<Enum>();

        foreach (Type enumType in
            type.GetNestedTypes()
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
