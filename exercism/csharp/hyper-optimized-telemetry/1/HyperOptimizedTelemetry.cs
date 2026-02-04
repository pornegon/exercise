

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
     {
        // Determine the type based on the value range
        byte prefix;
        var payload = BitConverter.GetBytes(reading);
        
        if (reading >= 0)
        {
            if (reading <= ushort.MaxValue)
            {
                prefix = 2;
            }
            else if (reading <= int.MaxValue) 
            {
                prefix = (byte)(256 - 4); 
            }
            else if (reading <= uint.MaxValue)
            {
                prefix = 4;
            }
            else 
            {
                prefix = (byte)(256 - 8); 
            }
        }
        else
        {
            if (reading >= short.MinValue) 
            {
                prefix = (byte)(256 - 2); 
                payload = BitConverter.GetBytes((short)reading);
            }
            else if (reading >= int.MinValue) 
            {
                prefix = (byte)(256 - 4); 
                payload = BitConverter.GetBytes((int)reading);
            }
            else 
            {
                prefix = (byte)(256 - 8); 
            }
        }
        
        byte[] buffer = new byte[9];
        buffer[0] = prefix;
        
        Array.Copy(payload, 0, buffer, 1, payload.Length);
        
        return buffer;
    }

    public static long FromBuffer(byte[] buffer) 
    {
        if (buffer[0] == 254)
            return BitConverter.ToInt16(buffer, 1);
        else if (buffer[0] == 252)
            return BitConverter.ToInt32(buffer, 1);
        else if (buffer[0] == 248 || buffer[0] == 2 || buffer[0] == 4 )
            return BitConverter.ToInt64(buffer, 1);
        else return 0;

        
    }
}
