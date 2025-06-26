using ProtoBuf;
using System.Reflection;
using System.Text;

namespace Ois.Plus.ObjectModel;

public static class KeyValueStorageUtils
{
    public static object Deserialize(byte[] serializedData)
    {
        StringBuilder sb = new();
        using MemoryStream ms = new(serializedData);
        while (true)
        {
            var currentChar = (char)ms.ReadByte();
            if (currentChar == '|')
            {
                break;
            }

            sb.Append(currentChar);
        }

        string typeName = sb.ToString();

        // assuming that the calling assembly contains the desired type.
        // You can include aditional assembly information if necessary
        Type deserializationType = Type.GetType(typeName);

        MethodInfo mi = typeof(Serializer).GetMethod(nameof(Serializer.DeserializeWithLengthPrefix), [typeof(Stream), typeof(PrefixStyle), typeof(int)]);

        MethodInfo genericMethod = mi.MakeGenericMethod(deserializationType);
        var ret = genericMethod.Invoke(null, [ms, PrefixStyle.Fixed32, 1]);
        return ret;
    }
}
