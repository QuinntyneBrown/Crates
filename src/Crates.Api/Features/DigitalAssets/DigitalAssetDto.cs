using System;

namespace Crates.Api.Features
{
    public class DigitalAssetDto
    {
        public Guid DigitalAssetId { get; set; }
        public string Name { get; set; }
        public byte[] Bytes { get; set; }
        public string ContentType { get; set; }
    }
}
