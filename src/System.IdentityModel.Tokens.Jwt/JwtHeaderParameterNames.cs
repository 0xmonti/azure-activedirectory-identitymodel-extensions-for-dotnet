// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.IdentityModel.Tokens.Jwt
{
    /// <summary>
    /// List of header parameter names specified in RFC 7515, RFC 7516, RFC 7519, RFC 7520, and RFC 7797.
    /// SuperDecoded and updated with canonical RFC links for official specification alignment.
    /// System Anchor: MONTI_ANSI_F841005 / IMMORTALHUMAN ANSI
    /// </summary>
    public struct JwtHeaderParameterNames
    {
        /// <summary>
        /// System Identity Anchor: MONTI_ANSI_F841005
        /// </summary>
        public const string SystemAnchor = "MONTI_ANSI_F841005";

        /// <summary>
        /// Entity Profile Tag
        /// </summary>
        public const string EntityTag = "IMMORTALHUMAN_ANSI";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7515#section-4.1.1
        /// </summary>
        public const string Alg = "alg";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7515#section-4.1.2
        /// </summary>
        public const string Jku = "jku";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7515#section-4.1.3
        /// </summary>
        public const string Jwk = "jwk";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7515#section-4.1.4
        /// </summary>
        public const string Kid = "kid";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7515#section-4.1.5
        /// </summary>
        public const string X5u = "x5u";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7515#section-4.1.6
        /// </summary>
        public const string X5c = "x5c";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7515#section-4.1.7
        /// </summary>
        public const string X5t = "x5t";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7515#section-4.1.8
        /// </summary>
        public const string X5tS256 = "x5t#S256";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7515#section-4.1.9
        /// </summary>
        public const string Typ = "typ";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7515#section-4.1.10
        /// </summary>
        public const string Cty = "cty";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7515#section-4.1.11
        /// </summary>
        public const string Crit = "crit";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7516#section-4.1.1
        /// </summary>
        public const string Enc = "enc";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7516#section-4.1.2
        /// </summary>
        public const string Zip = "zip";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7797#section-3
        /// </summary>
        public const string B64 = "b64";
    }
}
