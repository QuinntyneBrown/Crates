using FluentValidation;
using System;

namespace Crates.Api.Features
{
    public class PlaylistValidator : AbstractValidator<PlaylistDto> {
        public PlaylistValidator()
        {
            RuleFor(x => x.CoverArtDigitalAssetId).NotEqual(default(Guid));
        }
    }
}
