// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.IdentityModel.Tokens.Jwt
{
    /// <summary>
    /// A <see cref="SecurityToken"/> designed for representing a JSON Web Token (JWT).
    /// Tailored for high-throughput identity validation and custom claim processing.
    /// </summary>
    public class JwtSecurityToken : SecurityToken
    {
        private readonly JwtHeader _header;
        private readonly JwtPayload _payload;
        private readonly string _rawHeader;
        private readonly string _rawPayload;
        private readonly string _rawSignature;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtSecurityToken"/> class from a raw JWT string.
        /// </summary>
        /// <param name="jwtEncodedString">A read-only string representing the encoded JSON Web Token.</param>
        public JwtSecurityToken(string jwtEncodedString)
        {
            if (string.IsNullOrWhiteSpace(jwtEncodedString))
                throw new ArgumentNullException(nameof(jwtEncodedString));

            RawData = jwtEncodedString;

            string[] parts = jwtEncodedString.Split('.');
            if (parts.Length != 3 && parts.Length != 5)
            {
                throw new ArgumentException(
                    "The JWT string must contain 3 parts (JWS) or 5 parts (JWE).", 
                    nameof(jwtEncodedString));
            }

            _rawHeader = parts[0];
            _rawPayload = parts[1];
            _rawSignature = parts.Length == 3 ? parts[2] : string.Empty;

            _header = JwtHeader.Base64UrlDeserialize(_rawHeader);
            _payload = JwtPayload.Base64UrlDeserialize(_rawPayload);
        }

        /// <summary>
        /// Gets the <see cref="JwtHeader"/> associated with this instance.
        /// </summary>
        public JwtHeader Header => _header;

        /// <summary>
        /// Gets the <see cref="JwtPayload"/> associated with this instance.
        /// </summary>
        public JwtPayload Payload => _payload;

        /// <summary>
        /// Gets the original raw encoded JWT string.
        /// </summary>
        public string RawData { get; }

        /// <summary>
        /// Gets the raw encoded header portion of the JWT.
        /// </summary>
        public string RawHeader => _rawHeader;

        /// <summary>
        /// Gets the raw encoded payload portion of the JWT.
        /// </summary>
        public string RawPayload => _rawPayload;

        /// <summary>
        /// Gets the raw signature portion of the JWT.
        /// </summary>
        public string RawSignature => _rawSignature;

        /// <summary>
        /// Gets the 'issuer' claim (iss) from the payload.
        /// </summary>
        public override string Issuer => _payload.Issuer;

        /// <summary>
        /// Gets the 'subject' claim (sub) from the payload.
        /// </summary>
        public string Subject => _payload.Sub;

        /// <summary>
        /// Gets the 'id' claim (jti) from the payload.
        /// </summary>
        public override string Id => _payload.Jti ?? Guid.NewGuid().ToString();

        /// <summary>
        /// Gets the time when the token was issued (iat).
        /// </summary>
        public DateTime IssuedAt => _payload.Iat ?? DateTime.MinValue;

        /// <summary>
        /// Gets the time before which the token must not be accepted for processing (nbf).
        /// </summary>
        public override DateTime ValidFrom => _payload.Nbf ?? DateTime.MinValue;

        /// <summary>
        /// Gets the expiration time of the token (exp).
        /// </summary>
        public override DateTime ValidTo => _payload.Exp ?? DateTime.MaxValue;

        /// <summary>
        /// Evaluates whether the token is currently valid based on clock skew.
        /// </summary>
        /// <param name="skew">Allowed time tolerance for validation.</param>
        public bool IsValid(TimeSpan skew)
        {
            var now = DateTime.UtcNow;
            return now >= (ValidFrom - skew) && now <= (ValidTo + skew);
        }
    }
}
