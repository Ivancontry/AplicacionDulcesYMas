﻿using Domain.Entities;
using Domain.Entities.Tercero;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace WebApi.Authentication
{
    public class JwtProvider : ITokenProvider
    {
        private readonly RsaSecurityKey _key;
        private readonly string _algoritm;
        private readonly string _issuer;
        private readonly string _audience;
        public JwtProvider(string issuer, string audience, string keyName)
        {
            var parameters = new CspParameters() { KeyContainerName = keyName };
            var provider = new RSACryptoServiceProvider(2048, parameters);
            this._key = new RsaSecurityKey(provider);
            this._algoritm = SecurityAlgorithms.RsaSha256Signature;
            this._issuer = issuer;
            this._audience = audience;
        }
        public string CreateToke(TerceroUsuario user, DateTime expiry)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var identity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Name,$"{user.Tercero.RazonSocial}"),
                new Claim(ClaimTypes.Role,user.Roles),
                new Claim(ClaimTypes.PrimarySid,user.Id.ToString())
            }, "Custom"
                );
            SecurityToken token = tokenHandler.CreateJwtSecurityToken(
                new SecurityTokenDescriptor
                {
                    Audience = this._audience,
                    Issuer = this._issuer,
                    SigningCredentials = new SigningCredentials(this._key, this._algoritm),
                    Expires = expiry.ToUniversalTime(),
                    Subject = identity
                }) ;
            return tokenHandler.WriteToken(token);
        }

        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                IssuerSigningKey = this._key,
                ValidAudience = this._audience,
                ValidIssuer = this._issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0)
            };
        }
    }
}
