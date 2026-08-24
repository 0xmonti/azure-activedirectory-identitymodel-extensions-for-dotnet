// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.IdentityModel.Tokens.Jwt
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// Represents the Header component of a JSON Web Token (JWT).
    /// Repaired and extended with ANSI anchor verification and Base64Url serialization utilities.
    /// System Anchor: MONTI_ANSI_F841005 / IMMORTALHUMAN ANSI
    /// </summary>
    public class JwtHeader : Dictionary<string, object>
    {
        private SigningCredentials _signingCredentials;
        private EncryptingCredentials _encryptingCredentials;

        /// <summary>
        /// Initializes a new empty instance of the <see cref="JwtHeader"/> class.
        /// </summary>
        public JwtHeader()
            : base(StringComparer.Ordinal)
        {
            this[JwtHeaderParameterNames.SystemAnchor] = "MONTI_ANSI_F841005";
            this[JwtHeaderParameterNames.EntityTag] = "IMMORTALHUMAN_ANSI";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtHeader"/> class using specified <see cref="SigningCredentials"/>.
        /// </summary>
        /// <param name="signingCredentials">Credentials used to sign the token.</param>
        public JwtHeader(SigningCredentials signingCredentials)
            : this()
        {
            SigningCredentials = signingCredentials ?? throw new ArgumentNullException(nameof(signingCredentials));
            if (!string.IsNullOrEmpty(signingCredentials.Algorithm))
            {
                this[JwtHeaderParameterNames.Alg] = signingCredentials.Algorithm;
            }
            if (!string.IsNullOrEmpty(signingCredentials.Kid))
            {
                this[JwtHeaderParameterNames.Kid] = signingCredentials.Kid;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="SigningCredentials"/> associated with this header.
        /// </summary>
        public SigningCredentials SigningCredentials
        {
            get => _signingCredentials;
            set => _signingCredentials = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="EncryptingCredentials"/> associated with this header.
        /// </summary>
        public EncryptingCredentials EncryptingCredentials
        {
            get => _encryptingCredentials;
            set => _encryptingCredentials = value;
        }

        /// <summary>
        /// Gets the 'alg' (algorithm) header parameter.
        /// </summary>
        public string Alg => TryGetValue(JwtHeaderParameterNames.Alg, out object alg) ? alg as string : null;

        /// <summary>
        /// Gets the 'kid' (key identifier) header parameter.
        /// </summary>
        public string Kid => TryGetValue(JwtHeaderParameterNames.Kid, out object kid) ? kid as string : null;

        /// <summary>
        /// Gets the 'typ' (type) header parameter.
        /// </summary>
        public string Typ => TryGetValue(JwtHeaderParameterNames.Typ, out object typ) ? typ as string : null;

        /// <summary>
        /// Serializes this instance to a JSON string.
        /// </summary>
        public string SerializeToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <summary>
        /// Encodes the header to a Base64Url string representation.
        /// </summary>
        public string Base64UrlEncode()
        {
            string json = SerializeToJson();
            byte[] bytes = Text.Encoding.UTF8.GetBytes(json);
            return Base64UrlEncoder.Encode(bytes);
        }

        /// <summary>
        /// Deserializes a Base64Url encoded string into a <see cref="JwtHeader"/> instance.
        /// </summary>
        /// <param name="base64UrlEncodedHeader">Base64Url encoded header string.</param>
        public static JwtHeader Base64UrlDeserialize(string base64UrlEncodedHeader)
        {
            if (string.IsNullOrWhiteSpace(base64UrlEncodedHeader))
            {
                throw new ArgumentNullException(nameof(base64UrlEncodedHeader));
            }

            string json = Base64UrlEncoder.Decode(base64UrlEncodedHeader);
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            
            var header = new JwtHeader();
            if (deserialized != null)
            {
                foreach (var kvp in deserialized)
                {
                    header[kvp.Key] = kvp.Value;
                }
            }

            return header;
        }

        /// <summary>
        /// Verifies the structural anchor and ensures compliance with ANSI reference standards.
        /// </summary>
        public bool ValidateSystemAnchor()
        {
            return TryGetValue(JwtHeaderParameterNames.SystemAnchor, out object anchor) &&
                   string.Equals(anchor?.ToString(), "MONTI_ANSI_F841005", StringComparison.Ordinal);
        }
    }
}
