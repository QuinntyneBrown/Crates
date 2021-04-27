using System;

namespace Crates.Api.Features
{
    public class SimplifiedDigitalAssetDto
    {
        public Guid DigitalAssetId { get; set; }
        public string Name { get; set; }        
        public string ContentType { get; set; }
        public SimplifiedDigitalAssetDto(
            Guid digitalAssetId,
            string name,
            string contentType)
        {
            DigitalAssetId = digitalAssetId;
            Name = name;
            ContentType = contentType;
        }
    }
}
