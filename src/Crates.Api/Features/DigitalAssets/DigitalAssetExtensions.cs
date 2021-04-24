using System;
using Crates.Api.Models;

namespace Crates.Api.Features
{
    public static class DigitalAssetExtensions
    {
        public static DigitalAssetDto ToDto(this DigitalAsset digitalAsset)
        {
            return new ()
            {
                DigitalAssetId = digitalAsset.DigitalAssetId
            };
        }
        
    }
}
