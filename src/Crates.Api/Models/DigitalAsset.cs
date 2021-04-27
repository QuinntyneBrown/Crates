using System;

namespace Crates.Api.Models
{
    public class DigitalAsset
    {
        public Guid DigitalAssetId { get; private set; }
        public string Name { get; private set; }
        public byte[] Bytes { get; private set; }
        public string ContentType { get; private set; }
        
        public DigitalAsset(string name, byte[] bytes, string contentType)
        {
            Name = name;
            Bytes = bytes;
            ContentType = contentType;
        }

        private DigitalAsset()
        {
                
        }

        public void Update(byte[] bytes, string contentType)
        {
            Bytes = bytes;
            ContentType = contentType;
        }
    }
}
