namespace GuieMe.Infra.Services
{
    public static class ByteArrayExtensions
    {
        public static byte[] ToUint8Array(this byte[] source)
        {
            byte[] uint8Array = new byte[source.Length];
            Buffer.BlockCopy(source, 0, uint8Array, 0, source.Length);
            return uint8Array;
        }
    }
}
