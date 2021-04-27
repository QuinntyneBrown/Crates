using Crates.Api.Models;

namespace Crates.Api.Features
{
    public static class DigitalAssetExtensions
    {
        public static DigitalAssetDto ToDto(this DigitalAsset digitalAsset)
        {
            return new()
            {
                DigitalAssetId = digitalAsset.DigitalAssetId,
                Bytes = digitalAsset.Bytes,
                ContentType = digitalAsset.ContentType,
                Name = digitalAsset.Name
            };
        }

        public static SimplifiedDigitalAssetDto ToSimplifiedDto(this DigitalAsset digitalAsset)
            => new (digitalAsset.DigitalAssetId, digitalAsset.Name, digitalAsset.ContentType);

    }
}
